using System;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Leaderboards.Internal.Http;
using Unity.Services.Leaderboards.Internal.Models;

namespace Unity.Services.Leaderboards.Exceptions
{
    interface ILeaderboardsApiErrorHandler
    {
        bool IsRateLimited { get; }
        LeaderboardsException HandleBasicResponseException(HttpException<BasicErrorResponse> response);
        LeaderboardsValidationException HandleValidationResponseException(HttpException<ValidationErrorResponse> response);
        LeaderboardsException HandleDeserializationException(ResponseDeserializationException exception);
        LeaderboardsException HandleHttpException(HttpException exception);
        LeaderboardsException HandleException(Exception exception);
        LeaderboardsRateLimitedException CreateRateLimitException();
    }

    class LeaderboardsApiErrorHandler : ILeaderboardsApiErrorHandler
    {
        readonly IRateLimiter _rateLimiter;
        LeaderboardsRateLimitedException _exception;

        public LeaderboardsApiErrorHandler(IRateLimiter rateLimiter)
        {
            _rateLimiter = rateLimiter;
        }

        public bool IsRateLimited => _rateLimiter.RateLimited;

        public LeaderboardsRateLimitedException CreateRateLimitException()
        {
            if (_exception == null)
            {
                var error = new BasicErrorResponse("TooManyRequests", status: 429);
                var response = new HttpClientResponse(new Dictionary<string, string>(), 429,
                    true, false, Array.Empty<byte>(), string.Empty);
                _exception = new LeaderboardsRateLimitedException(GetReason(429), 429, GetGenericMessage(429),
                    _rateLimiter.RetryAfter, new HttpException<BasicErrorResponse>(response, error));
            }

            _exception.RetryAfter = _rateLimiter.RetryAfter;
            return _exception;
        }

        public LeaderboardsException HandleHttpException(HttpException exception)
        {
            if (exception.Response.IsNetworkError)
            {
                const string requestFailedMessage = "The request to the Leaderboards service failed - make sure you're connected to an internet connection and try again.";
                return new LeaderboardsException(LeaderboardsExceptionReason.NoInternetConnection, CommonErrorCodes.TransportError, requestFailedMessage, exception);
            }

            var message = exception.Response.ErrorMessage ?? GetGenericMessage(exception.Response.StatusCode);
            return new LeaderboardsException(GetReason(exception.Response.StatusCode), CommonErrorCodes.Unknown, message, exception);
        }

        public LeaderboardsException HandleException(Exception exception)
        {
            const string message = "An unknown error occurred in the Leaderboards SDK.";

            return new LeaderboardsException(LeaderboardsExceptionReason.Unknown, CommonErrorCodes.Unknown, message, exception);
        }

        public LeaderboardsException HandleDeserializationException(ResponseDeserializationException exception)
        {
            var message = exception.response.ErrorMessage ?? GetGenericMessage(exception.response.StatusCode);

            return new LeaderboardsException(GetReason(exception.response.StatusCode), CommonErrorCodes.Unknown, message, exception);
        }

        public LeaderboardsException HandleBasicResponseException(HttpException<BasicErrorResponse> response)
        {
            var message = string.IsNullOrEmpty(response.ActualError.Detail)
                ? GetGenericMessage(response.Response.StatusCode) : response.ActualError.Detail;

            if (_rateLimiter.IsRateLimitException(response))
            {
                _rateLimiter.ProcessRateLimit(response);
                return new LeaderboardsRateLimitedException(GetReason(response.Response.StatusCode),
                    response.ActualError.Code,
                    message, _rateLimiter.RetryAfter, response);
            }

            return new LeaderboardsException(GetReason(response.Response.StatusCode, response.ActualError.Code),
                response.ActualError.Code, message, response);
        }

        public LeaderboardsValidationException HandleValidationResponseException(HttpException<ValidationErrorResponse> response)
        {
            const string message = "There was a validation error.";

            var detailList = new List<LeaderboardsValidationErrorDetail>();
            foreach (var error in response.ActualError.Errors)
            {
                detailList.Add(new LeaderboardsValidationErrorDetail(error));
            }

            var exception = new LeaderboardsValidationException(GetReason(response.Response.StatusCode),
                response.ActualError.Code, message, detailList, response);

            return exception;
        }

        static LeaderboardsExceptionReason GetReason(long statusCode, long? serviceErrorCode = null)
        {
            switch (statusCode)
            {
                case 400:
                    return serviceErrorCode switch
                    {
                        27001 => LeaderboardsExceptionReason.ScoreSubmissionRequired,
                        27012 => LeaderboardsExceptionReason.LeaderboardNotBucketed,
                        27013 => LeaderboardsExceptionReason.LeaderboardBucketed,
                        27014 => LeaderboardsExceptionReason.LeaderboardNotTiered,
                        _ => LeaderboardsExceptionReason.InvalidArgument
                    };
                case 401:
                    return LeaderboardsExceptionReason.Unauthorized;
                case 404:
                    return serviceErrorCode switch
                    {
                        27005 => LeaderboardsExceptionReason.LeaderboardNotFound,
                        27006 => LeaderboardsExceptionReason.LeaderboardNotFound,
                        27007 => LeaderboardsExceptionReason.BucketNotFound,
                        27008 => LeaderboardsExceptionReason.TierNotFound,
                        27009 => LeaderboardsExceptionReason.EntryNotFound,
                        27010 => LeaderboardsExceptionReason.VersionNotFound,
                        _ => LeaderboardsExceptionReason.NotFound
                    };
                case 429:
                    return LeaderboardsExceptionReason.TooManyRequests;
                case 500:
                case 502:
                case 503:
                    return LeaderboardsExceptionReason.ServiceUnavailable;
                default:
                    return LeaderboardsExceptionReason.Unknown;
            }
        }

        static string GetGenericMessage(long statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "Some of the arguments passed to the Leaderboards request were invalid. Please check the requirements and try again.";
                case 401:
                    return "Permission denied when making a request to the Leaderboards service. Ensure you are signed in through the Authentication SDK and try again.";
                case 403:
                    return "Key-value pair limit per user exceeded.";
                case 404:
                    return "The requested action could not be completed as the specified resource is not found - please make sure it exists, then try again.";
                case 429:
                    return "Too many requests have been sent, so this device has been rate limited. Please try again later.";
                case 500:
                case 502:
                case 503:
                    return "Leaderboards service is currently unavailable. Please try again later.";
                default:
                    return "An unknown error occurred in the Leaderboards SDK.";
            }
        }
    }
}

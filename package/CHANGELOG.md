# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2023-02-20

Major release of the Leaderboards SDK, containing some added documentation and changes to the names, parameters, and namespace of the public interface.

### Changed

* Added XML documentation to service methods.
* Updated the signature of service methods:
  * Renamed service methods to omit repetitive "Leaderboards".
  * Wrapped optional parameters in options objects instead of specifying them directly.
* Service methods are now directly on `LeaderboardsService.Instance`, instead of `LeaderboardsService.Instance.LeaderboardsApi`.

## [0.3.0-preview] - 2023-02-17

Incremental release of the Leaderboards SDK, enabling the return of a player entry on score submission, new support for Tiers, and additional archived leaderboard functionality.

### New Features

* `AddLeaderboardPlayerScoreAsync` updated to return the `LeaderboardEntry` stored for the player, if it is returned by the service.
  A service update to enable this functionality will shortly follow this release.
* `GetLeaderboardScoresByTierAsync` and `GetLeaderboardVersionScoresByTierAsync` added, allowing players to retrieve only the subset 
  of the leaderboard specified by the given tier, for either live or archived leaderboard versions. The rank returned by this method
  will be scoped to the tier requested.
* `GetLeaderboardVersionPlayerRangeAsync` and `GetLeaderboardVersionScoresByPlayerIdsAsync`, extending existing live leaderboard
  functionality to archived leaderboard versions.

## [0.2.1-preview] - 2023-01-26

Incremental release of the Leaderboards SDK, containing new return values and improved error handling

### New Features

* The `GetLeaderboardVersionsAsync` response now includes a `nextReset` field, which shows the next time that
  a leaderboard will reset if the leaderboard has a scheduled reset configuration.
* When a request is made to retrieve leaderboard scores from a bucketed leaderboard, and the player has not yet
  submitted a score (and therefore has not been assigned a bucket), the error response will now include 
  `ScoreSubmissionRequired` in the `Reason` field.

## [0.2.0-preview] - 2022-11-02

Incremental release of the Leaderboards SDK, containing new features and routing to updated API endpoints.

### New Features

* Ability to retrieve scores based on a list of player IDs, enabling features such as Friends leaderboards.
* Ability to retrieve a range of scores around the signed in player, for easier player-scoped leaderboards.
* All methods updated to call the v1beta1 endpoints on the Leaderboards service rather than the Alpha v0 endpoints.

### Known Issues

* There is no client-side validation other than type protection.

## [0.1.0-preview] - 2022-10-07

This is the initial release of the Leaderboards SDK with improvements to the auto-generated code.

### New Features

* Auto-injection of ProjectID and PlayerID matching other SDKs.
* Submit and retrieve player scores/ranks.
* Retrieve Leaderboard scores.
* Retrieve a list of Leaderboard versions and scores from Leaderboard versions.

### Known Issues

* There is no client-side validation other than type protection.

## [0.0.1-preview] - 2022-06-01

- Generated this version of the API client

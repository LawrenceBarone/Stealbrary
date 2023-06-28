using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 3f;
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float waypointTolerance = 1f;
        [SerializeField] float waypointDwellTime = 3f;

        [Range(0, 1)]
        [SerializeField] float patrolSpeedFraction = 0.2f;

        GameObject player;

        float timeSinceLastSawPlayer = Mathf.Infinity;
        float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        int currentWaypointIndex = 0;

        [SerializeField] NavMeshMover mover;
        Vector3 nextPosition;

        [SerializeField] UnityEvent DeadEvent;
        bool DidOnce = false;

        [SerializeField] Animator anim;
        [SerializeField] AudioSource stopRightThereSoundSource;
        [SerializeField] AudioSource hmmSoundSource;
        bool StopRightThereOnlyOnce;
        bool hmmOnlyOnce;

        private void Awake()
        { 

            player = GameObject.FindWithTag("Player");

        }

        private Vector3 GetGuardPosition()
        {
            return transform.position;
        }
    
        private void Update()
        {
            if (InAttackRangeOfPlayer() )
            {
                AttackBehaviour();

                if (StopRightThereOnlyOnce)
                {
                    stopRightThereSoundSource.Play();
                    StopRightThereOnlyOnce = false;
                }
                hmmOnlyOnce = true;

            }
            else if (timeSinceLastSawPlayer < suspicionTime)
            {
                mover.Cancel();
                anim.speed = 2;

                if (hmmOnlyOnce)
                {
                    hmmSoundSource.Play();
                    hmmOnlyOnce = false;
                }
                StopRightThereOnlyOnce = true;
            }
            else
            {
                StopRightThereOnlyOnce = true;
                hmmOnlyOnce = true;

                PatrolBehaviour();
                anim.speed = 1;
            }

            UpdateTimers();
        }

        private void UpdateTimers()
        {
            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArrivedAtWaypoint += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {
            if (patrolPath != null)
            {
                if (AtWaypoint())
                {
                    timeSinceArrivedAtWaypoint = 0;
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWaypoint();
            }

            if (timeSinceArrivedAtWaypoint > waypointDwellTime)
            {
                mover.StartMoveAction(nextPosition, patrolSpeedFraction);
            }
        }

        private bool AtWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }

        private void CycleWaypoint()
        {
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }

        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetWaypoint(currentWaypointIndex);
        }


        private void AttackBehaviour()
        {
            timeSinceLastSawPlayer = 0;
            mover.MoveTo(player.transform.position, 2);
            anim.speed = 4;
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position + (transform.forward*2.5f));
            return distanceToPlayer < chaseDistance;
        }

        // Called by Unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position + (transform.forward * 2.5f), chaseDistance );
        }
    }
}
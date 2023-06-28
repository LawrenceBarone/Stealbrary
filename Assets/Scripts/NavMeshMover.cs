using UnityEngine;
using UnityEngine.AI;


    public class NavMeshMover : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float maxSpeed = 6f;
        [SerializeField] float maxNavPathLength = 40f;

        NavMeshAgent navMeshAgent;


        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

        }

        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            MoveTo(destination, speedFraction);
        }


        //public void StartDash(Vector3 destination, float speedFraction)
        //{
        //    GetComponent<ActionScheduler>().StartAction(this);

        //    Vector3 dir = (destination - transform.position).normalized;

        //    DashTo(transform.position  + (dir * 5f), speedFraction);

        //    GetComponent<Animator>().SetTrigger("roll");
        //}

        public bool CanMoveTo(Vector3 destination)
        {
            NavMeshPath path = new NavMeshPath();
            bool hasPath = NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path);
            if (!hasPath) return false;
            if (path.status != NavMeshPathStatus.PathComplete) return false;
            if (GetPathLength(path) > maxNavPathLength) return false;

            return true;
        }

        public void DashTo(Vector3 destination, float speedFraction)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * speedFraction;
            navMeshAgent.isStopped = false;
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        private float GetPathLength(NavMeshPath path)
        {
            float total = 0;
            if (path.corners.Length < 2) return total;
            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                total += Vector3.Distance(path.corners[i], path.corners[i + 1]);
            }

            return total;
        }


        //public object CaptureState()
        //{
        //    return new SerializableVector3(transform.position);
        //}

        //public void RestoreState(object state)
        //{
        //    //SerializableVector3 position = (SerializableVector3)state;
        //    //navMeshAgent.enabled = false;
        //    //transform.position = position.ToVector();
        //    //navMeshAgent.enabled = true;
        //    //GetComponent<ActionScheduler>().CancelCurrentAction();
        //}
    }

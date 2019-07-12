using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;
        Ray lastRay;
        private void Start() {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        // The purpose of this script is too in
        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Cancel() 
        {
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            //get global velocity from nav mesh agent.
            Vector3 velocity = navMeshAgent.velocity;
            //convert into a local value relative to character.
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            // used when updating animator.
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}

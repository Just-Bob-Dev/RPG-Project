using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    Ray lastRay;
    // The purpose of this script is too in
    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();

    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
    }



    private void UpdateAnimator()
    {
        //get global velocity from nav mesh agent.
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        //convert into a local value relative to character.
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        // used when updating animator.
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }

}
}

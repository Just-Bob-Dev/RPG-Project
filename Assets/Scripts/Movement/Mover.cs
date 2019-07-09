using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    Ray lastRay;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MoveToCursor();
            // Below was the first step in firing a ray.
            // lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        UpdateAnimator();

    }

    private void MoveToCursor()
    {
        //These two varibles are used to hold the location of the ray
        // and initialize a RaycastHit varible.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool hasHit = Physics.Raycast(ray, out hit);
        if(hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
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

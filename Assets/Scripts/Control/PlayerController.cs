using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;
using RPG.Combat;
using System;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private void Update() {
            if (InteractWithCombat()) 
            {
                return;
            }
            else
            {
                InteractWithMovement();   
            }            
        }

        private bool InteractWithCombat()
        {
            bool enemy = false;
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                // original try.
                // if(hit.collider != null ){
                //     var player = GetComponent<Combat.Fighter>();
                //     player.Fight();
                // }
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if  (target == null) continue;
                
                if (Input.GetMouseButtonDown(0))
                {
                    print("else block");
                    GetComponent<Fighter>().Attack();
                }   
                return true;
            }
            print("enemy: " + enemy);
            return false;
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }    
        public void MoveToCursor()
        {
            //These two varibles are used to hold the location of the ray
            // and initialize a RaycastHit varible.
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
                if (hasHit)
                {
                    GetComponent<Movement.Mover>().MoveTo(hit.point);
                }
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }
    }
}

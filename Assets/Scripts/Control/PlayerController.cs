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
            if (InteractWithCombat()) return;
            if(InteractWithMovement()) return;     
        }

        private bool InteractWithCombat()
        {
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
                    GetComponent<Fighter>().Attack(target);
                }   
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            //These two varibles are used to hold the location of the ray
            // and initialize a RaycastHit varible.
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
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

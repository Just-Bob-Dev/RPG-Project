using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        Mover mover;
        Transform target;
        private void Start() {
            mover = GetComponent<Mover>();
        }
        private void Update()
        {
            //return early if target is null
            if(target == null) return;

            if (!GetIsInRange())
            {
                mover.MoveTo(target.position);
                print("A... fuck you!");
            }
            else
            {
                mover.Stop();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}

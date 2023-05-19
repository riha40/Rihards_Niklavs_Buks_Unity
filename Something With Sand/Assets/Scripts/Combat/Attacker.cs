using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Movement;

namespace Game.Combat
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] float setRange = 2f;
        Transform target;

        private void Update()
        {
            if(target == null) return;

            if (!GetInRange())
            {
                GetComponent<Move>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Move>().Stop();
            }
        }

        private bool GetInRange()
        {
            return Vector3.Distance(transform.position, target.position) < setRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void CancleAttack()
        {
            target = null;
        }
    }
}

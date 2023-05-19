using UnityEngine;
using Game.Movement;
using Game.Combat;


namespace Game.Control
{
    public class PlayerMovement : MonoBehaviour
    {
        void Update()
        {
            if (MoveToEnemy()) return;
            if (MoveToPoint()) return;
        }

        private bool MoveToEnemy()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if(target == null) continue;

                if(Input.GetMouseButtonDown(1))
                {
                    GetComponent<Attacker>().Attack(target);
                }
                return true;
            }
            return false;
        }

        private bool MoveToPoint()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(1))
                {
                    GetComponent<Move>().StartMovmentAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

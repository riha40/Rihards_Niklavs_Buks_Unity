using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        if (MoveToPoint()) return;
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


    public void DoExplosionEffect()
    {
        Debug.Log(nameof(DoExplosionEffect));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is happening with the specific object you want to detect
        if (collision.gameObject.CompareTag("Bomb"))
        {
            // The player has met the object
            Debug.Log("Player has met the object!");

            // You can perform any other actions or logic here as needed
        }
    }
}

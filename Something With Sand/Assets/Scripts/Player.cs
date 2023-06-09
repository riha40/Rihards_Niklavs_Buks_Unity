using UnityEngine;


public class Player : MonoBehaviour
{
    public System.Action<int> OnHealthUpdated;
    public const int MaxHealth = 100;
    int _health;
    CountdownTimer CountdownTimer;

    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            OnHealthUpdated?.Invoke(_health);
        }
    }

    void Start()
    {
        CountdownTimer = GetComponent<CountdownTimer>();
        Health = MaxHealth;    
    }

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
        Health -= 25;
    }
}

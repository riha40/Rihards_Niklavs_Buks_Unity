using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    Player Player;
    CountdownTimer countdownTimer;

    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player = GetComponent<Player>();
        countdownTimer = FindObjectOfType<CountdownTimer>();
    }
    
    void Update()
    {
        float currentTime = countdownTimer.currentTime;
        UpdateAnimator();
        if(Player.Health <= 0 || currentTime <=0)
        {
            Stop();
        }
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        
    }

    public void StartMovmentAction(Vector3 destination)
    {
        MoveTo(destination);
    }

    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.destination = destination;
        navMeshAgent.isStopped = false;
    }

    public void Stop()
    {
        navMeshAgent.isStopped = true;
    }
}


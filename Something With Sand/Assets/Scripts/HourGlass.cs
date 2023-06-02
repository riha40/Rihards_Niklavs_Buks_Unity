using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlass : MonoBehaviour
{

    [SerializeField] float verticalSpeed;  
    [SerializeField] float verticalRange;   
    [SerializeField] float rotationSpeed;  
    [SerializeField] float rotationRange;
    [SerializeField] public float additionalTime;


    private Vector3 initialPosition;
    private float verticalOffset;

    void Start()
    {
        initialPosition = transform.position;
        verticalOffset = Random.Range(0f, Mathf.PI * 2f); 
    }

    void Update()
    {
        float verticalOffsetValue = Mathf.Sin(Time.time * verticalSpeed + verticalOffset);
        Vector3 newPosition = initialPosition + Vector3.up * verticalRange * verticalOffsetValue;
        transform.position = newPosition;

        float rotationAngle = Time.deltaTime * rotationSpeed;
        transform.Rotate(0f, rotationAngle, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collectable");
            CountdownTimer countdownTimer = other.gameObject.GetComponent<CountdownTimer>();
            if (countdownTimer != null)
            {
                countdownTimer.AddTime(additionalTime);
            }
            Destroy(gameObject);
        }
    }
}

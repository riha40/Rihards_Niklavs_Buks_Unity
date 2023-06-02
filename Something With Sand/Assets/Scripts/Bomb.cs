using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject ExplosionFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player != null)
            {
                Instantiate(ExplosionFX, transform.position, Quaternion.identity);
                player.DoExplosionEffect();
            }

            Destroy(gameObject);
        }
    }
}
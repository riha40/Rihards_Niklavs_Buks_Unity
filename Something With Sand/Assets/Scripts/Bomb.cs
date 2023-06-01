using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] GameObject ExplsionFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player != null)
            {
                Instantiate(ExplsionFX, transform.position, Quaternion.identity);
                player.DoExplosionEffect();
            }

            Destroy(gameObject);
        }

    }
}

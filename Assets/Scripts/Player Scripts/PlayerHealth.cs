using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerMaxHealth = 100f;

    private float playerHealth;

    [SerializeField]
    private GameObject playerExplosionFX;

    [SerializeField]
    private GameObject playerDamageFX;

    private void Awake()
    {
        playerHealth = playerMaxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;

        if (playerHealth <= 0)
        {
            Instantiate(playerExplosionFX, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayDestroySound();
            Destroy(gameObject);
        }
        else
        {
            Instantiate(playerDamageFX, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayDamageSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.METEOR_TAG))
        {
            TakeDamage(Random.Range(20, 40));
            Destroy(collision.gameObject);
        }
    }
}

using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;

    private Vector3 healthBarScale;

    [SerializeField]
    private float health = 100f;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private GameObject destroyEffect;

    private DropCollectable dropCollectable;

    private void Awake()
    {
        dropCollectable = GetComponent<DropCollectable>();
    }

    public void TakeDamage(float damageAmount, float damageResistance)
    {
        damageAmount -= damageResistance;

        health -= damageAmount;

        if (health <= 0)
        {

            health = 0;

            Instantiate(destroyEffect, transform.position, Quaternion.identity);

            if(gameObject.CompareTag(TagManager.ENEMY_TAG))
            {
                GameplayUIController.Instance.SetInfo(2);
                EnemySpawner.instance.CheckToSpawnNewWave(gameObject);
            }
            else if(gameObject.CompareTag(TagManager.METEOR_TAG))
            {
                GameplayUIController.Instance.SetInfo(3);
            }

            SoundManager.Instance.PlayDestroySound();

            dropCollectable.CheckToSpawnCollectable();

            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayDamageSound();
        }

        SetHealthBar();
    }

    void SetHealthBar()
    {
        if(!healthBar)
            {
            return;
        }

        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / 100f;
        healthBar.transform.localScale = healthBarScale;
    }
}

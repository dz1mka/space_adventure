using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    public float minDamage = 10f;
    public float maxDamage = 30f;

    private float projectileDamage;

    [SerializeField]
    private AudioClip spawnSound;

    [SerializeField]
    private GameObject boomEffect;

    [SerializeField]
    private AudioClip destroySound;

    private void Start()
    {
        projectileDamage = (int)Random.Range(minDamage, maxDamage);
        if (spawnSound)
        {
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 6f, 0f));
        }
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }
}

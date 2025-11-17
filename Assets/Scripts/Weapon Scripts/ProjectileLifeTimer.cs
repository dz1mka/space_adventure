using UnityEngine;

public class ProjectileLifeTimer : MonoBehaviour
{
    [SerializeField]
    private float timer = 3f;

    //private void Start()
    //{
    //    //Destroy(gameObject, timer);
    //}

   private void OnEnable()
    {
        Invoke("DeactivateProjectile", timer);
    }

    void DeactivateProjectile()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

}

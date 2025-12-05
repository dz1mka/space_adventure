using UnityEngine;

public class EnemyFXLifeTimer : MonoBehaviour
{
    [SerializeField]
    private float timer = 3f;

    void Start()
    {
        Destroy(gameObject, timer);
    }
}

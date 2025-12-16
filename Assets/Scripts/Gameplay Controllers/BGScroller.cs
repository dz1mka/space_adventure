using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;

    private float Y_Axis;

    private Material bgMaterial;

    private void Awake()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Y_Axis += speed * Time.deltaTime;
        bgMaterial.mainTextureOffset = new Vector2(0, Y_Axis);
    }
}

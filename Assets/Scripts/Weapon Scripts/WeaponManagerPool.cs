using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerPool : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private List<GameObject> projectilePool = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

 
}

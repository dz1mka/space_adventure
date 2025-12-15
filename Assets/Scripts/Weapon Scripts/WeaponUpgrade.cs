using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    [SerializeField]
    private WeaponManagerPool[] weapons;

    public void ActivateWeapon (int weaponIndex)
    {
        weapons[weaponIndex].enabled = true;
    }
}

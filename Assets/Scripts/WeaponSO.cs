using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int damage = 1;
    public float fireRate = 0.5f;
    public GameObject HitVFXPrefab;
    public bool isAutomatic = false;
}

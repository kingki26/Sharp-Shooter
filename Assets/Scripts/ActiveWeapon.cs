using UnityEngine;
using StarterAssets;
using Unity.Cinemachine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] CinemachineCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;
    
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    const string shoot_trigger = "Shoot";

    float timeSinceLastShot = 0f;
    float defaultFOV;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.Lens.FieldOfView;
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>(); 
    }
    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
    }

    private void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (!starterAssetsInputs.shoot)
        {
            return;
        }

        if(timeSinceLastShot >= weaponSO.fireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(shoot_trigger, 0, 0f);
            timeSinceLastShot = 0f;
        }

        if (!weaponSO.isAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            playerFollowCamera.Lens.FieldOfView = weaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
        }
        else
        {
            playerFollowCamera.Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
        }

    }
}

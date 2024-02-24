
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    private bool readyToFire = true;
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private float shootSpeed = 1;
    [SerializeField] private GameObject muzzleFlash;

    [Header("Keybinds")]
    public KeyCode KeyFire = KeyCode.Mouse0;
    
    // Start is called before the first frame update
    void Start()
    {
        readyToFire = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyFire) && readyToFire)
        {
            readyToFire = false;

            FireGun();

            Invoke(nameof(ResetFire), fireRate);
        }
    }

    void FireGun()
    {
        if (bullet == null)
        {
            Debug.LogError("no bullet");
            return;
        }
        if(barrel == null)
        {
            Debug.LogError("no Barrel");
            return;
        }
        

        Rigidbody bulletRB = Instantiate(bullet, barrel.position, barrel.rotation).GetComponent<Rigidbody>();
        if(bulletRB == null)
        {
            Debug.LogError("no RB in the bullet");
            return;
        }

        bulletRB.velocity = barrel.forward * shootSpeed;

        if(muzzleFlash == null)
        {
            Debug.LogWarning("no muzzle Flash");
            return;
        }
        muzzleFlash.SetActive(true);
        return;

    }

    private void ResetFire()
    {
        readyToFire = true;
    }

}

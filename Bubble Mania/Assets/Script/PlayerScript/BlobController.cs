using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlobController : NetworkBehaviour
{
    // shooting
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingPoint;

    [SerializeField] private float CurrentHp;

    [SerializeField] private float damage;

    public static BlobController instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    private void Start()
    {
        CurrentHp = Blob.instatnce.Hp;
    }


    void Update()
    {

    }

    [Rpc(SendTo.Owner)]
    public void shootRpc()
    {
       Bullet BulletInstatnce = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
       BulletInstatnce.GetComponent<NetworkObject>().Spawn(true);
    }

    private void TakeDamage()
    {
        CurrentHp -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Shit Enemy hit me");
        }
    }

    public float BlobHealth()
    {
        return CurrentHp;
    }
}

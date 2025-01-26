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
    public override void OnNetworkSpawn()
    {
        Debug.Log("OnNetworkSpawn: " + NetworkManager.Singleton.LocalClientId);
        if (NetworkManager.Singleton.LocalClientId == 0)
        {
            localPlayer = Players.PlayerOne;
        }
        else
        {
            localPlayer = Players.PlayerTwo;
        }
        if (IsServer)
        {
            localPlayer = Players.PlayerOne;
        }

    }
    private void Start()
    {
        if (!IsOwner)
            return;
        CurrentHp = Blob.instatnce.Hp;
        chanageColorRpc();
    }

    [Rpc(SendTo.Server)]
    public void chanageColorRpc()
    {
        if (IsHost)
        {
            Debug.Log(NetworkObject.GetInstanceID());
            NetworkObject.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (IsClient)
        {
            Debug.Log(NetworkObject.GetInstanceID());
            NetworkObject.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }


    void Update()
    {

    }

    public void shoot()
    {
        if (!IsOwner)
            return;
        shootRpc();
    }

    [Rpc(SendTo.Server)]
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
            if(IsHost)
            {
                Debug.Log("Shit Client hit me");
            }
            else if (IsClient)
            {
                Debug.Log("Shit Host hit me");
            }
        }
    }

    public float BlobHealth()
    {
        return CurrentHp;
    }   

    private Players localPlayer;
    public Players MePlayer;

        

}

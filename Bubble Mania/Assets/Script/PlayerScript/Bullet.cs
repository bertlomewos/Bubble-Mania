using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Bulletspeed = 500f;
    [SerializeField] private float lifespan = 5f;

    private float dir = 1;
    public override void OnNetworkSpawn()
    {
        if (!IsClient)
            return;

    }
    private void Start()
    {
        if (!IsClient) 
            return;
        SelfDistructRpc();
        dir = Blob.instatnce.direction;
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (!IsOwner) 
            return;
        ShootToRpc();
    }


    [Rpc(SendTo.Owner)]
    public virtual void ShootToRpc()
    {
        rb.linearVelocity = new Vector2(dir * Bulletspeed * Time.fixedDeltaTime, rb.linearVelocity.y);
    }

    [Rpc(SendTo.Owner)]
    private void SelfDistructRpc()
    {
        Destroy(gameObject, lifespan);
    }

}

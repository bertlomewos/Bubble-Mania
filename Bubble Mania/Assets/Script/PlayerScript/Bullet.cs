using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Bulletspeed = 50f;
    [SerializeField] private float lifespan = 5f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SelfDistruct();
    }
    private void FixedUpdate()
    {
        ShootTo();
    }
    public virtual void ShootTo()
    {
        rb.linearVelocity = new Vector2(-1 * Bulletspeed * Time.fixedDeltaTime, rb.linearVelocity.y);
    }

    private void SelfDistruct()
    {
        Destroy(gameObject, lifespan);
    }
}

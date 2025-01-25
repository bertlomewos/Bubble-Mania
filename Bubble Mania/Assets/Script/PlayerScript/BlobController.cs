using UnityEngine;
using UnityEngine.InputSystem;

public class BlobController : MonoBehaviour
{


    // shooting

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingPoint;


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
  
    public void shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
    }
}

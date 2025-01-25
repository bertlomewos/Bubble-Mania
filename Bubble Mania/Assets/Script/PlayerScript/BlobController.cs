using UnityEngine;
using UnityEngine.InputSystem;

public class BlobController : MonoBehaviour
{


    // shooting

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingPoint;


    void Update()
    {
    }
  
    public void shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
    }
}

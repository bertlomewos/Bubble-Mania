using UnityEngine;
using UnityEngine.InputSystem;

public class BlobController : MonoBehaviour
{


    // shooting

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingPoint;

    [SerializeField] private float CurrentHp;
    private void Start()
    {
       
    }


    void Update()
    {
    }
  
    public void shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
    }
}

using Unity.Netcode;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType {
        SpeedBoost,
        JumpBoost,
        HealthRestore,
        DamageIncrease
    }
    public PowerUpType powerUpType; 
    public float duration = 5f;    
    public float value = 1000f;      

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PowerUp Collected");
            ApplyEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void ApplyEffect(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            switch (powerUpType)
            {
                case PowerUpType.SpeedBoost:
                    Debug.Log("SpeedBoosted");
                    controller.ApplySpeedBoost(value, duration);
                    break;
                case PowerUpType.JumpBoost:
                    Debug.Log("JumpBoosted");
                    controller.ApplyJumpBoost(value, duration);
                    break;
                case PowerUpType.HealthRestore:
                    Debug.Log("HealthRestored");
                    controller.RestoreHealth(value);
                    break;
                case PowerUpType.DamageIncrease:
                    Debug.Log("DamageIncreased");
                    controller.ApplyDamageBoost(value, duration);
                    break;
            }
        }
    }
}

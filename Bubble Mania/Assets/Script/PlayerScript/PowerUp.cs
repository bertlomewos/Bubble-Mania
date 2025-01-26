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
    public float value = 10f;      

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
                    controller.ApplySpeedBoost(value, duration);
                    break;
                case PowerUpType.JumpBoost:
                    controller.ApplyJumpBoost(value, duration);
                    break;
                case PowerUpType.HealthRestore:
                    controller.RestoreHealth(value);
                    break;
                case PowerUpType.DamageIncrease:
                    controller.ApplyDamageBoost(value, duration);
                    break;
            }
        }
    }
}

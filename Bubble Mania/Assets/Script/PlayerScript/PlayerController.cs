using UnityEngine;

public class PlayerController : MonoBehaviour
{
    BlobMovement movementController = new BlobMovement();
    [SerializeField] private float maxHp = 100f;
    private float currentHp;

    private float originalSpeed;
    private float originalJumpPower;

    private void Start()
    {
        currentHp = maxHp;
        originalSpeed = movementController.speed;
        originalJumpPower = movementController.jumpingPower;
    }

    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        movementController.speed += boostAmount;
        Invoke(nameof(ResetSpeed), duration);
    }

    private void ResetSpeed()
    {
        movementController.speed = originalSpeed;
    }

    public void ApplyJumpBoost(float boostAmount, float duration)
    {
        movementController.jumpingPower += boostAmount;
        Invoke(nameof(ResetJumpPower), duration);
    }

    private void ResetJumpPower()
    {
        movementController.jumpingPower = originalJumpPower;
    }

    public void RestoreHealth(float amount)
    {
        currentHp = Mathf.Clamp(currentHp + amount, 0, maxHp);
        Debug.Log($"Health Restored: {currentHp}/{maxHp}");
    }

    public void ApplyDamageBoost(float boostAmount, float duration)
    {
        Debug.Log($"Damage increased by {boostAmount} for {duration} seconds.");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthAmount = 100f;
    [SerializeField] private BlobController blobController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blobController = GetComponent<BlobController>();
        //healthAmount = blobController.CurrentHp;
    }

    // Update is called once per frame
    void Update()
    {
        //healthAmount = blobController.CurrentHp;
        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }

    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0f, 100f);

        healthBar.fillAmount = healthAmount / 100f;
    }
}

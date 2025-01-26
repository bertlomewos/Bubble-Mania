using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text HealthText;
    void Start()
    {
        if(BlobController.instance != null)
        HealthText.text = BlobController.instance.BlobHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (BlobController.instance != null)
        {
            HealthText.text = BlobController.instance.BlobHealth().ToString();
        }
    }
}

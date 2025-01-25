using UnityEngine;

public class Blob : MonoBehaviour
{
    [SerializeField] private string Name;
    public static float direction = 1;
    public static Blob instatnce;

    [SerializeField] private float Hp = 100000;

    private void Awake()
    {
        if (instatnce == null)
        {
            instatnce = this;
        }
    }
}

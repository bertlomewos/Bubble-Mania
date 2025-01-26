using UnityEngine;

public enum Players
{
    PlayerOne,
    PlayerTwo
}

public class Blob : MonoBehaviour
{
    [SerializeField] private string Name;
    [SerializeField] public float direction = 1;
    public static Blob instatnce;

    public float Hp = 100000;

    private void Awake()
    {
        if (instatnce == null)
        {
            instatnce = this;
        }
    }
}

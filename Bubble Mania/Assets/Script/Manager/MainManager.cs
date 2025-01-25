using UnityEngine;
using UnityEngine.InputSystem;

public class MainManager : MonoBehaviour
{

    public void Quit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}

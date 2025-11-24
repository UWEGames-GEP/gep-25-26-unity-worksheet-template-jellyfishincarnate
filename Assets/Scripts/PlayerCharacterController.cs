using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : ThirdPersonController
{
    private void OnPause(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.Log("Pause Game.");
        }
    }
}

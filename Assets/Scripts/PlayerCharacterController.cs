using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameManager;

public class PlayerCharacterController : ThirdPersonController
{
    [SerializeField]StarterAssetsInputs starterAssets;
    [SerializeField]GameManager gameManager;
    //private void Start()
    //{
    //    starterAssets = GameObject.FindAnyObjectByType<StarterAssetsInputs>();
    //    gameManager = GameObject.FindAnyObjectByType<GameManager>();
    //}

    private void LateUpdate()
    {
        if (starterAssets != null)
        {
            if (starterAssets.pause && gameManager.state == GameState.GAMEPLAY)
            {
                gameManager.state = GameState.PAUSE;
                gameManager.hasChangedState = true;
                starterAssets.pause = false;
            }
            else if (gameManager.state == GameState.PAUSE)
            {
                if (starterAssets.pause)
                {
                    gameManager.state = GameState.GAMEPLAY;
                    gameManager.hasChangedState = true;
                    starterAssets.pause = false;

                }
            }
        }
    }

    private void OnRemoveItem(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.Log("Remove Item");
           // GetComponent<Inventory>().RemoveItemFromInventory();
        }
    }


}

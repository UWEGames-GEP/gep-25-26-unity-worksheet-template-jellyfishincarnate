using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
public enum GameState
{
    GAMEPLAY,
    PAUSE
}
public GameState state;
public bool hasChangedState = true;
public GameObject inventoryUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void LateUpdate()
    {
        if(hasChangedState)
        {
            hasChangedState = false;

            if (state == GameState.GAMEPLAY)
            {
                Time.timeScale = 1.0f;
                inventoryUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (state == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
                inventoryUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}

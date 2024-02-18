using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CowMilking.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void OnPlay(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                SceneManager.LoadScene("Farm");
            }
        }
    }
}

using CowMilking.Persistency;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Break))
        {
            SceneManager.LoadScene("Farm");
        }
    }
}

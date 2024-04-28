using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public string sceneName = "MainScene";
    
    public void ChangeScene(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}

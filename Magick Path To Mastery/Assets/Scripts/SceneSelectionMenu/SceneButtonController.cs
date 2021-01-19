using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using System;
using UnityEngine.SceneManagement;

public class SceneButtonController : MonoBehaviour
{

    public Button VRGameButton;
    public Button MainGameButton;

    // Start is called before the first frame update
    void Start()
    {
        XRSettings.enabled = false;

        VRGameButton.onClick.AddListener(VRGame);
        MainGameButton.onClick.AddListener(MainGame);
    }

    void VRGame()
    {
        SceneManager.LoadScene(1);
    }
    void MainGame()
    {
        SceneManager.LoadScene(2);
    }
}

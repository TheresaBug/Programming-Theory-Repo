using System;
using System.IO; ///////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField PlayerNameInput;
    public Text WelcomeText;
    public Text BestScoreText;

    private void Start()
    {
        LoadNameClicked();
    }

    public void SaveNameClicked()
    {
        mMainManager.Instance.CurrentPlayerName = PlayerNameInput.text;

        mMainManager.Instance.SaveName();
        WelcomeText.text = mMainManager.Instance.CurrentPlayerName;
        LoadNameClicked();
    }

    public void LoadNameClicked()
    {
        mMainManager.Instance.LoadName();
        BestScoreText.text = $"Best Score: {mMainManager.Instance.BestScore} : {mMainManager.Instance.BestPlayerName}";

    }

    public void StartNew()
    {
        SaveNameClicked();
        SceneManager.LoadScene(1);
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        mMainManager.Instance.SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        //Application.Quit(); // original code to quit Unity player
        Application.OpenURL("javascript:window.location, _self");  //can put true in () but no longer necessary
        //Application.OpenURL("javascript:window.location://refresh");
        
        //Application.ExternalEval("window.open('javascript:window.location', '_self')");
#endif
    }
}

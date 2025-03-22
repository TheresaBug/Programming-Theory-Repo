using UnityEngine;
using UnityEngine.SceneManagement;


public class canvasManager : MonoBehaviour
{
    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

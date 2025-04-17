using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

   
    public void QuitButton()
    {
        Debug.Log("Quit button is working");
    }
}

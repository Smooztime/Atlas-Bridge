using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void ReStartGame(string name)
    {
        HidePauseMenu();
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }
    public void HidePauseMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void ShowPaudeMenu()
    { 
        this.gameObject.SetActive(true);
    }

}

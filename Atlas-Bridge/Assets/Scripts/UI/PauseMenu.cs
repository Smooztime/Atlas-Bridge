using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        HidePauseMenu();
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

using UnityEngine;

[CreateAssetMenu(fileName = "GameUI", menuName = "Scriptable Objects/GameUI")]
public class GameUI : ScriptableObject
{
    [SerializeField] private GameObject winMenuPerfab;  
    [SerializeField] private GameObject pauseMenuPerfab; 
    private GameObject winMenu;
    private GameObject pauseMenu;

    public GameObject WinMenu => winMenuPerfab;
    public GameObject PauseMenu => pauseMenuPerfab;
    public void SetWinMenu()
    {
        this.winMenu = Instantiate(winMenuPerfab);
        this.pauseMenuPerfab.SetActive(true);
    }

    public void SetPauseMenu()
    {
        SetMenuWhenLoad();
        this.pauseMenuPerfab.SetActive(true);
    }
    public void SetMenuWhenLoad()
    {
        this.winMenu = Instantiate(winMenuPerfab);
        this.pauseMenu = Instantiate(pauseMenuPerfab);
        this.pauseMenuPerfab.SetActive(false);
        this.pauseMenuPerfab.SetActive(false);
    }
}

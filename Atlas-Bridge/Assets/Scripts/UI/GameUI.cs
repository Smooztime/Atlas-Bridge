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
    }

    public void SetPauseMenu()
    {
        this.pauseMenu = Instantiate(pauseMenuPerfab);
        this.pauseMenuPerfab.SetActive(true);
    }
}

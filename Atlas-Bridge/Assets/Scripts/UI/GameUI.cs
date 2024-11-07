using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "GameUI", menuName = "Scriptable Objects/GameUI")]
public class GameUI : ScriptableObject
{
    [SerializeField] private GameObject winMenuPerfab;  
    [SerializeField] private GameObject pauseMenuPerfab;
    [SerializeField] public TMP_Text winnerNameTMP;
    private GameObject winMenu;
    private GameObject pauseMenu;

    public GameObject WinMenu => winMenuPerfab;
    public GameObject PauseMenu => pauseMenuPerfab;
    public void SetWinMenu()
    {
        Debug.Log("set win menu in gameUI");
        this.winMenu = Instantiate(winMenuPerfab);
       
        this.pauseMenuPerfab.SetActive(true);
    }

    public void SetPauseMenu()
    {
        this.winMenu = Instantiate(pauseMenuPerfab);
        this.pauseMenuPerfab.SetActive(true);
    }
    public void SetMenuWhenLoad()
    {
        this.winMenu = Instantiate(winMenuPerfab);
        this.pauseMenu = Instantiate(pauseMenuPerfab);
        this.pauseMenuPerfab.SetActive(false);
        this.pauseMenuPerfab.SetActive(false);
    }


    //Game over who win
    public void SetWinnerName(TMP_Text winnerName)
    {
        this.winnerNameTMP = winnerName;
        winnerName.text = "123";
    }
}

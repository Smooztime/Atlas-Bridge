using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class GameManager : Singleton<GameManager>
{
    [Header("---UI---")]
    [SerializeField] private GameObject winMenuPerfab;
    [SerializeField] private GameObject pauseMenuPerfab;
    [SerializeField] public TMP_Text winnerNameTMP;

    [Header("Win set up 1 situation")]

    [SerializeField] string redPlayerName;
    [SerializeField] string bluePlayerName;
    public string winnerName;

    public GameUI gameUI;
    [Header("Win set up 2 situation")]
    public List<Block> redBlocks = new List<Block>();
    public List<Block> blueBlocks = new List<Block>();
    public bool isGameOver = false;
    public bool isBlockHit= false;
    public bool _isPause { get; set; }




    private void Start()
    {
        winnerName = "";
        redBlocks.Clear();
        blueBlocks.Clear();
        winMenuPerfab.SetActive(false);
        pauseMenuPerfab.SetActive(false);
        _isPause = false;
    }
    private void InitializeUI()
    {
        gameUI.SetMenuWhenLoad();
    }

    public void GameRestart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
    public void PauseGame()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            if(_isPause)
            {
                Time.timeScale = 0f;
                pauseMenuPerfab.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenuPerfab.SetActive(false);
            }
        }
        else
        {
            return;
        }
 
    }
    public void WinHappen(FlagHolder player)
    {
        Time.timeScale = 0f;
        winnerName = player.playerName;
        Debug.Log(winnerName);
        isGameOver =true;
        winMenuPerfab.SetActive(true);
        SoundManagerNew.Instance.PlaySFX("WinSfx");
    }
    public void WinAccordingBlocks(string name)
    {
        name = winnerName;
        isGameOver = true;
        winMenuPerfab.SetActive(true);
        SoundManagerNew.Instance.PlaySFX("WinSfx");
    }

    public void CheckBlockNumber()
    {
        if (redBlocks.Count > blueBlocks.Count)
        {
            winnerName = redPlayerName;
            Debug.Log("red win");
        }
        else if (redBlocks.Count < blueBlocks.Count)
        {
            winnerName = bluePlayerName;
            Debug.Log("blue win" + winnerName);
        }
        else
        {
            Debug.Log("equal situation");
            winnerName = "";
        }

        WinAccordingBlocks(winnerName);
    }

    //if when game time is use up will calculate this which is more will win
    public void AddRedBlock(Block block)
    {

        redBlocks.Add(block);
        SoundManagerNew.Instance.PlaySFX("hitSfx");
    }

    public void RemoveRedBlock(Block block)
    {
        redBlocks.Remove(block);
        SoundManagerNew.Instance.PlaySFX("hitSfx");
    }

    public void AddBlueBlock(Block block)
    {
        blueBlocks.Add(block);

    }

    public void RemoveBlueBlock(Block block)
    {
        blueBlocks.Remove(block);
        
    }

}

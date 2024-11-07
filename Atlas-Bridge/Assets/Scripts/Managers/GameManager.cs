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




    private void Start()
    {
        winnerName = "";
        redBlocks.Clear();
        blueBlocks.Clear();
    }
    private void InitializeUI()
    {
        gameUI.SetMenuWhenLoad();
    }


    public void GameOver()
    {
        Debug.Log("game over");
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
            gameUI.SetPauseMenu();
            Time.timeScale = 0f;
        }
        else
        {
            return;
        }
 
    }
    public void WinHappen(FlagHolder player)
    {
        winnerName = player.playerName;
        Debug.Log(winnerName);
        isGameOver =true;
        gameUI.SetWinMenu();
    }
    public void WinAccordingBlocks(string name)
    {
        name = winnerName;
        isGameOver = true;
        gameUI.SetWinMenu();
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

    }

    public void RemoveRedBlock(Block block)
    {
        redBlocks.Remove(block);
       
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

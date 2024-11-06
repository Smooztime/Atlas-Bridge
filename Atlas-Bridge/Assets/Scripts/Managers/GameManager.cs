using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Win set up 1 situation")]
    [SerializeField] GameObject winMenu;
    [SerializeField] string redPlayerName;
    [SerializeField] string bluePlayerName;
    private string winnerName;
    [SerializeField]  TMP_Text winnerNameTMP;

    [Header("Win set up 2 situation")]
    public List<Block> redBlocks = new List<Block>();
    public List<Block> blueBlocks = new List<Block>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManagerDontDestroyOnLoad: " + gameObject.GetInstanceID());
        }
        else
        {
            Debug.Log("GameManager: " + gameObject.GetInstanceID());
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        winnerName = "";
        winMenu.SetActive(false);

        redBlocks.Clear();
        blueBlocks.Clear();
    }

    public void GameOver()
    {
        Debug.Log("game over");
    }
    public void WinHappen(FlagHolder player)
    {
        //Debug.Log(player+"win");
        winnerName = player.playerName;
        winnerNameTMP.text = winnerName + " wins! Congratulations";
        winMenu.SetActive(true);
    }
    public void WinAccordingBlocks(string name)
    {
        
        Debug.Log("name" + name);
        if (winnerNameTMP != null)
        {
            if (name == "")
            {
                winnerNameTMP.text = "The game ends in a draw!";
            }
            else
            {
                winnerNameTMP.text = name + " wins! Congratulations";
            }

        }
        else
        {
            Debug.Log("winnerNameTMP" + winnerNameTMP);
        }

        if (winMenu != null)
        {
            winMenu.SetActive(true);
        }
       
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

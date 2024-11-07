using TMPro;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    [SerializeField] public TMP_Text winnerNameTMP;
    private void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            ShowWinnerName();
        }
    }
    private void  ShowWinnerName()
    {
        Debug.Log("win");

        if (winnerNameTMP != null)
        {
            if (GameManager.Instance.winnerName == "")
            {
                winnerNameTMP.text = "The game ends in a draw!";
            }
            else
            {
                winnerNameTMP.text = GameManager.Instance.winnerName + " wins! Congratulations";
            }
        }
    }
}

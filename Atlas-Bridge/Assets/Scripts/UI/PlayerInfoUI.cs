using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    [Header("blue Player")]
    private Image bluePlayerImage;
    [SerializeField] TMP_Text blueTMPCount;
    [Header("red Player")]
    private Image redPlayerImage;
    [SerializeField] TMP_Text redTMPCount;
    private void Start()
    {
       
        PlayerInfoDisply();
    }

    public void PlayerInfoDisply()
    {
        blueTMPCount.text = GameManager.Instance.blueBlocks.Count.ToString();   
        redTMPCount.text = GameManager.Instance.redBlocks.Count.ToString();
    }
    private void Update()
    {
        PlayerInfoDisply();
    }
}

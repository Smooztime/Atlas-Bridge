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
    private FlagHolder flagHolder;

  
    private void Awake()
    {
        flagHolder =gameObject.GetComponent<FlagHolder>();
    }
    private void Start()
    {
       
        PlayerInfoDisply();

    }
    private void Update()
    {
        PlayerInfoDisply();
    }
    private void PlayerInfoDisply()
    {
        blueTMPCount.text = GameManager.Instance.blueBlocks.Count.ToString();   
        redTMPCount.text = GameManager.Instance.redBlocks.Count.ToString();
    }

 
}

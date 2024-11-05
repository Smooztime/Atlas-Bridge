using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject winMenu;
    [SerializeField] string WinerName;
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        { 
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        winMenu.SetActive(false);
    }
    public void GameOver()
    {
        Debug.Log("game over");
      
    }
    public void WinHappen(FlagHolder player)
    {
        Debug.Log(player+"win");
        WinerName =player.name;
        winMenu.SetActive(true);
    }
}

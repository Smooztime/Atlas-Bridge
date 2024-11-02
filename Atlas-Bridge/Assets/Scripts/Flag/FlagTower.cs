using UnityEngine;

public class FlagTower : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform _towerFlagPosition;
    [SerializeField] private GameObject _flag;
   public void Interact()
    {
        //if player come with his flag, get the flag and light on with color
        Debug.Log("get the flag");
        SetFlagPosition();
    }
    private void SetFlagPosition()
    {
        _flag.transform.SetParent(null);
        _flag.transform.position = _towerFlagPosition.position;
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Flag;

public class FlagHolder : MonoBehaviour
{
    public List<Flag> flagsHolding = new List<Flag>();
    static public bool isHoldingFlag = false;
    static public int CountToHold = 0;
    [SerializeField] public FlagHolderType flagHolderType;
    public string playerName;


    public enum FlagHolderType
    {
        redHolder,
        blueHolder
    }
    private void Start()
    {
        if (this.flagHolderType == FlagHolderType.redHolder)
        {
            playerName = "Blue Player";
        }
        else 
        {
            playerName = "Red Player";
        } 
    }

    public void AddFlag(Flag flag)
    {
        flagsHolding.Add(flag);
       Debug.Log("AddFlag hold flag:" + flagsHolding.Count);
        isHoldingFlag = true;
    }
    public void RemoveFlag(Flag flag)
    {
        flagsHolding.Remove(flag);
        Debug.Log("RemoveFlag hold flag:" + flagsHolding.Count);
        if (flagsHolding.Count <= 0) isHoldingFlag = false;
        
    }
   
}

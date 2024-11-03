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
    
    public enum FlagHolderType
    {
        redHolder,
        blueHolder
    }
    public void AddFlag(Flag flag)
    {
        flagsHolding.Add(flag);
        Debug.Log("hold flag:" + flagsHolding.Count);
        isHoldingFlag = true;
    }
    public void RemoveFlag(Flag flag)
    {
       
        flagsHolding.Remove(flag);
        Debug.Log("hold flag:" + flagsHolding.Count);
        
    }
   
}

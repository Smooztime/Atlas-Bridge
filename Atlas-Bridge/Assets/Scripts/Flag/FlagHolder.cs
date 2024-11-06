using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Flag;

public class FlagHolder : MonoBehaviour
{
    public List<Flag> flagsHolding = new List<Flag>();
    static public bool isHoldingFlag = false;
    static public int CountToHold = 0;
    [SerializeField] public FlagHolderType flagHolderType;
    public string playerName;

    public GameObject[] flagImageSlot;
   

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
        InitializeFlagDisplay();
    }
   

    private void InitializeFlagDisplay()
    {
        foreach (GameObject flagImg in flagImageSlot)
        {
            flagImg.SetActive(false);
        }
    }
    public void AddFlag(Flag flag)
    {
        flagsHolding.Add(flag);
        Debug.Log("AddFlag hold flag:" + flagsHolding.Count);
        isHoldingFlag = true;

        //update the UI info
        if (flag.Type == Flag.FlagType.flagBlue)
        {
            foreach (GameObject flagImg in flagImageSlot)
            {
                flagImageSlot[0].SetActive(true);
            }
        }
        else if (flag.Type == Flag.FlagType.flagRed)
        {
            foreach (GameObject flagImg in flagImageSlot)
            {
                flagImageSlot[1].SetActive(true);
            }
        }

    }
    public void RemoveFlag(Flag flag)
    {
        flagsHolding.Remove(flag);
        Debug.Log("RemoveFlag hold flag:" + flagsHolding.Count);

        if (flag.Type == Flag.FlagType.flagBlue)
        {
            foreach (GameObject flagImg in flagImageSlot)
            {
                flagImageSlot[0].SetActive(false);
            }
        }
        else if (flag.Type == Flag.FlagType.flagRed)
        {
            foreach (GameObject flagImg in flagImageSlot)
            {
                flagImageSlot[1].SetActive(false);
            }
        }
    }
   
}

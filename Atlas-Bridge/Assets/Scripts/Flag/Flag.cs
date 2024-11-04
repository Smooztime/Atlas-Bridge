using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class Flag : MonoBehaviour
{
    [SerializeField] private FlagType flagType;
    private FlagHolder flagHolder;
    private bool canBePickedUp = true;
    [SerializeField] private float pickupCooldown = 3f; 

    public enum FlagType
    {
        flagRed,
        flagBlue
    }

    public FlagType Type => flagType;

    private void OnTriggerEnter(Collider other)
    {
        flagHolder = other.GetComponent<FlagHolder>();
        if (flagHolder != null)
        {
            if (canBePickedUp)
            {
                FlagBePickedUP();
                Debug.Log("pickup " +this.name);
                flagHolder.AddFlag(this);
            }
        }
    }
    private void FlagBePickedUP()
    {
        this.transform.SetParent(flagHolder.transform);
        this.transform.localPosition = new Vector3(0.3f, 0.3f, 0.3f);

    }

    private IEnumerator PickUpCooldown()
    {
        yield return new WaitForSeconds(pickupCooldown);
        canBePickedUp = true;
    }

    public void FlagFallOnGround()
    {
        this.transform.SetParent(null);
        canBePickedUp = false;
        StartCoroutine(PickUpCooldown());
    }

}

using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Flag : MonoBehaviour
{
    [SerializeField] private FlagType flagType;
    private FlagHolder flagHolder;
    private bool canBePickedUp = true;
    [SerializeField] private float pickupCooldown = 3f;
    private Transform originalRotation;

    private void Start()
    {
        //store the rotate at beginnings
        originalRotation =this.transform;
    }
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
        this.transform.localPosition = new Vector3(0.5f, 0.5f, 0.5f);
        if (flagHolder.flagsHolding.Count == 0)
        {
            this.transform.Rotate(30f, 0f, 0f, Space.World);
        }
        else if(flagHolder.flagsHolding.Count == 1)
        {
            this.transform.Rotate(-30f, 0f, 0f, Space.World);
        }
    }

    private IEnumerator PickUpCooldown()
    {
        yield return new WaitForSeconds(pickupCooldown);
        canBePickedUp = true;
    }

    public void FlagFallOnGround()
    {
        this.transform.SetParent(null);
        this.transform.position = new Vector3(transform.position.x, 0,this.transform.position.z);
        this.transform.Rotate(10,10f,90f);
        canBePickedUp = false;
        StartCoroutine(PickUpCooldown());
    }

}

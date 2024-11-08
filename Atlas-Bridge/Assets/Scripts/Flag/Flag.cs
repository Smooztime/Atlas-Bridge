using System.Collections;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private FlagType flagType;
    [SerializeField] private Light _light;
    private FlagHolder flagHolder;
    private bool canBePickedUp = true;
    [SerializeField] private float pickupCooldown = 3f;
    private Transform originalRotation;
    private bool _isPickedUp = false;
    private Transform _backPosition;
    private Rigidbody rb;
    private Transform _dropPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //store the rotate at beginnings
        originalRotation = this.transform;
    }
    public enum FlagType
    {
        flagRed,
        flagBlue
    }

    public FlagType Type => flagType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<FlagHolder>())
        {
            bool _isKnockBack = other.GetComponent<PlayerController>()._isKnockBack;
            flagHolder = other.GetComponent<FlagHolder>();
            if (flagHolder != null && !_isPickedUp && _isKnockBack == false)
            {
                if (canBePickedUp)
                {
                    FlagBePickedUP();
                    Debug.Log("pickup " + this.name);
                    flagHolder.AddFlag(this);
                }
            }
        }
    }
    private void FlagBePickedUP()
    {
        _light.enabled = false;
        rb.freezeRotation = false;
        rb.isKinematic = true;
        rb.detectCollisions = false;
        _backPosition = flagHolder.transform.GetChild(1).transform;
        this.transform.SetParent(_backPosition);
        this.transform.position = _backPosition.position;
        if (flagHolder.flagsHolding.Count == 0)
        {
            this.transform.localRotation = Quaternion.Euler(45f, 90f, 0f);
        }
        else if (flagHolder.flagsHolding.Count == 1)
        {
            this.transform.localRotation = Quaternion.Euler(45f, -90f, 0f);
        }
        _isPickedUp = true;
    }

    private IEnumerator PickUpCooldown()
    {
        yield return new WaitForSeconds(pickupCooldown);
        canBePickedUp = true;
    }

    public void FlagFallOnGround()
    {
        _light.enabled = true;
        _isPickedUp = false;
        rb.freezeRotation = true;
        rb.isKinematic = false;
        rb.detectCollisions = true;

        this.transform.SetParent(null);
        if (flagHolder.flagsHolding.Count == 2)
        {
            this.transform.position = new Vector3(_backPosition.position.x, _backPosition.position.y, _backPosition.position.z);
            this.transform.rotation = Quaternion.Euler(0f, 90f, 90f);
        }
        else if (flagHolder.flagsHolding.Count == 1)
        {
            this.transform.position = new Vector3(_backPosition.position.x, _backPosition.position.y, _backPosition.position.z);
            this.transform.rotation = Quaternion.Euler(180f, 90f, 90f);
        }
        canBePickedUp = false;
        StartCoroutine(PickUpCooldown());
    }

    public void FlagDropAtPosition(Transform pos)
    {
        _dropPosition = pos;
    }

    public void FlagDropOnGroundAfterDrowned()
    {
        _light.enabled = true;
        _isPickedUp = false;
        rb.freezeRotation = true;
        rb.isKinematic = false;
        rb.detectCollisions = true;

        this.transform.SetParent(null);
        if (flagHolder.flagsHolding.Count == 2)
        {
            this.transform.position = new Vector3(_dropPosition.position.x, _dropPosition.position.y, _backPosition.position.z);
            this.transform.rotation = Quaternion.Euler(0f, 90f, 90f);
        }
        else if (flagHolder.flagsHolding.Count == 1)
        {
            this.transform.position = new Vector3(_dropPosition.position.x, _dropPosition.position.y, _backPosition.position.z);
            this.transform.rotation = Quaternion.Euler(180f, 90f, 90f);
        }
        canBePickedUp = false;
        StartCoroutine(PickUpCooldown());
    }
}

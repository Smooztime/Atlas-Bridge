using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStatsSO playerState;

    private Rigidbody rb; 
    private float _movement;
    private Transform _playerDir;
    private bool _rotateChange;
    private bool _isMove;
    public bool _isControllerActive { get; set; }

    public Rigidbody RB => rb;
    public PlayerStatsSO PlayerState => playerState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _isMove = false;
        _isControllerActive = true;
    }

    private void FixedUpdate()
    {
        OnMove();
        RotatePlayer();
    }

    public void MovementInput(float value)
    {
        _movement = value;
    }

    private void OnMove()
    {
        if (_movement == 1 && _isControllerActive == true)
        {
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = transform.forward * playerState.MovementSpeed;
            rb.linearVelocity.Normalize();
        }
    }

    public void OnMoveReleased()
    {
        _movement = 0;
        _rotateChange = !_rotateChange;
    }

    private void RotatePlayer()
    {
        if (rb.linearVelocity.magnitude > 0.2f) return;
        else if (_isControllerActive == true)
        {
            if (_rotateChange) rb.angularVelocity = new Vector3(0, playerState.RotateSpeed * Time.fixedDeltaTime, 0);
            else rb.angularVelocity = new Vector3(0, -playerState.RotateSpeed * Time.fixedDeltaTime, 0);
        }
        else rb.angularVelocity = Vector3.zero;
    }

    public IEnumerator DisableController()
    {
        Debug.Log("Start");
        _isControllerActive = false;
        yield return new WaitForSeconds(1);
        _isControllerActive = true;
    }
}

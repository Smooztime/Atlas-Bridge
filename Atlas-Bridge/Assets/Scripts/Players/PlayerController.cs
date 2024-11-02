using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStatsSO playerState;

    private Rigidbody rb;
    private float _movement;
    private bool _rotateChange;
    private bool _isMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _isMove = false;
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
        if (_movement == 1)
        {
            rb.linearVelocity = transform.forward * playerState.MovementSpeed;
            rb.linearVelocity.Normalize();
        }
    }

    public void OnMoveReleased()
    {
        rb.linearVelocity = transform.forward * playerState.MovementSpeed;
        _movement = 0;
        _rotateChange = !_rotateChange;
    }

    private void RotatePlayer()
    {
        if (rb.linearVelocity.magnitude > 0.1f) return;
        else
        {
            if (_rotateChange) transform.Rotate(0, playerState.RotateSpeed * Time.fixedDeltaTime, 0);
            else transform.Rotate(0, -playerState.RotateSpeed * Time.fixedDeltaTime, 0);
        }
    }
}

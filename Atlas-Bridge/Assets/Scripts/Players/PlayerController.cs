using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStatsSO playerStats;
    [SerializeField] private Animator _anim;

    private Rigidbody rb;
    private float _movement;
    private Transform _playerDir;
    private bool _rotateChange;
    private bool _isPause;

    public bool _isKnockBack { get; set; }
    public bool _isControllerActive { get; set; }
    public Rigidbody RB => rb;
    public Animator Anim => _anim;
    public PlayerStatsSO PlayerState => playerStats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _isControllerActive = true;
        _isPause = false;
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
            _anim.SetBool("IsRunning", true);
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = transform.forward * playerStats.MovementSpeed;
        }
    }

    public void OnMoveReleased()
    {
        _anim.SetBool("IsRunning", false);
        _movement = 0;
        _rotateChange = !_rotateChange;
    }

    public void OnGamePause()
    {
        _isPause = !_isPause;
        GameManager.Instance._isPause = _isPause;
        GameManager.Instance.PauseGame();
        Debug.Log(_isPause);
    }

    private void RotatePlayer()
    {
        if (rb.linearVelocity.magnitude > 0.2f) return;
        else if (_isControllerActive == true)
        {
            if (_rotateChange) rb.angularVelocity = new Vector3(0, playerStats.RotateSpeed * Time.fixedDeltaTime, 0);
            else rb.angularVelocity = new Vector3(0, -playerStats.RotateSpeed * Time.fixedDeltaTime, 0);
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

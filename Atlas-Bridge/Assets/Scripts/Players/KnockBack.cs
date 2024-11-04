using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float viewRadius;
    [Range(0f, 360f), SerializeField] private float viewAngle;

    private List<Transform> _visibleThreats = new List<Transform>();
    private bool _isDetect = false;
    private PlayerController _controller;
    private PlayerInputController _input;
    private SpawnPlayer _spawnPlayer;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _input = GetComponent<PlayerInputController>();
        _spawnPlayer = GetComponent<SpawnPlayer>();
    }

    private void FixedUpdate()
    {
        Detect();
        Debug.Log(_controller.RB.linearVelocity.normalized.magnitude);
    }

    private void Detect()
    {
        _visibleThreats.Clear();
        _isDetect = false;
        var targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius);

        for(int i = 0; i < targetInViewRadius.Length; i++)
        {
            var target = targetInViewRadius[i].transform;
            var opponentInput = target.GetComponent<PlayerInputController>();
            var directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                if(opponentInput != null && opponentInput.MapName != _input.MapName)
                {
                    _visibleThreats.Add(target);
                    _isDetect = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
       if(collision.gameObject.GetComponent<PlayerController>())
        {
            var opponentMapName = collision.gameObject.GetComponent<PlayerInputController>().MapName;
            var opponentCtrl = collision.gameObject.GetComponent<PlayerController>();
            var opponentSpawn = collision.gameObject.GetComponent<SpawnPlayer>();

            if (_isDetect == true && opponentMapName != _input.MapName)
            {
                Debug.Log("Enter");
                if (_controller.RB.linearVelocity.normalized.magnitude > opponentCtrl.RB.linearVelocity.normalized.magnitude)
                {
                    Vector3 OpponentDirection = (collision.transform.position - transform.position).normalized;
                    opponentCtrl.RB.AddForce(OpponentDirection * _controller.RB.linearVelocity.magnitude * _controller.PlayerState.PlayerForce, ForceMode.Impulse);
                    _controller.StartCoroutine(_controller.DisableController());
                    opponentSpawn.PlayerDead();
                }
                else if (Mathf.Abs(_controller.RB.linearVelocity.magnitude - opponentCtrl.RB.linearVelocity.magnitude) < 0.1f)
                {
                    Vector3 OpponentDirection = (collision.transform.position - transform.position).normalized;
                    opponentCtrl.RB.AddForce(OpponentDirection * _controller.RB.linearVelocity.magnitude * _controller.PlayerState.PlayerForce / 2, ForceMode.Impulse);
                    opponentSpawn.PlayerDead();
                }
            }
        }
    }

    [SerializeField] private float viewSpectrumIterator = 5;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach(var target in _visibleThreats)
        {
            Gizmos.DrawLine(transform.position, target.position);
        }

        Gizmos.color = Color.yellow;
        float halfPOV = viewAngle / 2;

        for(float i = -halfPOV; i < halfPOV; i += viewSpectrumIterator)
        {
            Quaternion rayRot = Quaternion.AngleAxis(i, Vector3.up);
            Vector3 rayDir = rayRot * transform.forward;
            Gizmos.DrawRay(transform.position, rayDir * viewRadius);
        }

        Gizmos.color = Color.green;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfPOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfPOV, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay(transform.position, leftRayDirection * viewRadius);
        Gizmos.DrawRay(transform.position, rightRayDirection * viewRadius);
    }
}

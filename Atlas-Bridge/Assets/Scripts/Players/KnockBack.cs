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
    private float forceSpeed;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _input = GetComponent<PlayerInputController>();
        _spawnPlayer = GetComponent<SpawnPlayer>();
    }

    private void FixedUpdate()
    {
        Detect();
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
                    forceSpeed = _controller.RB.linearVelocity.normalized.magnitude;
                }
            }
        }
    }

    public void KnockBackFromStuffs(Transform obstacleTransform, float obstacleForce)
    {
        _controller._isKnockBack = true;
        Vector3 objDirection = (transform.position - obstacleTransform.transform.position).normalized;
        _controller.RB.AddForce(objDirection * _controller.RB.linearVelocity.normalized.magnitude * obstacleForce, ForceMode.Impulse);
        _spawnPlayer.PlayerDead();
    }

    private void OnTriggerEnter(Collider collision)
    {
       if(collision.gameObject.GetComponent<PlayerController>())
        {
            var opponentMapName = collision.gameObject.GetComponent<PlayerInputController>().MapName;
            var opponentCtrl = collision.gameObject.GetComponent<PlayerController>();
            var opponentSpawn = collision.gameObject.GetComponent<SpawnPlayer>();
            var opponentKnockBack = collision.gameObject.GetComponent<KnockBack>();

            if (_isDetect == true && opponentMapName != _input.MapName && opponentCtrl._isControllerActive)
            {
                if (_controller.RB.linearVelocity.normalized.magnitude > opponentCtrl.RB.linearVelocity.normalized.magnitude)
                {
                    opponentCtrl._isKnockBack = true;
                    Debug.Log(_input.MapName + "is POWERFUL!!");
                    Vector3 OpponentDirection = (collision.transform.position - transform.position).normalized;
                    opponentCtrl.RB.AddForce(OpponentDirection * forceSpeed * _controller.PlayerState.PlayerForce, ForceMode.Impulse);
                    _controller.StartCoroutine(_controller.DisableController());
                    opponentSpawn.PlayerDead();
                }
                else if (_controller.RB.linearVelocity.normalized.magnitude == opponentCtrl.RB.linearVelocity.normalized.magnitude)
                {
                    opponentCtrl._isKnockBack = true;
                    Debug.Log("We are kissing for each other");
                    Vector3 OpponentDirection = (collision.transform.position - transform.position).normalized;
                    opponentCtrl.RB.AddForce(OpponentDirection * forceSpeed * _controller.PlayerState.PlayerForce, ForceMode.Impulse);
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

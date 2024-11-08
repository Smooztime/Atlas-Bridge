using System.Collections;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    private PlayerController _controller;
    private FlagHolder _flagHolder;
    private Flag[] _flag;
    private Collider[] _collider;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _collider = GetComponents<Collider>();
        _flagHolder = GetComponent<FlagHolder>();
    }
    public void PlayerDead()
    {
        _controller._isControllerActive = false;
        StartCoroutine(PlayerRespwan());
    }

    private IEnumerator PlayerRespwan()
    {
        yield return new WaitForSeconds(1);

        _flag = GetComponentsInChildren<Flag>();
        foreach (Flag flag in _flag)
        {
            if (_flag != null)
            {
                Debug.Log("drop");
                flag.FlagFallOnGround();
                _flagHolder.RemoveFlag(flag);
            }
        }
        _controller.Anim.SetBool("IsKnockBack", false);

        foreach (Collider collider in _collider)
        {
            collider.enabled = false;
        }
        yield return new WaitForSeconds(3);

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(2);

        foreach (Collider collider in _collider)
        {
            collider.enabled = true;
        }
        gameObject.transform.position = spawnPos.position;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        
        _controller._isControllerActive = true;
        _controller._isKnockBack = false;
    }

    public void PlayerDrowning()
    {
        _controller._isControllerActive = false;
        StartCoroutine(PlayerRespwanAfterDrowned());
    }

    private IEnumerator PlayerRespwanAfterDrowned()
    {
        yield return new WaitForSeconds(1);
        _flag = GetComponentsInChildren<Flag>();
        foreach (Flag flag in _flag)
        {
            if (_flag != null)
            {
                Debug.Log("drop");
                flag.FlagDropOnGroundAfterDrowned();
                _flagHolder.RemoveFlag(flag);
            }
        }

        foreach (Collider collider in _collider)
        {
            collider.enabled = false;
        }
        yield return new WaitForSeconds(1);

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(1);

        foreach (Collider collider in _collider)
        {
            collider.enabled = true;
        }
        gameObject.transform.position = spawnPos.position;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        _controller._isControllerActive = true;
        _controller._isKnockBack = false;
    }
}

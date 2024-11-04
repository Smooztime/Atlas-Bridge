using System.Collections;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    private PlayerController _controller;
    private Collider[] _collider;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _collider = GetComponents<Collider>();
    }
    public void PlayerDead()
    {
        _controller._isControllerActive = false;
        StartCoroutine(PlayerRespwan());
    }

    private IEnumerator PlayerRespwan()
    {
        yield return new WaitForSeconds(1);
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
    }
}

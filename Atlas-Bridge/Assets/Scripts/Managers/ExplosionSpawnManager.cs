using System.Collections;
using UnityEngine;

public class ExplosionSpawnManager : MonoBehaviour
{
    [Header("---Spawner---")]
    [SerializeField] private GameObject explosion;
    [SerializeField] private int min, max;
    [SerializeField] private float forEachTime;
    [SerializeField] private float forEachExplode;
    [SerializeField] private float overgroundDistance;
    [SerializeField] private Vector2 positivePos, negativePos;

    [Header("---Field Check---")]
    [SerializeField] private float distance;

    private int _amount;
    private int _randomAmount;
    private bool _canSpawn;
    private Vector3 pos;
    private GameObject _explodsionSpawn;

    private void Start()
    {
        StartCoroutine(Explode());
    }

    private void Update()
    {
        Debug.Log(_amount);
    }

    private IEnumerator Explode()
    {
        while(true)
        {
            yield return new WaitForSeconds(forEachTime);
            _amount = 0;
            _randomAmount = 0;
            _randomAmount = Random.Range(min, max);
            RaycastHit hit;
            while(_amount < _randomAmount)
            {
                yield return new WaitForSeconds(forEachExplode);
                _canSpawn = false;
                while (!_canSpawn)
                {
                    Vector3 origin = new Vector3(Random.Range(positivePos.x, negativePos.x), transform.position.y, Random.Range(positivePos.y, negativePos.y));
                    if (Physics.Raycast(origin, Vector3.down, out hit, distance))
                    {
                        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                        {
                            pos = hit.point;
                            _canSpawn = true;
                            SoundManagerNew.Instance.PlaySFX("explosionSfx");
                        }
                        else
                        {
                            _canSpawn = false;
                            Debug.Log("Bad spot, cannot plant the bomb");
                        }
                    }
                    else
                    {
                        _canSpawn = false;
                        Debug.Log("Where is ground?");
                    }
                    if (_canSpawn)
                    {
                        _explodsionSpawn = Instantiate(explosion, pos, Quaternion.identity);
                    }
                }
                _amount += 1;
            }
        }
    }


    /*while (_amount < _randomAmount)
    {

        while (!_canSpawn)
        {
            Vector3 origin = new Vector3(Random.Range(positivePos.x, negativePos.x), 0f, Random.Range(positivePos.y, negativePos.y));
            if (Physics.Raycast(origin, Vector3.down, out hit, distance, _leyerCheck))
            {
                Debug.Log(hit.collider.gameObject.name);
                pos = hit.point;
                _canSpawn = true;
                Debug.Log("Found spot to plant");
            }
            else
            {
                _canSpawn = false;
                Debug.Log("Bad spot, cannot plant!");
            }
        }
        _explodsionSpawn = Instantiate(explosion, pos, Quaternion.identity);
        _amount += 1;
    }*/
}

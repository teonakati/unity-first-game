using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private float _spawnSecondsInterval = 5f;
    private IEnumerator _coroutine;
    private bool _stopSpawning = false;
    void Start()
    {
        _coroutine = SpawnEnemy(_spawnSecondsInterval);
        StartCoroutine(_coroutine);
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemy(float seconds)
    {
        while (_stopSpawning == false)
        {
            var newEnemy = Instantiate(_enemyPrefab);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(seconds);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}

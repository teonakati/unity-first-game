using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPowerUpPrefab;
    [SerializeField]
    private float _spawnSecondsInterval = 5f;
    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemy(_spawnSecondsInterval));
        StartCoroutine(SpawnPowerUp());
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

    IEnumerator SpawnPowerUp()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(Random.Range(3f, 7f));
            Instantiate(_tripleShotPowerUpPrefab);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}

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
    private bool _stopSpawning = false;
    [SerializeField]
    private GameObject[] _powerUpPrefabs;
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

            var randomPowerUp = Random.Range(0, 3);

            Instantiate(_powerUpPrefabs[randomPowerUp]);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}

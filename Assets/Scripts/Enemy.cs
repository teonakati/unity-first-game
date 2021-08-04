using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private float _spawnHeight = 10f;
    private Player _player;
    void Start()
    {
        transform.position = RandomizeSpawn();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        MoveDown();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);

            if (_player != null)
                _player.AddScore(10);

            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            if (_player != null)
            {
                _player.Damage();
            }

            Destroy(gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            transform.position = RandomizeSpawn();
        }
    }

    Vector3 RandomizeSpawn()
    {
        var randomPosition = Random.Range(-11f, 11f);
        return new Vector3(randomPosition, _spawnHeight, 0);
    }
}

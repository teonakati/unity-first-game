using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tipleShotPrefab;
    [SerializeField]
    private float _fireCooldown = 0.3f;
    private float _nextFire = 0f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private bool _isShieldActive = false;
    [SerializeField]
    private GameObject _shield;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.x <= -13.80f)
        {
            transform.position = new Vector3(13.81f, transform.position.y, 0);
        }
        if (transform.position.x >= 13.82f)
        {
            transform.position = new Vector3(-13.79f, transform.position.y, 0);
        }

        if (transform.position.y <= -5.54f)
        {
            transform.position = new Vector3(transform.position.x, 7.54f, 0);
        }
        if (transform.position.y >= 7.55f)
        {
            transform.position = new Vector3(transform.position.x, -5.53f, 0);
        }
    }

    void FireLaser()
    {
        _nextFire = Time.time + _fireCooldown;

        if (_isTripleShotActive)
        {
            Instantiate(_tipleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            var position = new Vector3(transform.position.x, transform.position.y + 1.05f, 0);
            Instantiate(_laserPrefab, position, Quaternion.identity);
        }
    }

    public void Damage()
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            _shield.SetActive(_isShieldActive);
            return;
        }

        _lives--;

        if (_lives == 0)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    public void EnableTripleShot()
    {
        _isTripleShotActive = true;
        StartCoroutine(StopTripleShot());
    }

    IEnumerator StopTripleShot()
    {
        yield return new WaitForSeconds(5f);
        _isTripleShotActive = false;
    }

    public void EnableSpeedBoost()
    {
        StartCoroutine(StopSpeedBoost(_speed));
    }

    IEnumerator StopSpeedBoost(float speed)
    {
        _speed += speed;
        yield return new WaitForSeconds(5f);
        _speed -= speed;
    }

    public void EnableShield()
    {
        _isShieldActive = true;
        _shield.SetActive(_isShieldActive);
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireCooldown = 0.3f;
    private float _nextFire = 0f;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();
        FireLaser();
    }

    void CalculateMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_speed == 3.5f)
                _speed = _speed * 2;
        }
        else
        {
            _speed = 3.5f;
        }

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
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireCooldown;
            var position = new Vector3(transform.position.x, transform.position.y + 1f, 0);
            Instantiate(_laserPrefab, position, Quaternion.identity);
        }
    }
}

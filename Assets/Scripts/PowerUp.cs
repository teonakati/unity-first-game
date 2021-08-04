using Assets.Scripts.Enums;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private EnPowerUp _powerUp;
    private Player _player;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-11f, 11f), 10f, 0f);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Destroy(gameObject);

            if (_player != null)
                switch(_powerUp)
                {
                    case EnPowerUp.TripleShot:
                        _player.EnableTripleShot();
                        break;
                    case EnPowerUp.SpeedBoost:
                        _player.EnableSpeedBoost();
                        break;
                    case EnPowerUp.Shield:
                        _player.EnableShield();
                        break;
                }
        }
    }
}

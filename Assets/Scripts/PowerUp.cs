using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-11f, 11f), 10f, 0f);
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
            var player = collision.transform.GetComponent<Player>();

            if (player != null)
                player.EnableTripleShot();
        }
    }
}

using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;
    void Start()
    {
        
    }
    
    void Update()
    {
        MoveLaserUp();
    }

    void MoveLaserUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class Enamy : MonoBehaviour
{
    [SerializeField] private float _speedEnamy;
    [SerializeField] private float _startWaitTime;
    [SerializeField] private Transform[] _moveSpots;

    private int _randomSpot;
    private float _waitTime;

    void Start()
    {
        _waitTime = _startWaitTime;
        _randomSpot = 12;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveSpots[_randomSpot].position,
            _speedEnamy * Time.deltaTime);
       

        if (Vector2.Distance(transform.position, _moveSpots[_randomSpot].position) < 0.5f)
        {
            if (_waitTime <= 0)
            {
                _randomSpot = Random.Range(0, _moveSpots.Length);
                _waitTime = _startWaitTime;
                Vector2 _lookDir = _moveSpots[_randomSpot].position - transform.position;
                var  rot_z = Mathf.Atan2(_lookDir.y , _lookDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
    
    // обработка столкновения с бомбой
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "BombActiv" || collision.gameObject.tag == "Bomb")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}



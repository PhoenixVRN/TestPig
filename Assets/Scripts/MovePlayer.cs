using UnityEngine;


public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private DynamicJoystick _joystick;
   
    private Rigidbody2D _rigidbody2DL;
   
    void Start()
    {
        _rigidbody2DL = GetComponent<Rigidbody2D>();
        }


    void FixedUpdate()
    {
        float horizontal = _joystick.Horizontal;
        float vertical = _joystick.Vertical;

        Vector2 position = _rigidbody2DL.position;
        position.x = position.x + horizontal * _speed * Time.deltaTime;
        position.y = position.y + vertical * _speed * Time.deltaTime;
        _rigidbody2DL.MovePosition(position);
        
        // поворачиваем плейера по направлению движения
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            var  rot_z = Mathf.Atan2(_joystick.Vertical, _joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
    }

}


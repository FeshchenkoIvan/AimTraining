using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTransform : MonoBehaviour
{
    private Transform _transform;
    private float _speed;
    private Vector3 _direction;
    // Start is called before the first frame update

    public PlayerMoveTransform(Transform transform, float speed)
    {
        _transform = transform; _speed = speed;
    }

    public void Move(float horizontal, float vertical, float deltaTime)
    {
        _direction.z = vertical;
        _direction.x = horizontal;
        _transform.Translate(_direction * _speed * deltaTime);
    }

    public void Rotation(float sensitivy)
    {
        _transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivy, 0);

        if ((_transform.GetChild(0).eulerAngles.x < 80) || (_transform.GetChild(0).eulerAngles.x > 320))
        {
            _transform.GetChild(0).rotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * sensitivy, 0, 0);
        }
        else
        {
            if (_transform.GetChild(0).eulerAngles.x < 90)
            {
                _transform.GetChild(0).rotation *= Quaternion.Euler(-0.1f, 0, 0);
            }
            else
            {
                _transform.GetChild(0).rotation *= Quaternion.Euler(0.1f, 0, 0);
            }
        }
    }
}

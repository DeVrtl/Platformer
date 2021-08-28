using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _groundDetector;

    private bool _isMovingRight = true;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetector.position, Vector2.down, _distance);

        if (groundInfo.collider == false)
        {
            if (_isMovingRight == true)
            {
                Rotation(0, -180, 0, false);
            }
            else
            {
                Rotation(0, 0, 0, true);
            }
        }
    }

    private void Rotation(int x, int y, int z, bool resualt)
    {
        transform.eulerAngles = new Vector3(x, y, z);
        _isMovingRight = resualt;
    }
}

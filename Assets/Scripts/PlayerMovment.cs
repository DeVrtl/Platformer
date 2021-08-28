using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _raycatsDistance;
    [SerializeField] private LayerMask _groundLayerMask;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private const string Speed  = "Speed";

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var movevment = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movevment, 0, 0) * Time.deltaTime * _speed;

        _animator.SetFloat(Speed, Mathf.Abs(movevment));

        if (GroundCheck() && Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private bool GroundCheck()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, _raycatsDistance, _groundLayerMask);
        return raycastHit.collider != null;
    }
}

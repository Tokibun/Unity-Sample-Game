using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePB : MonoBehaviour
{
    private float _playerInput;

    private float _rotationInput;
    private Vector3 _userRotation;

    private bool _userJumped;

    private const float _inputScale = 0.25f;

    private Rigidbody _rigidbody;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerInput = Input.GetAxis("Vertical");
        _rotationInput = Input.GetAxis("Horizontal");
        // _userJumped = Input.GetKeyDown("C")
        _userJumped = Input.GetButton("Jump"); //This is mapped to spacebar in unity project settings > input

    }

    private void FixedUpdate() 
    {
        _userRotation = _transform.rotation.eulerAngles;
        _userRotation += new Vector3(0, _rotationInput, 0);
        _transform.rotation = Quaternion.Euler(_userRotation);
        _rigidbody.velocity += transform.forward * _playerInput * _inputScale; 

        if(_userJumped)
        {
            _rigidbody.AddForce(Vector3.up, ForceMode.VelocityChange);
        }
    }
}
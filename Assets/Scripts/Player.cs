using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _velocity;

    private float _speed = 5.0f;
    private float _gravity = 5.0f;
    private float _jumpHeight = 15.0f;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame 
    void Update()
    {
        // Calculate Physics 
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _velocity = direction * _speed;
        
        if(_characterController.isGrounded && Input.GetButtonDown("Jump")){
            _velocity.y = _jumpHeight;
        }else{
            _velocity.y -= _gravity;
        }

        // Update Character 
        _characterController.Move(_velocity * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int SpeedHorizontal;

    private Animator _animation;
    private Rigidbody2D _playerRb;
    private Transform _playerTransform;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {  
        _playerRb = GetComponent<Rigidbody2D>();
        _playerTransform = GetComponent<Transform>();
        _animation = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");   
        if(HorizontalMovement != 0)
        {
            if(HorizontalMovement < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
            _animation.SetBool("IsRun", true);
            if(this.gameObject.transform.position.x < 26.3f && HorizontalMovement > 0)
            {
                _playerRb.AddRelativeForce(_playerTransform.right * SpeedHorizontal * HorizontalMovement);
            }
            else if(this.gameObject.transform.position.x > -21f && HorizontalMovement < 0)
            {
                _playerRb.AddRelativeForce(_playerTransform.right * SpeedHorizontal * HorizontalMovement);
            }
        }
        else
        {
            _animation.SetBool("IsRun", false);
        }
     
    }
}

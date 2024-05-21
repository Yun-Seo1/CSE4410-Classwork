using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = 5;
    }

    // Update is called once per frame
    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log($"Health: {_health}");
    }

}

/*
    [SerializeField] private float _Speed = 3.0f;
    [SerializeField] private FPSInput _FPSInput;
    private int _health;


    Rigidbody PlayerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();
        _health = 5;
    }

    private void Update()
    {
        HandleMovement();
    }
    // Update is called once per frame
    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log($"Health: {_health}");
    }

    private void HandleMovement()
    {
        Vector2 InputVector = _FPSInput.GetMovementVectorNormalized();
        //Vector3 MoveDir = new Vector3(InputVector.x, 0f, InputVector.y);
        //transform.position += MoveDir * _Speed * Time.deltaTime;

        Vector3 PlayerVelocity = new Vector3(InputVector.x * _Speed * Time.deltaTime, PlayerRigidBody.velocity.y , InputVector.y * _Speed * Time.deltaTime);
        PlayerRigidBody.velocity = transform.TransformDirection(PlayerVelocity);
        
    }
*/
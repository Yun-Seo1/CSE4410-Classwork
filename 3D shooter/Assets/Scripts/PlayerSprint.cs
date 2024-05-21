using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class PlayerSprint : MonoBehaviour
{
    [Header("Movement")]
    private float _MoveSpeed;
    public float WalkSpeed;
    public float SprintSpeed;

    private bool _Grounded = true;

    [Header("Keybinds")]
    public KeyCode SprintKey = KeyCode.LeftShift;

    public MovementState State;
    public enum MovementState
    {
        walking,
        sprinting,
        air
    }

    
    public float gravity = -9.8f;

    private CharacterController _CharController;
    // Start is called before the first frame update
    void Start()
    {
        _CharController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _MoveSpeed /** Time.deltaTime*/;
        float deltaZ = Input.GetAxis("Vertical") * _MoveSpeed /** Time.deltaTime*/;
        //transform.Translate(deltaX, 0, deltaZ);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, _MoveSpeed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _CharController.Move(movement);

        StateHandler();
    }

    private void StateHandler()
    {
        //Sprinting
        if (_Grounded && Input.GetKey(SprintKey))
        {
            State = MovementState.sprinting;
            _MoveSpeed = SprintSpeed;
        }
        //Walking
        else if (_Grounded)
        {
            State = MovementState.walking;
            _MoveSpeed = WalkSpeed;
        }
        //Air
        else
        {
            State = MovementState.air;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{

    public float speed = 3.0f;
    public float gravity = -9.8f;

    public const float BaseSpeed = 6f;

    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float Value)
    {
        speed = BaseSpeed * Value;
    }


    private CharacterController _CharController;
    // Start is called before the first frame update
    void Start()
    {
        _CharController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed /** Time.deltaTime*/;
        float deltaZ = Input.GetAxis("Vertical") * speed /** Time.deltaTime*/;
        //transform.Translate(deltaX, 0, deltaZ);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _CharController.Move(movement);

    }
}


/*
private PlayerInputActions _PlayerInputActions;
    private void Awake()
    {
        _PlayerInputActions = new PlayerInputActions();
        _PlayerInputActions.Player.Enable();
    }


    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 InputVector = _PlayerInputActions.Player.Move.ReadValue<Vector2>();

        InputVector.Normalize();
        return InputVector;
    }

*/
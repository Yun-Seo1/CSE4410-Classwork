using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAnyY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAnyY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45f;

    private float verticalRot = 0;

    [SerializeField] Transform playerbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            //Horizonal rotation here
            transform.Rotate(0,Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }

        else if (axes == RotationAxes.MouseY)
        {
            //Vertical rotation here
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizonalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizonalRot, 0);
            
        }

        else
        {
            //Horizontal and Veritcal rotation here
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float horizonalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizonalRot, 0);
        }
    }
}
/*

[SerializeField] private float _MinViewDistance = 45f;
    [SerializeField] Transform Playerbody;

    [SerializeField] private float _MouseSensitity = 100f;

    float xRotation = 0f;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _MouseSensitity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _MouseSensitity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, _MinViewDistance);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Playerbody.Rotate(Vector3.up * mouseX);
    }
*/

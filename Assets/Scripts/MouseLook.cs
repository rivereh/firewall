using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float lookSensitivity = 5;

    float yRotation;
    float xRotation;

    void LateUpdate()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, -85, 85);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.parent.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

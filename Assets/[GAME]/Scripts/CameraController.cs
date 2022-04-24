using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(1, 100)]
    public float Mouse_Sensitivity = 1;
    public Transform Target;
    public float Distance_From_Target = 2;
    public Vector2 Pitch_MinMax = new Vector2(-40, 85);

    public float Rotation_Smooth_Time = 1.2f;
    Vector3 rotation_smooth_time_velocity;
    Vector3 current_rotation;

    float yaw;
    float pitch;

    void Start()
    {

    }


    void LateUpdate()
    {
        yaw += Input.GetAxisRaw("Mouse X") * Mouse_Sensitivity;
        pitch += Input.GetAxisRaw("Mouse Y") * Mouse_Sensitivity;
        pitch = Mathf.Clamp(pitch, Pitch_MinMax.x, Pitch_MinMax.y);

        current_rotation = Vector3.SmoothDamp(current_rotation, new Vector3(pitch, yaw), ref rotation_smooth_time_velocity, Rotation_Smooth_Time);

        transform.eulerAngles = current_rotation;

        transform.position = Target.position - transform.forward * Distance_From_Target;
    }
}

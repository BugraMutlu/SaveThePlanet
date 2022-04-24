using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShipController : MonoBehaviour
{
    Rigidbody rb;

    public float Move_Speed;
    public float Speed_Smooth_Time = 0.1f;
    float speed_smooth_velocity;
    float current_speed;
    float turn_smooth_velocity;
    public float Turn_Smooth_Time = 0.1f;

    Transform camera_transform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera_transform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector2 inputDir = new Vector2(hor, ver).normalized;
        Move(inputDir);
        Rotate(inputDir);
    }

    void Move(Vector2 inputDir)
    {
        float target_speed = Move_Speed * inputDir.magnitude;
        current_speed = Mathf.SmoothDamp(current_speed, target_speed, ref speed_smooth_velocity, Speed_Smooth_Time);
        rb.velocity = current_speed * transform.forward;
    }

    void Rotate(Vector2 inputDir)
    {
        float target_rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + camera_transform.eulerAngles.y;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, target_rotation, ref turn_smooth_velocity, Turn_Smooth_Time);

    }
}

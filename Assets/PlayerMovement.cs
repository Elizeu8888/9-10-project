using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public Animator animator;
    public Rigidbody m_Rigidbody;
    public float runSpeed = 40f;
    Vector3 direction;
    bool jump = false, crouch = false;
    float turnSmoothing = 1f;
    public float topSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction.x = joystick.Horizontal;
        direction.y = joystick.Vertical;

    }


    void FixedUpdate()
    {

        if (m_Rigidbody.velocity.magnitude >= topSpeed)
        {
            m_Rigidbody.velocity *= 0.9f;
        }


        if (direction.magnitude >= 0.1f)
        {
            Movement(runSpeed);
        }


    }


    public void Movement(float speed)
    {

        float targetangle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;// finds direction of movement


        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnSmoothing, 0.2f);// makes it so the player faces its movement direction
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;// here is the movement
        m_Rigidbody.AddForce(movedir.normalized * speed, ForceMode.Impulse);

    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController Controller = null;
    private float speed = 5.0f;
    private float gravity = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement() {

        Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 Velocity = Direction * speed;
        Velocity.y -= gravity;

        // change from local to global space
        Velocity = transform.transform.TransformDirection(Velocity);
            // transform - player
            // transform - world
            // method - conversion

        Controller.Move(Velocity * Time.deltaTime);
    }
}

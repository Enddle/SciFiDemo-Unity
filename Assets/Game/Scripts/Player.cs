using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController Controller = null;
    private float speed = 5.0f;
    private float gravity = 9.81f;
    [SerializeField] private GameObject muzzleFlash = null;
    [SerializeField] private GameObject hitMarker = null;
    [SerializeField] private AudioSource weaponSound = null;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButton(0)) {

            muzzleFlash.SetActive(true);

            if (!weaponSound.isPlaying) weaponSound.Play();

            // Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
            // points to the middle of the screen

            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            // if (Physics.Raycast(rayOrigin, Mathf.Infinity)) {
                
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo)) {

                Debug.Log("Hit something:" + hitInfo.collider);

                GameObject hit = Instantiate(hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    // get hit memory address
                
                Destroy(hit, 2.0f);
            }
        } else {
            
            muzzleFlash.SetActive(false);

            weaponSound.Stop();
        }

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

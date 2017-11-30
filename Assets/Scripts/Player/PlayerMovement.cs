using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject[] attackType;
    public GameObject attackSpawn;
    public int attackID = 0;
    CharacterController controller;
    public float speed = 6.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        Mover();
        Attacker();
        if(transform.position.z > 0 || transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    void Mover()
    {
        controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void Attacker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clone = Instantiate(attackType[attackID], attackSpawn.transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(transform.right * 1000);
            Destroy(clone, 2);
        }
    }
}

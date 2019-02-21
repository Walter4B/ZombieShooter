using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public ObjectSpawner boola;
    public ObjectSpawner boolb;
    public ObjectSpawner boolc;
    public ObjectSpawner boold;
    public float MovementSpeed = 3.0f;
    public float Gravity = -9.81f;
    public float Health = 100f;

    private CharacterController _characterController;

    private float _movementH;
    private float _movementV;

    private void Start()
    {
        GameObject a = GameObject.FindGameObjectWithTag("Spawn1");
        boola = a.GetComponent<ObjectSpawner>();
        GameObject b = GameObject.FindGameObjectWithTag("Spawn2");
        boolb = b.GetComponent<ObjectSpawner>();
        GameObject c = GameObject.FindGameObjectWithTag("Spawn3");
        boolc = c.GetComponent<ObjectSpawner>();
        GameObject d = GameObject.FindGameObjectWithTag("Spawn4");
        boold = d.GetComponent<ObjectSpawner>();
    }

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _movementH = Input.GetAxisRaw("Horizontal");
        _movementV = Input.GetAxisRaw("Vertical");

        Vector3 movementX = _movementH * Vector3.right; // * MovementSpeed * Time.deltaTime;
        Vector3 movementZ = _movementV * Vector3.forward; // * MovementSpeed * Time.deltaTime;

        Vector3 movement = movementX + movementZ;
        movement.Normalize();
        movement *= MovementSpeed * Time.deltaTime;
        //Debug.Log("Local:" + movement);
        movement = transform.TransformDirection(movement);
        //Debug.Log("Global:" + movement);
        

        movement.y = Gravity * Time.deltaTime;

        _characterController.Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor1")
        {
            boola.active = false;
            boolb.active = true;
            boolc.active = true;
            boold.active = true;
        }
        
        if (other.tag == "Floor2")
        {
            boola.active = true;
            boolb.active = false;
            boolc.active = true;
            boold.active = true;
        }
        
        if (other.tag == "Floor3")
        {
            boola.active = true;
            boolb.active = true;
            boolc.active = false;
            boold.active = true;
        }
        
        if (other.tag == "Floor4")
        {
            boola.active = true;
            boolb.active = true;
            boolc.active = true;
            boold.active = false;
        }
        
    }
}

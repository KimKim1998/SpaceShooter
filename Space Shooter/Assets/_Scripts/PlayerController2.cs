using System.Collections;
using System.Collections.Generic;
using UnityEngine;





    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;


    private float nextFire;
    private Rigidbody rb;

    void Update()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            Instantiate(shot, transform.position , Quaternion.identity);
            GetComponent<AudioSource>().Play();
        }
    }
        
    
        
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
    

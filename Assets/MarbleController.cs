using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour
{
    public float moveSpeed = 1;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float speedThisframe = moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0,0,1) * moveSpeed,ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -1) * moveSpeed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * moveSpeed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(1, 0, 0) * moveSpeed, ForceMode.Force);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destuctable") {
            transform.localScale *= 1.1f;
            Destroy(collision.gameObject);
        }
        
    }


}

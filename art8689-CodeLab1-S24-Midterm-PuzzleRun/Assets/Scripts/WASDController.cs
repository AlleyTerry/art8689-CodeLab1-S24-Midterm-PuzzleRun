using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WASDController : MonoBehaviour
{
    private Rigidbody rb;

    public float forceAmt = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceAmt);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * forceAmt);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * forceAmt);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceAmt);
        }
    }
    

}

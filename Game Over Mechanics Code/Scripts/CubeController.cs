using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody cubeRb;
    public bool isOnGround = false;

    // Start is called before the first frame update
    void Start()
    {
        cubeRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // This is the count functionality. Destroys block when they get past the barrier. 
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Destroy(this.gameObject);
            PlayerController.blockFallCount += 1;
            Debug.Log("Block Hit Ground " + PlayerController.blockFallCount);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int blockFallCount;
    public GameObject cubePrefab;
    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //Replace Space Press with the grab block functionality. This section exists for testing.  
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            Instantiate(cubePrefab, transform.position, cubePrefab.transform.rotation);
        }
    }
}

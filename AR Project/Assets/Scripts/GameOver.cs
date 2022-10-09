using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject TowerOfBlocks;
    public float groundLevel;

    public GameObject[] fallingBlock;

    private Renderer renderer;

    public Text youLoseText;
    
    // Start is called before the first frame update
    void Start()
    {
        youLoseText.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject TowerOfBlocks = GameObject.FindGameObjectWithTag("Tower");
        findBottomOfTower();
        setBlockY();
    }

    public void findBottomOfTower()
    {
        renderer = TowerOfBlocks.GetComponent<Renderer>();
        groundLevel = renderer.bounds.min.y;
    }

    public void setBlockY()
    {
        GameObject[] fallingBlock = GameObject.FindGameObjectsWithTag("Blocks");
        foreach (GameObject block in fallingBlock)
        {
            if (block.transform.position.y < groundLevel)
            {
                youLoseText.GetComponent<Text>().enabled = true;
                //Debug.Log("Block fell past limit; the game is over.");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levelBlock;
    
    void Start()
    {
     InitializeLevel();   
    }

    void Update()
    {
        
    }

    void InitializeLevel() {
        foreach (GameObject block in GameObject.FindGameObjectsWithTag("LevelBlock"))
        {
            levelBlock.Add(block);
        }

        int blockCount = 0;

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                GameObject block = levelBlock[blockCount++];
                block.transform.position = new Vector3(i-7.5f, 0, j-7.5f);
            }
        }
    }
}

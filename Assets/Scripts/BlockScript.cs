using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public List<GameObject> blockList;
    public GameObject activeBlock;
    public GameObject inactiveBlock;
    public GameObject previousActiveBlock;
    public GameObject previousInactiveBlock;


    void Update()
    {
        blockList.Clear();
        activeBlock = LevelManager.block;

        if (LevelManager.isActive)
        {
            foreach (Transform child in activeBlock.transform)
            {
                blockList.Add(child.gameObject);
            }
            InitializeActiveBlock();
        }
    }

    void InitializeActiveBlock()
    {
        if (previousActiveBlock != null && previousInactiveBlock !=null)
        {
            previousActiveBlock.SetActive(false);
            previousInactiveBlock.SetActive(true);
        }

        GameObject newActiveBlock = blockList[1];
        newActiveBlock.SetActive(true);
        GameObject newInactiveBlock = blockList[0];
        newInactiveBlock.SetActive(false);

        previousActiveBlock = newActiveBlock;
        previousInactiveBlock = newInactiveBlock;
    }
}

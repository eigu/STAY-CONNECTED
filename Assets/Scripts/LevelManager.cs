using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static public GameObject player;
    public List<GameObject> levelBlock;
    public GameObject blockPrefab;
    private GameObject levelSpawn;
    
    [Range(16, 32)]
    public int sideLength;

    static public GameObject block;
    static public bool isActive;
    private float activeTime = 5f;
    
    public GameObject gameOverScreen;
    
    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player");

        InitializeLevel();   
    }

    void Update()
    {
        activeTime -= Time.deltaTime;

        if (activeTime <= 0)
        {
            if (!isActive)
            {
                RandomizeActiveBlock();
            }
            else
            {
                Destroy(player);
            }
        }
        
        if (GameScript.pointGiven)
        {
            RandomizeActiveBlock();
            GameScript.pointGiven = false;
        }

        if (!player)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            AudioManager.instance.PlaySFX("Game Over");
        }
    }

    void InitializeLevel()
    {
        levelSpawn = GameObject.FindGameObjectWithTag("LevelSpawn");

        int blockCount = 0;

        for (int i = 0; i < sideLength; i++)
        {
            for (int j = 0; j < sideLength; j++)
            {
                GameObject block = Instantiate(blockPrefab, levelSpawn.transform);
                levelBlock.Add(block);
                block = levelBlock[blockCount++];
                block.transform.position = new Vector3(i-(sideLength/2-.5f), 0-1f, j-(sideLength/2-.5f));
            }
        }

        isActive = false;
    }

    void RandomizeActiveBlock()
    {
        activeTime = 5f;
        isActive = true;
        block = levelBlock[Random.Range(0, levelBlock.Count)];
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GAME START");
    } 
}

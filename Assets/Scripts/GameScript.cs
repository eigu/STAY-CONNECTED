using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    static public int playerScore;
    static public bool pointGiven;
    [SerializeField] private TextMeshProUGUI scoreCounter;

    void Start()
    {
        playerScore = 0;
    }

    void Update()
    {
        scoreCounter.SetText("Score: " + playerScore);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ActiveBlock"))
        {
            AudioManager.instance.PlaySFX("Score");
            playerScore++;
            pointGiven = true;
        }

        if (other.gameObject.CompareTag("FallDetector"))
        {
            Destroy(LevelManager.player);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;
    private CameraScript cameraScript;
    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

     void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }
    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }
            previousPosition = transform.position;
            GameplayController.instance.SetScore(scoreCount);

        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            GameplayController.instance.SetScore(scoreCount);   
            GameplayController.instance.SetCoinScore(coinCount); 
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            collision.gameObject.SetActive(false);
        }
        if(collision.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;
            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeCount);
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            collision.gameObject.SetActive(false);
        }
        if(collision.tag == "Bounds" || collision.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);

        }
    }
}

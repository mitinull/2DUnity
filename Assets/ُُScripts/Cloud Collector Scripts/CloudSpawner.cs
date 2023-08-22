using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject[] collectables;

    private float distenceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;
    
    private GameObject player;

     void Awake()
    {
        controlX = 0f;
        SetMinAndMAxX();
        CreateClouds();
        player = GameObject.Find("Player");

        for(int i = 0;i<collectables.Length;i++)
        {
            collectables[i].SetActive(false);
        }
    }
     void Start()
    {
        PositionThePlayer();
    }
    void SetMinAndMAxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5F;
    }
    void Shuffle(GameObject[] arrayToShuffle)
    {
        for(int i= 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random  = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }
    void CreateClouds()
    {
        Shuffle(clouds);
        float positionY = 0f;
        for(int i=0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;
            if (controlX == 0)
            {
                temp.x = Random.Range(0, maxX);
                controlX = 1;

            }else if(controlX == 1)
            {
                temp.x = Random.Range(0, minX);
                controlX = 2;
            }else if(controlX == 2)
            {
                temp.x = Random.Range(1, maxX);
                controlX = 3;
            }
            else if(controlX == 3)
            {
                temp.x = Random.Range(-1, minX);
                controlX = 0;
            }
            
            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distenceBetweenClouds;

        }
    }
     void PositionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
        for(int i=0;i < darkClouds.Length; i++)
        {
            if (darkClouds[i].transform.position.y ==0 )
            {
                var temp = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(clouds[0].transform.position.x,
                    clouds[0].transform.position.y,
                    clouds[0].transform.position.z);
                clouds[0].transform.position = temp;
            }
        }
        Vector3 tempo = clouds[0].transform.position;
        for(int i = 1; i < clouds.Length; i++)
        {
            if(tempo.y < clouds[i].transform.position.y)
            {
                tempo = clouds[i].transform.position;
            }
        }
        tempo.y += 0.8f;
        player.transform.position = tempo;
    }
     void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Cloud" ||  target.tag == "Deadly")
        {
            if(target.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                //Shuffle(collectables);
                Vector3 temp = target.transform.position;

                for(int i = 1;i<clouds.Length;i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0, maxX);
                            controlX = 1;

                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0, minX);
                            controlX = 2;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1, maxX);
                            controlX = 3;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1, minX);
                            controlX = 0;
                        }
                        temp.y -= distenceBetweenClouds;
                         lastCloudPositionY = temp.y;
                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0,collectables.Length);
                        if (clouds[i].tag != "Deadly")
                        {
                            if (!collectables[random].activeInHierarchy)
                            {
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;
                                if (collectables[random].tag == "Life")
                                {
                                    if(PlayerScore.lifeCount < 2)
                                    {
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true);   
                                    }
                                }
                                else
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }
                            }
                        }
                    }
                }


            }
        }
    }
}

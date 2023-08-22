using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBound : MonoBehaviour
{
    private float minX, maxX;
    void Start()
    {
        SetMinAndMAxX();
    }
    void Update()
    {
        if (transform.position.x < minX)
        {
            var temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        if (transform.position.x > maxX)
        {
            var tempo = transform.position;
            tempo.x = maxX;
            transform.position = tempo;
        }
    }
    void SetMinAndMAxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
    // Update is called once per frame

}

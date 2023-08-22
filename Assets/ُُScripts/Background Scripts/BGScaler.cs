using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;
        float width = sr.sprite.bounds.size.x;
        float worldHieght = Camera.main.orthographicSize * 2f;
        float worldwidth =  worldHieght / Screen.height * Screen.width;
        tempScale.x = worldwidth / width;
        transform.localScale = tempScale;
    }

}

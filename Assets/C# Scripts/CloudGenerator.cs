using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour {

    const float fVELOCITY = 5.0f;

    public GameObject cloud;

    float fWaitTime;
    bool bWait;

    // Use this for initialization
    void Start()
    {
        fWaitTime = Time.time;
        bWait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (! bWait && fWaitTime < Time.time && GameController.iCantClouds < 20)
        {
            bWait = true;

            Vector2 vec2V = transform.position;
            vec2V.y = vec2V.y + 2.5f - ((float) (GameController.GetRandom(50))) / 10.0f;
            Instantiate(cloud, vec2V, Quaternion.identity);

            fWaitTime = Time.time + GameController.GetRandom(5);
            GameController.iCantClouds ++;
            bWait = false;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    const float fDIF = 0.1f;

    Rigidbody2D rgb2Cloud;

    int iDir = -1;
    float fX;
    float fLifetime;

    // Use this for initialization
    void Start () {
        fLifetime = Time.time + 8.0f;

        fX = transform.position.x;
        if (fX < 0)
        {
            iDir = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameController.bPause)
        {
            return;
        }

        fX += iDir * fDIF;
        Vector3 vec3V = transform.position;
        vec3V.x = fX;
        transform.position = vec3V;

        if (fLifetime <= Time.time || GameController.bEnd)
        {
            GameController.iCantClouds --;
            GameObject.Destroy(gameObject);
        }
    }
}

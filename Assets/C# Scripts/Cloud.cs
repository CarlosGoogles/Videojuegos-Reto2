using System.Collections;
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
        fLifetime = Time.time + 10.0f;

        fX = transform.position.x;
        if (fX < 0)
        {
            iDir = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        fX += iDir * fDIF;
        Vector3 vec3V = transform.position;
        vec3V.x = fX;
        transform.position = vec3V;

        Debug.Log(fLifetime + " " + Time.time);
        if (fLifetime <= Time.time || GameController.bEnd)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

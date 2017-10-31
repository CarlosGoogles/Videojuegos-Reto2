using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    float fLifetime;

    Rigidbody2D rgb2Cloud;
    // Use this for initialization
    void Start () {
        fLifetime = Time.time + 10.0f;

        int iDir = -1;
        if (transform.position.x < 0)
        {
            iDir = 1;
        }
        rgb2Cloud.velocity = new Vector2(iDir * 5.0f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(fLifetime + " " + Time.time);
        if (fLifetime <= Time.time)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

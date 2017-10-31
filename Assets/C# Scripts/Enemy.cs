using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public AudioClip audScore;
    public AudioClip audHit;

    float fLifetime;

    // Use this for initialization
    void Start () {
        fLifetime = Time.time + 10.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, Player.rgb2Player.position) < 1.5f)
        {
            if (Player.bAttacking)
            {
                AudioSource.PlayClipAtPoint(audScore, this.transform.position);
                GameController.iScore += 100;
            }
            else
            {
                AudioSource.PlayClipAtPoint(audHit, this.transform.position);
                GameController.iHealth -= 10;
                // AudioSource.PlayClipAtPoint(ouchSound, this.transform.position);
            }
            GameObject.Destroy(gameObject);
        }

        if (fLifetime <= Time.time || GameController.bEnd)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

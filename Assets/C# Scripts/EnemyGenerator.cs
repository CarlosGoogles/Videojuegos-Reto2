using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    const float fVELOCITY = 8.0f;

    public Rigidbody2D rgb2Enemy;
    public int iDir = -1;
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
        if (GameController.bEnd)
        {
            return;
        }

        if (!bWait && fWaitTime < Time.time && GameController.iCantEnemies < 25)
        {
            bWait = true;

            Vector2 vec2V = transform.position;
            vec2V.y = vec2V.y + 2.5f - ((float)(GameController.GetRandom(50))) / 10.0f;
            Rigidbody2D rgb2InstantiatedProjectile = Instantiate(rgb2Enemy,
                                                           vec2V,
                                                           transform.rotation)
                as Rigidbody2D;

            vec2V = new Vector2(fVELOCITY, 0.0f);
            rgb2InstantiatedProjectile.velocity = vec2V;

            fWaitTime = Time.time + GameController.GetRandom(2);
            GameController.iCantClouds++;
            bWait = false;
        }
    }
}

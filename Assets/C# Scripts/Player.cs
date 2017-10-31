using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {
    const float fVELOCITY = 4.0f;
    const float fWAITATTACK = 0.85f;

    public static bool bAttacking = false;
    public static Rigidbody2D rgb2Player;

    public GameObject gamoLeft,gamoRight;
    public AudioClip audWhip;

    int iDirection = -1; // 1 Left, -1 Right
    bool bRunning = false;
    float fIniTime = 0.0f;
    
    Animator aniA;

    // Use this for initialization
    void Start () {
        rgb2Player = GetComponent<Rigidbody2D>();
        aniA = GetComponent<Animator>();
    }

    // Para utilizar el componente Rigidbody y hacer sus actualizaciones en un GameObject
    void FixedUpdate() {
        if (GameController.bEnd)
        {
            return;
        }
        float fVelX = rgb2Player.velocity.x;
        float fVelY = rgb2Player.velocity.y;

        if (Time.time < fIniTime)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(audWhip, this.transform.position);
            // fVelX = 0.0f;
            bAttacking = true;
            fIniTime = Time.time + fWAITATTACK;
        }
        else {
            bAttacking = false;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                fVelX = - fVELOCITY;
                iDirection = 1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                fVelX = fVELOCITY;
                iDirection = -1;
            }
            else
            {
                fVelX = 0.0f;
            }

            if (rgb2Player.velocity.y == 0 && Input.GetKey(KeyCode.UpArrow))
            {
                fVelY = 7.5f;
            }
        }

        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
        {
            bRunning = true;
            fVelX *= 2.0f;
        }
        else
        {
            bRunning = false;
        }

        if (iDirection == -1 && Math.Abs(transform.position.x - gamoRight.transform.position.x) < 1.5f ||
            iDirection == 1 && Math.Abs(transform.position.x - gamoLeft.transform.position.x) < 1.5f)
        {
            fVelX = 0;
        }
        Vector2 vec2V = new Vector2(fVelX, fVelY);
        rgb2Player.velocity = vec2V;

        Vector3 vec3Scale = new Vector3(iDirection * 4.0f, 4.0f, 1.0f);
        transform.localScale = vec3Scale;

        UpdateAnimation(fVelX);
    }

    void UpdateAnimation(float fVelX)
    {
        if (bAttacking)
        {
            aniA.SetInteger("State", 3);
        }
        else if (fVelX == 0)
        {
            aniA.SetInteger("State", 0);
        }
        else if (! bRunning)
        {
            aniA.SetInteger("State", 1);
        }
        else
        {
            aniA.SetInteger("State", 2);
        }
    }
}
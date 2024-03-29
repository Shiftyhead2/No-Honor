﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 targetPos;
    Vector2 PlayerInput;
    Rigidbody2D RB;
    private enum Facing { UP, DOWN, RIGHT, LEFT, NONE }
    private Facing FacingDir = Facing.NONE;
    public GameObject SmokeParticles;
    private AudioSource MyAudio;
    public AudioClip DashSFX;
    


    [Header("Float & Int Values")]
    [Tooltip("Float & Int values like speed and dash range")]
    public float Speed;
    public float DashRange;
    [SerializeField]
    private float DashCoolDown = 1f;
    [Space]


    #region Sprites
    private SpriteRenderer MySpriteRenderer;
    [Header("Sprites")]
    [Tooltip("Directional Sprites")]
    public Sprite[] DirectionalSprites;
    #endregion




    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        MySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        MyAudio = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        RB.velocity = PlayerInput.normalized * Speed;
        CheckDir();
        Dash();
        ChangeSpriteDirection();
      

    }

    private void Update()
    {
        DashCoolDown -= Time.deltaTime;
    }

    void CheckDir()
    {
        if (PlayerInput.x == 0 && PlayerInput.y == 1)
        {
            FacingDir = Facing.UP;
        }
        else if (PlayerInput.x == 0 && PlayerInput.y == -1)
        {
            FacingDir = Facing.DOWN;
        }
        else if (PlayerInput.x == 1 && PlayerInput.y == 0)
        {
            FacingDir = Facing.RIGHT;
        }
        else if (PlayerInput.x == -1 && PlayerInput.y == 0)
        {
            FacingDir = Facing.LEFT;
        }

    }

    void Dash()
    {
        if (Input.GetKey(KeyCode.Space) && DashCoolDown <= 0f)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = Vector2.zero;
            if (FacingDir == Facing.UP)
            {
                targetPos.y = 1;
            }
            else if (FacingDir == Facing.DOWN)
            {
                targetPos.y = -1;
            }
            else if (FacingDir == Facing.RIGHT)
            {
                targetPos.x = 1;
            }
            else if (FacingDir == Facing.LEFT)
            {
                targetPos.x = -1;
            }
            MyAudio.clip = DashSFX;
            MyAudio.Play();
            Instantiate(SmokeParticles, transform.position, Quaternion.identity);
            transform.Translate(targetPos * DashRange);
            DashCoolDown = 1f;
        }
    }

    void ChangeSpriteDirection()
    {
        if (FacingDir == Facing.UP)
        {
            MySpriteRenderer.sprite = DirectionalSprites[0];
            
        }
        else if (FacingDir == Facing.DOWN)
        {
            MySpriteRenderer.sprite = DirectionalSprites[1];
            
        }
        else if (FacingDir == Facing.LEFT)
        {
            MySpriteRenderer.sprite = DirectionalSprites[2];
            
        }
        else if (FacingDir == Facing.RIGHT)
        {
            MySpriteRenderer.sprite = DirectionalSprites[3];
           
        }
    }

   
}

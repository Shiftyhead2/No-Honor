using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed;
    public float StoppingDistance;
    public float RetreatDistance;
    private Rigidbody2D rb;
    private Vector2 Movement;
    private float TimeBtwShots;
    public float StartTimeBtwShots;
    public GameObject ShadowStar;
    public Transform ShootPoint;
    private AudioSource MyAudio;
    public AudioClip Shoot;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        if(Player == null)
        {
            return;
        }
        rb = GetComponent<Rigidbody2D>();
        MyAudio = GetComponent<AudioSource>();
        TimeBtwShots = StartTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverManager.GameOver == false)
        {
            Vector3 direction = Player.position - transform.position;
            Movement = direction.normalized;
            if ((transform.position - Player.position).sqrMagnitude > StoppingDistance * StoppingDistance)
            {
                moveSpeed = 1f;
            }
            else if ((transform.position - Player.position).sqrMagnitude < StoppingDistance * StoppingDistance && (transform.position - Player.position).sqrMagnitude > RetreatDistance * RetreatDistance)
            {
                moveSpeed = 0f;
               
            }
            else if ((transform.position - Player.position).sqrMagnitude < RetreatDistance * RetreatDistance)
            {
                moveSpeed = -1f;
               
            }

            if (TimeBtwShots <= 0f)
            {
                MyAudio.clip = Shoot;
                MyAudio.Play();
                Instantiate(ShadowStar, transform.position, Quaternion.identity);
                TimeBtwShots = StartTimeBtwShots;
            }
            else
            {
                TimeBtwShots -= Time.deltaTime;
            }

        }
        else
        {
            moveSpeed = 0f;
        }

        

    }


    private void FixedUpdate()
    {
        if(GameOverManager.GameOver == false)
        {
            MoveCharacter(Movement);
        }
    }

    void MoveCharacter(Vector2 Direction)
    {
        if(GameOverManager.GameOver == false)
        {
            rb.MovePosition((Vector2)transform.position + (Direction * moveSpeed * Time.deltaTime));
        }
        
    }
}

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
   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        TimeBtwShots = StartTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Vector3 direction = Player.position - transform.position;
            Movement = direction.normalized;
            if (Vector2.Distance(transform.position, Player.position) > StoppingDistance)
            {
                moveSpeed = 1f;
            }
            else if (Vector2.Distance(transform.position, Player.position) < StoppingDistance && Vector2.Distance(transform.position, Player.position) > RetreatDistance)
            {
                moveSpeed = 0f;
               
            }
            else if (Vector2.Distance(transform.position, Player.position) < RetreatDistance)
            {
                moveSpeed = -1f;
               
            }

            if (TimeBtwShots <= 0f)
            {
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
        MoveCharacter(Movement);
    }

    void MoveCharacter(Vector2 Direction)
    {
        rb.MovePosition((Vector2)transform.position + (Direction * moveSpeed * Time.deltaTime));
    }
}

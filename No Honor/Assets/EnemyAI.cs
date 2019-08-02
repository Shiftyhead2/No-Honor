using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 Movement;
   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        Movement = direction.normalized;  
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projective : MonoBehaviour
{
    public float Speed;
    private Transform Player;
    private Vector2 target;
    public float Damage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Player.position.x, Player.position.y);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverManager.GameOver)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            //Debug.Log("transforms position are equal to the targets position");
            DestroyProjective();
        }
        
    }

    void DestroyProjective()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            //Debug.Log("Damaged Player");
            collision.gameObject.GetComponent<HealthPoints>().Damage(Damage);
            DestroyProjective();
        }
        else
        {
            //Do nothing
        }
    }
}

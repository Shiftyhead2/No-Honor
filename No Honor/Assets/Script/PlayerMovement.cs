using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 targetPos;
    [SerializeField]Vector2 PlayerInput;
    Rigidbody2D RB;
    private enum Facing {UP,DOWN,RIGHT,LEFT,NONE}
   [SerializeField] private Facing FacingDir = Facing.NONE;

    public float Speed;
    public float DashRange;


   

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        RB.velocity = PlayerInput.normalized * Speed;
        CheckDir();
        Dash();

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
        else if (PlayerInput.x == 1 && PlayerInput.y == 0) {
            FacingDir = Facing.RIGHT;
        }
        else if (PlayerInput.x == -1 && PlayerInput.y == 0)
        {
            FacingDir = Facing.LEFT;
        }
       
    }

    void Dash() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = Vector2.zero;
            if (FacingDir == Facing.UP)
            {
                targetPos.y = 1;
            }
            else if (FacingDir == Facing.DOWN) {
                targetPos.y = -1;
            }
            else if (FacingDir == Facing.RIGHT)
            {
                targetPos.x = 1;
            }else if(FacingDir == Facing.LEFT)
            {
                targetPos.x = -1;
            }
            transform.Translate(targetPos * DashRange);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField]private float force = 1;
    [SerializeField]private Rigidbody2D playerRB;

    void Start()
    {

        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W)))
        {
            Vector2 velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y+force);
            playerRB.velocity=(velocity);
        }
        else if((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.S)))
        {
            Vector2 velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y-force);
            playerRB.velocity = (velocity);
        }
        else
        {
            playerRB.velocity = Vector2.zero;   
        }
    }
}

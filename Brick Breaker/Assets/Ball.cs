using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 4f;

    Vector2 direction;
    bool start = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float angleInRadians = (240) * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bounce vertical if wall horizontal if paddle
        if(collision.gameObject.CompareTag("Roof"))
        {
            direction.y = -direction.y;
        }else if(collision.gameObject.CompareTag("Player"))
        {
            Collider2D collider = collision.gameObject.GetComponent<Collider2D>();
            float position_x = collision.gameObject.transform.position.x;
            float width = collider.bounds.size.x;

            float ball_on_paddle =gameObject.transform.position.x-position_x;
            //set the max angles the player can send the ball out at
            float minAngle = 30f;
            float maxAngle = 150f; 

            //finds the angle between max and min based on ball_on_paddle (which is between -1 and 1)
            float mappedAngle = Mathf.Lerp(maxAngle, minAngle, (ball_on_paddle + 1f) / 2f);

            //convert the mapped angle to radians then send it in new direction
            float angleInRadians = (mappedAngle) * Mathf.Deg2Rad;
            direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

        }else if(collision.gameObject.CompareTag("Brick"))
        {
            // get collider to find the lower bound of the brick
            Collider2D collider = collision.gameObject.GetComponent<Collider2D>();

            float position_y = collision.gameObject.transform.position.y;

            //get the colliders height and take half away from the center to find the bottom of the brick.
            float height = collider.bounds.size.y;
            float lower = position_y - (height/2);

            if(gameObject.transform.position.y < lower )
            {
                direction.y = -direction.y;
            }else{
                direction.x = -direction.x;
            }
            
        }
    }
}

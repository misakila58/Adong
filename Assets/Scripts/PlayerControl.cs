using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 inputVector;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    //transform.Translate(Vector2.left * PlayerStats.Spd * Time.deltaTime);
                    inputVector = new Vector2(-1 * PlayerStats.Spd, rb.velocity.y);
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    //transform.Translate(Vector2.right * PlayerStats.Spd * Time.deltaTime);
                    inputVector = new Vector2(1 * PlayerStats.Spd, rb.velocity.y);
                }
            }
        }
        else
        {
            inputVector = new Vector2(0, rb.velocity.y);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(new Vector2(-1 * PlayerStats.Spd * Time.deltaTime, 0));
            //transform.Translate(Vector2.left * PlayerStats.Spd * Time.deltaTime);
            inputVector = new Vector2(-1 * PlayerStats.Spd, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(new Vector2(1 * PlayerStats.Spd * Time.deltaTime, 0));
            //transform.Translate(Vector2.right * PlayerStats.Spd * Time.deltaTime);
            inputVector = new Vector2(1 * PlayerStats.Spd, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            inputVector = new Vector2(0, rb.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            inputVector = new Vector2(0, rb.velocity.y);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = inputVector;
    }
}

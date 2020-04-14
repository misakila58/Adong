using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    //rb.AddForce(new Vector2(-1 * PlayerStats.Spd * Time.deltaTime, 0));
                    transform.Translate(Vector2.left * PlayerStats.Spd * Time.deltaTime);
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    //rb.AddForce(new Vector2(1 * PlayerStats.Spd * Time.deltaTime, 0));
                    transform.Translate(Vector2.right * PlayerStats.Spd * Time.deltaTime);
                }
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(new Vector2(-1 * PlayerStats.Spd * Time.deltaTime, 0));
            transform.Translate(Vector2.left * PlayerStats.Spd * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(new Vector2(1 * PlayerStats.Spd * Time.deltaTime, 0));
            transform.Translate(Vector2.right * PlayerStats.Spd * Time.deltaTime);
        }
    }
}

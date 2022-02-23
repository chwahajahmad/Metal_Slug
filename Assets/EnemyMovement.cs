using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float leftCap;
    [SerializeField] float rightCap;
    [SerializeField] float movementSpeed;
    [SerializeField] int healthDamage;
    float min;
    float max;
    float direction = -1;
    Rigidbody2D rb;
    Transform player;
    bool startMoving;
    bool collidedOnce;


    void Start()
    {
        startMoving = false;
        rb = GetComponent<Rigidbody2D>();
        min = leftCap;
        max = rightCap;
        min *= -1;
        min += transform.position.x;
        max -=  transform.position.x;
        player = GameObject.Find("Player").GetComponent<Transform>();
        collidedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        if(Mathf.Abs(player.position.x-this.transform.position.x)<5 && Mathf.Abs(player.position.x-this.transform.position.x)>1 && gameObject.GetComponent<EnemyScore>().enemyHealth>0)
        {
         
            startMoving = true;
            collidedOnce = false;
        }
        else
        {
            startMoving = false;
        }
        
        if(Mathf.Abs(transform.position.x-player.position.x)<0.2 && player.position.y < 2 && !collidedOnce)
        {
            startMoving = false;
            collidedOnce = true;
            GameObject.Find("PlayerRecords").GetComponent<Records>().Health-=healthDamage;
        }
        if(startMoving)
        {
            if(player.position.x < this.transform.position.x)
                direction = -1;
            else
                direction = 1;

            
            if(direction == -1)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
                if(transform.position.x>player.position.x)
                {
                    rb.velocity = new Vector2(-movementSpeed,rb.velocity.y);
                }
                else{
                    direction = 1;
                }
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0,180,0);
                if(transform.position.x<player.position.x)
                {
                    rb.velocity = new Vector2(movementSpeed,rb.velocity.y);
                }
                else{
                    direction = -1;
                }
            }

           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    
    [SerializeField] int enemyHealthDec;
    
    [SerializeField] int bossHealthDec;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyScore>().enemyHealth-=enemyHealthDec;
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<BossScore>().bossHealth-=bossHealthDec;
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("Survivor"))
        {
            other.gameObject.GetComponent<SurvivorFree>().freeSurvivorFunc();
        }
    }
}

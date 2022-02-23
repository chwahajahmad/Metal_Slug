using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    // Start is called before the first frame update

    public int enemyHealth;

    private Animator anim;

    private float animLength = 0.5f;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(enemyHealth <= 0)
        {
            anim.SetTrigger("startDeath");
            // Destroy(this.gameObject);
            StartCoroutine("OnCompleteAttackAnimation");
        }
           
    }
    IEnumerator OnCompleteAttackAnimation()
    {
        yield return new WaitForSeconds(animLength );

         Destroy(this.gameObject);
    }
}


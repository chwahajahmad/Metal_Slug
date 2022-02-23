using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScore : MonoBehaviour
{
    public int bossHealth;
    
    private Animator anim;

    private float animLength = 0.8f;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(bossHealth <= 0)
        {
            anim.SetTrigger("BossDeath");
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

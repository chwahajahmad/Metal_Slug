using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorFree : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    private bool doneOnce;

    [SerializeField] int HealthBonus;
    void Start()
    {
        anim = GetComponent<Animator>();
        doneOnce = false;
    }
    
   
    public void freeSurvivorFunc()
    {
        if(!doneOnce)
        {
            doneOnce = true;
            anim.SetBool("FreeAnim", true);
            Destroy(this.gameObject, 2f);
            GameObject.Find("PlayerRecords").GetComponent<Records>().Health+=HealthBonus;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   [SerializeField] Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=new Vector3(-1,0,-10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void FixedUpdate()
    {
        transform.position=new Vector3(Player.position.x,0,-10);
    }
}

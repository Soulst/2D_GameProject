using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaser : MonoBehaviour

{
    public Rigidbody2D laser;
    public float moveSpeed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        laser = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        laser.velocity = new Vector2(1, 0) * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name == "enemyship")
        //{
         //   collision.gameObject.SetActive(false);
        //}
        if(collision.gameObject.name == "BarrierR" || collision.gameObject.name == "enemyship")
            {
                Object.Destroy(this.gameObject);
               
            }
    }

 }

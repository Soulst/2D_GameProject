using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public Rigidbody2D laser;
    public float moveSpeed = 4.5f;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        laser = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        laser.velocity = new Vector2(-1, 0) * moveSpeed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "BarrierL" || collision.gameObject.name == "PlayerShip")
        {
            Object.Destroy(this.gameObject);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDino : MonoBehaviour
{
    public Rigidbody2D Dino;
    public float moveSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        Dino = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveEnemyShip();
    }
    public void moveEnemyShip()
    {
        Dino.velocity = new UnityEngine.Vector2(-1, 0) * moveSpeed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Cube")
        { 
            SceneManager.LoadScene(0);
        }

    }

}

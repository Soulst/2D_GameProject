using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Scripts for the player spaceship, it's movement, 
public class Player : MonoBehaviour
{
    public float shipSpeed = 10.0f;
    public Rigidbody2D player;
    public int livesLeft;
    public Text display;
    // Start is called before the first frame update
    void Start()
    {
        //failed attempt to pause game. if (Input.GetKeyDown("p");

        livesLeft = 3;
        player = this.GetComponent<Rigidbody2D>();
        display = GameObject.Find("LivesText").GetComponent<Text>();
        display.text = "Lives: " + livesLeft;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * shipSpeed;
    }
    public void Pause()
    {
 
    }
    //Checking collisions for the player spaceship, may load different scenes depending on what happens here!
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyLaser")
        {
            
            if (livesLeft <= 0)
            {
                
                Object.Destroy(this.gameObject);
                SceneManager.LoadScene(4);
            }
            livesLeft--;
            display.text = "Lives: " + livesLeft;
        }
        if(collision.gameObject.tag == "Planet")
        {
            SceneManager.LoadScene(0);
        }

    }
}

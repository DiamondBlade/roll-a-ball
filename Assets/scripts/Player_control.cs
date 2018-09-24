using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_control : MonoBehaviour{

    public float speed;
    public Text counttext;
    public Text wintext;
    public Text scoretext;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setcounttext();
        score = 0;
        setscoretext();
        wintext.text = "";
        
    }

    void Update ()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.CompareTag("pickup"))
     {
          other.gameObject.SetActive(false);
          count = count + 1;
          score = score + 1; // I added this to start tracking score and count separate.
          setcounttext();
          setscoretext();
     }
     else if (other.gameObject.CompareTag("enemy"))
     {
          other.gameObject.SetActive(false);
          // count = count + 1; // I commented this out because I am not going to use it for the enemy.
          score = score - 1; // this removes 1 from the score
          setscoretext();
     }
} 
    void setcounttext ()
    {
        counttext.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            wintext.text = "You Finished with a score of: " + score.ToString();
        }
    }
    void setscoretext ()
    {
        scoretext.text = "Score: " + score.ToString();
    }
}
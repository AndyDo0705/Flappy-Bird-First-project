using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrenght;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        checkBirdOutOfScreen();
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrenght;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    private void checkBirdOutOfScreen()
    {
        if (!IsInView())
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private bool IsInView()
    {
        Vector3 birdPosition = Camera.main.WorldToViewportPoint(transform.position);
        return birdPosition.x > 0 && birdPosition.x < 1 && birdPosition.y > 0 && birdPosition.y < 1;
    }
}

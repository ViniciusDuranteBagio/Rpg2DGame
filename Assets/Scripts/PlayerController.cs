using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    public Player player;
    public Animator playeraAnimator;
    float input_x = 0;
    float input_y = 0;
    
    bool isWalking = false;

    Rigidbody2D rb2D;

    Vector2 movement = Vector2.zero;


   
    void Start()
    {
        isWalking = false;
        rb2D = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        isWalking = (input_x != 0 | input_y != 0);
        movement = new Vector2(input_x, input_y);

        if (isWalking)
        {
            playeraAnimator.SetFloat("input_x", input_x);
            playeraAnimator.SetFloat("input_y", input_y);
        }

        playeraAnimator.SetBool("isWalking", isWalking);

        if (Input.GetButtonDown("Fire1"))
        {
            playeraAnimator.SetTrigger("Attack");
        }
    }
    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movement * player.entity.speed * Time.fixedDeltaTime);
    }
}

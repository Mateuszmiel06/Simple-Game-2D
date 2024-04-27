using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float herospeed;
    public float jumpForce;
    public Transform groundTester;
    public LayerMask layersToTest;
    Animator anim;
    Rigidbody2D rgdBody;
    bool dirToRight = true;
    public Transform startPoint;
   

    private bool onTheGround;
    private float radius = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
         if (anim.GetCurrentAnimatorStateInfo(0).IsName("cactus"))
        {
            rgdBody.velocity = Vector2.zero;
            return;
        }

        
        onTheGround = Physics2D.OverlapCircle(groundTester.position, radius , layersToTest);

        float horizontalMove = Input.GetAxis("Horizontal");
        rgdBody.velocity = new Vector2(horizontalMove * herospeed, rgdBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            rgdBody.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("jump");
        }

        anim.SetFloat("speed", Mathf.Abs(horizontalMove));

        if(horizontalMove < 0 && dirToRight)
        {
            Filp();
        }
        if (horizontalMove > 0 && !dirToRight)
        {
            Filp();
        }

    }

    void Filp ()
    {
        dirToRight = !dirToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }
    public void RestarHero()
    {
        gameObject.transform.position = startPoint.position;
    }
}

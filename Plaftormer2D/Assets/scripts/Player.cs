using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float playerScale = 5.0f;

    private float               inputX;
    private Animator            animator;
    private Rigidbody2D         body2d;
    private bool                combatIdle = false;
    private bool                isGrounded = true;

    void Start () {
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
	}

	void Update () {

        inputX = Input.GetAxis("Horizontal");

        if (inputX > 0)
            transform.localScale = new Vector3(-playerScale, playerScale, playerScale);
        else if (inputX < 0)
            transform.localScale = new Vector3(playerScale, playerScale, playerScale);

        body2d.velocity = new Vector2(inputX * speed, body2d.velocity.y);

        isGrounded = IsGrounded();
        animator.SetBool("Grounded", isGrounded);

        if (Input.GetKeyDown("k")){
            animator.SetTrigger("Death");
        }
        else if (Input.GetKeyDown("h")) {
            animator.SetTrigger("Hurt");
        }
       
        else if (Input.GetKeyDown("r"))
            animator.SetTrigger("Recover");
       
        else if (Input.GetKeyDown("i"))
            combatIdle = !combatIdle;

        else if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }

        else if (Input.GetKeyDown("space") && isGrounded)
        {
            animator.SetTrigger("Jump");
            body2d.velocity = new Vector2(body2d.velocity.x, jumpForce);
        }

        //Walk
        else if (Mathf.Abs(inputX) > Mathf.Epsilon && isGrounded)
            animator.SetInteger("AnimState", 2);
        //Combat idle
        else if (combatIdle)
            animator.SetInteger("AnimState", 1);
        //Idle
        else
            animator.SetInteger("AnimState", 0);
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector3.up, 0.03f);
    }
}

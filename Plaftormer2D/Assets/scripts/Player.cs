using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float playerScale = 5.0f;

    private float inputX;
    private Animator animator;
    private Rigidbody2D body2d;
    private bool combatIdle = false;
    private bool isGrounded = true;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public Transform waterDetection;
    public Transform healthBar;
    public float attackRange;
    public int damage;
    public int maxHealth = 10;
    public int currentHealth;
    public bool death = false;

    void Start () {
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
	}

	void Update () {
        if (death == false) {
       
            inputX = Input.GetAxis("Horizontal");

            if (inputX > 0){
                transform.localScale = new Vector3(-playerScale, playerScale, playerScale);
            }
            else if (inputX < 0) {
                transform.localScale = new Vector3(playerScale, playerScale, playerScale);
            }
                
            body2d.velocity = new Vector2(inputX * speed, body2d.velocity.y);

            isGrounded = IsGrounded();
            animator.SetBool("Grounded", isGrounded);

            if (Input.GetKeyDown("k")){
               animator.SetTrigger("Death");
           }
            else if (Input.GetKeyDown("h")) {
                animator.SetTrigger("Hurt");
            }
       
            else if (Input.GetKeyDown("r")) {
                animator.SetTrigger("Recover");
            }

            else if (Input.GetKeyDown("i")) {
                combatIdle = !combatIdle;
            }

            else if (Input.GetKeyDown("space"))
            {
              animator.SetTrigger("Attack");
            }

            else if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                animator.SetTrigger("Jump");
                body2d.velocity = new Vector2(body2d.velocity.x, jumpForce);
            }

        //Walk
            else if (Mathf.Abs(inputX) > Mathf.Epsilon && isGrounded) {
                animator.SetInteger("AnimState", 2);
            }
            
        //Combat idle
            else if (combatIdle) {
                animator.SetInteger("AnimState", 1);
            }
            
        //Idle
            else {
                animator.SetInteger("AnimState", 0);
            }

            RaycastHit2D waterInfo = Physics2D.Raycast(waterDetection.position, Vector2.down, 1f, LayerMask.GetMask("Water"));
            if (waterInfo.collider == true) {
                death=true;
                animator.SetTrigger("Death");
            }
        }

    }
    
    public void OnAttack () {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++) {
            enemiesToDamage[i].GetComponent<Patrol>().TakeDamage(damage);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector3.up, 0.03f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);    
    }

    public void TakeDamage(int damage) {

        if (currentHealth > 0) {
            animator.SetTrigger("Hurt");
		    currentHealth -= damage; 
        }
        if (currentHealth <= 0) {
            animator.SetTrigger("Death");
			death = true;
        }
        healthBar.GetComponent<HealthBar>().SetHealth(currentHealth);
    }

    public void Heal (int heal) {
        currentHealth += heal; 
        healthBar.GetComponent<HealthBar>().SetHealth(currentHealth);
    }

}

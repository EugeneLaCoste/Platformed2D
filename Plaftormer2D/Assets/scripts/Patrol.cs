using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public float speed;
	public float distance;
	public float enemyScale = 5;
	private int direction = -1;
	public int health = 5;
	private bool death = false;
	public float attackRange;
    public int damage;

	public Transform groundDetection;
	private Rigidbody2D body2d;
	private Animator animator;
	public Transform attackPos;
    public LayerMask whatIsPlayer;
	public GameObject target;
	public Transform healthBar;
	
	void Start () {
		body2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		transform.localScale = new Vector3(enemyScale, enemyScale, 0);
		healthBar.transform.localScale = new Vector3(-1, 1, 0);
		animator.SetInteger("AnimState", 2);
		animator.SetBool("Grounded", true);
		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		if (death == false) {
			if (Mathf.Abs(transform.position.x - target.transform.position.x) > 2) {
				animator.SetInteger("AnimState", 2);
				body2d.velocity = new Vector2(speed * direction, body2d.velocity.y);
				RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, LayerMask.GetMask("Ground"));
				if (groundInfo.collider == false) {
					if (direction == 1) {
						direction *= -1;
						transform.localScale = new Vector3(enemyScale, enemyScale, 0);
						healthBar.transform.localScale = new Vector3(1, 1, 0);
					} else {
						direction *= -1;
						transform.localScale = new Vector3(-enemyScale, enemyScale, 0);
						healthBar.transform.localScale = new Vector3(-1, 1, 0);
					}
				}
			}
			if (Mathf.Abs(transform.position.x - target.transform.position.x) < 2) {
				if(transform.position.x - target.transform.position.x > 0) {
					transform.localScale = new Vector3(enemyScale, enemyScale, 0);
					healthBar.transform.localScale = new Vector3(1, 1, 0);
					direction = -1;
				} else {
					transform.localScale = new Vector3(-enemyScale, enemyScale, 0);
					healthBar.transform.localScale = new Vector3(-1, 1, 0);
					direction = 1;
				}
				animator.SetTrigger("Attack");

			}
		}		
	}

	public void TakeDamage(int damage) 
	{
		animator.SetTrigger("Hurt");
		animator.SetInteger("AnimState", 0);
		health -= damage;
		if (health == 0) {
			death = true;
			animator.SetTrigger("Death");
			Destroy(gameObject, 0.5f);
		}
		// else {

		// }
		healthBar.GetComponent<HealthBar>().SetHealth(health);

	}

	public void OnAttack() {
		Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
        for (int i = 0; i < playerToDamage.Length; i++) {
           	playerToDamage[i].GetComponent<Player>().TakeDamage(damage);
        }

	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);    
    }
}

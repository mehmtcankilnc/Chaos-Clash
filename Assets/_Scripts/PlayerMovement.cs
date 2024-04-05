using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Transform attackPoint;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement = Vector2.zero;
    private Vector2 mousePos;
    private bool canAttack = true;
    private float attackRange = 1.5f;
    private float attackCooldown = 0.4f;
    public AudioSource attackSound;
    public bool isDead = false;
    private void Awake()
    {
        Time.timeScale = 1.0f;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack) 
        {
            StartCoroutine(Attack());
        }
    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("mHorizontal", mousePos.x);
        animator.SetFloat("mVertical", mousePos.y);

        if( ((mousePos.x < transform.position.x) && movement.x == 1) ||
            ((mousePos.x > transform.position.x) && movement.x == -1) ||
            ((mousePos.y < transform.position.y) && movement.y == 1) ||
            ((mousePos.y > transform.position.y) && movement.y == -1) )
        {
            animator.SetBool("Backward", true);
            animator.SetFloat("mHorizontal", mousePos.x);
            animator.SetFloat("mVertical", mousePos.y);
        }
        else
        {
            animator.SetBool("Backward", false);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * GameManager.Instance.moveSpeed * Time.deltaTime);
    }
    IEnumerator Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            animator.SetTrigger("Attack");

            yield return new WaitForSeconds(0.8f);
            if (!isDead)
                attackSound.Play();
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            yield return new WaitForSeconds(0.3f);
            foreach(Collider2D hit in hitEnemies)
            {
                if(Vector2.Distance(hit.transform.position, attackPoint.position) < attackRange)
                {
                    hit.GetComponent<EnemyHealth>().TakeDamage(GameManager.Instance.attackDamage);
                }
            }
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
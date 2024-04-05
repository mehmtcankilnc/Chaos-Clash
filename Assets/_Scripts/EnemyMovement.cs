using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public AIPath aiPath;

    private EnemyData enemyData;
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject player;
    private float distanceToPlayer;
    private bool isAttacking = false;
    private float animLength;
    public AudioSource attackSound;
    void Start()
    {
        enemyData = GetComponent<EnemyData>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        animLength = animator.runtimeAnimatorController.animationClips[5].length;
    }
    void Update()
    {
        animator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
        animator.SetFloat("Vertical", aiPath.desiredVelocity.y);

        distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < enemyData.attackRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("Attack", true);
        rb.bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(animLength);
        if (distanceToPlayer < enemyData.attackRange)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(enemyData.damage);
        }

        isAttacking = false;
        animator.SetBool("Attack", false);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void AttackSound()
    {
        attackSound.Play();
    }
}

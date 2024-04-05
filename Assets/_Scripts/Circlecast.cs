using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circlecast : MonoBehaviour
{
    public GameObject player;
    private float attackRange = 1.5f;
    void Update()
    {
        Collider2D[] detectArea = Physics2D.OverlapCircleAll(transform.position, attackRange);
        
        foreach (Collider2D hit in detectArea)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player");
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

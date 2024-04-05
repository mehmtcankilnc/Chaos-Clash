using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;
    public Animator anim;
    public Transform target;

    private void Start()
    {
        target = pointA;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < 5f)
        {
            if (target == pointA)
            {
                target = pointB;
                anim.SetBool("isLeft", true);
            }
            else
            {
                target = pointA;
                anim.SetBool("isLeft", false);
            }
        }
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
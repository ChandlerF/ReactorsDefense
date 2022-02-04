using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 Target = Vector3.zero;
    [SerializeField] private float MoveSpeed = 140f, Damage = 5f;
    private Rigidbody2D rb;
    private Vector3 MoveDir;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveDir = Vector3.zero;

        Vector3 direction = Target - transform.position;

        MoveDir = direction.normalized;
    }


    void FixedUpdate()
    {
        rb.AddForce(MoveDir * MoveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Reactor"))
        {
            //Damage Reactor
            //Spawn Particles
            col.transform.GetComponent<Health>().Damage(Damage, transform.position);
            GetComponent<Health>().Death();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private float Damage = 5f;
    private HammerAnimator Anim;

    private void Start()
    {
        Anim = transform.parent.GetComponent<HammerAnimator>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Anim.Swing();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            col.GetComponent<Health>().Damage(Damage, transform.parent.position);
        }
    }
}

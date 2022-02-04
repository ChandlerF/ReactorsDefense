using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHP, HP;
    [SerializeField] private bool CanGetKnockbacked = true;
    private Rigidbody2D rb;
    [SerializeField] private GameObject HitParticles;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        HP = MaxHP;
    }


    public void Damage(float dmg, Vector3 target)
    {
        Instantiate(HitParticles, transform.position, Quaternion.identity);
        HP -= dmg;

        if(HP <= 0)
        {
            Death();
        }

        Knockback(50f, target);

        if (transform.CompareTag("Reactor"))
        {
            CameraShake.cam.Trauma += 0.5f;
        }
        else if(transform.CompareTag("Enemy"))
        {
            if (GameManager.instance.GameIsOver == false)
            {
                AudioManager.instance.Play("EnemyDamage");
                NumberCounter.instance.Value += 20;
            }

            CameraShake.cam.Trauma += 0.15f;
        }
    }

    public void Knockback(float force, Vector3 target)
    {
        if (CanGetKnockbacked)
        {
            Vector3 MoveDir = Vector3.zero;

            Vector3 direction = target - transform.position;

            MoveDir = -direction.normalized;

            rb.AddForce(MoveDir * force, ForceMode2D.Impulse);
        }
    }


    public void Death()
    {
        if (transform.CompareTag("Reactor"))
        {
            GameManager.instance.GameOver();
            GameManager.instance.GameIsOver = true;
        }
        else
        {
            AudioManager.instance.Play("EnemyDeath");
        }
        Destroy(gameObject);
    }
}

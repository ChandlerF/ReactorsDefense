using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAnimator : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject SwingParticles;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Swing()
    {
        if (!Swinging())
        {
            AudioManager.instance.Play("SwingHammer");
            IsSwinging();
            Instantiate(SwingParticles, transform.position, Quaternion.identity);
        }
    }


    public void IsSwinging()
    {
        anim.SetBool("IsSwinging", true);
    }
    public void IsNotSwinging()
    {
        anim.SetBool("IsSwinging", false);
    }

    public bool Swinging()
    {
        return anim.GetBool("IsSwinging");
    }

    public void Velocity(float xVel)
    {
        anim.SetFloat("xVel", xVel);
    }
}

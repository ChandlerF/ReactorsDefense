using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarButton : MonoBehaviour
{
    private Pillar pillar;

    private void Start()
    {
        pillar = transform.parent.GetComponent<Pillar>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Hammer") && pillar.CanResetButton)
        {
            pillar.ResetButton();
        }
    }
}

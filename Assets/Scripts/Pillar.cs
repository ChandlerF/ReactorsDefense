using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public bool CanResetButton = false;

    [SerializeField] private Vector3 StartPos, EndPos = new Vector3(0, 1.75f, 0);
    [SerializeField] Vector2 DesiredTimeRange;
    private float DesiredTime;
    private float ElapsedTime, PercentComplete;
    [SerializeField] private List<Collider2D> Colliders = new List<Collider2D>();
    [SerializeField] private GameObject ButtonParticles, ExplosionParticles;
    private GameObject Button;
    private bool HasLostGame = false;

    void Start()
    {
        StartPos = transform.position;
        EndPos = StartPos + EndPos;

        SetTimer();
        Invoke("SetBool", 2f);

        Button = transform.GetChild(0).gameObject;

        for (int i = 0; i < Colliders.Count; i++)
        {
            Colliders[i].enabled = false;
        }
    }

    void Update()
    {
        if (PercentComplete < 1)
        {
            ElapsedTime += Time.deltaTime;
            PercentComplete = ElapsedTime / DesiredTime;

            transform.position = Vector3.Lerp(StartPos, EndPos, PercentComplete);



            if(PercentComplete >= 0.77f)
            {
                Colliders[2].enabled = true;
            }
            else if(PercentComplete >= 0.44f)
            {
                Colliders[1].enabled = true;
            }
            else if(PercentComplete >= 0.2f)
            {
                Colliders[0].enabled = true;
            }
        }
        else if(!HasLostGame)
        {
            LoseGame();
        }
    }


    private void LoseGame()
    {
        HasLostGame = true;
        Instantiate(ExplosionParticles, Button.transform.position, Quaternion.identity);
        try
        {
            GameObject Reactor = GameObject.FindGameObjectWithTag("Reactor");
            Reactor.GetComponent<Health>().Damage(100f, transform.position);
        }
        catch
        {
            Debug.Log("No Reactor");
        }
    }


    public void ResetButton()
    {
        if (PercentComplete < 1)
        {
            CanResetButton = false;

            AudioManager.instance.Play("PillarReset");
            Instantiate(ButtonParticles, Button.transform.position, Quaternion.identity);
            transform.position = StartPos;
            ElapsedTime = 0;
            SetTimer();
            Invoke("SetBool", 2f);

            Colliders[0].enabled = false;
            Colliders[1].enabled = false;
            Colliders[2].enabled = false;
            CameraShake.cam.Trauma += 0.2f;
        }
    }

    private void SetTimer()
    {
        DesiredTime = Random.Range(DesiredTimeRange.x, DesiredTimeRange.y);
    }

    private void SetBool()
    {
        CanResetButton = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SubmitName : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField Name;
    [SerializeField] private GameObject Background, InputField;
    [SerializeField] private string[] Profanity;

    private void Start()
    {
        if(PlayerInfo.instance.Name.Length == 3)
        {
            DestroyGUI();
        }


        Name.onValidateInput += delegate (string s, int i, char c)
        {
            if (s.Length >= 3) { return '\0'; }
            c = char.ToUpper(c);
            return char.IsLetter(c) ? c : '\0';
        };
    }

    public void ClickButton()
    {
        if(Name.text.Length == 3)
        {
            

            if (!Profanity.Contains(Name.text))
            {
                AudioManager.instance.Play("MenuSelect");
                PlayerInfo.instance.Name = Name.text;
                DestroyGUI();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AudioManager.instance.Play("MenuSelect");
            ClickButton();
        }
    }

    private void DestroyGUI()
    {
        Destroy(InputField);
        Destroy(Background);
        Destroy(gameObject);
    }


    public void CorrectName()
    {/*
        Name.onValidateInput += delegate (string s, int i, char c)
        {
            if (s.Length >= 3) { return '\0'; }
            c = char.ToUpper(c);
            return char.IsLetter(c) ? c : '\0';
        };*/
    }
}

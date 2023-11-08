using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{
    public GameObject joyStick;
    public GameObject dialog;
    public GameObject npcCamera;

    public Text npcDialogue; // NPC�� ��ȭ�� ����� �ؽ�Ʈ


    public Animator animator; // �ִϸ����� ���� ����




    // NPC�� ��ȭ ����
    string[] dialogues;
    int index = 0;
    bool isTyping = false; // ��� ����� ���� �������� �Ǵ��ϴ� ����

    void Awake()
    {
        dialogues = new string[]
        {
            "������������������",
            "�ȳ��ϼ���!",
            "���� ������ ���׿�.",
            "��ſ� �Ϸ� �Ǽ���."
        };
    }

    void OnEnable()
    {
        if (index < dialogues.Length)
        {
            StartCoroutine(TypeSentence(dialogues[index]));
        }
    }

    void Update()
    {
        // ���콺 ���� ��ư Ŭ���� �����ϸ� ���� ��ȭ ����
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            if (index < dialogues.Length)
            {
                StartCoroutine(TypeSentence(dialogues[index]));
            }
            else
            {
                joyStick.gameObject.SetActive(true);
                dialog.gameObject.SetActive(false);
                npcCamera.gameObject.SetActive(false);
            }

            //animator.SetTrigger("VictoryTrigger"); // 'victory' �ִϸ��̼� ����

        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        npcDialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            npcDialogue.text += letter;
            yield return new WaitForSeconds(0.1f); // �� ���� ��� ���� �ð� ����
        }
        isTyping = false;

        // ��� ����� ���� �Ŀ� �ε��� ����
        if (index < dialogues.Length)
        {
            index++;
        }
    }
}

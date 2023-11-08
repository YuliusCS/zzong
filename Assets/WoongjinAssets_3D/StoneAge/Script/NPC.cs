using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Transform player;
    float distance;
    public float withPlayerDistance;
    public GameObject talkButton;
    public GameObject joyStick;
    public GameObject dialog;
    public GameObject npcCamera;

    bool isTalk;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isTalk = false;
    }

    void Update()
    {
        // �÷��̾�� npc ���� �Ÿ� üũ
        distance = Vector3.Distance(player.transform.position, transform.position);

        // �÷��̾�� npc ���� �Ÿ��� Ư�� �Ÿ� ������ ���� ��ȭ�ϱ� ��ư Ȱ��ȭ
        if (distance <= withPlayerDistance && !isTalk)
        {
            talkButton.gameObject.SetActive(true);
        }
        else talkButton.gameObject.SetActive(false);
    }
    public void Onclick()
    {
        joyStick.gameObject.SetActive(false);
        dialog.gameObject.SetActive(true);
        // npc ���� ��� �̵�
        npcCamera.gameObject.SetActive(true);
        talkButton.gameObject.SetActive(false);

        isTalk = true;
    }
}

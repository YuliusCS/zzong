using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Diagnostics;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("���� Ŭ��");

        // ���� ����� ���ӿ����� �۵��մϴ�.
        Application.Quit();
    }

    public void OnButtonClick()
    {
        Debug.Log("��ư�� Ŭ��");
    }


}

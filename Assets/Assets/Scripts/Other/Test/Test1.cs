using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>(); // ��ȡCanvas�ϵ�GraphicRaycaster���
        eventSystem = GetComponent<EventSystem>(); // ��ȡCanvas�ϵ�EventSystem���
        pointerEventData = new PointerEventData(eventSystem); // ����һ��PointerEventData����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ����ҵ��������ʱ
        {
            pointerEventData.position = Input.mousePosition; // �������߼���λ��Ϊ���λ��

            List<RaycastResult> results = new List<RaycastResult>(); // ���ڴ洢���߼��Ľ��
            raycaster.Raycast(pointerEventData, results); // �������߼��

            foreach (RaycastResult result in results)
            {
                // �����ﴦ�����߼��Ľ���������ȡ�������UIԪ�ز�������Ӧ�Ĵ���
                Debug.Log("UIԪ�ر�����ˣ�" + result.gameObject.name);
            }
        }
    }
}

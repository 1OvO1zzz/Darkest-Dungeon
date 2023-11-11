using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolEsc : InstanceBaseAuto_Mono<PoolEsc>
{
    public List<string> ListEsc = new();        

    private void Start()
    {
        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.Esc)            
                HideTop();
        });
    }    

    /// <summary>
    /// �������м���PoolEsc�����
    /// </summary>
    public void HideAll()
    {
        int tempCount = ListEsc.Count;
        for (int i = 0; i < tempCount; i++)
            HideTop();
    }

    /// <summary>
    /// ������PoolEsc���˵����
    /// </summary>
    public void HideTop()
    {
        if (ListEsc.Count > 0)
        {
            Hot.CenterEvent_.EventTrigger("Esc" + ListEsc[^1]);

            PoolBuffer.GetInstance().Push
                (false, MgrUI.GetInstance().GetPanel(ListEsc[^1]).gameObject, ListEsc[^1]);

            PoolNowPanel.GetInstance().ListNowPanel.Remove(ListEsc[^1]);

            ListEsc.Remove(ListEsc[^1]);
        }               
    }
}

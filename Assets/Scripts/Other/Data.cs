using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data : InstanceBaseAuto_Mono<Data>
{    
    public string PathGameArchiveData;    
    
    public List<DataContainer_PanelCellGameArchive> DataListCellGameArchive = new List<DataContainer_PanelCellGameArchive>();

    protected override void Start()
    {
        base.Start();

        PathGameArchiveData = "/GameArchiveData";

        if (!File.Exists(MgrJson.GetInstance().filePath))
        {
            Directory.CreateDirectory(MgrJson.GetInstance().filePath);
        }

        string[] AllPathGameArchive = Directory.GetFiles(MgrJson.GetInstance().filePath);        
        
        for (int i = 0; i < AllPathGameArchive.Length; i++)
        {
            DataListCellGameArchive.Add(MgrJson.GetInstance().Load<DataContainer_PanelCellGameArchive>(PathGameArchiveData + i));
        }
    }

    /// <summary>
    /// ����ָ���浵
    /// </summary>
    /// <param name="index">Ҫ������Ĵ浵��Index</param>
    public void Save(int index)
    {
        MgrJson.GetInstance().Save(DataListCellGameArchive[index], PathGameArchiveData + index);
    }

    /// <summary>
    /// ���浱ǰ�浵
    /// </summary>
    public void Save()
    {
        Save(Hot.NowIndexCellGameArchive);
    }

    /// <summary>
    /// �������д浵
    /// </summary>
    public void SaveAll()
    {
        for (int i = 0; i < DataListCellGameArchive.Count; i++)
            Save(i);
    }

    /// <summary>
    /// ɾ��ָ���浵
    /// </summary>
    /// <param name="index">Ҫ��ɾ���Ĵ浵��Index</param>
    public void Destroy(int index)
    {                
        for (int i = index; i < DataListCellGameArchive.Count - 1; i++)
        {
            File.Copy(MgrJson.GetInstance().filePath + PathGameArchiveData + (i + 1) + ".json",
                      MgrJson.GetInstance().filePath + PathGameArchiveData + i + ".json", true);            
        }
            

        File.Delete(MgrJson.GetInstance().filePath + PathGameArchiveData + (DataListCellGameArchive.Count - 1) + ".json");
        DataListCellGameArchive.RemoveAt(index);
    }
}



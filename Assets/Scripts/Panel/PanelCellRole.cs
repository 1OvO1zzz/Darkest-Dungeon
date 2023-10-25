using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellRole : PanelBaseCell
{
    public Image ImgPortrait;
    public Image ImgProgress;
    public Image ImgRoleLevelBk;
    public Text TxtRoleName;
    public Text TxtRoleLevel;

    public Transform RootSanityValueBar;

    public List<GameObject> ListImgCellSanity = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();

        ImgPortrait = transform.FindSonSonSon("ImgPortrait").GetComponent<Image>();
        ImgProgress = transform.FindSonSonSon("ImgProgress").GetComponent<Image>();
        ImgRoleLevelBk = transform.FindSonSonSon("ImgRoleLevelBk").GetComponent<Image>();

        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();
        TxtRoleLevel = transform.FindSonSonSon("TxtRoleLevel").GetComponent<Text>();

        RootSanityValueBar = transform.FindSonSonSon("RootSanityValueBar");        
    }

    public void InitInfo()
    {
        ImgPortrait.sprite =
            Hot.MgrRes_.Load<Sprite>("Art/" + Hot.DataNowCellGameArchive.ListCellRole[Index].e_SpriteNamePortraitRole);
        TxtRoleName.text = Hot.DataNowCellGameArchive.ListCellRole[Index].Name;
        TxtRoleLevel.text = Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel.ToString();

        TxtRoleName.text = Hot.DataNowCellGameArchive.ListCellRole[Index].Name;        
        ChangeSanityExplosionLimit();
        UpdateLevelInfo();
        UpdateSanityInfo();
        UpdateExperience();
    }

    /// <summary>
    /// �ı�RootSanityValueBar�µ�ImgCellSanity������
    /// ��סһ��Ҫ��UpdateSanityInfoǰ����
    /// </summary>
    public void ChangeSanityExplosionLimit()
    {
        if (ListImgCellSanity.Count < Hot.DataNowCellGameArchive.ListCellRole[Index].SanityExplosionLimit)
        {
            for 
            (int i = 0; 
             i < Hot.DataNowCellGameArchive.ListCellRole[Index].SanityExplosionLimit - ListImgCellSanity.Count;
             i++)
            {
                ListImgCellSanity.Add(Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgCellSanity"));
                ListImgCellSanity[i].transform.SetParent(RootSanityValueBar, false);
                ListImgCellSanity[i].GetComponent<Image>().sprite = 
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanValueNone");
            }
        }

        if (ListImgCellSanity.Count > Hot.DataNowCellGameArchive.ListCellRole[Index].SanityExplosionLimit)
        {
            for
            (int i = 0;
             i < ListImgCellSanity.Count - Hot.DataNowCellGameArchive.ListCellRole[Index].SanityExplosionLimit;
             i++)
            {
                ListImgCellSanity.RemoveAt(ListImgCellSanity.Count - 1);
            }
        }
    }

    public void ChangeName(string NameToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].Name = NameToChange;
        
        TxtRoleName.text = NameToChange;
        Hot.Data_.Save();
    }

    public void ChangeSanity(int ValueToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].NowSanity += ValueToChange;

        UpdateSanityInfo();
        Hot.Data_.Save();
    }

    public void ChangeExperience()
    {
        Hot.Data_.Save();
    }

    public void ChangeLevel(int ValueToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel += ValueToChange;
        if
        (Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel > Hot.DataNowCellGameArchive.ListCellRole[Index].MaxLevel)
         Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel = Hot.DataNowCellGameArchive.ListCellRole[Index].MaxLevel;

        UpdateLevelInfo();
        Hot.Data_.Save();
    }

    public void UpdateSanityInfo()
    {
        for (int i = 0; i < ListImgCellSanity.Count; i++)
        {
            if
            (i < Hot.DataNowCellGameArchive.ListCellRole[Index].NowSanity / Hot.StepSanity)
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanValueHave");
            }
            else
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanValueNone");
        }
    }    

    public void UpdateLevelInfo()
    {
        //�ȼ��ĵ�ͼ�ı��߼�

        TxtRoleLevel.text = Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel.ToString();
    }

    public void UpdateExperience()
    {
        ImgProgress.GetComponent<RectTransform>().sizeDelta = 
            new Vector2(ImgProgress.GetComponent<RectTransform>().sizeDelta.x, 
                        49.3f * ((float)Hot.DataNowCellGameArchive.ListCellRole[Index].NowExperience /
                        Hot.ListNeedExperienceToUpLevel[Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel])); 
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class Hot
{
    #region Config

    public static int StepSanity = 10;    

    /// <summary>
    /// ��TranslateNum�Ļ�������ӵı���
    /// </summary>
    public static int AddTranslateRate = 4;
    /// <summary>
    /// ���ڵ�ת������
    /// </summary>
    public static int NowTranslateRate = 1;

    /// <summary>
    /// AddMapSize �� ReduceMapSize����һ�����ӻ���ٵ�ֵ
    /// </summary>
    public static float ValueChangeMapSize = 0.2f;

    /// <summary>
    /// �����ȼ���������ľ���
    /// </summary>
    public static List<int> ListNeedExperienceToUpLevel = new List<int>()
    {
        50,
        55,
        60,
        90,
        100,
        130
    };

    #endregion

    #region ��ݵõ�BaseFrameWork��Ľű�

    public static MgrUI MgrUI_
    {
        get { return MgrUI.GetInstance(); }
    }
    public static Data Data_
    {
        get { return Data.GetInstance(); }
    }    
    public static PoolNowPanel PoolNowPanel_
    {
        get { return PoolNowPanel.GetInstance(); }
    }
    public static PoolBuffer PoolBuffer_
    {
        get { return PoolBuffer.GetInstance(); }
    }
    public static MgrInput MgrInput_
    {
        get { return MgrInput.GetInstance(); }
    }
    public static MgrJson MgrJson_
    {
        get { return MgrJson.GetInstance(); }
    }
    public static CenterEvent CenterEvent_
    {
        get { return CenterEvent.GetInstance(); }
    }
    public static MgrRes MgrRes_
    {
        get { return MgrRes.GetInstance(); }
    }

    #endregion

    #region Panel
    
    public static PanelExpeditionMiniMap PanelExpeditionMiniMap_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionMiniMap>("PanelExpeditionMiniMap"); }
    }
    public static PanelExpeditionPrePare PanelExpedition_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionPrePare>("PanelExpeditionPrePare"); }
    }
    public static PanelRoleGuildRecruit PanelRoleGuildRecruit_
    {
        get { return MgrUI_.GetPanel<PanelRoleGuildRecruit>("PanelRoleGuildRecruit"); }
    }
    public static PanelRoleGuildRecruitCost PanelRoleGuildRecruitCost_
    {
        get { return MgrUI_.GetPanel<PanelRoleGuildRecruitCost>("PanelRoleGuildRecruitCost"); }
    }
    public static PanelOtherSetting PanelOtherSetting_
    {
        get { return MgrUI_.GetPanel<PanelOtherSetting>(""); }
    }
    public static PanelBarExpedition PanelBarExpedition_
    {
        get { return MgrUI_.GetPanel<PanelBarExpedition>("PanelBarExpedition"); }
    }
    public static PanelBarTown PanelBarTown_
    {
        get { return MgrUI_.GetPanel<PanelBarTown>("PanelBarTown"); }
    }
    public static PanelRoleDetails PanelRoleDetails_
    {
        get { return MgrUI_.GetPanel<PanelRoleDetails>("PanelRoleDetails"); }
    }
    public static PanelRoleList PanelRoleList_
    {
        get { return MgrUI_.GetPanel<PanelRoleList>("PanelRoleList"); }
    }
    /// <summary>
    /// ���г����������
    /// </summary>
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }    
    public static PanelOhterResTable PanelOtherResTable_
    {
        get { return MgrUI_.GetPanel<PanelOhterResTable>("PanelOhterResTable"); }
    }    
    public static PanelGameArchiveChoose PanelGameArchiveChoose_
    {
        get { return MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose"); }
    }    
    public static PanelOtherDestroyArchiveHint PanelOtherDestroyArchiveHint_
    {
        get { return MgrUI_.GetPanel<PanelOtherDestroyArchiveHint>("PanelOtherDestroyArchiveHint"); }
    }

    #endregion    

    #region �����̵�

    /// <summary>
    /// �����̵�
    /// </summary>
    public static PanelRoomTownShop PanelRoomTownShop_
    {
        get { return MgrUI_.GetPanel<PanelRooms>("PanelRooms").AllPanel["PanelRoomTownShop"] as PanelRoomTownShop; }
    }
    /// <summary>
    /// �����̵�����ڴ浵���Data
    /// </summary>
    public static List<DataContainer_CellItem> DataPanelTownShopItem
    {
        get { return DataNowCellGameArchive.ListCellShopItem; }
    }
    /// <summary>
    /// �����̵껨�����
    /// </summary>
    public static PanelTownShopCost PanelShopCost_
    {
        get { return MgrUI_.GetPanel<PanelTownShopCost>("PanelTownShopCost"); }
    }
    /// <summary>
    /// �����̵������PoPoCat
    /// </summary>
    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return MgrUI_.GetPanel<PanelMinistrantPoPoCat>("PanelMinistrantPoPoCat"); }
    }
    /// <summary>
    /// �����̵����
    /// </summary>
    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return MgrUI_.GetPanel<PanelTownShopItem>("PanelTownShopItem"); }
    }

    #endregion

    #region Data

    public static DataContainer_ResTable DataPanelResTable
    {
        get { return DataNowCellGameArchive.ResTable; }
    }
    public static DataContainer_CellTownStore DataNowPanelStore
    {
        get
        {
            if (NowPanelItem != null && NowPanelItem is PanelTownItem)
            {
                return DataNowCellGameArchive.ListCellStore[(NowPanelItem as PanelTownItem).FatherPanelCellTownStore.Index];
            }
            return null;
        }
    }
    /// <summary>
    /// ���ڶ�ȡ�Ĵ浵Data
    /// </summary>
    public static DataContainer_PanelCellGameArchive DataNowCellGameArchive
    {
        get { return Data_.DataListCellGameArchive[NowIndexCellGameArchive]; }
    }

    #endregion    

    #region Now    

    public static int IndexPaddingContentStep;
    public static E_ArrowDirection e_PaddingArrowDirection;
    public static DynamicContentStep PaddingContentStep_;
    /// <summary>
    /// �����϶��Ľ�ɫ��ļPanelCell
    /// </summary>
    public static PanelCellRoleRecruit DragingPanelCellRoleRecruit;
    /// <summary>
    /// ���ڽ���Ľ�ɫԶ������
    /// </summary>
    public static GameObject NowRootExpeditionRole;
    /// <summary>
    /// �滻�Ľ�ɫФ��
    /// </summary>
    public static GameObject ReplaceRolePortrait;
    /// <summary>
    /// ��ҷ�Ľ�ɫФ��
    /// </summary>
    public static GameObject DragingRolePortrait;    
    /// <summary>
    /// ��ק����Ʒ
    /// </summary>
    public static PanelCellTownItem DragingItem;
    /// <summary>
    /// ���������Ʒ
    /// </summary>
    public static PanelCellTownItem NowItem;
    /// <summary>
    /// ��ק������
    /// </summary>
    public static PanelCellTownStore DragingTownStore;
    /// <summary>
    /// ���ڽ����PanelItem
    /// </summary>
    public static PanelBaseItem NowPanelItem;
    /// <summary>
    /// ��ǰ�浵��Index
    /// </summary>
    public static int NowIndexCellGameArchive = -1;    
    /// <summary>
    /// ����������ڵ�����
    /// </summary>
    public static E_NowPointerLocation e_NowPointerLocation = E_NowPointerLocation.None;  
    /// <summary>
    /// ����������ڵ�����(�ӿ������ӽ�����)
    /// </summary>
    public static E_PlayerLocation e_NowPlayerLocation = E_PlayerLocation.None;    

    #endregion

    /// <summary>
    /// ���Item��ָ��Cotent
    /// </summary>
    /// <param name="e_AddLocation">��ӵ�����</param>
    public static void AddItem(E_Location e_AddLocation)
    {
        switch (e_AddLocation)
        {
            case E_Location.TownItem:
                DragingItem.transform.SetParent(NowPanelItem.Content, false);
                DragingItem.e_Location = E_Location.TownItem;
                DragingItem.Index = NowPanelItem.NowIndex++;
                DataNowPanelStore.ListCellStoreItem.Add
                    (new DataContainer_CellItem(E_Location.TownItem, DragingItem.e_SpriteNamePanelCellItem));                
                break;
            case E_Location.TownShopItem:
                DragingItem.transform.SetParent(PanelTownShopItem_.Content, false);
                DragingItem.e_Location = E_Location.TownShopItem;
                DragingItem.Index = PanelTownShopItem_.NowIndex++;
                DataPanelTownShopItem.Add
                    (new DataContainer_CellItem(E_Location.TownShopItem, DragingItem.e_SpriteNamePanelCellItem));                
                break;
        }                      
    }
}

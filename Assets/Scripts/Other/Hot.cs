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
    public static float ValueChangeMapSize = 0.4f;

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

    public static Vector2 SizeCellItemBody = new(40, 40);

    public static Dictionary<E_PanelCellTownStore, Vector2> DicStoreBody = new()
    {
        { E_PanelCellTownStore.StoreWood, new Vector2(10, 5) },
        { E_PanelCellTownStore.StoreIron, new Vector2(12, 10) },
        { E_PanelCellTownStore.StoreGold, new Vector2(15, 13) },
    };

    public static Dictionary<E_SpriteNamePanelCellItem, Vector2> DicItemBody = new()
    {
        { E_SpriteNamePanelCellItem.ItemFoodCookie, new Vector2(1, 1) },
        { E_SpriteNamePanelCellItem.ItemFoodApple, new Vector2(3, 3) },
        { E_SpriteNamePanelCellItem.ItemFoodBread, new Vector2(1, 2) },

        { E_SpriteNamePanelCellItem.ItemFoodRawBeef, new Vector2(2, 3) },
        { E_SpriteNamePanelCellItem.ItemFoodCookedBeef, new Vector2(2, 3) },

        { E_SpriteNamePanelCellItem.ItemFoodRawChicken, new Vector2(2, 2) },
        { E_SpriteNamePanelCellItem.ItemFoodCoodedChicken, new Vector2(2, 2) },

        { E_SpriteNamePanelCellItem.ItemFoodRawMutton, new Vector2(2, 2) },
        { E_SpriteNamePanelCellItem.ItemFoodCoodedMutton, new Vector2(2, 2) },               

        { E_SpriteNamePanelCellItem.ItemFoodRawPotato, new Vector2(2, 2) },     
        { E_SpriteNamePanelCellItem.ItemFoodCookedPotato, new Vector2(2, 2) },        
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
    
    public static PanelOtherMapEditor PanelOtherMapEditor_
    {
        get { return MgrUI_.GetPanel<PanelOtherMapEditor>("PanelOtherMapEditor"); }
    }
    public static PanelExpeditionMiniMap PanelExpeditionMiniMap_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionMiniMap>("PanelExpeditionMiniMap"); }
    }
    public static PanelExpeditionPrepare PanelExpeditionPrepare_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionPrepare>("PanelExpeditionPrepare"); }
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
    /// <summary>
    /// ���ڶ�ȡ�Ĵ浵Data
    /// </summary>
    public static DataContainer_PanelCellGameArchive DataNowCellGameArchive
    {
        get { return Data_.DataListCellGameArchive[NowIndexCellGameArchive]; }
    }

    #endregion    

    #region Now    
    
    public static E_CellExpeditionMiniMapHall e_NowChooseHall = E_CellExpeditionMiniMapHall.None;
    public static E_CellExpeditionMiniMapRoom e_NowChooseRoom = E_CellExpeditionMiniMapRoom.None;
    public static E_ArrowDirection e_PaddingArrowDirection;
    public static DynamicContentStep PaddingContentStep_;
    /// <summary>
    /// ���ڽ����DynamicScrollView ������ �浵 ��ɫ���� �������� �� ��̬�ı�λ��
    /// </summary>
    public static PanelBaseDynamicScrollView NowPanelBaseDynamicScrollView_ = null;
    /// <summary>
    /// ����ѡ�е���Ʒ
    /// </summary>
    public static PanelCellItem NowCellItem = null;
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
    /// ��ק������
    /// </summary>
    public static PanelCellTownStore DragingTownStore;
    /// <summary>
    /// ���ڽ���Ŀ��Դ洢Item�����
    /// </summary>
    public static PanelBaseVector2Store NowPanelCanStoreItem;
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
}

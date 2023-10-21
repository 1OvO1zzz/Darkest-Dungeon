using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class Hot
{

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

    public static DataContainer_PanelResTable DataPanelResTable
    {
        get { return DataNowCellGameArchive.PanelResTable; }
    }
    public static PanelOhterResTable PanelOtherResTable_
    {
        get { return MgrUI_.GetPanel<PanelOhterResTable>("PanelOhterResTable"); }
    }
    /// <summary>
    /// �浵ѡ�����
    /// </summary>
    public static PanelGameArchiveChoose PanelGameArchiveChoose_
    {
        get { return MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose"); }
    }
    /// <summary>
    /// ɾ���浵��ʾ���
    /// </summary>
    public static PanelOtherDestroyArchiveHint PanelOtherDestroyArchiveHint_
    {
        get { return MgrUI_.GetPanel<PanelOtherDestroyArchiveHint>("PanelOtherDestroyArchiveHint"); }
    }
    public static DataContainer_PanelResTable DataPanelResTable_
    {
        get { return DataNowCellGameArchive.PanelResTable; }
    }

    #endregion

    /// <summary>
    /// ���ڶ�ȡ�Ĵ浵Data
    /// </summary>
    public static DataContainer_PanelCellGameArchive DataNowCellGameArchive
    {
        get { return Data_.DataListCellGameArchive[NowIndexCellGameArchive]; }        
    }
    /// <summary>
    /// ���ڶ�ȡ�Ĵ浵��Index
    /// </summary>
    public static int NowIndexCellGameArchive
    {
        get { return MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").IndexNowCellGameArchive; }

        set { MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").IndexNowCellGameArchive = value; }
    }

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
    public static List<DataContainer_PanelCellItem> DataPanelTownShopItem
    {
        get { return DataNowCellGameArchive.ListCellShopItem; }
    }
    /// <summary>
    /// �����̵껨�����
    /// </summary>
    public static PanelTownShopCost PanelShopCost_
    {
        get { return PanelRoomTownShop_.PanelShopCost_; }
    }
    /// <summary>
    /// �����̵������PoPoCat
    /// </summary>
    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return PanelRoomTownShop_.PanelMinistrantPoPoCat_; }
    }
    /// <summary>
    /// �����̵����
    /// </summary>
    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return PanelRoomTownShop_.PanelTownShopItem_; }
    }

    #endregion

    /// <summary>
    /// ���г����������
    /// </summary>
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }    
    /// <summary>
    /// ���ڴ򿪵ĳ��������ڴ浵�ж�Ӧ��Data
    /// </summary>
    public static DataContainer_PanelCellTownStore DataNowPanelCellTownStore
    {
        get { return DataNowCellGameArchive.ListCellStore[NowIndexPanelCellTownStore]; }
    }
    /// <summary>
    /// ���ڴ򿪵ĳ������ӵ�Index
    /// </summary>
    public static int NowIndexPanelCellTownStore
    {
        get { return NowPanelCellTownStore.Index; }
    }
    /// <summary>
    /// ���ڴ򿪵�����
    /// </summary>
    public static PanelCellTownStore NowPanelCellTownStore
    {
        get { return PanelTownStore_.NowPanelCellTownStore; }
        set { PanelTownStore_.NowPanelCellTownStore = value; }
    }
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
    /// ������ڵ���
    /// </summary>
    public static E_Location e_NowPointerLocation = E_Location.None;

    /// <summary>
    /// ���Item��ָ��Cotent
    /// </summary>
    /// <param name="e_AddLocation">��ӵ�����</param>
    public static void AddItem(E_Location e_AddLocation)
    {
        int SoureceIndex = DragingItem.Index;
        E_Location e_SourceLocation = DragingItem.e_Location;

        switch (e_AddLocation)
        {
            case E_Location.PanelTownItem:
                DragingItem.transform.SetParent(NowPanelCellTownStore.PanelCellItem_.Content, false);
                DragingItem.e_Location = E_Location.PanelTownItem;
                DragingItem.Index = NowPanelCellTownStore.PanelCellItem_.NowIndex++;
                DataNowPanelCellTownStore.DataListCellStoreItem.Add
                    (new DataContainer_PanelCellItem(E_Location.PanelTownItem, DragingItem.e_SpriteNamePanelCellItem));
                DestroySourceItemData(e_SourceLocation, SoureceIndex);
                break;
            case E_Location.PanelTownShopItem:
                DragingItem.transform.SetParent(PanelTownShopItem_.Content, false);
                DragingItem.e_Location = E_Location.PanelTownShopItem;
                DragingItem.Index = PanelTownShopItem_.NowIndex++;
                DataPanelTownShopItem.Add
                    (new DataContainer_PanelCellItem(E_Location.PanelTownShopItem, DragingItem.e_SpriteNamePanelCellItem));
                DestroySourceItemData(e_SourceLocation, SoureceIndex);
                break;
        }                      
    }

    private static void DestroySourceItemData(E_Location e_SourceLocation, int SoureceIndex)
    {
        switch (e_SourceLocation)
        {
            case E_Location.PanelTownItem:
                NowPanelCellTownStore.PanelCellItem_.NowIndex--;
                DataNowPanelCellTownStore.DataListCellStoreItem.RemoveAt(SoureceIndex);
                break;
            case E_Location.PanelTownShopItem:
                PanelTownShopItem_.NowIndex--;
                DataPanelTownShopItem.RemoveAt(SoureceIndex);
                break;
        }
    }
}

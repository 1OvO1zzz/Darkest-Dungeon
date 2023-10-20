using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class Hot
{
    /// <summary>
    /// ��ݵõ�MgrUI
    /// </summary>
    public static MgrUI MgrUI_
    {
        get { return MgrUI.GetInstance(); }
    }
    /// <summary>
    /// ��ݵõ�Data
    /// </summary>
    public static Data Data_
    {
        get { return Data.GetInstance(); }
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
    //---
    /// <summary>
    /// �����̵�
    /// </summary>
    public static PanelRoomTownShop PanelRoomTownShop_
    {
        get { return MgrUI_.GetPanel<PanelRooms>("PanelRooms").AllPanel["PanelRoomTownShop"] as PanelRoomTownShop; }
    }
    /// <summary>
    /// �����̵껨�����
    /// </summary>
    public static PanelShopCost PanelShopCost_
    {
        get { return PanelRoomTownShop_.PanelShopCost_; }
    }
    /// <summary>
    /// �����̵�����ڴ浵���Data
    /// </summary>
    public static List<DataContainer_PanelCellItem> DataPanelTownShopItem
    {
        get { return DataNowCellGameArchive.DataListCellShopItem; }
    }
    /// <summary>
    /// �����̵����
    /// </summary>
    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return PanelRoomTownShop_.PanelTownShopItem_; }
    }
    /// <summary>
    /// �����̵������PoPoCat
    /// </summary>
    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return PanelRoomTownShop_.PanelMinistrantPoPoCat_; }
    }
    /// <summary>
    /// ����ֿ����
    /// </summary>
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }    
    /// <summary>
    /// ���ڴ򿪵ĳ����ֿ����Data
    /// </summary>
    public static List<DataContainer_PanelCellItem> DataNowPanelTownItem
    {
        get { return DataNowPanelCellTownStore.DataListCellStoreItem; }
    }
    /// <summary>
    /// ���ڴ򿪵ĳ���ֿ��ڴ浵�ж�Ӧ��Data
    /// </summary>
    public static DataContainer_PanelCellTownStore DataNowPanelCellTownStore
    {
        get { return DataNowCellGameArchive.DataListCellStore[NowIndexPanelCellTownStore]; }
    }
    /// <summary>
    /// ���ڴ򿪵ĳ���ֿ��Index
    /// </summary>
    public static int NowIndexPanelCellTownStore
    {
        get { return NowPanelCellTownStore.Index; }
    }
    /// <summary>
    /// ���ڴ򿪵ĳ���ֿ�
    /// </summary>
    public static PanelCellTownStore NowPanelCellTownStore
    {
        get { return PanelTownStore_.NowPanelCellTownStore; }                            
    }
    /// <summary>
    /// ���ڴ򿪵���Ʒ��
    /// </summary>
    public static PanelTownItem NowPanelTownItem
    {
        get { return NowPanelCellTownStore.PanelCellItem_; }
    }
    //---
    public static PanelStoreAncestralProperty PanelStoreAncestralProperty_
    {
        get { return MgrUI_.GetPanel<PanelStoreAncestralProperty>("PanelStoreAncestralProperty"); }
    }

    public static PanelStoreCoin PanelStoreCoin_
    {
        get { return MgrUI_.GetPanel<PanelStoreCoin>("PanelStoreCoin"); }
    }
    //---
    /// <summary>
    /// ��ק����Ʒ
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
        int SoureceIndex = NowItem.Index;
        E_Location e_SourceLocation = NowItem.e_Location;

        switch (e_AddLocation)
        {
            case E_Location.PanelTownItem:
                NowItem.transform.SetParent(NowPanelTownItem.Content, false);
                NowItem.e_Location = E_Location.PanelTownItem;
                NowItem.Index = NowPanelTownItem.NowIndex++;
                DataNowPanelCellTownStore.DataListCellStoreItem.Add(MakeItemDataBySourceItem(e_SourceLocation, SoureceIndex));
                DestroySourceItemData(e_SourceLocation, SoureceIndex);
                break;
            case E_Location.PanelTownShopItem:
                NowItem.transform.SetParent(PanelTownShopItem_.Content, false);
                NowItem.e_Location = E_Location.PanelTownShopItem;
                NowItem.Index = PanelTownShopItem_.NowIndex++;
                DataPanelTownShopItem.Add(MakeItemDataBySourceItem(e_SourceLocation, SoureceIndex));
                DestroySourceItemData(e_SourceLocation, SoureceIndex);
                break;
        }                      
    }

    public static DataContainer_PanelCellItem MakeItemDataBySourceItem(E_Location e_SourceLocation, int SoureceIndex)
    {        
        switch (e_SourceLocation)
        {
            case E_Location.PanelTownItem:
                NowPanelTownItem.NowIndex--;
                return DataNowPanelTownItem[SoureceIndex];                
            case E_Location.PanelTownShopItem:
                PanelTownShopItem_.NowIndex--;
                return DataPanelTownShopItem[SoureceIndex];                
        }

        return null;
    }

    private static void DestroySourceItemData(E_Location e_SourceLocation, int SoureceIndex)
    {
        switch (e_SourceLocation)
        {
            case E_Location.PanelTownItem:
                DataNowPanelTownItem.RemoveAt(SoureceIndex);
                break;
            case E_Location.PanelTownShopItem:
                DataPanelTownShopItem.RemoveAt(SoureceIndex);
                break;
        }
    }
}

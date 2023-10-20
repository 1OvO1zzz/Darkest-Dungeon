using System.Collections;
using System.Collections.Generic;
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
    /// ���ڶ�ȡ�Ĵ浵
    /// </summary>
    public static DataContainer_PanelCellGameArchive NowCellGameArchive
    {
        get { return Data_.DataListCellGameArchive[IndexNowCellGameArchive]; }
    }
    /// <summary>
    /// ���ڶ�ȡ�Ĵ浵��Index
    /// </summary>
    public static int IndexNowCellGameArchive
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
    /// �����̵����
    /// </summary>
    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return PanelRoomTownShop_.PanelTownShopItem_; }
    }

    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return PanelRoomTownShop_.PanelMinistrantPoPoCat_; }
    }
    //---
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
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
}

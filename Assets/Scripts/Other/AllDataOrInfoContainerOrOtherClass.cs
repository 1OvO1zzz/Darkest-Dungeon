using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class AllDataOrInfoContainerOrOtherClass { }

[Serializable]
public class my_VectorInt2
{
    public int X;
    public int Y;

    public my_VectorInt2()
    {
        X = -1;
        Y = -1;
    }
    public my_VectorInt2(int p_X, int p_Y)
    {
        X = p_X;
        Y = p_Y;
    }
}

public class VectorInt2_4
{
    public int Jump;
    public int Fall;
    public int BackUp;
    public int Forward;

    public int this[KeyCode key]
    {
        get
        {
            switch (key)
            {
                case KeyCode.W:
                    return Jump;
                case KeyCode.S:
                    return Fall;
                case KeyCode.A:
                    return BackUp;
                case KeyCode.D:
                    return Forward;
                default:
                    return 0;
            }
        }
    }

    public VectorInt2_4() { }
    public VectorInt2_4(int p_Jump, int p_Fall, int p_BackUp, int p_Forward)
    {
        Jump = p_Jump;
        Fall = p_Fall;
        BackUp = p_BackUp;
        Forward = p_Forward;
    }
}

public class SkillConfig
{
    public my_VectorInt2 StartPos = new();
    public List<List<E_RoleSkillArea>> Area = new();

    public SkillConfig() { }
    public SkillConfig(my_VectorInt2 p_StartPos, List<List<E_RoleSkillArea>> p_Area)
    {
        StartPos = p_StartPos;
        Area = p_Area;
    }
}

public class RoleConfig
{
    public E_RoleMoveType e_MoveType;
    public List<int> ListLevelUpNeedExperience;
    public Dictionary<E_Skill, SkillConfig> DicSkill;

    public int MaxHp;
    public int MaxSanity;
    public int MaxLevel;
    public int MaxAction;
    public int LimitToSanityExplosion;
    public int InitialSpeed;

    public my_VectorInt2 SizeStore;
    public my_VectorInt2 SizeBody;
    public VectorInt2_4 SizeMove;

    public RoleConfig() { }
    public RoleConfig
    (E_RoleMoveType p_e_MoveType,
     List<int> p_ListLevelUpNeedExperience,
     Dictionary<E_Skill, SkillConfig> p_DicSkill,
     int p_MaxHp, int p_MaxSanity, int p_MaxLevel, int p_MaxActionValue,
     int p_LimitToSanityExplosion, int p_InitialSpeed,
     my_VectorInt2 p_SizeStore, my_VectorInt2 p_SizeBody, VectorInt2_4 p_SizeMove)
    {
        e_MoveType = p_e_MoveType;
        ListLevelUpNeedExperience = p_ListLevelUpNeedExperience;
        DicSkill = p_DicSkill;

        SizeStore = p_SizeStore;
        SizeBody = p_SizeBody;
        SizeMove = p_SizeMove;

        MaxHp = p_MaxHp;
        MaxSanity = p_MaxSanity;
        MaxLevel = p_MaxLevel;
        MaxAction = p_MaxActionValue;
        LimitToSanityExplosion = p_LimitToSanityExplosion;
        InitialSpeed = p_InitialSpeed;
    }
}

public class DataContainer_CellGameArchive
{
    public E_GameArchiveLevel e_GameArchiveLevel = E_GameArchiveLevel.None;
    public string GameArchiveName = "";
    public string Week = "0";
    public string Time = "0000/00/00 00:00:00";

    public List<int> ListNowPutRole = new();
    public List<int> ListExpeditionRoleIndex = new();
    public E_ExpeditionLocation e_NowExpeditionLocation = E_ExpeditionLocation.Town;
    public int NowEventIndex = -1;
    public my_VectorInt2 NowCellMiniMapPos = new();
    [JsonIgnore]
    public DataContainer_CellExpeditionMiniMap DataNowCellMiniMap => DataNowEvent.ListCellMiniMap[NowCellMiniMapPos.Y][NowCellMiniMapPos.X];
    [JsonIgnore]
    public DataContainer_ExpeditionMiniMap DataNowEvent => ExpeditionPrepare[e_NowExpeditionLocation][NowEventIndex];
    public DataContainer_CellExpeditionMiniMap GetDataNowCellMiniMap(int p_Y, int p_X)
    {
        return DataNowEvent.ListCellMiniMap[p_Y][p_X];
    }
    public DataContainer_ExpeditionMiniMap GetDataNowEvent(E_ExpeditionLocation p_e_NowExpeditionLocation, int p_NowEventIndex)
    {
        return ExpeditionPrepare[p_e_NowExpeditionLocation][p_NowEventIndex];
    }

    public DataContainer_ResTable ResTable = new();
    public List<DataContainer_CellTownStore> ListStore = new();
    public List<DataContainer_CellRole> ListRole = new();
    public List<DataContainer_CellRoleRecruit> ListRoleRecruit = new();
    public DataContainer_TownShop TownShop = new();
    public DataContainer_ExpeditionPrepare ExpeditionPrepare = new();

    public DataContainer_CellGameArchive() { }
    public DataContainer_CellGameArchive
    (string p_GameArchiveName, E_GameArchiveLevel p_e_GameArchiveLevel, E_ExpeditionLocation p_e_NowExpeditionLocation, string p_Week, string p_Time,
    List<DataContainer_CellTownStore> p_ListCellStore)
    {
        GameArchiveName = p_GameArchiveName;
        e_GameArchiveLevel = p_e_GameArchiveLevel;
        e_NowExpeditionLocation = p_e_NowExpeditionLocation;
        Week = p_Week;
        Time = p_Time;
        ListStore = p_ListCellStore;
    }

    public void ClearNowEvent()
    {
        e_NowExpeditionLocation = E_ExpeditionLocation.Town;
        NowEventIndex = -1;
        NowCellMiniMapPos = new();
        ListExpeditionRoleIndex.Clear();
        ListNowPutRole.Clear();
    }

    public void UpdataNowCellMiniMapPos()
    {
        NowCellMiniMapPos = new(Hot.NowInCellExpeditionMiniMap.RootGrid.X, Hot.NowInCellExpeditionMiniMap.RootGrid.Y);
    }
}

#region Role

public class DataContainer_CellRole
{
    public E_RoleName e_RoleName = E_RoleName.None;
    public string Name = "Default";
    public int NowHp = 0;
    public int NowSanity = 0;
    public int NowLevel = 0;
    public int NowExperience = 0;
    public int NowSpeed = 0;
    public int NowAction = 0;

    public int NowTimeLinePos = -1;

    public int MaxHp = 0;
    public int MaxSanity = 0;
    public int MaxLevel = 0;
    public int MaxAction = 0;
    public int LimitToSanityExplosion = 0;

    public int VFlip = 1;
    public int IndexExpeditionRoot = -1;

    public List<List<DataContainer_CellItem>> ListItem = new();
    public Dictionary<E_Skill, SkillConfig> DicSkill = new();

    public DataContainer_CellRole() { }
    public DataContainer_CellRole(E_RoleName p_e_RoleName)
    {
        NowHp = Hot.DicRoleConfig[e_RoleName].MaxHp;
        NowSanity = 0;
        NowLevel = 0;
        NowAction = Hot.DicRoleConfig[e_RoleName].MaxAction;
        NowSpeed = Hot.DicRoleConfig[e_RoleName].InitialSpeed;

        MaxHp = Hot.DicRoleConfig[e_RoleName].MaxHp;
        MaxSanity = Hot.DicRoleConfig[e_RoleName].MaxSanity;
        MaxLevel = Hot.DicRoleConfig[e_RoleName].MaxLevel;
        MaxAction = Hot.DicRoleConfig[e_RoleName].MaxAction;
        LimitToSanityExplosion = Hot.DicRoleConfig[e_RoleName].LimitToSanityExplosion;

        DicSkill = Hot.DicRoleConfig[e_RoleName].DicSkill;

        for (int Y = 0; Y < Hot.DicRoleConfig[p_e_RoleName].SizeStore.Y; Y++)
        {
            ListItem.Add(new());

            for (int X = 0; X < Hot.DicRoleConfig[p_e_RoleName].SizeStore.X; X++)
            {
                ListItem[Y].Add(new());
            }
        }
    }
    public DataContainer_CellRole
    (E_RoleName p_e_RoleName,
     string p_Name, int p_NowHp, int p_NowSanity, int p_NowLevel, int p_NowExperience, int p_NowAction)
    {
        e_RoleName = p_e_RoleName;
        NowHp = p_NowHp;
        Name = p_Name;
        NowLevel = p_NowLevel;
        NowExperience = p_NowExperience;
        NowSanity = p_NowSanity;
        NowAction = p_NowAction;
        NowSpeed = Hot.DicRoleConfig[e_RoleName].InitialSpeed;

        MaxHp = Hot.DicRoleConfig[e_RoleName].MaxHp;
        MaxSanity = Hot.DicRoleConfig[e_RoleName].MaxSanity;
        MaxLevel = Hot.DicRoleConfig[e_RoleName].MaxLevel;
        MaxAction = Hot.DicRoleConfig[e_RoleName].MaxAction;
        LimitToSanityExplosion = Hot.DicRoleConfig[e_RoleName].LimitToSanityExplosion;

        DicSkill = Hot.DicRoleConfig[e_RoleName].DicSkill;

        for (int Y = 0; Y < Hot.DicRoleConfig[p_e_RoleName].SizeStore.Y; Y++)
        {
            ListItem.Add(new());

            for (int X = 0; X < Hot.DicRoleConfig[p_e_RoleName].SizeStore.X; X++)
            {
                ListItem[Y].Add(new());
            }
        }
    }

    public void ReSetExpeditionData()
    {
        VFlip = 1;
        NowTimeLinePos = -1;
    }
}

public class DataContainer_CellRoleRecruit
{
    public DataContainer_CellRole Role;
    public DataContainer_CoinCost Cost;

    public DataContainer_CellRoleRecruit() { }
    public DataContainer_CellRoleRecruit
    (DataContainer_CellRole Role, DataContainer_CoinCost Cost)
    {
        this.Role = Role;
        this.Cost = Cost;
    }
}

#endregion

#region Expedition

public class DataContainer_ExpeditionPrepare
{
    public List<DataContainer_ExpeditionMiniMap> BloodCourtyard = new();
    public List<DataContainer_ExpeditionMiniMap> Lair = new();
    public List<DataContainer_ExpeditionMiniMap> Farm = new();
    public List<DataContainer_ExpeditionMiniMap> Wilds = new();
    public List<DataContainer_ExpeditionMiniMap> Ruins = new();
    public List<DataContainer_ExpeditionMiniMap> Sea = new();
    public List<DataContainer_ExpeditionMiniMap> Darkest = new();

    public List<DataContainer_ExpeditionMiniMap> this[E_ExpeditionLocation e_ExpeditionLocation]
    {
        get
        {
            switch (e_ExpeditionLocation)
            {
                case E_ExpeditionLocation.BloodCourtyard:
                    return BloodCourtyard;
                case E_ExpeditionLocation.Lair:
                    return Lair;
                case E_ExpeditionLocation.Farm:
                    return Farm;
                case E_ExpeditionLocation.Wilds:
                    return Wilds;
                case E_ExpeditionLocation.Ruins:
                    return Ruins;
                case E_ExpeditionLocation.Darkest:
                    return Darkest;
                case E_ExpeditionLocation.Sea:
                    return Sea;
                default:
                    return null;
            }
        }
    }

    public DataContainer_ExpeditionPrepare() { }
    public DataContainer_ExpeditionPrepare
    (List<DataContainer_ExpeditionMiniMap> bloodCourtyard, List<DataContainer_ExpeditionMiniMap> lair, List<DataContainer_ExpeditionMiniMap> farm,
     List<DataContainer_ExpeditionMiniMap> wilds, List<DataContainer_ExpeditionMiniMap> ruins, List<DataContainer_ExpeditionMiniMap> sed,
     List<DataContainer_ExpeditionMiniMap> darkest)
    {
        BloodCourtyard = bloodCourtyard;
        Lair = lair;
        Farm = farm;
        Wilds = wilds;
        Ruins = ruins;
        Sea = sed;
        Darkest = darkest;
    }
}

#region Map

public class DataContainer_ExpeditionMiniMap
{
    public E_DungeonLevel e_dungeonLevel = E_DungeonLevel.Zero;
    public E_DungeonSize e_dungeonSize = E_DungeonSize.Small;
    public E_ExpeditionEvent e_ExpeditionEvent = E_ExpeditionEvent.Boss0;

    public my_VectorInt2 EntrancePos = new();
    public List<List<DataContainer_CellExpeditionMiniMap>> ListCellMiniMap = new();

    public DataContainer_ExpeditionMiniMap() { }
    public DataContainer_ExpeditionMiniMap(my_VectorInt2 p_EntrancePos)
    {
        EntrancePos = p_EntrancePos;
    }
}

public class DataContainer_CellExpeditionMiniMap
{
    public E_CellMiniMap e_CellMiniMap = E_CellMiniMap.None;

    public List<List<DataContainer_GridExpeditionMap>> Map = new();

    public DataContainer_CellExpeditionMiniMap() { }
    public DataContainer_CellExpeditionMiniMap(E_CellMiniMap p_e_CellMap = E_CellMiniMap.None)
    {
        e_CellMiniMap = p_e_CellMap;

        if (e_CellMiniMap != E_CellMiniMap.None && Map.Count <= 0)
        {
            for (int Y = 0; Y < Hot.BodyMap.Y; Y++)
            {
                Map.Add(new());

                for (int X = 0; X < Hot.BodyMap.X; X++)
                {
                    Map[Y].Add(new());
                }
            }
        }
    }
}

public class DataContainer_CellExpeditionMapObj
{
    public E_MapObject e_Obj = E_MapObject.None;
}

public class DataContainer_GridExpeditionMap
{
    public int IndexListRole = -1;
    public DataContainer_CellRole OtherRole;
    public DataContainer_CellExpeditionMapObj MapObj;
}

#endregion

#endregion

public class DataContainer_CellTownStore
{
    public string Name = "没有名字";
    public E_PanelCellTownStore e_PanelCellTownStore = E_PanelCellTownStore.StoreWood;
    public List<List<DataContainer_CellItem>> ListItem = new();

    public DataContainer_CellTownStore
    (string p_name, E_PanelCellTownStore p_e_PanelCellTownStore)
    {
        Name = p_name;
        e_PanelCellTownStore = p_e_PanelCellTownStore;

        for (int i1 = 0; i1 < Hot.BodyDicStore[e_PanelCellTownStore].Y; i1++)
        {
            ListItem.Add(new());

            for (int i2 = 0; i2 < Hot.BodyDicStore[e_PanelCellTownStore].X; i2++)
            {
                ListItem[i1].Add(new());
            }
        }
    }
}

public class DataContainer_TownShop
{
    public int X;
    public int Y;

    public List<List<DataContainer_CellItem>> ListItem = new();
}

public class DataContainer_CellItem
{
    public E_Item e_Item = E_Item.None;

    public DataContainer_CellItem() { }
    public DataContainer_CellItem
    (E_Item p_e_Item)
    {
        e_Item = p_e_Item;
    }
}

public class DataContainer_ResTable
{
    public int NowStoreDebris = 0;

    #region AncestralProperty

    public int NowStatue = 0;
    public int NowDeed = 0;
    public int NowBadge = 0;
    public int NowPicture = 0;
    public int NowCrystal = 0;

    public int NowLevelStatue = 1;
    public int NowLevelDeed = 1;
    public int NowLevelBadge = 1;
    public int NowLevelPicture = 1;
    public int NowLevelCrystal = 1;

    public int LevelUpNeedBadge = 10;
    public int LevelUpNeedStatue = 20;
    public int LevelUpNeedPicture = 40;
    public int LevelUpNeedDeed = 80;
    public int LevelUpNeedCrystal = 160;

    public int LevelStepStatue = 10;
    public int LevelStepDeed = 10;
    public int LevelStepBadge = 10;
    public int LevelStepPicture = 10;
    public int LevelStepCrystal = 10;

    public int LevelMaxStatue = 100;
    public int LevelMaxDeed = 100;
    public int LevelMaxBadge = 100;
    public int LevelMaxPicture = 100;
    public int LevelMaxCrystal = 100;

    //Ancestral Property
    //  Badge 1 --Standard
    //  Statue 2
    //  Picture 4
    //  Deed 8
    //  Crystal 16
    //--
    public int RateStatueToDeed = 4;
    public int RateStatueToPicture = 2;
    public int RateStatueToBadge = 2;
    public int RateStatueToCrystal = 8;
    public int RateDeedToPicture = 2;
    public int RateDeedToBadge = 8;
    public int RateDeedToCrystal = 2;
    public int RatePictureToBadge = 4;
    public int RatePictureToCrystal = 4;
    public int RateBadgeToCrystal = 16;

    #endregion

    #region Coin

    public int NowCopper = 0;
    public int NowSilver = 0;
    public int NowGold = 0;
    public int NowPlatinum = 0;

    public int NowLevelCopper = 1;
    public int NowLevelSilver = 1;
    public int NowLevelGold = 1;
    public int NowLevelPlatinum = 1;

    public int LevelUpNeedCopper = 1;
    public int LevelUpNeedSilver = 10;
    public int LevelUpNeedGold = 50;
    public int LevelUpNeedPlatinum = 100;

    public int LevelStepCopper = 1000;
    public int LevelStepSilver = 50;
    public int LevelStepGold = 10;
    public int LevelStepPlatinum = 5;

    public int LevelMaxCopper = 100;
    public int LevelMaxSilver = 100;
    public int LevelMaxGold = 100;
    public int LevelMaxPlatinum = 100;

    public int RateCopperToSilver = 100;
    public int RateSilverToGold = 100;
    public int RateGoldToPlatinum = 100;

    #endregion

    #region CoinToAncestralProperty    

    public int RateBadgeToCopper = 10000;
    public int RateStatueToCopper = 20000;
    public int RatePictureToCopper = 40000;
    public int RateDeedToCopper = 80000;
    public int RateCrystalToCopper = 160000;

    public int RateBadgeToSilver = 100;
    public int RateStatueToSilver = 200;
    public int RatePictureToSilver = 400;
    public int RateDeedToSilver = 800;
    public int RateCrystalToSilver = 1600;

    public int RateBadgeToGold = 1;
    public int RateStatueToGold = 2;
    public int RatePictureToGold = 4;
    public int RateDeedToGold = 8;
    public int RateCrystalToGold = 16;

    #endregion

    public DataContainer_ResTable() { }
    public DataContainer_ResTable
    (int NowCopper, int NowSilver, int NowGold, int NowPlatinum,
     int NowLevelCopper, int NowLevelSilver, int NowLevelGold, int NowLevelPlatinum)
    {
        this.NowCopper = NowCopper;
        this.NowSilver = NowSilver;
        this.NowGold = NowGold;
        this.NowPlatinum = NowPlatinum;
        this.NowLevelCopper = NowLevelCopper;
        this.NowLevelSilver = NowLevelSilver;
        this.NowLevelGold = NowLevelGold;
        this.NowLevelPlatinum = NowLevelPlatinum;
    }
}

public class DataContainer_CoinCost
{
    public int Copper;
    public int Silver;
    public int Gold;
    public int Platinum;
    public DataContainer_CoinCost() { }
    public DataContainer_CoinCost
    (int Copper, int Silver, int Gold, int Platinum)
    {
        this.Copper = Copper;
        this.Silver = Silver;
        this.Gold = Gold;
        this.Platinum = Platinum;
    }
}

public class InfoContainer_Cost
{
    public int Copper;
    public int Silver;
    public int Gold;
    public int Platinum;

    public int Statue;
    public int Deed;
    public int Badge;
    public int Picture;
    public int Crystal;

    public InfoContainer_Cost() { }
    public InfoContainer_Cost
    (int copper, int silver, int gold, int platinum,
     int statue, int deed, int badge, int picture, int crystal)
    {
        Copper = copper;
        Silver = silver;
        Gold = gold;
        Platinum = platinum;

        Statue = statue;
        Deed = deed;
        Badge = badge;
        Picture = picture;
        Crystal = crystal;
    }
}

//������� ����PanelCellItem ��¼������Ϣ PriceOffSet ��������
//......

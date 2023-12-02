using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellGridMiniMapEditor : PanelBase
{
    public int X;
    public int Y;

    public Image ImgBk;
    public Image ImgStatus;

    public PanelCellMiniMapEditor CellMiniMapEditor;

    protected override void Awake()
    {
        base.Awake();

        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();

        ImgBk.alphaHitTestMinimumThreshold = 0.2f;

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterCellGridMiniMapEditor = this;

            if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                    {
                        Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctRed");
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
            }
        });

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterCellGridMiniMapEditor = null;

            if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                    {
                        Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        });
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "ImgBk":
                if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None && JudgeCanPut())
                {
                    if (Hot.ChoseCellMiniMapEditor == null)
                    {
                        //����PanelCellMiniMapEditor
                        Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditor>(false, "/PanelCellMiniMapEditor",
                        (panel) =>
                        {
                            panel.transform.SetParent(Hot.PanelOtherMapEditor_.ItemRoot[Y][X], false);
                            panel.transform.transform.localPosition = new Vector3(-20, 20);
                            panel.RootGrid = this;

                            panel.Init(Hot.e_ChoseRoom);

                            for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor = panel;
                                }
                            }

                            if (Hot.e_ChoseRoom == E_CellMiniMapRoom.CellMapRoomEntrance)
                            {
                                Hot.PanelOtherMapEditor_.EntrancePos.X = X;
                                Hot.PanelOtherMapEditor_.EntrancePos.Y = Y;

                                Hot.PanelOtherMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                                Hot.e_ChoseRoom = E_CellMiniMapRoom.None;
                            }   
                        });
                    }

                    //�ƶ�PanelCellMiniMapEditor
                    if (Hot.ChoseCellMiniMapEditor != null)
                    {
                        if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None)
                        {
                            for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Hot.ChoseCellMiniMapEditor.RootGrid.Y + i1][Hot.ChoseCellMiniMapEditor.RootGrid.X + i2].CellMiniMapEditor = null;
                                }
                            }

                            for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor = Hot.ChoseCellMiniMapEditor;
                                }
                            }
                        }

                        Hot.ChoseCellMiniMapEditor.transform.SetParent(Hot.PanelOtherMapEditor_.ItemRoot[Y][X], false);
                        Hot.ChoseCellMiniMapEditor.transform.localPosition = new(-20, 20);
                        Hot.ChoseCellMiniMapEditor.RootGrid = this;
                    }

                    //���status
                    if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None)
                    {
                        for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }
                    }
                }
                break;
        }
    }    

    public bool JudgeCanPut()
    {
        if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None)
        {
            if (Y + Hot.BodyDicRoom[Hot.e_ChoseRoom].Y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                X + Hot.BodyDicRoom[Hot.e_ChoseRoom].X > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))
            {
                return false;
            }

            for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
            {
                for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                {
                    if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == null ||
                        Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == Hot.ChoseCellMiniMapEditor)
                    {
                        ;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }    
}

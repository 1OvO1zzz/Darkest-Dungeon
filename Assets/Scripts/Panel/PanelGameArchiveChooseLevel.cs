using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelGameArchiveChooseLevel : PanelBase
{
    public PanelGameArchiveCell Cell;

    private Transform ImgCurrentChoice;
    private Image ImgGameArchiveDecorateLevel;
    private Text TxtDescribes;

    string[] Describes =
    {
        "��ҫս�� ��Ȼ������ս�� ��������Ϊ����ͨģʽ���� ������ �Ƽ����ڵ��ε�����ҳ��� ֻ�в�ͨ�Ż��� (����~~~)",
        "��ͨս������Ϸ��\"ԭʼ\"���� ��Ȼû��ʱ������ ������ҫս����� ս�ۻ�����Ҹ�������ս�� (�����˾�ȥ��Ѫ���޹�)",
        "Ѫ��ս�۲��ʺϵ�С���˲μ� ��Ҫ��ϣ����ʱ��Ϳ�ˡ �������һ��ʱ���ڲ���Ӣ���������������֮ǰսʤа�� " +
        "(�� ������� Ȱ�㻹�Ǳ�Ѫ���޹��˰� �������������·�������� �����Ǹ߹���Ҳ�Ų������� �Ͻ�ж����Ϸ�� ����������~~~)"
    };

    protected override void Start()
    {
        base.Start();

        ImgCurrentChoice = transform.FindSonSonSon("ImgCurrentChoice");
        ImgCurrentChoice.gameObject.SetActive(false);
        ImgGameArchiveDecorateLevel = transform.FindSonSonSon("ImgGameArchiveDecorateLevel").GetComponent<Image>();
        TxtDescribes = transform.FindSonSonSon("TxtDescribes").GetComponent<Text>();

        #region ��ӹ������뿪�¼�        

        string[] controlnames = 
        {
            "BtnGameArchiveChooseLevelBright",
            "BtnGameArchiveChooseLevelDarkness",
            "BtnGameArchiveChooseLevelBloodmoon"
        };
        string[] decorate =
        {
            "Art/DecorateGameArchiveLevelBright",
            "Art/DecorateGameArchiveLevelDarkness",
            "Art/DecorateGameArchiveLevelBloodmoon",
            "Art/DecorateGameArchiveLevelNone"
        };
        int[] pos =
        {
          93,
          27,
         -43
        };
        for (int i = 0; i < 3; i++)
        {
            int tempi = i;
            MgrUI.GetInstance().AddCustomEventListener(transform.FindSonSonSon(controlnames[i]).gameObject,
            EventTriggerType.PointerEnter, (param) =>
            {
                ImgCurrentChoice.gameObject.SetActive(true);
                ImgCurrentChoice.localPosition = new Vector3(ImgCurrentChoice.localPosition.x, pos[tempi], 0);                
                ImgGameArchiveDecorateLevel.sprite = 
                                   MgrRes.GetInstance().Load<Sprite>(decorate[tempi]);
                TxtDescribes.text = Describes[tempi];
            });
            MgrUI.GetInstance().AddCustomEventListener(transform.FindSonSonSon(controlnames[i]).gameObject,
            EventTriggerType.PointerExit, (param) =>
            {
                ImgCurrentChoice.gameObject.SetActive(false);
                ImgGameArchiveDecorateLevel.sprite = MgrRes.GetInstance().Load<Sprite>(decorate[decorate.Length - 1]);
                TxtDescribes.text = "-------------\r\n-------------\r\n-------------\r\n-------------\r\n-------------\r\n-------------";
            });
        }

        #endregion        
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnGameArchiveChooseLevelBright":
                Cell.GameArchiveCellData.e_GameArchiveLevel = E_GameArchiveLevel.Bright;
                Cell.InitGameArchiveCellData(Cell.GameArchiveCellData);
                MgrXml.GetInstance().Save(StartDataAndMgr.GetInstance().ListGameArchiveDataCell, StartDataAndMgr.GetInstance().PathGameArchiveData);
                break;

            case "BtnGameArchiveChooseLevelDarkness":
                Cell.GameArchiveCellData.e_GameArchiveLevel = E_GameArchiveLevel.Darkness;
                Cell.InitGameArchiveCellData(Cell.GameArchiveCellData);
                MgrXml.GetInstance().Save(StartDataAndMgr.GetInstance().ListGameArchiveDataCell, StartDataAndMgr.GetInstance().PathGameArchiveData);
                break;

            case "BtnGameArchiveChooseLevelBloodmoon":
                Cell.GameArchiveCellData.e_GameArchiveLevel = E_GameArchiveLevel.Bloodmoon;
                Cell.InitGameArchiveCellData(Cell.GameArchiveCellData);
                MgrXml.GetInstance().Save(StartDataAndMgr.GetInstance().ListGameArchiveDataCell, StartDataAndMgr.GetInstance().PathGameArchiveData);
                break;

            case "BtnClose":
                MgrUI.GetInstance().HidePanel(false, gameObject, gameObject.name);
                break;
        }
    }    
}

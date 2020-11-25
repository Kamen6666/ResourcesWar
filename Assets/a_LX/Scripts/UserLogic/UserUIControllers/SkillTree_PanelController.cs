using System.Collections.Generic;
using UIFrame;
using UnityEngine;
using UnityEngine.UI;
using Utilty;

public class SkillTree_PanelController : UIControllerBase
{
    int skillPoint = 20;
    SkillData currentClickData;
    SkillData[] Datas;
    Image skillImage;
    Text skillName, skillLvText, skillDesText, pointText;
    UIWidgetsBase[] btns;
    public override void ControllerStart(UIModuleBase module)
    {
        base.ControllerStart(module);
        Init();
        UpdatePointUI();
    }
    private void Init()
    {
        skillImage = _module.FindCurrentModuleWidget("Skill Image#").Image;
        skillName = _module.FindCurrentModuleWidget("Skill Name#").Text;
        skillLvText = _module.FindCurrentModuleWidget("Skill Lv#").Text;
        skillDesText = _module.FindCurrentModuleWidget("Des Text#").Text;
        pointText = _module.FindCurrentModuleWidget("Skill Point Text#").Text;
        _module.FindCurrentModuleWidget("Upgrade Button#").Button.onClick.AddListener(UpgradeButton);

        btns = _module.GetSecondWidgets();
        if (Datas == null)
        {
            Datas = new SkillData[btns.Length];
        }
        for (int i = 0; i < btns.Length; i++)
        {
            Datas[i] = AssetsManager.GetInstance().GetAssets<SkillData>($"LX/SkillData/{i}");
            btns[i].Image.sprite = Datas[i].skillSprite;
        }

        #region 绑定按钮
        _module.FindCurrentModuleSecondWidget("00_Fire Ball~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[0];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("01_transformer~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[1];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("02_Inferno~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[2];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("03_Blaze~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[3];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("04_Wolf~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[4];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("05_Recovery~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[5];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("06_Lifesteal~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[6];
            DisplaySkillInfo();

        });
        _module.FindCurrentModuleSecondWidget("07_Metro~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[7];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("08_Fire Dragon~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[8];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("09_Duration~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[9];
            DisplaySkillInfo();
        });
        _module.FindCurrentModuleSecondWidget("10_Magic Power~").Button.onClick.AddListener(() =>
        {
            currentClickData = Datas[10];
            DisplaySkillInfo();
        });
        #endregion
       
       
    }
    public void UpgradeButton()
    {
        //点数小于0
        if (skillPoint <= 0 )
        {
            return;
        }
        //当前技能等级 >= 最大等级
        if (currentClickData.skillLevel >= currentClickData.maxSkillPoint)
        {
            return;
        }
        //前置技能不为空  && 前置技能解锁
        if (currentClickData.preSkills.Length != 0 && CanUpdate())
        {
            UpdateSkillUI();
        }//无前置技能
        else if(currentClickData.preSkills.Length == 0)
        {
            UpdateSkillUI();
        }
    }

    private void UpdateSkillUI()
    {
        if (currentClickData.isPassive)
        {
            btns[currentClickData.SkillID].transform.Find("PassiveSkillEffective").gameObject.SetActive(true);
        }
        //更改透明度
        btns[currentClickData.SkillID].Image.color = Color.white;
        //显示右下角强化点数
        GameObject Point = btns[currentClickData.SkillID].Transform.Find("Point#").gameObject;
        Point.SetActive(true);
       //计算点数
        Point.transform.GetChild(0).GetComponent<Text>().text = (++currentClickData.skillLevel).ToString();
        DisplaySkillInfo();
        skillPoint--;
        //更新UI
        UpdatePointUI();
        //解锁技能
        currentClickData.isUnlock = true;
    }

    private bool CanUpdate()
    {
        //只要有一个前置技能解锁就返回真
        for (int i = 0; i < currentClickData.preSkills.Length; i++)
        {
            if (currentClickData.preSkills[i].isUnlock)
            {
                return true;
            }
        }
        return false;
    }

    public void DisplaySkillInfo()
    {
        //显示技能信息
        skillImage.sprite = currentClickData.skillSprite;
        skillName.text = currentClickData.skillName;
        skillLvText.text = "Skill Level : Lv " + currentClickData.skillLevel.ToString();
        skillDesText.text = currentClickData.skillDes;
    }
    public void UpdatePointUI()
    {
        //更新点数
        pointText.text = $"Point: {skillPoint}/20";
    }
    public void Refresh()
    {
        btns = _module.GetSecondWidgets();
        if (Datas == null)
        {
            Datas = new SkillData[btns.Length];
        }
        for (int i = 0; i < btns.Length; i++)
        {
           Datas[i] = AssetsManager.GetInstance().GetAssets<SkillData>($"LX/SkillData/{i}");
           if (Datas[i].isUnlock)
            {
                if (Datas[i].isPassive)
                {
                    btns[i].transform.Find("PassiveSkillEffective").gameObject.SetActive(true);
                }
                btns[i].Image.color = Color.white;
                GameObject Point = btns[i].Transform.Find("Point#").gameObject;
                Point.SetActive(true);
                //计算点数
                Point.transform.GetChild(0).GetComponent<Text>().text = Datas[i].skillLevel.ToString();

            }
        }
        UpdatePointUI();
    }

    public void Clear()
    {
        btns = _module.GetSecondWidgets();
        if (Datas == null)
        {
            Datas = new SkillData[btns.Length];
        }
        for (int i = 0; i < btns.Length; i++)
        {
            Datas[i] = AssetsManager.GetInstance().GetAssets<SkillData>($"LX/SkillData/{i}");
            Datas[i].isUnlock = false;
            Datas[i].skillLevel = 0;
        }
        UpdatePointUI();
    }
}
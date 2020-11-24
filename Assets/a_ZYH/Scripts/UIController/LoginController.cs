using System.Collections;
using System.Collections.Generic;
using MobaCommon.Code;
using UIFrame;
using UnityEngine;
using MobaCommon.Dto;

public class LoginController : UIControllerBase
{
    public override void ControllerStart(UIModuleBase module)
    {
        base.ControllerStart(module);
        _module.FindCurrentModuleWidget("RegisterBtn#").Button.onClick.AddListener(OnClickBtn);
        _module.FindCurrentModuleWidget("LoginBtn#").Button.onClick.AddListener(Init);
    }
    
    /// <summary>
    /// 注册点击事件
    /// </summary>
    private void OnClickBtn()
    {
        //关闭当前登录面板
        UIManager.GetInstance().PopModule();
        //打开注册面板
        UIManager.GetInstance().VagueOpenModule("RegisterPanel",null);
    }

    /// <summary>
    /// 登录账号
    /// </summary>
    private void Init()
    {
        UIWidgetsBase inAccount = _module.FindCurrentModuleWidget("In_Account#");
        UIWidgetsBase inPassword = _module.FindCurrentModuleWidget("In_Password#");
        if (string.IsNullOrEmpty(inAccount.InputField.text) || string.IsNullOrEmpty(inPassword.InputField.text))
        {
            Debug.Log("输入的账号密码为空");
            return;
        }
        //账号数据
        AccountDto dto = new AccountDto()
        {
            Account = inAccount.InputField.text,
            Password = inPassword.InputField.text
        };
        //发送请求
        PhotonManager.GetInstance.OnRequste(OpCode.AccountCode,OpAccount.Login,JsonUtility.ToJson(dto));
    }
}

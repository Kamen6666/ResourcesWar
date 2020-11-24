using System.Collections;
using System.Collections.Generic;
using UIFrame;
using UnityEngine;
using MobaCommon.Code;

public class RegisterController : UIControllerBase
{
    public override void ControllerStart(UIModuleBase module)
    {
        base.ControllerStart(module);
        _module.FindCurrentModuleWidget("RegisterBtn#").Button.onClick.AddListener(OnClickBtn);
        
    }

    /// <summary>
    /// 注册点击事件
    /// </summary>
    private void OnClickBtn()
    {
        Init();
        //关闭当前注册面板
        UIManager.GetInstance().PopModule();
        //打开登录面板
        UIManager.GetInstance().VagueOpenModule("LoginPanel",null);
    }

    /// <summary>
    /// 注册账号
    /// </summary>
    private void Init()
    {
        UIWidgetsBase inAccount = _module.FindCurrentModuleWidget("In_Account#");
        UIWidgetsBase inPassword = _module.FindCurrentModuleWidget("In_Password#");
        UIWidgetsBase repPassword = _module.FindCurrentModuleWidget("Rep_Password#");
        if (string.IsNullOrEmpty(inAccount.InputField.text) || string.IsNullOrEmpty(inPassword.InputField.text)
            || !repPassword.InputField.text.Equals(inPassword.InputField.text) )
        {
            Debug.Log("输入的账号密码为空或密码不相同");
            return;
        }
        string account =inAccount.InputField.text;
        string password = inPassword.InputField.text;
        //发送注册请求
        PhotonManager.GetInstance.OnRequste(OpCode.AccountCode,OpAccount.Register,account,password);
        inAccount.InputField.text = null;
        inPassword.InputField.text = null;
    }
}

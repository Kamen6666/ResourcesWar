using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;
using MobaCommon.Code;

public class CreateController : UIControllerBase
{
    public override void ControllerStart(UIModuleBase module)
    {
        base.ControllerStart(module);
        _module.FindCurrentModuleWidget("ApplyBtn#").Button.onClick.AddListener(OnClickBtn);
    }

    /// <summary>
    /// 点击事件
    /// </summary>
    private void OnClickBtn()
    {
        UIWidgetsBase inName = _module.FindCurrentModuleWidget("InPlayerName#");
        if(string.IsNullOrEmpty(inName.InputField.text))
            return;
        //发起请求
        PhotonManager.GetInstance.OnRequste(OpCode.PlayerCode,OpPlayer.Create,inName.InputField.text);
    }
}

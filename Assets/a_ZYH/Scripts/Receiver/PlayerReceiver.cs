using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using MobaCommon.Code;
using UnityEngine;

public class PlayerReceiver : MonoBehaviour, IReceiver {
    public void OnReceiver (byte subCode, OperationResponse response) {
        int code = response.ReturnCode;
        switch (subCode) {
            case OpPlayer.GetInfo:  
                GetInfo(code);
                break;
            case OpPlayer.Create:
                Create();
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// 创建角色信息
    /// </summary>
    private void Create()
    {
        //关闭创建面板
        UIFrame.UIManager.GetInstance().CloseModule("CreatePanel");
        //刷新界面
        
    }

    /// <summary>
    /// 获取角色信息
    /// </summary>
    /// <param name="code"></param>
    private void GetInfo (int code) {
        if (code == 0) 
        {
            //角色存在，上线

        } else if (code == -1) 
        {
            //非法登录

        } else if (code == -2) 
        {
            //没有角色  //创建角色
            //显示创建角色面板
            UIFrame.UIManager.GetInstance().VagueOpenModule ("CreatePanel", null);
        }
    }
}
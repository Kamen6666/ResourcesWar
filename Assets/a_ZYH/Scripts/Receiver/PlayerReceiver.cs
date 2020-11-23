using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using MobaCommon.Code;
using UnityEngine;

public class PlayerReceiver : MonoBehaviour, IReceiver
{
    public void OnReceiver(byte subCode, OperationResponse response)
    {
        switch (subCode)
        {
            case OpPlayer.GetInfo:
                int code = response.ReturnCode;
                if(code == 0)
                {
                    //角色存在，上线
                }else if(code == -1)
                {
                    //非法登录
                }else if(code == -2)
                {
                    //没有角色  //创建角色   
                    //显示创建角色面板  关闭开始界面
                }
                break;
            case OpPlayer.Create:
                break;
            default:
                break;
        }
        
    }
}

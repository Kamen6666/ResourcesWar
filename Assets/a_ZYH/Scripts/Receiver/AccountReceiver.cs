using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using MobaCommon.Code;
using UnityEngine;

public class AccountReceiver : MonoBehaviour,IReceiver
{
    /// <summary>
    /// 服务器给客户端的响应
    /// </summary>
    /// <param name="subCode"></param>
    /// <param name="response"></param>
    public void OnReceiver(byte subCode, OperationResponse response)
    {
        /// <summary>
        /// 返回对应操作码数字
        /// </summary>
        short code = response.ReturnCode;
        /// <summary>
        /// 消息
        /// </summary>
        string mess = response.DebugMessage;
        switch (subCode)
        {
            case OpAccount.Login:
                OnLogin(code,mess);
                break;
            case OpAccount.Register:
                OnRegister(code,mess);
                break;
            default:
                break;
        }    
    }

    /// <summary>
    /// 响应登录处理
    /// </summary>
    /// <param name="code"></param>
    private void OnLogin(short code,string mess)
    {
        switch (code)
        {
            case 0:
                //隐藏登录面板
                
                //显示主面板面板

                //发送获取角色信息请求
                PhotonManager.GetInstance.OnRequste(OpCode.PlayerCode,OpPlayer.GetInfo);
                break;
            case -1:
            //提示面板信息
                break;
            case -2:
            //提示面板信息
                break;
            default:
                break;
        }
        
    }

    /// <summary>
    /// 响应注册处理
    /// </summary>
    /// <param name="code"></param>
    private void OnRegister(short code,string mess)
    {
        switch (code)
        {
            case 0:
            //提示信息
                break;
            case -1:
            //提示信息
                break;
            default:
            //提示信息
                break;
        }
    }
}

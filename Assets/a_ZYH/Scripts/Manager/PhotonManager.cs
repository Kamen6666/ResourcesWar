using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using MobaCommon.Code;
using UnityEngine;
using Utilty;

public class PhotonManager : MonoSingleton<PhotonManager> ,IPhotonPeerListener
{
    
    #region Receiver
    /// <summary>
    /// 账号
    /// </summary>
    private AccountReceiver account;
    public AccountReceiver Account
    {
        get
        {
            if(account == null)
                account = FindObjectOfType<AccountReceiver>();
            return account;
        }
    }

    /// <summary>
    /// 角色
    /// </summary>
    private PlayerReceiver player;
    public PlayerReceiver Player
    {
        get
        {
            if(player == null)
                player = FindObjectOfType<PlayerReceiver>();
            return player;
        }
    }

    #endregion

    #region Photon接口
    
    /// <summary>
    /// 客户端
    /// </summary>
    private PhotonPeer _peer;
    /// <summary>
    /// 协议
    /// </summary>
    private ConnectionProtocol _protocol = ConnectionProtocol.Udp;
    /// <summary>
    /// 连接flag
    /// </summary>
    private bool connected = false;
    /// <summary>
    /// 服务器名称
    /// </summary>
    private string applicationName = "MOBA";
    /// <summary>
    /// IP地址
    /// </summary>
    private string serverAddress = "10.9.75.220:5055";
    
    /// <summary>
    /// 服务器给客户端的响应
    /// </summary>
    /// <param name="operationResponse"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void OnOperationResponse(OperationResponse response)
    {
        Debug.Log(response.DebugMessage);
        //主操作
        byte opCode = response.OperationCode;
        //子操作
        byte subCode = (byte)response[80];
        switch (opCode)
        {
            case OpCode.AccountCode:
                Account.OnReceiver(subCode,response);
                break;
            case OpCode.PlayerCode:
                Player.OnReceiver(subCode,response);
                break;
            default:
                break;
        }
        
    }

    /// <summary>
    /// 向服务器发起请求
    /// </summary>
    /// <param name="code">主操作</param>
    /// <param name="subCode">子操作</param>
    /// <param name="parameters">参数</param>
    public void OnRequste(byte code,byte subCode,params object[] parameters )
    {
        
        Dictionary<byte,object> dic = new Dictionary<byte, object>();
        dic[80] = subCode;
        for (int i = 0; i < parameters.Length; i++)
        {
            dic[(byte)i] = parameters[i];
        }
        _peer.OpCustom(code, dic, true);
    }

    /// <summary>
    /// 服务器状态
    /// </summary>
    /// <param name="statusCode"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void OnStatusChanged(StatusCode statusCode)
    {
        //打印当前服务器连接状态
        Debug.Log(statusCode.ToString());
        switch (statusCode)
        {
            case StatusCode.Connect:
                connected = true;
                break;
            case StatusCode.Disconnect:
                connected = false;
                break;
        }
    }
    
    
    /// <summary>
    /// 事件
    /// </summary>
    /// <param name="eventData"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void OnEvent(EventData eventData)
    {
        
    }
    
    public void DebugReturn(DebugLevel level, string message)
    {
        
    }

    #endregion

    #region Unity回调

    protected override void Awake()
    {
        base.Awake();
        _peer = new PhotonPeer(this,_protocol);
        _peer.Connect(serverAddress, applicationName);
    }

    private void Update()
    {
        if (!connected)
        {
            _peer.Connect(serverAddress, applicationName);
        }
        //连接服务器
        _peer.Service();
    }
    
    private void OnApplicationQuit()
    {
        //断开连接
        _peer.Disconnect();
    }

    #endregion
    
}

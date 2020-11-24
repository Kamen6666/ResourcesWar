using ExitGames.Client.Photon;
/// <summary>
/// 客户端收到服务器响应接口
/// </summary>
public interface IReceiver
{
    /// <summary>
    /// 收到服务器响应
    /// </summary>
    /// <param name="subCode">子操作</param>
    /// <param name="response">收到的响应</param>
    void OnReceiver(byte subCode,OperationResponse response); 
}

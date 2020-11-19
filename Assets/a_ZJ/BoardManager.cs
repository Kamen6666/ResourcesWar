using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject GamePlayer;
    //单例
    public static BoardManager instance;
    //棋盘父类
    private GameObject BoardParent;
    //棋盘字典
    private Dictionary<Vector2Int, GameObject> boardDic;
    //移动状态
    private bool IsMoving = false;
    #region 回调
    void Awake()
    {
        //单例
        instance = this;
        //获取棋盘父物体
        BoardParent = GameObject.FindGameObjectWithTag("Board");
        //初始化字典
        boardDic = new Dictionary<Vector2Int, GameObject>();
        //初始化路线
        path = new Stack<AStarBase>();
    }
    void Start()
    {
        //棋盘父物体不存在
        if (!BoardParent)
        {
            //创建
            BoardParent = new GameObject("BoardParent");
            //设置标签
            BoardParent.tag = "Board";
        }
        //创建棋盘字典
        CreateBoardDic();
        //刷漆
        //ShowBoardDic();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //清空路线栈
            path.Clear();
            //点击格子
            MouseClickBoard();
            //启动移动协成
            if (!IsMoving)
                StartCoroutine(BoardMoveToEnd());
        }
    }

    //射线返回值
    RaycastHit raycastHit;
    private void MouseClickBoard()
    {
        //屏幕射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 100f))
        {
            if (raycastHit.transform.CompareTag("BoardItem"))
            {
                Debug.Log(raycastHit.transform.position);

                Vector2Int start = new Vector2Int(Mathf.RoundToInt(GamePlayer.transform.position.x), Mathf.RoundToInt(GamePlayer.transform.position.z));
                Vector2Int end = new Vector2Int(Mathf.RoundToInt(raycastHit.transform.position.x), Mathf.RoundToInt(raycastHit.transform.position.z));

                AStar(start, end);
            }
        }
    }
    /// <summary>
    /// 棋子移动协成
    /// </summary>
    /// <returns></returns>
    IEnumerator BoardMoveToEnd()
    {
        IsMoving = true;
        //去除起点
        path.Pop();
        //启动动画
        GamePlayer.GetComponent<Animator>().SetBool("Walk", true);
        while (path.Count > 0)
        {
            //出栈
            AStarBase current = path.Pop();
            //获取目标坐标
            Vector3 endpoint = boardDic[current.vector2()].transform.position + new Vector3(0, 1, 0);
            //旋转
            int CurrentX = Mathf.RoundToInt(GamePlayer.transform.position.x);
            int CurrentY = Mathf.RoundToInt(GamePlayer.transform.position.z);
            CurrentX -= current.X;
            CurrentY -= current.Y;
            if (CurrentX != 0)
                GamePlayer.transform.eulerAngles = Vector3.up * CurrentX * (-90);
            else if (CurrentY != 0)
                GamePlayer.transform.eulerAngles = Vector3.up * (CurrentY == 1 ? 180 : 0);
            //高度
            float height = endpoint.y - GamePlayer.transform.position.y;
            Debug.Log(height);
            //跳动
            if (height > 0.2f)
            {
                GamePlayer.GetComponent<Animator>().SetTrigger("Jump");
                GamePlayer.GetComponent<Rigidbody>().velocity = Vector3.up * height * 5f + GamePlayer.transform.forward * 0.2f;
                yield return 0;
            }
            //行走
            while (Vector2.Distance(new Vector2(GamePlayer.transform.position.x, GamePlayer.transform.position.z)
                , current.vector2()) > 0.15f)
            {
                GamePlayer.transform.position += GamePlayer.transform.forward * 0.01f;
                yield return 0;
            }
        }
        //关闭动画
        GamePlayer.GetComponent<Animator>().SetBool("Walk", false);
        IsMoving = false;
    }
    #endregion
    /// <summary>
    /// 创建棋盘字典
    /// </summary>
    private void CreateBoardDic()
    {
        //获取Transform组件
        Transform _transform = BoardParent.transform;
        //遍历所有格子
        for (int i = 0; i < _transform.childCount; i++)
        {
            //排除障碍物
            if (!_transform.GetChild(i).CompareTag("BoardItem"))
                continue;
            //获取坐标
            Vector2Int v2 = new Vector2Int((int)_transform.GetChild(i).transform.position.x,
                (int)_transform.GetChild(i).transform.position.z);
            //判断字典内是否存在
            if (boardDic.ContainsKey(v2))
            {
                //获取当前位置最高的方块
                if (_transform.GetChild(i).position.y > boardDic[v2].transform.position.y)
                    boardDic[v2] = _transform.GetChild(i).gameObject;
            }
            else
            {
                boardDic.Add(v2, _transform.GetChild(i).gameObject);
            }
        }
    }
    /// <summary>
    /// 调试用
    /// </summary>
    private void ShowBoardDic()
    {
        //遍历字典
        foreach (GameObject go in boardDic.Values)
        {
            go.transform.localPosition += new Vector3(0, 3, 0);
        }
    }

    #region 搜索设置
    //搜索方向（方格8方向）
    private int[] dirX = { 1, 0, -1, 0, 1, -1, 1, -1 };
    private int[] dirY = { 0, 1, 0, -1, 1, -1, -1, 1 };
    //搜寻数组
    Dictionary<Vector2Int, AStarBase> aStarBase;
    //路线栈
    Stack<AStarBase> path;
    #endregion
    #region A星搜索
    /// <summary>
    /// A*搜索元件
    /// </summary>
    public class AStarBase : IComparable<AStarBase>
    {
        int x, y, g, h, f;
        public AStarBase finder;
        public bool close;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int G { get => g; set => g = value; }
        public int H { get => h; set => h = value; }
        public int F { get => f; set => f = value; }

        //构造方法
        public AStarBase(int x, int y, AStarBase finder)
        {
            X = x;
            Y = y;
            G = 0;
            this.finder = finder;
            close = false;
        }
        //比较坐标
        public bool CompareXY(int x, int y)
        {
            if (X == x && Y == y)
                return true;
            return false;
        }
        //设置观察者
        public void SetWeight(int g, int h, AStarBase finder)
        {
            G = g;
            H = h;
            F = G + H;
            this.finder = finder;
        }
        public Vector2Int vector2()
        {
            return new Vector2Int(X, Y);
        }
        public int CompareTo(AStarBase other)
        {
            if (F < other.F)
                return -1;
            if (F > other.F)
                return 1;
            return 0;
        }
    }
    /// <summary>
    /// 计算格子的观察者
    /// </summary>
    /// <param name="start">起始点坐标</param>
    /// <param name="boards">可移动的范围</param>
    /// <param name="end">目的地坐标</param>
    private void AStar(Vector2Int start, Vector2Int end)
    {


        //设置数组
        aStarBase = new Dictionary<Vector2Int, AStarBase>();
        path = new Stack<AStarBase>();
        //初始化结果
        List<AStarBase> open = new List<AStarBase>();
        //起始点没有观察者
        aStarBase[start] = new AStarBase(start.x, start.y, null);
        //起点入列
        open.Add(aStarBase[start]);
        //有路可走
        while (open.Count > 0)
        {
            //排序
            open.Sort();
            //拿出F值最小的格子
            AStarBase current = open[0];
            //原先高度
            float cuurentHeight = boardDic[current.vector2()].transform.position.y;
            //是否到达终点
            if (current.CompareXY(end.x, end.y))
            {
                //生成路径
                PushPath(current);
                break;
            }
            //遍历周边格子
            for (int i = 0; i < 4; i++)
            {
                //计算新坐标
                int newX = current.X + dirX[i];
                int newY = current.Y + dirY[i];
                Vector2Int newV2 = new Vector2Int(newX, newY);

                //测试
                //Debug.Log("进来了2222" + newV2);
                //排除意外
                //①越界
                //②障碍物
                if (!boardDic.ContainsKey(newV2))
                    continue;
                //赋值
                if (!aStarBase.ContainsKey(newV2))
                    aStarBase[newV2] = new AStarBase(newX, newY, current);
                //①高度差
                if (Math.Abs(boardDic[newV2].transform.position.y - cuurentHeight) > 0.5)
                    continue;
                //③排除观察者
                if (aStarBase[newV2].close)
                    continue;
                //计算格子权重
                int G;
                //测试
                //Debug.Log("进来了3333" + newV2);
                if (dirX[i] == 0 || dirY[i] == 0)
                    G = 10 + current.G;
                else
                    G = 14 + current.G;
                //如果G值为设置 或者 比当前G值大 则重新设置权重和观察者
                if (aStarBase[newV2].G == 0 || G < aStarBase[newV2].G)
                {
                    int H = (end.x - newX > 0 ? end.x - newX : -end.x + newX)
                        + (end.y - newY > 0 ? end.y - newY : -end.y + newY);
                    //设置
                    aStarBase[newV2].SetWeight(G, H, current);
                }
                //是否在待观察数组中
                if (!open.Contains(aStarBase[newV2]))
                    open.Add(aStarBase[newV2]);
            }
            //当前格子观察完毕
            current.close = true;
            //移除当前格子
            open.Remove(current);
        }
    }
    /// <summary>
    /// 路径压栈
    /// </summary>
    /// <param name="Info">终点元件</param>
    private void PushPath(AStarBase Info)
    {
        //近栈
        path.Push(Info);
        if (Info.finder != null)
        {
            //存在观察者则继续压栈
            PushPath(Info.finder);
        }
    }
    #endregion
}

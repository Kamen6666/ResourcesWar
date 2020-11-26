using UnityEngine;
using XLua;
[Hotfix]
public class LuaText : MonoBehaviour
{
    public int id;

    private LuaEnv _luaEnv;

    private string luaTxt = @"
        xlua.hotfix(CS.LuaText,'ChangeID',function()
        print('xlua coming!!!')

        end)
";
    public void ChangeID()
    {
        Debug.Log("C# coming!!!!!");
    }
    void Start()
    {
        _luaEnv = new LuaEnv();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _luaEnv.DoString(luaTxt);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeID();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(id);
        }
    }
}
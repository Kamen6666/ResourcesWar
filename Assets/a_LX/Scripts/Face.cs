using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

public class Face : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.GetInstance().PushModule("SkillTree_Panel");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.GetInstance().PopModule();
        }
    }


}

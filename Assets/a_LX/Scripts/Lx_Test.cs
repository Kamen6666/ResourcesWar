using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lx_Test : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(FindMinArrowShots(new int[][]
         {
            new int[]{10,16},
            new int[]{2,8 },
            new int[]{1,6 },
            new int[]{7,12 }
         }));
    }
    public int FindMinArrowShots(int[][] points)
    {
        List<int[]> list1 = new List<int[]>();
        //遍历给定的i个气球
        for (int i = 0; i < points.Length; i++)
        {
            //第一个气球直接加入List
            if (i == 0)
            {
                list1.Add(points[i]);
                continue;
            }
            bool needAdd = true;
            //遍历List中的气球
            for (int j = 0; j < list1.Count; j++)
            {
                //遍历当前气球的x坐标
                for (int k = 0; k < 2; k++)
                {
                    //如果当前遍历的x坐标在List中气球的坐标内，
                    //则该气球可被同一支箭击破
                    if (points[i][k] >= list1[j][0] && points[i][k] <= list1[j][1])
                    {
                        needAdd = false;
                    }
                }
            }
            //    两个x坐标都不在List中所有气球范围内，将当前气球添加到List
            if (needAdd)
            {
                list1.Add(points[i]);
            } 
        }
        return list1.Count;
    }

    public void Test()
    {
        
    }
}

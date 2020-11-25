using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class ZYX_Player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int a = Random.Range(1, 16);
            KnapsackPanel.Instance.StoreItem(a);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerInfoPanel.Instance.RefeshPlayerItem(1);
            PlayerInfoPanel.Instance.SaveAllPlayerInfo();
            //  DataMrg.Instance.SavePlayerDataJson();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            DataMrg.Instance.ParsePlayerItemJson();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            InventoryManager.Instance.GetItemById(10);
        }
        
    }
}

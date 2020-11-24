using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class KnapsackPanel : Inventory
{


    private Button sort;
    
    public static KnapsackPanel Instance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KnapsackPanel.Instance.Hide();
        }
    }
    
    private void Awake()
    {
        Instance = this;
    }

    public override void Start()
    { 
        sort = transform.Find("Sort").GetComponent<Button>();
        sort.onClick.AddListener(() =>
        {
            base.SortSlot();
        }); 
        base.Start();
    }
}

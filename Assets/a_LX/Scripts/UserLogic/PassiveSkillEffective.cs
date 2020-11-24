using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkillEffective : MonoBehaviour
{
    RectTransform parentRect;
    public float speed = 1f;
    Vector3[] v;
    Vector3 target;
    int i = 3;
    private void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
        v = new Vector3[4];
    }
    private void Start()
    {
        parentRect.GetLocalCorners(v);
        //for (int i = 0; i < v.Length; i++)
        //{
        //    Debug.Log(v[i]);
        //}
        StartCoroutine(Move());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StopCoroutine(Move());
        }
    }
    private IEnumerator Move()
    { 
        while (true)
        {
            target = v[i++ % v.Length];
           while(Vector3.Distance(transform.localPosition,target)>speed)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition,target,speed);
                yield return 0;
            }
            transform.localPosition = target;
            yield return new WaitForSeconds(0.2f);
        }
    }
}

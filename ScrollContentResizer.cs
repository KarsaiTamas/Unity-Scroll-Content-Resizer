using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContentResizer : MonoBehaviour
{
    //
    public bool isGoingDown;
    public bool both = false;
    public RectTransform rectTransform;
    int childCount;

    void Start()
    {
         
        UpdateContentSize(); 
    }

    public void UpdateContentSize()
    {
        float sizex = 0;
        float sizey = 0;
         
        childCount = transform.childCount;
         
        foreach (RectTransform item in transform)
        {
            if (item.gameObject.activeSelf)
            {
                sizey += item.sizeDelta.y+50;
                sizex += item.sizeDelta.x+50;
            }
        }
        sizey += 100;
        sizex += 100;
        if (!both)
        {
            if (isGoingDown)
            {
                sizex = rectTransform.sizeDelta.x;
            }
            else
            {
                sizey = rectTransform.sizeDelta.y;

            }

        }
        rectTransform.sizeDelta = new Vector2(sizex, sizey);

        
    }
    private void Update()
    {
        if (childCount!=transform.childCount && isUpdated)
        {
            Debug.Log("updated scroll");
            isUpdated = false;
            UpdateContentSize();
        }
    }
}

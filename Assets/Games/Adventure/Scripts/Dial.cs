using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Unity.VisualScripting;
using System;

public class Dial : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private ActionListAsset m_DialUpActionList;
    [SerializeField] private ActionListAsset m_DialDownActionList;
    [SerializeField] private Transform m_DialTransform;
    [SerializeField] private List<int> m_Numbers;
    [SerializeField] private Puzzlemanager m_Puzzlemanager;

    private Vector3 startPosition;
    private int m_CurrentIndex = 2;

    public int _DesiredValue;
    public String _VariableName;

    #region to update disgits while swipe up and swipe down
    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float verticalMovement = eventData.position.y - eventData.pressPosition.y;

        // Check if it's moving up or down
        if (verticalMovement > 0)
        {
            if (m_CurrentIndex < m_Numbers.Count - 1)
            {
                m_CurrentIndex += 1;
                m_DialDownActionList.Interact();
            }
        }
        else if (verticalMovement < 0)
        {
            if (m_CurrentIndex > 0)
            {
                m_CurrentIndex -= 1;
                m_DialUpActionList.Interact();
            }
        }
        if (m_CurrentIndex >= 0 && m_CurrentIndex < m_Numbers.Count)
        {
            GVar myVariable = GlobalVariables.GetVariable(_VariableName);
            if (myVariable != null)
            {
                myVariable.IntegerValue = m_Numbers[m_CurrentIndex];
            }
        }
        m_Puzzlemanager.PuzzleComplete();

    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;
using UnityEngine.EventSystems;
using DG.Tweening;
public class CanvasManager : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private ActionListAsset m_PuzzleLoadAction;

    [SerializeField] private GameObject m_CanvasButton;

    [SerializeField] private GameObject m_Puzzle;

    #region Puzzle load and close
    //to load the puzzle
    public IEnumerator LoadPuzzle()
    {
        if (m_PuzzleLoadAction != null)
        {
            m_PuzzleLoadAction.Interact();
        }
        yield return new WaitForSeconds(1.3f);
        HandleCanvasButton(true);
    }

    //to close puzzle
    public void ClosePuzzle()
    {
        m_Puzzle.transform.DOScale(Vector3.zero, 1.2f).OnComplete(() =>
        {
            HandleCanvasButton(false);
        });
    }
   
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(LoadPuzzle());
    }
    #endregion

    private void HandleCanvasButton(bool visible)
    {
        if (m_CanvasButton != null)
        {
            m_CanvasButton.SetActive(visible);
        }
    }
}

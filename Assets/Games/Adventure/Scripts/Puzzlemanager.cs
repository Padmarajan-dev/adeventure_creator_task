using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;
public class Puzzlemanager : MonoBehaviour
{
    [SerializeField] List<Dial> m_Dials;
    [SerializeField] AC.ActionListAsset m_PuzzleComplete;

    // to check puzzle got completed
    public void PuzzleComplete()
    {
        foreach(Dial dial in m_Dials)
        {
            GVar myVariable = GlobalVariables.GetVariable(dial._VariableName);
            if (myVariable.IntegerValue != dial._DesiredValue)
            {
                return;
            }
        }
        if(m_PuzzleComplete != null)
        {
            m_PuzzleComplete.Interact();
        }
        
    }
}

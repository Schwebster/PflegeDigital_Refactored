using Assets.Scripts.Lists;
using Assets.Scripts.WorksequenceClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoadWorkSequence : MonoBehaviour
{
    WorksequenceListLoadManager worksequenceListLoadManager;

    void Awake()
    {
        worksequenceListLoadManager = GameObject.FindGameObjectWithTag("Main").GetComponent<WorksequenceListLoadManager>();
        foreach (WorkSequence workSeq in worksequenceListLoadManager.workSequenceList.list)
        {
            GameObject button = new GameObject(workSeq.sequenceID);
            button.transform.SetParent(this.transform);
        }
    }

}

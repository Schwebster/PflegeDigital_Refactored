using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Lists
{
    public class WorksequenceList
    {
        public List<WorkSequence> list {  get; private set; }

        public WorksequenceList()
        {
            list = new List<WorkSequence>();
        }

        public WorkSequence GetWorkSequence(string name) {
            foreach (WorkSequence workSeq in list) { 
                if (workSeq.sequenceID == name) { return workSeq; } 
            }
            throw new Exception(name + " does not exist");
        }
        public void Add(WorkSequence workSeq)
        {
            list.Add(workSeq);
        }
    }
}

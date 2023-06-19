using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using UnityEngine.UIElements;

public class WorksequenceTest
{
    [UnityTest]
    public IEnumerator All_ObjectPlaces_Of_Every_Worksequence_Are_Loaded()
    {

        var worksequenceLM = new WorksequenceListLoadManager();
        List<WorkSequence> list = worksequenceLM.workSequenceList.list;
        int objectPlacesCount = GameObject.FindGameObjectsWithTag("ObjectPlace").Length;

        bool listIsLoaded = true;

        foreach (WorkSequence worksequence in list)
        {
            if (worksequence.objectPlaceList.list.Count != objectPlacesCount)
            {
                listIsLoaded = false;
                Debug.Log("Listlength is of Worksequence " + worksequence.sequenceID + " is " + worksequence.objectPlaceList.list.Count + " but should be " + objectPlacesCount);
                break;
            }
        }

        yield return null;

        Assert.IsTrue(listIsLoaded);
    }

    [UnityTest]
    public IEnumerator All_ObjectPlaces_Of_Every_Worksequence_With_Object_Have_Name_For_ObjectName()
    {
        var worksequenceLM = new WorksequenceListLoadManager();
        List<WorkSequence> list = worksequenceLM.workSequenceList.list;

        bool placesHaveRightObjects = true;

        foreach (WorkSequence worksequence in list)
        {
            var objectPlaces = worksequence.objectPlaceList.list;
            var objectPositions = worksequence.usableObjectList.list;

            foreach (ObjectPlace place in objectPlaces)
            {
                foreach (UsableObject objPosition in objectPositions)
                {
                    if (place.position == objPosition.position && objPosition.objectName != "Dish")
                    {
                        if (worksequence.GetPlace(place.name).objectName != objPosition.objectName)
                        {
                            placesHaveRightObjects = false;
                            Debug.Log(place.name + " has not " + objPosition.objectName + " set as objectName.");
                            //break;
                        }
                        if (!worksequence.GetPlace(place.name).hasItem)
                        {
                            placesHaveRightObjects = false;
                            Debug.Log(place.name + " has boolObject not set on true but same position as Object " + objPosition.objectName);
                            //break;
                        }
                    }
                }
            }
        }

        yield return null;

        Assert.IsTrue(placesHaveRightObjects);
    }

    [UnityTest]
    public IEnumerator All_Objects_Of_Every_Worksequence_Have_Different_Position()
    {
        var worksequenceLM = new WorksequenceListLoadManager();
        List<WorkSequence> list = worksequenceLM.workSequenceList.list;

        bool allObjectsHaveDifferentPositions = true;

        foreach (WorkSequence worksequence in list)
        {
            var usableObjList = worksequence.usableObjectList.list;

            foreach (var pos1 in usableObjList)
            {
                foreach (var pos2 in usableObjList)
                {
                    if (!pos1.objectName.Equals(pos2.objectName))
                    {
                        if (pos1.position == pos2.position)
                        {
                            allObjectsHaveDifferentPositions = false;
                            Debug.Log(pos1.objectName + " and " + pos2.objectName + " have the same Position.");
                        }
                    }
                }
            }
        }

        yield return null;

        Assert.IsTrue(allObjectsHaveDifferentPositions);
    }

    [UnityTest]
    public IEnumerator All_ObjectPlaces_Of_Every_Worksequence_Have_Different_Position()
    {
        var worksequenceLM = new WorksequenceListLoadManager();
        List<WorkSequence> list = worksequenceLM.workSequenceList.list;

        bool allObjectPlacesHaveDifferentPositions = true;

        foreach (WorkSequence worksequence in list)
        {
            var objPlaceList = worksequence.objectPlaceList.list;

            foreach (var place1 in objPlaceList)
            {
                foreach (var place2 in objPlaceList)
                {
                    if (!place1.name.Equals(place2.name))
                    {
                        if (place1.position == place2.position)
                        {
                            allObjectPlacesHaveDifferentPositions = false;
                            Debug.Log(place1.objectName + " and " + place2.objectName + " have the same Position.");
                        }
                    }
                }
            }
        }

        yield return null;

        Assert.IsTrue(allObjectPlacesHaveDifferentPositions);
    }

    [UnityTest]
    public IEnumerator All_UsableObjects_Of_Every_Worksequence_Are_Loaded()
    {
        var worksequenceLM = new WorksequenceListLoadManager();
        List<WorkSequence> list = worksequenceLM.workSequenceList.list;
        int objectCount = GameObject.FindGameObjectsWithTag("ObjectWithTooltip").Length;

        bool listIsLoaded = true;

        foreach (WorkSequence worksequence in list)
        {
            if (worksequence.usableObjectList.list.Count != objectCount)
            {
                listIsLoaded = false; break;
            }
        }

        yield return null;

        Assert.IsTrue(listIsLoaded);
    }

    [UnityTest]
    public IEnumerator All_UsableObjects_Of_Every_Worksequence_Have_ObjectPlace()
    {
        var worksequenceLM = new WorksequenceListLoadManager();
        List<WorkSequence> list = worksequenceLM.workSequenceList.list;

        bool allPositionsHavePlace = true;
        
        foreach (WorkSequence worksequence in list)
        {
            var objectPositions = worksequence.usableObjectList.list;
            var objectPlaces = worksequence.objectPlaceList.list;

            foreach (UsableObject pos in objectPositions)
            {
                if (pos.objectName != "Tissue" && 
                    pos.objectName != "Rubbish" &&
                    pos.objectName != "CompressAtHand" &&
                    pos.objectName != "FixationTape" &&
                    pos.objectName != "CelluloseOnDish" &&
                    pos.objectName != "OldDressingInDish" &&
                    pos.objectName != "SwabInDish1" &&
                    pos.objectName != "SwabInDish2" &&
                    pos.objectName != "TweezerAtHand" &&
                    pos.objectName != "SwabOnTweezer")
                {
                    if (pos.place == null)
                    {
                        allPositionsHavePlace = false;
                        Debug.Log("Position of " + pos.objectName + " in Worksequence " + worksequence.sequenceID + " has no ObjectPlace.");

                        foreach (var place in GameObject.FindGameObjectsWithTag("ObjectPlace"))
                        {
                            if ("ObjectPlace_" + pos.objectName == place.name)
                            {
                                Debug.Log("Empty place " + place.name + " in Worksequence " + worksequence.sequenceID + " has position " + place.transform.position +
                                    " and Object " + pos.objectName + " has position " + pos.position);
                            }
                        }
                        //break;
                    }
                }
            }

            yield return null;

            Assert.IsTrue(allPositionsHavePlace);
        }
    }

    [UnityTest]
    public IEnumerator All_ObjectPlaces_Of_Every_Worksequence_With_No_Object_Have_Empty_Name_For_ObjectName()
    {
        var worksequenceLM = new WorksequenceListLoadManager();
        List<WorkSequence> list = worksequenceLM.workSequenceList.list;
        yield return null;
        
        bool placesWithNoObjectsHaveRightSettings = true;


        foreach (WorkSequence worksequence in list)
        {
            var positions = worksequence.usableObjectList.list;
            var places = worksequence.objectPlaceList.list;
            foreach (ObjectPlace place in places)
            {
                bool hasObject = false;
                foreach (var position in positions)
                {
                    if (place.position == position.position)
                    {
                        hasObject = true;
                    }
                }
                if (!hasObject)
                {
                    if (worksequence.GetPlace(place.name).hasItem)
                    {
                        placesWithNoObjectsHaveRightSettings = false;
                        Debug.Log("Empty place " + place.name + " in Worksequence " + worksequence.sequenceID + " has boolObject set on true");
                        break;
                    }
                    if (worksequence.GetPlace(place.name).objectName != "")
                    {
                        placesWithNoObjectsHaveRightSettings = false;
                        Debug.Log("Empty place " + place.name + " in Worksequence " + worksequence.sequenceID + " has objectName not NULL");
                        break;
                    }
                }
            }
        }

        yield return null;

        Assert.IsTrue(placesWithNoObjectsHaveRightSettings);
    }
}

using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace Assets.Scripts.Lists
{
    public class UsableObjectList
    {
        public List<UsableObject> list { get; private set; }
       
        public UsableObjectList() {             
            list = new List<UsableObject>();   
        }

        public UsableObject UsableObject(string objName)
        {
            foreach (UsableObject usableObj in list)
            {
                if(usableObj.objectName == objName)
                {
                    return usableObj;
                }
            }
            Debug.Log(objName + " does not exist in List with length: " +  list.Count.ToString());
            return null;
        }
        public void SetPosition(string name, ObjectPlace position)
        {
            UsableObject(name).SetPosition(position);
        }
        public void SetObjectPlaces(ObjectPlaceList objectPlaceList)
        {
            foreach (ObjectPlace place in objectPlaceList.list)
            {
                foreach (UsableObject pos in list)
                {
                    if (place.position == pos.position)
                    {
                        pos.SetPosition(place);
                    }
                }
            }
        }
        public void InitializeStartList()
        {
            list = new List<UsableObject>();
            foreach (GameObject _object in GameObject.FindGameObjectsWithTag("ObjectWithTooltip"))
            {
                UsableObject usableObject = new UsableObject(_object.name, _object.transform.position);
                
                /*
                if (_object.name.Equals("Tissue") ||
                    _object.name.Equals("OldDressing") ||
                    _object.name.Equals("CompressAtHand") ||
                    _object.name.Equals("CompressOnArm") ||
                    _object.name.Equals("CelluloseUnderArm") ||
                    _object.name.Equals("TweezerAtHand") ||
                    _object.name.Equals("SwabOnTweezer") ||
                    _object.name.Equals("CelluloseOnDish") ||
                    _object.name.Equals("OldDressingInDish") ||
                    _object.name.Equals("SwabInDish1") ||
                    _object.name.Equals("SwabInDish2") ||
                    _object.name.Equals("") ||
                    _object.name.Equals(""))
                {
                    usableObject.SetActive(true);
                }
                else
                {
                } 
                */
                usableObject.SetActive(true);

                if (_object.GetComponent<Collider>() != null)
                {
                    usableObject.SetColliderActive(_object.GetComponent<Collider>().enabled);
                }
                list.Add(usableObject);              
            }
        }
        public void Substitute(List<UsableObject> objects) {
            list = new List<UsableObject>();
            foreach (UsableObject _usableObject in objects) {
                UsableObject usableObject = new UsableObject(_usableObject.objectName, _usableObject.position);
                usableObject.SetPlace(_usableObject.place);
                usableObject.SetActive(_usableObject.isActive);
                usableObject.SetColliderActive(_usableObject.isColliderActive);
                list.Add(usableObject);

            }
        }
    }
}

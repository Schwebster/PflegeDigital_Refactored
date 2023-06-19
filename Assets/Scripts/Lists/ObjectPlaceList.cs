using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.Scripts.Lists
{
    public class ObjectPlaceList
    {
        public List<ObjectPlace> list {  get; private set; }

        public ObjectPlaceList()
        {
            list = new List<ObjectPlace>();
        }

        public void InitializeStartList()
        {
            list = new List<ObjectPlace>();

            GameObject[] objectPlaces = GameObject.FindGameObjectsWithTag("ObjectPlace");
            foreach (GameObject objPlace in objectPlaces) { list.Add(new ObjectPlace(objPlace.name, objPlace.transform.position)); }
        }
        public void Substitute(List<ObjectPlace> objectPlaces)
        {
            list = new List<ObjectPlace>();

            foreach (ObjectPlace objPlace in objectPlaces)
            {
                list.Add(new ObjectPlace(objPlace.name, objPlace.position));
                Place(objPlace.name).SetObject(objPlace.objectName);
                Place(objPlace.name).SetBoolItem(objPlace.hasItem);
            }
        }
        public ObjectPlace Place(String name)
        {
            foreach (ObjectPlace objPlace in list)
            {
                if (objPlace.name.Equals(name)){
                    return objPlace;
                }
            }
            throw new Exception("ObjectPlace: " + name + " not found.");
        }
        public void SetUsableObjects(UsableObjectList usableObjectList)
        {
            foreach (ObjectPlace place in list)
            {
                foreach (UsableObject usableObjects in usableObjectList.list)
                {
                    if (usableObjects.position == place.position) {                        
                        place.SetObject(usableObjects.objectName);
                    }
                }
            }
        }
    }
}

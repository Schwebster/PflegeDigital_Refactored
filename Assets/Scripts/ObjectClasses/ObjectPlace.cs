using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System;
using UnityEditor;
using UnityEngine;


namespace Assets.Scripts.ObjectClasses
{
    public class ObjectPlace
    {
        public string name { get; private set; }
        public string objectName { get; private set; }
        public Vector3 position { get; private set; }
        public bool hasItem { get; private set; }

        public ObjectPlace(string _name, Vector3 _position)
        {
            objectName = "";
            name = _name;
            position = _position;
            hasItem = false;
        }

        public void SetBoolItem(bool hasObject) { hasItem = hasObject; }
        public void SetObject(string objName) {

            objectName = objName;

            if (objectName == "")  {  hasItem = false; }
            else { hasItem = true; }
        }
    }
}

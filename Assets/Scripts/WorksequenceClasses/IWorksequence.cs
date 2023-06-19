using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.WorksequenceClasses
{   
    public interface IWorkSequence
    {
        public UsableObject GetUsableObject(string name);
        public ObjectPlace GetPlace(string name);
        public Icon GetIcon(string name);
        public void Initialize();
        public void Substitute(WorkSequence sequence);
        public void PlaceObject(string obj, string place);
        public void SetStartingWorksequence();
    }

    public class WorkSequence : IWorkSequence
{
        public string sequenceID { get; private set; }
        public UsableObjectList usableObjectList { get; private set; }
        public ObjectPlaceList objectPlaceList { get; private set; }
        public IconList iconList { get; private set; }
        public ObjectModelList objectModelList { get; private set; }
        public HitplaneList hitplaneList { get; private set; }
        public ItemList items { get; private set; }
        public ObjectAnimationList objectAnimationList { get; private set; }
        public string objectAllowedToUse { get; private set; }
        public string itemAtHand { get; private set; }
        public bool bedIsUp { get; set; }
        public bool lidIsUp { get; set; }

        public WorkSequence(string id)
        {
            sequenceID = id;
            objectAllowedToUse = "";
            itemAtHand = "";
            usableObjectList = new UsableObjectList();
            objectPlaceList = new ObjectPlaceList();
            objectModelList = new ObjectModelList();
            iconList = new IconList();
            hitplaneList = new HitplaneList();
            objectAnimationList = new ObjectAnimationList();
            //Debug.Log("New worksequence with ID " + sequenceID);
        }

        public UsableObject GetUsableObject(string name) { 
            foreach (UsableObject obj in usableObjectList.list) { 
                if (obj.objectName.Equals(name)) { return obj; } 
            }
            throw new Exception(name + " does not exist in usableObjectList of " + sequenceID);
        }
        public ObjectPlace GetPlace(string name)
        {
            foreach (ObjectPlace objPlace in objectPlaceList.list)
            {
                if (objPlace.name.Equals(name)) { return objPlace; }
            }
            throw new Exception(name + " does not exist in objectPlaceList of " + sequenceID);
        }
        public Icon GetIcon(string name)
        {
            foreach (Icon icon in iconList.list)
            {
                if (icon.name.Equals(name)) { return icon; }
            }
            throw new Exception(name + " does not exist in iconList of " + sequenceID);
        }
        public ObjectModel GetModel(string name)
        {
            foreach (ObjectModel model in objectModelList.list)
            {
                if (model.name.Equals(name))
                {
                    return model;
                }
            }
            throw new Exception("Model with name: " + name + " in " + sequenceID + " does not exist.");
        }
        public Hitplane GetHitplane(string name)
        {
            foreach (Hitplane hitplane in hitplaneList.list)
            {
                if (hitplane.name.Equals(name))
                {
                    return hitplane;
                }
            }
            throw new Exception("Model with name: " + name + " in " + sequenceID + " does not exist.");
        }
        public void Initialize()
        {
            Debug.Log(sequenceID + " initialized.");

            foreach (GameObject objectPlace in GameObject.FindGameObjectsWithTag("ObjectPlace")) 
            {
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("ObjectWithTooltip"))
                {
                    foreach (UsableObject usableObject in usableObjectList.list)
                    {
                        if (usableObject.objectName.Equals(item.name))
                        {
                            item.transform.position = usableObject.position;
                            item.SetActive(usableObject.isActive);
                            if (objectPlace.transform.position == item.transform.position)
                            {
                                item.transform.rotation = objectPlace.transform.rotation;
                            }
                        }
                    }
                }
            }              
            foreach (GameObject iconObj in GameObject.FindGameObjectsWithTag("Icon"))
            {
                foreach (Icon icon in iconList.list)
                {
                    if (iconObj.name.Equals(icon.name))
                    {
                        iconObj.GetComponent<RawImage>().enabled = icon.isActive;
                    }
                }
            }
            foreach (GameObject hitplaneObj in GameObject.FindGameObjectsWithTag("Hitplane"))
            {
                foreach (Hitplane hitplane in hitplaneList.list)
                {
                    if (hitplaneObj.name.Equals(hitplane.name))
                    {
                        hitplaneObj.GetComponent<MeshCollider>().enabled = hitplane.isActive;
                    }
                }
            }
            foreach (GameObject modelObj in items.modelList)
            {
                foreach (ObjectModel model in objectModelList.list)
                {
                    if (modelObj.name.Equals(model.name))
                    {
                        modelObj.GetComponent<MeshRenderer>().enabled = model.isActive;
                    }
                }
            }
            foreach (GameObject usableObj in items.itemList)
            {
                foreach (UsableObject usableObject in usableObjectList.list)
                {
                    if (usableObj.name.Equals(usableObject.objectName) && usableObj.GetComponent<BoxCollider>() != null)
                    {
                        usableObj.GetComponent<BoxCollider>().enabled = usableObject.isColliderActive;
                        usableObj.SetActive(usableObject.isActive);
                    }
                }
            }
            foreach (ObjectAnimation objAnimation in objectAnimationList.list)
            {
                if (!objAnimation.alreadyPlayed)
                {
                    objAnimation.Rewind();
                }
            }
        }
        public void Substitute(WorkSequence sequence)
        {
            usableObjectList.Substitute(sequence.usableObjectList.list);
            objectPlaceList.Substitute(sequence.objectPlaceList.list);
            iconList.Substitute(sequence.iconList.list);
            objectModelList.Substitute(sequence.objectModelList.list);
            hitplaneList.Substitute(sequence.hitplaneList.list);
            objectAnimationList.Substitute(sequence.objectAnimationList.list);
            bedIsUp = sequence.bedIsUp;
            lidIsUp = sequence.lidIsUp;
            items = sequence.items;
        }
        public void PlaceObject(string obj, string place)
        {
            GetPlace(GetUsableObject(obj).place.name).SetObject("");
            GetUsableObject(obj).SetPosition(GetPlace(place));
            GetPlace(place).SetObject(obj);
        }
        public void SetStartingWorksequence()
        {
            usableObjectList.InitializeStartList();
            objectPlaceList.InitializeStartList();
            usableObjectList.SetObjectPlaces(objectPlaceList);
            objectPlaceList.SetUsableObjects(usableObjectList);
            iconList.InitializeStartList();
            objectModelList.InitializeStartList();
            hitplaneList.InitializeStartList();
            objectAnimationList.InitializeStartList();
            items = new ItemList();
            bedIsUp = false;
            lidIsUp = false;
        }
        public void SetAllowedToUse(string name) { objectAllowedToUse = name; }
        public void SetWorkplateActive(bool active)
        {
            GetHitplane("Hitplane_Safebox").SetActive(active);
            GetHitplane("Hitplane_Fixation").SetActive(active);
            GetHitplane("Hitplane_WoundDisinfectant").SetActive(active);
            GetHitplane("Hitplane_Mask").SetActive(active);
            GetHitplane("Hitplane_Compress").SetActive(active);
            GetHitplane("Hitplane_Swab").SetActive(active);
            GetHitplane("Hitplane_Tweezer").SetActive(active);
            GetHitplane("Hitplane_Scissors").SetActive(active);
            GetHitplane("Hitplane_Dish").SetActive(active);
            GetHitplane("Hitplane_Cellulose").SetActive(active);
        }
        public void SetItemAtHand(string name)
        {
            itemAtHand = name;
        }
        public void SetAnimationPlayed(string name, bool played)
        {
            objectAnimationList.GetAnimation(name).SetAnimationPlayed(played);
        }
    }
}

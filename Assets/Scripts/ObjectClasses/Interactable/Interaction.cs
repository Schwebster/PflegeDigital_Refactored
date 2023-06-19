using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using UnityEngine;

namespace Assets.Scripts.ObjectClasses.InteractClasses
{
    public class Interaction
    {
        private ItemList _items;
        
        public Interaction() { 
            _items = new ItemList();
        }

        public void TakeItem(string itemName)
        {
            /*
            if (_items.Item(itemName).GetComponent<Collider>() != null)
            {
                _items.Item(itemName).GetComponent<Collider>().enabled = false;
            }
            */
        }

        public void HoldItem(string itemName)
        {
            GameObject go = _items.Item(itemName);

            if (go != null)
            {
                go.transform.position = Camera.main.transform.position + 
                    Camera.main.transform.forward * 1;
                go.transform.Translate(new Vector3(0, -0.2f, -0.5f));
                go.transform.rotation = new Quaternion(
                    0.0f, Camera.main.transform.rotation.y, 
                    0.0f, Camera.main.transform.rotation.w);
            }
        }
        public void ReplaceItem(UsableObject itemAtHand, UsableObject itemAtSight)
        {
            itemAtHand.SetPlace(itemAtSight.place);
            itemAtSight.place.SetBoolItem(true);
            itemAtSight.place.SetObject(itemAtHand.objectName);

            //transform object
            itemAtHand.SetPosition(itemAtSight.place);
            _items.Item(itemAtHand.objectName).GetComponent<Collider>().enabled = true;
            _items.Item(itemAtSight.objectName).SetActive(false);
        }

        public void PlaceItem(UsableObject itemAtHand, ObjectPlace placeAtSight)
        {
            if (!placeAtSight.hasItem)
            {
                itemAtHand.SetPlace(placeAtSight);
                placeAtSight.SetBoolItem(true);
                placeAtSight.SetObject(itemAtHand.objectName);

                //transform object
                itemAtHand.SetPosition(placeAtSight);
                _items.Item(itemAtHand.objectName).GetComponent<Collider>().enabled = true;
            }
        }
        
    }
}
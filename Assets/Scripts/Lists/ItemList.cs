using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Lists
{
    public class ItemList
    {
        public GameObject[] itemList {  get; private set; }
        public GameObject[] modelList { get; private set; }

        public ItemList() {
            itemList = GameObject.FindGameObjectsWithTag("ObjectWithTooltip");
            modelList = GameObject.FindGameObjectsWithTag("ObjectModel");
        }

        public GameObject Item(string name)
        {
            foreach (GameObject item in itemList)
            {
                if (item.name == name)
                {
                    return item;
                }
            }
            throw new Exception("Item " +  name + " does not Exist.");
        }

        public GameObject Model(string name)
        {
            foreach (GameObject model in modelList)
            {
                if (model.name == name)
                {
                    return model;
                }
            }
            throw new Exception("Model " + name + " does not Exist.");
        }

    }
}

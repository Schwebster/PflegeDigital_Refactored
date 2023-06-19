using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ObjectClasses;
using UnityEngine;

namespace Assets.Scripts.Lists
{
    public class ObjectModelList
    {
        public List<ObjectModel> list { get; private set; }

        public ObjectModelList() {
            list = new List<ObjectModel>();
        }

        public void InitializeStartList()
        {
            foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag("ObjectModel"))
            {
                if (gameObj.GetComponent<MeshRenderer>() == null)
                {
                    throw new Exception(gameObj.name + " has no Renderer.");
                }
                bool rendererEnabled = gameObj.GetComponent<MeshRenderer>().enabled;
                list.Add(new ObjectModel(gameObj.name, rendererEnabled));
            }
        }

        public void Substitute(List<ObjectModel> _list)
        {
            list = new List<ObjectModel>();
            foreach (ObjectModel model in _list)
            {
                list.Add(new ObjectModel(model.name, model.isActive));
            }
        }
    }
}

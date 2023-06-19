using Assets.Scripts.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Lists
{
    public class HitplaneList
    {
        public List<Hitplane> list { get; private set; }
        public HitplaneList()
        {
            list = new List<Hitplane>();
        }

        public void InitializeStartList()
        {
            list = new List<Hitplane>();
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Hitplane"))
            {
                Hitplane hitplane = new Hitplane(gameObject.name, gameObject.transform.position);
                hitplane.SetActive(gameObject.GetComponent<MeshCollider>().enabled);
                list.Add(hitplane);
            }
        }

        public void Substitute(List<Hitplane> _list)
        {
            list = new List<Hitplane>();
            foreach (Hitplane _hitplane in _list)
            {
                Hitplane hitplane = new Hitplane(_hitplane.name, _hitplane.position);
                hitplane.SetActive(_hitplane.isActive);
                list.Add(hitplane);
            }
        }
    }
}

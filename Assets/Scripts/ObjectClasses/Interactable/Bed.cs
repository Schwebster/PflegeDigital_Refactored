using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObjectClasses.InteractClasses
{
    public class Bed : MonoBehaviour
    {
        public bool bedIsUp { get; private set; }
        public Vector3 up { get; private set; }
        public Vector3 down { get; private set; }

        void Awake()
        {
            down = GameObject.Find("Scene/Objects/Bed/Bed_Model/Bed").transform.position;
            up = down + Vector3.up * 0.25f;
        }

        public void Up() { if (up != Vector3.zero) transform.position = up; }
        public void Down() { if (up != Vector3.zero) transform.position = down; }
    }
}

using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using UnityEngine;

namespace Assets.Scripts.PlayerClasses
{
    public class CastRaycast
    {
        public GameObject itemAtSight { get; private set; }
        public string itemAtHand { get; private set; }
        public string workSequenceID { get; private set; }
        private float distanceToSee = 3f, raycastStartRange = 0.3f;
        private RaycastHit objectAtTarget;
        private Vector3 raycastDirection, raycastOrigin;

        public CastRaycast()
        {
            itemAtHand = "";
        }

        public void RaycastSight(GameObject mainCamera)
        {
            raycastDirection = mainCamera.transform.forward;
            raycastOrigin = mainCamera.transform.position + (raycastDirection * raycastStartRange);

            if (mainCamera.activeInHierarchy && 
                Time.timeScale != 0 &&
                Physics.Raycast(raycastOrigin, raycastDirection, out objectAtTarget, distanceToSee))
            {
                itemAtSight = objectAtTarget.collider.gameObject;
            }

            // show ray of raycast
            Debug.DrawRay(raycastOrigin, mainCamera.transform.forward * distanceToSee, Color.magenta);
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * raycastStartRange, Color.blue);
            //Debug.Log("Raycast at: " + itemAtSight.name);
        }

        public void SetItemAtHand(string name, string _workSequenceID)
        {
            itemAtHand = name;
            workSequenceID = _workSequenceID;
        }
    }
}

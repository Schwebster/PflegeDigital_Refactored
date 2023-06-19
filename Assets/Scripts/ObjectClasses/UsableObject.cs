using UnityEngine;

namespace Assets.Scripts.ObjectClasses
{
    public class UsableObject
    {
        public string objectName { get; private set; }
        public Vector3 position { get; private set; }
        public Vector3 lastPosition { get; private set; }
        public ObjectPlace place { get; private set; }
        public bool isActive { get; private set; }
        public bool isColliderActive { get; private set; }

        public UsableObject(string objName, Vector3 pos)
        {
            position = pos;
            objectName = objName;
        }

        public void SetPosition(ObjectPlace _place)
        {
            place = _place;
            position = _place.position;
        }       
        public void SetLastPosition() { lastPosition = position; }
        public void SetPlace(ObjectPlace _place) { place = _place; }
        public void SetActive(bool _isActive) { isActive = _isActive; }
        public void SetColliderActive(bool _isColliderActive) { isColliderActive = _isColliderActive; }
    }
}
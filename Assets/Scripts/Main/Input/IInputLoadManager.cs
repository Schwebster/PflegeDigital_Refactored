using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface IInputLoadManager
    {
        public void UpdateValues();
        public bool Menu();
        public bool Action();
        public float MoveZ();
        public float MoveX();
        public float LookY();
        public float LookX();
    }

    public class InputLoadManager : IInputLoadManager
    {
        public IUnityService unityService;

        private bool _menuKey, _actionKey;
        private float _moveAxisZ, _moveAxisX,
            _lookAxisX, _lookAxisZ;

        public InputLoadManager()
        {
            unityService = new UnityService();
        }

        public void UpdateValues()
        {
            _menuKey = unityService.GetKeyDown(KeyCode.Escape);
            _actionKey = unityService.GetMouseButtonUp(0);
            _moveAxisZ = unityService.GetAxis("Vertical");
            _moveAxisX = unityService.GetAxis("Horizontal");
            _lookAxisX = unityService.GetAxis("Mouse X");
            _lookAxisZ = unityService.GetAxis("Mouse Y");
        }

        public bool Menu() { return _menuKey; }

        public bool Action() { return _actionKey; }

        public float MoveZ() { return _moveAxisZ; }

        public float MoveX() { return _moveAxisX; }

        public float LookY() { return _lookAxisX; }

        public float LookX() { return _lookAxisZ; }
    }    
}


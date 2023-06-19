using Assets.Scripts.Lists;
using Assets.Scripts.TooltipClasses;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using UnityEngine;

namespace Assets.Scripts.PlayerClasses
{
    public class Player : MonoBehaviour
    {
        private CharacterController _characterController;
        private TooltipManager _tooltipManager;
        private HeadMovement headMovement;
        public BodyMovement bodyMovement;
        public GameObject fpsCamera;
        public IInputLoadManager _input;

        private float _bodyMovementSpeed = 5f;
        private float _headMovementSpeed = 10f;
        private Vector3 _startPosition;

        public void AwakePlayer()
        {
            _startPosition = transform.position;
            transform.position = _startPosition;
            fpsCamera = GameObject.FindGameObjectWithTag("MainCamera");
            _characterController = GetComponent<CharacterController>();
            bodyMovement = new BodyMovement(_bodyMovementSpeed);
            headMovement = new HeadMovement(_headMovementSpeed);
            _tooltipManager = new TooltipManager();
            _input = GameObject.FindGameObjectWithTag("Main").GetComponent<MainScene>().inputLoadManager;
        }

        public void UpdatePlayer(CastRaycast _raycast)
        {
            Move();
            LookHorizontal();
            LookVertical();
            _raycast.RaycastSight(fpsCamera);
            _tooltipManager.UpdateTooltip(_raycast.itemAtSight, _raycast.itemAtHand, _raycast.workSequenceID);
        }

        public void Move()
        {
            _characterController.SimpleMove(
                transform.TransformDirection(
                bodyMovement.Calculate(
                    _input.MoveX(),
                    _input.MoveZ()
                    )));
        }

        public void LookHorizontal()
        {
            transform.Rotate(
                headMovement.CalculateY(
                    _input.LookY()
                    )
                );
        }

        public void LookVertical()
        {
            fpsCamera.transform.localRotation = headMovement.CalculateX(_input.LookX());
        }

        public void SetHeadMovementSpeed(float speed)
        {
            _headMovementSpeed = speed;
            headMovement = new HeadMovement(_headMovementSpeed);
        }

        public void SetBodyMovementSpeed(float speed)
        {
            _bodyMovementSpeed = speed;
            bodyMovement = new BodyMovement(_bodyMovementSpeed);
        }
    }
}


using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class MainController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private List<Transform> _transformListSpawn = new List<Transform>();
        [SerializeField] private string _dataPath;

        private Controllers _controller;
        private ControlUIView _controlUIView;
        private Data _data;
        private Camera _camera;

        #endregion


        #region Properties

        public Controllers Controller { get => _controller; private set => _controller = value; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _camera = Camera.main;

            Controller = new Controllers();

            _data = Resources.Load<Data>(Path.Combine(ManagerPath.DATA, ManagerPath.DATA));
            if (_data == null) _data = Resources.Load<Data>(_dataPath);


            #region PlaneCreate

            var playerFactory = new PlayerFactory(_data.PlayerData);
            var playerInitialization = new PlayerInitialization(playerFactory.CreatePlayerModel());

            var vectorPosition = new List<Vector3>();

            foreach (var item in _transformListSpawn)
            {
                vectorPosition.Add(item.position);
                Destroy(item.gameObject);
            }

            playerInitialization.PlayerModel.PlayerComponents.TransformPlayer.position = 
                vectorPosition[Random.Range(0, vectorPosition.Count)];

            #endregion


            #region CinemachineVirtualCamera

            var cameraInitialization = new CameraInitialization(playerInitialization.PlayerModel);
            _controller.Add(cameraInitialization);

            #endregion


            #region UIControlCreate

            var UIInitialization = new UiInitialization();
            var UIController = new UIController(UIInitialization);
            _controller.Add(UIController);

            #endregion


            #region InputSystem

            var inputInitialization = new InputInitialization();
            _controller.Add(inputInitialization);

            var inputController = new InputController(inputInitialization.ActiveInput());
            _controller.Add(inputController);

            #endregion


            #region Player

            var planeController = new PlaneController(inputController, playerInitialization.PlayerModel, cameraInitialization);
            _controller.Add(planeController);

            planeController.SendActionButtons(UIController);

            #endregion
        }

        #endregion


        #region UnityMethods

        private void Start()
        {
            _controller.Initialization();
        }

        private void Update()
        {
            _controller.Execute(Time.deltaTime);
        }

        #endregion
    }
}

using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using XynokConvention.Patterns;
using XynokConvention.Procedural;
using XynokGUI.Enums;
using XynokGUI.Input;

namespace XynokGUI.Manager
{
    /// <summary>
    ///  Quản lý các API của input. Muốn sử dụng action gì thì gọi tới đây.
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public class InputManager : ASingleton<InputManager>
    {
        [ReadOnly] [SerializeField] private PlayerInput playerInput;
        [SerializeField] private InputActionAsset inputActionAsset;

        [ShowInInspector] public string CurrentControlScheme => _currentControlScheme;
        [ShowInInspector] public string CurrentMap => _currentMap;

        private InputMap[] _inputMaps;
        private Action _onDispose;
        private string _currentMap;


        public PlayerInput PlayerInput => playerInput;
        public event Action<string> OnControlSchemeChanged;

        private string _currentControlScheme = "???";

        private void OnValidate()
        {
            if (!playerInput) playerInput = GetComponent<PlayerInput>();
            if (playerInput && inputActionAsset) playerInput.actions = inputActionAsset;
        }

#if UNITY_EDITOR

        [Button]
        void Reload()
        {
            XynokInput.Settings.Input.EmbedInputMap.Instance.Reload();
        }
#endif

        protected override void Awake()
        {
            base.Awake();
            Init();
            _currentMap = playerInput.currentActionMap.name;
        }

        private void Start()
        {
            playerInput.actions.Enable();
        }

        /// <summary>
        /// active or deactive input response of current map only
        /// </summary>
        public void SetActiveInput(bool value)
        {
            if (value) playerInput.ActivateInput();
            else playerInput.DeactivateInput();
        }


        public void ActiveInputMap(string map)
        {
            _currentMap = map;
            playerInput.SwitchCurrentActionMap(map);
            EventManager.EmitEvent(XynokGuiEvent.SwapInputMap.ToString());
        }

        public InputActionWrapper GetInput(string map, string action)
        {
            var inputMap = _inputMaps.FirstOrDefault(e => e.Name == map);
            if (inputMap != null) return inputMap.GetInputAction(action);
            Debug.LogError($"inputMap {map} does not exist");
            return null;
        }

        void Init()
        {
            if (inputActionAsset == null)
            {
                Debug.LogError("inputActionAsset is null");
                return;
            }

            // init maps
            _inputMaps = new InputMap[inputActionAsset.actionMaps.Count];

            for (int i = 0; i < inputActionAsset.actionMaps.Count; i++)
            {
                int index = i;
                var map = inputActionAsset.actionMaps[index];

                _inputMaps[index] ??= new();
                _inputMaps[index].SetDependency(map);
                _onDispose += _inputMaps[index].Dispose;
            }
        }

        void Update()
        {
            if (_currentControlScheme == playerInput.currentControlScheme) return;
            _currentControlScheme = playerInput.currentControlScheme;
            OnControlSchemeChanged?.Invoke(_currentControlScheme);
        }

        private void OnDestroy()
        {
            _onDispose?.Invoke();
        }
    }
}
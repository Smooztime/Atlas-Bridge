//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Scripts/Players/InputSystem_Actions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputSystem_Actions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem_Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem_Actions"",
    ""maps"": [
        {
            ""name"": ""Red"",
            ""id"": ""111b32bd-fa7b-4470-86a7-b96d2ea9f700"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""62733203-1e81-4ae4-b214-6ccf6abe6f7e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""08f88acf-250d-47c4-b372-cd9d2140a56f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f6c21714-b534-4f9d-aa2d-f013dcff72a9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Blue"",
            ""id"": ""b910d6aa-94b3-40f8-9166-9ed707603a3f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""680033f7-bad5-4888-9d69-712701637a22"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2a037db7-7194-494b-a067-7933269d7cb5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""06187b1a-ad94-49cc-8efc-d4f7d72835a1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""ESC"",
            ""id"": ""12e57d41-9d37-492d-85d9-f137077fde18"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""d80af613-657f-4aba-b96f-7eb16dff4645"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b16690d3-2158-4866-b73d-6d0796ca460b"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Red
        m_Red = asset.FindActionMap("Red", throwIfNotFound: true);
        m_Red_Movement = m_Red.FindAction("Movement", throwIfNotFound: true);
        // Blue
        m_Blue = asset.FindActionMap("Blue", throwIfNotFound: true);
        m_Blue_Movement = m_Blue.FindAction("Movement", throwIfNotFound: true);
        // ESC
        m_ESC = asset.FindActionMap("ESC", throwIfNotFound: true);
        m_ESC_Pause = m_ESC.FindAction("Pause", throwIfNotFound: true);
    }

    ~@InputSystem_Actions()
    {
        UnityEngine.Debug.Assert(!m_Red.enabled, "This will cause a leak and performance issues, InputSystem_Actions.Red.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_Blue.enabled, "This will cause a leak and performance issues, InputSystem_Actions.Blue.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_ESC.enabled, "This will cause a leak and performance issues, InputSystem_Actions.ESC.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Red
    private readonly InputActionMap m_Red;
    private List<IRedActions> m_RedActionsCallbackInterfaces = new List<IRedActions>();
    private readonly InputAction m_Red_Movement;
    public struct RedActions
    {
        private @InputSystem_Actions m_Wrapper;
        public RedActions(@InputSystem_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Red_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Red; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RedActions set) { return set.Get(); }
        public void AddCallbacks(IRedActions instance)
        {
            if (instance == null || m_Wrapper.m_RedActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RedActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(IRedActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
        }

        public void RemoveCallbacks(IRedActions instance)
        {
            if (m_Wrapper.m_RedActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRedActions instance)
        {
            foreach (var item in m_Wrapper.m_RedActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RedActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RedActions @Red => new RedActions(this);

    // Blue
    private readonly InputActionMap m_Blue;
    private List<IBlueActions> m_BlueActionsCallbackInterfaces = new List<IBlueActions>();
    private readonly InputAction m_Blue_Movement;
    public struct BlueActions
    {
        private @InputSystem_Actions m_Wrapper;
        public BlueActions(@InputSystem_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Blue_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Blue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BlueActions set) { return set.Get(); }
        public void AddCallbacks(IBlueActions instance)
        {
            if (instance == null || m_Wrapper.m_BlueActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BlueActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(IBlueActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
        }

        public void RemoveCallbacks(IBlueActions instance)
        {
            if (m_Wrapper.m_BlueActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBlueActions instance)
        {
            foreach (var item in m_Wrapper.m_BlueActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BlueActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BlueActions @Blue => new BlueActions(this);

    // ESC
    private readonly InputActionMap m_ESC;
    private List<IESCActions> m_ESCActionsCallbackInterfaces = new List<IESCActions>();
    private readonly InputAction m_ESC_Pause;
    public struct ESCActions
    {
        private @InputSystem_Actions m_Wrapper;
        public ESCActions(@InputSystem_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_ESC_Pause;
        public InputActionMap Get() { return m_Wrapper.m_ESC; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ESCActions set) { return set.Get(); }
        public void AddCallbacks(IESCActions instance)
        {
            if (instance == null || m_Wrapper.m_ESCActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ESCActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IESCActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IESCActions instance)
        {
            if (m_Wrapper.m_ESCActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IESCActions instance)
        {
            foreach (var item in m_Wrapper.m_ESCActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ESCActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ESCActions @ESC => new ESCActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IRedActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IBlueActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IESCActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}

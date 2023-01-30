//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/GameplayInputs.inputactions
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

public partial class @GameplayInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayInputs"",
    ""maps"": [
        {
            ""name"": ""Boat"",
            ""id"": ""be6c4bf5-cce8-4353-ac99-d5a013e6256a"",
            ""actions"": [
                {
                    ""name"": ""PaddleLeft"",
                    ""type"": ""Value"",
                    ""id"": ""ec7d4462-88fd-4f43-8928-11e27232ea53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PaddleRight"",
                    ""type"": ""Value"",
                    ""id"": ""90c3aca1-1a2b-4b05-a9a6-0ecf98f6952b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""StaticRotateLeft"",
                    ""type"": ""Value"",
                    ""id"": ""31fcf997-f244-4d71-9596-0801daf74d3f"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""StaticRotateRight"",
                    ""type"": ""Value"",
                    ""id"": ""68f74b2f-e772-4377-9710-58135b74f550"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateCameraActivation"",
                    ""type"": ""Value"",
                    ""id"": ""ab86d594-21ec-40bb-8ec8-749b64f9654a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Value"",
                    ""id"": ""94bc673f-e28e-491d-987f-4e04c7c7dbad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DialogSkip"",
                    ""type"": ""Button"",
                    ""id"": ""5d09007b-cbc8-4cd4-a8f0-4eed24b01a10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3cfa1491-41a9-4ca7-a280-5a43d52d446e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""PaddleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecc743e3-3393-43b9-8bb9-fc74b1d7df00"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""PaddleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84d99ad0-1484-4aab-991c-2d9fa37ffddc"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""PaddleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""552cac4e-9249-4cbe-9e57-4af35a458181"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""PaddleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62a3c127-3f1f-4b5a-9e99-e4c86b6c0755"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""StaticRotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9080299f-91ab-47cf-883d-fb860410a663"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""StaticRotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ef8087e-4505-4945-aeb6-aff821b2bc0b"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""StaticRotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98e456ff-58ef-4d20-bd85-6f2f8c69cc97"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""StaticRotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18d35e25-5cdb-4bf6-9f72-6016e5884a9a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.2,y=0.2),InvertVector2(invertX=false)"",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e987401-15f1-4c58-8252-74271067c81b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1b4b7b8-9fe4-428b-84be-cf322c633df0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""RotateCameraActivation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4c9b76c-690c-4ebf-8821-dd3443904c8f"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""RotateCameraActivation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""499f5e8e-ee4b-43ea-bb48-fd3c9f4d6d4b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""DialogSkip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46354184-2a3e-4b3f-a67f-fef2bb867f03"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""DialogSkip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": []
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": []
        }
    ]
}");
        // Boat
        m_Boat = asset.FindActionMap("Boat", throwIfNotFound: true);
        m_Boat_PaddleLeft = m_Boat.FindAction("PaddleLeft", throwIfNotFound: true);
        m_Boat_PaddleRight = m_Boat.FindAction("PaddleRight", throwIfNotFound: true);
        m_Boat_StaticRotateLeft = m_Boat.FindAction("StaticRotateLeft", throwIfNotFound: true);
        m_Boat_StaticRotateRight = m_Boat.FindAction("StaticRotateRight", throwIfNotFound: true);
        m_Boat_RotateCameraActivation = m_Boat.FindAction("RotateCameraActivation", throwIfNotFound: true);
        m_Boat_RotateCamera = m_Boat.FindAction("RotateCamera", throwIfNotFound: true);
        m_Boat_DialogSkip = m_Boat.FindAction("DialogSkip", throwIfNotFound: true);
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

    // Boat
    private readonly InputActionMap m_Boat;
    private IBoatActions m_BoatActionsCallbackInterface;
    private readonly InputAction m_Boat_PaddleLeft;
    private readonly InputAction m_Boat_PaddleRight;
    private readonly InputAction m_Boat_StaticRotateLeft;
    private readonly InputAction m_Boat_StaticRotateRight;
    private readonly InputAction m_Boat_RotateCameraActivation;
    private readonly InputAction m_Boat_RotateCamera;
    private readonly InputAction m_Boat_DialogSkip;
    public struct BoatActions
    {
        private @GameplayInputs m_Wrapper;
        public BoatActions(@GameplayInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @PaddleLeft => m_Wrapper.m_Boat_PaddleLeft;
        public InputAction @PaddleRight => m_Wrapper.m_Boat_PaddleRight;
        public InputAction @StaticRotateLeft => m_Wrapper.m_Boat_StaticRotateLeft;
        public InputAction @StaticRotateRight => m_Wrapper.m_Boat_StaticRotateRight;
        public InputAction @RotateCameraActivation => m_Wrapper.m_Boat_RotateCameraActivation;
        public InputAction @RotateCamera => m_Wrapper.m_Boat_RotateCamera;
        public InputAction @DialogSkip => m_Wrapper.m_Boat_DialogSkip;
        public InputActionMap Get() { return m_Wrapper.m_Boat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BoatActions set) { return set.Get(); }
        public void SetCallbacks(IBoatActions instance)
        {
            if (m_Wrapper.m_BoatActionsCallbackInterface != null)
            {
                @PaddleLeft.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnPaddleLeft;
                @PaddleLeft.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnPaddleLeft;
                @PaddleLeft.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnPaddleLeft;
                @PaddleRight.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnPaddleRight;
                @PaddleRight.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnPaddleRight;
                @PaddleRight.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnPaddleRight;
                @StaticRotateLeft.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnStaticRotateLeft;
                @StaticRotateLeft.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnStaticRotateLeft;
                @StaticRotateLeft.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnStaticRotateLeft;
                @StaticRotateRight.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnStaticRotateRight;
                @StaticRotateRight.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnStaticRotateRight;
                @StaticRotateRight.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnStaticRotateRight;
                @RotateCameraActivation.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnRotateCameraActivation;
                @RotateCameraActivation.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnRotateCameraActivation;
                @RotateCameraActivation.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnRotateCameraActivation;
                @RotateCamera.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnRotateCamera;
                @DialogSkip.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnDialogSkip;
                @DialogSkip.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnDialogSkip;
                @DialogSkip.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnDialogSkip;
            }
            m_Wrapper.m_BoatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PaddleLeft.started += instance.OnPaddleLeft;
                @PaddleLeft.performed += instance.OnPaddleLeft;
                @PaddleLeft.canceled += instance.OnPaddleLeft;
                @PaddleRight.started += instance.OnPaddleRight;
                @PaddleRight.performed += instance.OnPaddleRight;
                @PaddleRight.canceled += instance.OnPaddleRight;
                @StaticRotateLeft.started += instance.OnStaticRotateLeft;
                @StaticRotateLeft.performed += instance.OnStaticRotateLeft;
                @StaticRotateLeft.canceled += instance.OnStaticRotateLeft;
                @StaticRotateRight.started += instance.OnStaticRotateRight;
                @StaticRotateRight.performed += instance.OnStaticRotateRight;
                @StaticRotateRight.canceled += instance.OnStaticRotateRight;
                @RotateCameraActivation.started += instance.OnRotateCameraActivation;
                @RotateCameraActivation.performed += instance.OnRotateCameraActivation;
                @RotateCameraActivation.canceled += instance.OnRotateCameraActivation;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @DialogSkip.started += instance.OnDialogSkip;
                @DialogSkip.performed += instance.OnDialogSkip;
                @DialogSkip.canceled += instance.OnDialogSkip;
            }
        }
    }
    public BoatActions @Boat => new BoatActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IBoatActions
    {
        void OnPaddleLeft(InputAction.CallbackContext context);
        void OnPaddleRight(InputAction.CallbackContext context);
        void OnStaticRotateLeft(InputAction.CallbackContext context);
        void OnStaticRotateRight(InputAction.CallbackContext context);
        void OnRotateCameraActivation(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnDialogSkip(InputAction.CallbackContext context);
    }
}

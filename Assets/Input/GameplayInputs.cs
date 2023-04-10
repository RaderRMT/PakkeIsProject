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
                },
                {
                    ""name"": ""OpenWheelMenu"",
                    ""type"": ""Value"",
                    ""id"": ""3897178e-d8e5-42d2-b1c6-075428adc16c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SelectOnWheel"",
                    ""type"": ""Value"",
                    ""id"": ""41104c3d-e5eb-4b95-9d70-09869384b221"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DeselectWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""3df5f837-8436-4878-9be5-2f58a701ed96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""e8cecd45-fe58-4e62-880c-2d553338bee1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveAim"",
                    ""type"": ""Value"",
                    ""id"": ""6d1491e7-7ca5-413c-9386-98053f453c4b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""7057980f-4ac7-41c6-a33c-ea6ca6e9401e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""UnbalancedRight"",
                    ""type"": ""Button"",
                    ""id"": ""536c1b49-1bbd-4281-94e8-66356b26c49c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UnbalancedLeft"",
                    ""type"": ""Button"",
                    ""id"": ""825655f2-9165-416b-a147-181bd2009188"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DisplayControlScreen"",
                    ""type"": ""Button"",
                    ""id"": ""e412642b-f162-4c33-9f57-0efea12c64c4"",
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
                    ""id"": ""98e456ff-58ef-4d20-bd85-6f2f8c69cc97"",
                    ""path"": ""<Keyboard>/d"",
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
                    ""id"": ""62a3c127-3f1f-4b5a-9e99-e4c86b6c0755"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""StaticRotateRight"",
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
                    ""id"": ""0e987401-15f1-4c58-8252-74271067c81b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""0f43ca2a-d8b2-442e-bf39-32832d7c4143"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""OpenWheelMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7fa617b-1ea1-4ae8-831d-a0f69de7ae94"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""OpenWheelMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f65d129-1c19-4806-aa4d-dc91c9bd8998"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""SelectOnWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2fc37d0-a769-4043-aed1-6719ec9c1bcf"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""DeselectWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a0281f8-918b-4947-bfbc-3050167498f4"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""DeselectWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4672f842-d893-4358-8095-fc96aa2b4492"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8583a4d7-eb25-49b8-9fec-64b882d52bc5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b782da75-3bc2-4af1-928a-9a0947ee8542"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""MoveAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc51c2ad-af2e-40ca-be76-584bc7d914fd"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc693c8b-5880-425f-86fc-1b9a97e8014d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c5181f8-75d8-4536-a0a7-ae0ef4a05301"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d8d0ac4-d8c4-4be2-ac02-0f4af55d9156"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""UnbalancedRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45417cfa-9acf-4c1a-ad21-61e31c9a33fb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""UnbalancedRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7e15cc8-3a1e-4c6f-8f2c-18357324baa4"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""UnbalancedLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3c2823d-dd45-4011-ad57-742a574d5ac6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""UnbalancedLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b8fdf28-c343-4bca-b5d3-32eceed31fd4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""DisplayControlScreen"",
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
        m_Boat_OpenWheelMenu = m_Boat.FindAction("OpenWheelMenu", throwIfNotFound: true);
        m_Boat_SelectOnWheel = m_Boat.FindAction("SelectOnWheel", throwIfNotFound: true);
        m_Boat_DeselectWeapon = m_Boat.FindAction("DeselectWeapon", throwIfNotFound: true);
        m_Boat_Aim = m_Boat.FindAction("Aim", throwIfNotFound: true);
        m_Boat_MoveAim = m_Boat.FindAction("MoveAim", throwIfNotFound: true);
        m_Boat_Shoot = m_Boat.FindAction("Shoot", throwIfNotFound: true);
        m_Boat_UnbalancedRight = m_Boat.FindAction("UnbalancedRight", throwIfNotFound: true);
        m_Boat_UnbalancedLeft = m_Boat.FindAction("UnbalancedLeft", throwIfNotFound: true);
        m_Boat_DisplayControlScreen = m_Boat.FindAction("DisplayControlScreen", throwIfNotFound: true);
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
    private readonly InputAction m_Boat_OpenWheelMenu;
    private readonly InputAction m_Boat_SelectOnWheel;
    private readonly InputAction m_Boat_DeselectWeapon;
    private readonly InputAction m_Boat_Aim;
    private readonly InputAction m_Boat_MoveAim;
    private readonly InputAction m_Boat_Shoot;
    private readonly InputAction m_Boat_UnbalancedRight;
    private readonly InputAction m_Boat_UnbalancedLeft;
    private readonly InputAction m_Boat_DisplayControlScreen;
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
        public InputAction @OpenWheelMenu => m_Wrapper.m_Boat_OpenWheelMenu;
        public InputAction @SelectOnWheel => m_Wrapper.m_Boat_SelectOnWheel;
        public InputAction @DeselectWeapon => m_Wrapper.m_Boat_DeselectWeapon;
        public InputAction @Aim => m_Wrapper.m_Boat_Aim;
        public InputAction @MoveAim => m_Wrapper.m_Boat_MoveAim;
        public InputAction @Shoot => m_Wrapper.m_Boat_Shoot;
        public InputAction @UnbalancedRight => m_Wrapper.m_Boat_UnbalancedRight;
        public InputAction @UnbalancedLeft => m_Wrapper.m_Boat_UnbalancedLeft;
        public InputAction @DisplayControlScreen => m_Wrapper.m_Boat_DisplayControlScreen;
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
                @OpenWheelMenu.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnOpenWheelMenu;
                @OpenWheelMenu.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnOpenWheelMenu;
                @OpenWheelMenu.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnOpenWheelMenu;
                @SelectOnWheel.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnSelectOnWheel;
                @SelectOnWheel.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnSelectOnWheel;
                @SelectOnWheel.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnSelectOnWheel;
                @DeselectWeapon.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnDeselectWeapon;
                @DeselectWeapon.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnDeselectWeapon;
                @DeselectWeapon.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnDeselectWeapon;
                @Aim.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnAim;
                @MoveAim.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnMoveAim;
                @MoveAim.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnMoveAim;
                @MoveAim.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnMoveAim;
                @Shoot.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnShoot;
                @UnbalancedRight.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnUnbalancedRight;
                @UnbalancedRight.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnUnbalancedRight;
                @UnbalancedRight.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnUnbalancedRight;
                @UnbalancedLeft.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnUnbalancedLeft;
                @UnbalancedLeft.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnUnbalancedLeft;
                @UnbalancedLeft.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnUnbalancedLeft;
                @DisplayControlScreen.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnDisplayControlScreen;
                @DisplayControlScreen.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnDisplayControlScreen;
                @DisplayControlScreen.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnDisplayControlScreen;
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
                @OpenWheelMenu.started += instance.OnOpenWheelMenu;
                @OpenWheelMenu.performed += instance.OnOpenWheelMenu;
                @OpenWheelMenu.canceled += instance.OnOpenWheelMenu;
                @SelectOnWheel.started += instance.OnSelectOnWheel;
                @SelectOnWheel.performed += instance.OnSelectOnWheel;
                @SelectOnWheel.canceled += instance.OnSelectOnWheel;
                @DeselectWeapon.started += instance.OnDeselectWeapon;
                @DeselectWeapon.performed += instance.OnDeselectWeapon;
                @DeselectWeapon.canceled += instance.OnDeselectWeapon;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @MoveAim.started += instance.OnMoveAim;
                @MoveAim.performed += instance.OnMoveAim;
                @MoveAim.canceled += instance.OnMoveAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @UnbalancedRight.started += instance.OnUnbalancedRight;
                @UnbalancedRight.performed += instance.OnUnbalancedRight;
                @UnbalancedRight.canceled += instance.OnUnbalancedRight;
                @UnbalancedLeft.started += instance.OnUnbalancedLeft;
                @UnbalancedLeft.performed += instance.OnUnbalancedLeft;
                @UnbalancedLeft.canceled += instance.OnUnbalancedLeft;
                @DisplayControlScreen.started += instance.OnDisplayControlScreen;
                @DisplayControlScreen.performed += instance.OnDisplayControlScreen;
                @DisplayControlScreen.canceled += instance.OnDisplayControlScreen;
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
        void OnOpenWheelMenu(InputAction.CallbackContext context);
        void OnSelectOnWheel(InputAction.CallbackContext context);
        void OnDeselectWeapon(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnMoveAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnUnbalancedRight(InputAction.CallbackContext context);
        void OnUnbalancedLeft(InputAction.CallbackContext context);
        void OnDisplayControlScreen(InputAction.CallbackContext context);
    }
}

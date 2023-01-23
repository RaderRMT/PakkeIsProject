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
                    ""type"": ""Button"",
                    ""id"": ""ec7d4462-88fd-4f43-8928-11e27232ea53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PaddleRight"",
                    ""type"": ""Button"",
                    ""id"": ""90c3aca1-1a2b-4b05-a9a6-0ecf98f6952b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StaticRotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""31fcf997-f244-4d71-9596-0801daf74d3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StaticRotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""68f74b2f-e772-4377-9710-58135b74f550"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3cfa1491-41a9-4ca7-a280-5a43d52d446e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PaddleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecc743e3-3393-43b9-8bb9-fc74b1d7df00"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PaddleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84d99ad0-1484-4aab-991c-2d9fa37ffddc"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PaddleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""552cac4e-9249-4cbe-9e57-4af35a458181"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PaddleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62a3c127-3f1f-4b5a-9e99-e4c86b6c0755"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
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
                    ""groups"": """",
                    ""action"": ""StaticRotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98e456ff-58ef-4d20-bd85-6f2f8c69cc97"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StaticRotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9080299f-91ab-47cf-883d-fb860410a663"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StaticRotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Boat
        m_Boat = asset.FindActionMap("Boat", throwIfNotFound: true);
        m_Boat_PaddleLeft = m_Boat.FindAction("PaddleLeft", throwIfNotFound: true);
        m_Boat_PaddleRight = m_Boat.FindAction("PaddleRight", throwIfNotFound: true);
        m_Boat_StaticRotateLeft = m_Boat.FindAction("StaticRotateLeft", throwIfNotFound: true);
        m_Boat_StaticRotateRight = m_Boat.FindAction("StaticRotateRight", throwIfNotFound: true);
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
    public struct BoatActions
    {
        private @GameplayInputs m_Wrapper;
        public BoatActions(@GameplayInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @PaddleLeft => m_Wrapper.m_Boat_PaddleLeft;
        public InputAction @PaddleRight => m_Wrapper.m_Boat_PaddleRight;
        public InputAction @StaticRotateLeft => m_Wrapper.m_Boat_StaticRotateLeft;
        public InputAction @StaticRotateRight => m_Wrapper.m_Boat_StaticRotateRight;
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
            }
        }
    }
    public BoatActions @Boat => new BoatActions(this);
    public interface IBoatActions
    {
        void OnPaddleLeft(InputAction.CallbackContext context);
        void OnPaddleRight(InputAction.CallbackContext context);
        void OnStaticRotateLeft(InputAction.CallbackContext context);
        void OnStaticRotateRight(InputAction.CallbackContext context);
    }
}

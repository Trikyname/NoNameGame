// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/GamepadController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GamepadController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GamepadController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GamepadController"",
    ""maps"": [
        {
            ""name"": ""Gamepad"",
            ""id"": ""8bb90cb9-26d6-4d96-a324-829ee3c09aa8"",
            ""actions"": [
                {
                    ""name"": ""Right_Stick"",
                    ""type"": ""Value"",
                    ""id"": ""085d2a06-43cf-4b61-827b-42ff0a542994"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R1"",
                    ""type"": ""Button"",
                    ""id"": ""37cd5513-9983-469b-a5c7-7cade2e0f417"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R2"",
                    ""type"": ""Button"",
                    ""id"": ""1c1d0820-576b-4f1a-9856-7a5f3bfb51df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cross"",
                    ""type"": ""Button"",
                    ""id"": ""3033f951-2784-4b0e-b6f3-ad026df68fb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Triangle"",
                    ""type"": ""Button"",
                    ""id"": ""023caf45-717b-423f-9e3f-e8ddc17fcc17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left_Stick"",
                    ""type"": ""Value"",
                    ""id"": ""d464cc08-68fa-4107-aa9d-10ed4fabdb73"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L1"",
                    ""type"": ""Button"",
                    ""id"": ""48692fab-18b6-49b5-bb40-3fc748d0dbab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L2"",
                    ""type"": ""Button"",
                    ""id"": ""4c2a5bee-5196-4185-bcfd-02dcd30e2b4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D_Pad"",
                    ""type"": ""Button"",
                    ""id"": ""92e4b86a-75cb-4398-8b39-3af31b6efac8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Keyboard"",
                    ""type"": ""Button"",
                    ""id"": ""8a544165-8539-4548-99b4-8e4aadffc177"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Left Stick [Gamepad]"",
                    ""id"": ""2c4a04d1-7ed5-411b-9668-6fd2bfbbe83a"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b3b9aee7-4a07-4b80-b885-6ab716b8c8f3"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""11b225d3-24ef-466f-856f-91ff8a966cd9"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""05ca419a-ea01-4d58-87e2-62a04d7b53b4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b0b3ae51-0636-4662-a893-d7529af25429"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e83e5340-6de4-44bd-8983-3a92d883b77d"",
                    ""path"": ""<SwitchProControllerHID>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1cdf539-fbb7-4126-a9fd-dc3e62135399"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a73b4add-4ac1-4de3-97cd-7a229ea0e6da"",
                    ""path"": ""<SwitchProControllerHID>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Right Stick [Gamepad]"",
                    ""id"": ""2c0e8f25-e1b5-40fd-bd6e-4e8d0814b5ef"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""95406b53-7085-4c4c-94db-c13b34b5bdf5"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""64b52d94-d93e-4f17-9f6d-95871880d426"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""585da7bb-e1f5-4f2a-9d74-7933934e9f8f"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ec682ae3-e993-4f34-88d2-58d0ab87c144"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""329e7881-7d0a-4c5d-aee9-f875234ef827"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b810455-e764-461d-be98-c3c1645a8b2d"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3a1eed0-e742-48ca-9209-fa61ac3eeb9f"",
                    ""path"": ""<SwitchProControllerHID>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30c69e0e-de52-4df1-8e3b-01dc48b20723"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""R1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2d7382b-c538-47b5-8bad-38bea21e4b83"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""R1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""601e6b56-f672-4727-8c42-f080f7cccfd3"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""R1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7af76ec2-78e9-4166-9efc-0ed8e65ccaeb"",
                    ""path"": ""<SwitchProControllerHID>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""R1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""057948d8-0b6a-4100-a8f1-bd7750475468"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""L1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32b23228-bcc4-45b2-84e5-7a84935f6020"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""L1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe80bc3d-ba7a-4d87-9509-07e48aaace12"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""L1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e01a7d4-a8ef-4a50-b638-1d1892accb6b"",
                    ""path"": ""<SwitchProControllerHID>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""L1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58d077b8-423b-44cb-9f4d-23b03f1098c3"",
                    ""path"": ""<DualShock4GampadiOS>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Cross"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cd83eb2-5610-4af9-af12-246bde5a5ebe"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Cross"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f29b96b4-5c77-4e08-97f9-b2a83e03b2c7"",
                    ""path"": ""<XboxOneGampadiOS>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Cross"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27396a72-04f8-480f-b42b-37a1a4b336e3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Cross"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c384bbc-c78d-49c2-b105-c50f30eb7af6"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""D_Pad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94359870-dee2-4849-88fd-3c95b4a6e6bd"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""D_Pad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be0da503-e00e-446e-8ad3-4986855b10e0"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""D_Pad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30d25571-04a3-4b5e-ba4d-74b7ad355d9f"",
                    ""path"": ""<SwitchProControllerHID>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""D_Pad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""433214a2-9492-4a7f-82c9-6a11897d71d7"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Triangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""282c5c5c-f333-4a21-bd60-ff51a6f92e70"",
                    ""path"": ""<SwitchProControllerHID>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Triangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""294e01c0-dd7e-4454-a4c3-57195905118c"",
                    ""path"": ""<XboxOneGampadiOS>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Triangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b80020f8-a516-4869-802d-9a55131443ad"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Triangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18a44e09-b887-45a4-9b52-5cfd8d053549"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""R2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6513d8b-aed9-4bac-abb6-a801849e42c4"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""L2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7de4fefb-ef68-430f-bf4a-9aa5248b8bff"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""508c00f5-90e3-4117-951c-9703de9a941c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a220f57-c156-4a2f-99be-65cc1d18dcf9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""257ceee6-7760-4707-af35-69061b16a6d8"",
                    ""path"": ""<Keyboard>/#(Y)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74130d55-f7b7-4235-b69b-2a570366cb0d"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6095db7a-8757-43af-b464-f8ccb2243913"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DosJugadores"",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""DosJugadores"",
            ""bindingGroup"": ""DosJugadores"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gamepad
        m_Gamepad = asset.FindActionMap("Gamepad", throwIfNotFound: true);
        m_Gamepad_Right_Stick = m_Gamepad.FindAction("Right_Stick", throwIfNotFound: true);
        m_Gamepad_R1 = m_Gamepad.FindAction("R1", throwIfNotFound: true);
        m_Gamepad_R2 = m_Gamepad.FindAction("R2", throwIfNotFound: true);
        m_Gamepad_Cross = m_Gamepad.FindAction("Cross", throwIfNotFound: true);
        m_Gamepad_Triangle = m_Gamepad.FindAction("Triangle", throwIfNotFound: true);
        m_Gamepad_Left_Stick = m_Gamepad.FindAction("Left_Stick", throwIfNotFound: true);
        m_Gamepad_L1 = m_Gamepad.FindAction("L1", throwIfNotFound: true);
        m_Gamepad_L2 = m_Gamepad.FindAction("L2", throwIfNotFound: true);
        m_Gamepad_D_Pad = m_Gamepad.FindAction("D_Pad", throwIfNotFound: true);
        m_Gamepad_Keyboard = m_Gamepad.FindAction("Keyboard", throwIfNotFound: true);
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

    // Gamepad
    private readonly InputActionMap m_Gamepad;
    private IGamepadActions m_GamepadActionsCallbackInterface;
    private readonly InputAction m_Gamepad_Right_Stick;
    private readonly InputAction m_Gamepad_R1;
    private readonly InputAction m_Gamepad_R2;
    private readonly InputAction m_Gamepad_Cross;
    private readonly InputAction m_Gamepad_Triangle;
    private readonly InputAction m_Gamepad_Left_Stick;
    private readonly InputAction m_Gamepad_L1;
    private readonly InputAction m_Gamepad_L2;
    private readonly InputAction m_Gamepad_D_Pad;
    private readonly InputAction m_Gamepad_Keyboard;
    public struct GamepadActions
    {
        private @GamepadController m_Wrapper;
        public GamepadActions(@GamepadController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Right_Stick => m_Wrapper.m_Gamepad_Right_Stick;
        public InputAction @R1 => m_Wrapper.m_Gamepad_R1;
        public InputAction @R2 => m_Wrapper.m_Gamepad_R2;
        public InputAction @Cross => m_Wrapper.m_Gamepad_Cross;
        public InputAction @Triangle => m_Wrapper.m_Gamepad_Triangle;
        public InputAction @Left_Stick => m_Wrapper.m_Gamepad_Left_Stick;
        public InputAction @L1 => m_Wrapper.m_Gamepad_L1;
        public InputAction @L2 => m_Wrapper.m_Gamepad_L2;
        public InputAction @D_Pad => m_Wrapper.m_Gamepad_D_Pad;
        public InputAction @Keyboard => m_Wrapper.m_Gamepad_Keyboard;
        public InputActionMap Get() { return m_Wrapper.m_Gamepad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamepadActions set) { return set.Get(); }
        public void SetCallbacks(IGamepadActions instance)
        {
            if (m_Wrapper.m_GamepadActionsCallbackInterface != null)
            {
                @Right_Stick.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRight_Stick;
                @Right_Stick.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRight_Stick;
                @Right_Stick.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRight_Stick;
                @R1.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnR1;
                @R1.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnR1;
                @R1.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnR1;
                @R2.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnR2;
                @R2.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnR2;
                @R2.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnR2;
                @Cross.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnCross;
                @Cross.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnCross;
                @Cross.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnCross;
                @Triangle.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnTriangle;
                @Triangle.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnTriangle;
                @Triangle.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnTriangle;
                @Left_Stick.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeft_Stick;
                @Left_Stick.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeft_Stick;
                @Left_Stick.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeft_Stick;
                @L1.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnL1;
                @L1.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnL1;
                @L1.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnL1;
                @L2.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnL2;
                @L2.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnL2;
                @L2.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnL2;
                @D_Pad.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnD_Pad;
                @D_Pad.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnD_Pad;
                @D_Pad.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnD_Pad;
                @Keyboard.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnKeyboard;
                @Keyboard.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnKeyboard;
                @Keyboard.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnKeyboard;
            }
            m_Wrapper.m_GamepadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Right_Stick.started += instance.OnRight_Stick;
                @Right_Stick.performed += instance.OnRight_Stick;
                @Right_Stick.canceled += instance.OnRight_Stick;
                @R1.started += instance.OnR1;
                @R1.performed += instance.OnR1;
                @R1.canceled += instance.OnR1;
                @R2.started += instance.OnR2;
                @R2.performed += instance.OnR2;
                @R2.canceled += instance.OnR2;
                @Cross.started += instance.OnCross;
                @Cross.performed += instance.OnCross;
                @Cross.canceled += instance.OnCross;
                @Triangle.started += instance.OnTriangle;
                @Triangle.performed += instance.OnTriangle;
                @Triangle.canceled += instance.OnTriangle;
                @Left_Stick.started += instance.OnLeft_Stick;
                @Left_Stick.performed += instance.OnLeft_Stick;
                @Left_Stick.canceled += instance.OnLeft_Stick;
                @L1.started += instance.OnL1;
                @L1.performed += instance.OnL1;
                @L1.canceled += instance.OnL1;
                @L2.started += instance.OnL2;
                @L2.performed += instance.OnL2;
                @L2.canceled += instance.OnL2;
                @D_Pad.started += instance.OnD_Pad;
                @D_Pad.performed += instance.OnD_Pad;
                @D_Pad.canceled += instance.OnD_Pad;
                @Keyboard.started += instance.OnKeyboard;
                @Keyboard.performed += instance.OnKeyboard;
                @Keyboard.canceled += instance.OnKeyboard;
            }
        }
    }
    public GamepadActions @Gamepad => new GamepadActions(this);
    private int m_DosJugadoresSchemeIndex = -1;
    public InputControlScheme DosJugadoresScheme
    {
        get
        {
            if (m_DosJugadoresSchemeIndex == -1) m_DosJugadoresSchemeIndex = asset.FindControlSchemeIndex("DosJugadores");
            return asset.controlSchemes[m_DosJugadoresSchemeIndex];
        }
    }
    public interface IGamepadActions
    {
        void OnRight_Stick(InputAction.CallbackContext context);
        void OnR1(InputAction.CallbackContext context);
        void OnR2(InputAction.CallbackContext context);
        void OnCross(InputAction.CallbackContext context);
        void OnTriangle(InputAction.CallbackContext context);
        void OnLeft_Stick(InputAction.CallbackContext context);
        void OnL1(InputAction.CallbackContext context);
        void OnL2(InputAction.CallbackContext context);
        void OnD_Pad(InputAction.CallbackContext context);
        void OnKeyboard(InputAction.CallbackContext context);
    }
}

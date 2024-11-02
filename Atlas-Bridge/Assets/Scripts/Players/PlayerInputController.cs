using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private string mapName;
    [SerializeField] InputActionAsset actionAsset;

    private PlayerController _playerController;
    private InputActionMap playerCtrl;
    
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        playerCtrl = actionAsset.FindActionMap(mapName);
    }

    private void OnEnable()
    {
        playerCtrl.Enable();
        playerCtrl.FindAction("Movement").performed += ctx => _playerController.MovementInput(ctx.ReadValue<float>());
        playerCtrl.FindAction("Movement").canceled += ctx => _playerController.OnMoveReleased();
    }

    private void OnDisable()
    {
        playerCtrl.Disable();
    }

    private void ESC_Performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }
}

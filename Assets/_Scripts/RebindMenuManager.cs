using UnityEngine;
using UnityEngine.InputSystem;

public class RebindMenuManager : MonoBehaviour
{
    public InputActionReference MoveRef, AttackRef;
    private void OnEnable()
    {
        MoveRef.action.Disable();
        AttackRef.action.Disable();
    }
    private void OnDisable()
    {
        MoveRef.action.Enable();
        AttackRef.action.Enable();
    }
}

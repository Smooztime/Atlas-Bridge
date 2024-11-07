using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "SOs/PlayerStatsSO")]
public class PlayerStatsSO : ScriptableObject
{
    [Range(0, 10)] public float MovementSpeed;
    [Range(0, 200)]public float RotateSpeed;
    [Range(20, 200)] public float PlayerForce;
}

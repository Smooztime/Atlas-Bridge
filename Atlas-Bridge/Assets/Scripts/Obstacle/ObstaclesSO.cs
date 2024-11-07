using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclesSO", menuName = "SOs/ObstaclesSO")]
public class ObstaclesSO : ScriptableObject
{
    [Range(1, 30)] public float ObstacleForce;
}

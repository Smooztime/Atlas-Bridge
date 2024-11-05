using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclesSO", menuName = "SOs/ObstaclesSO")]
public class ObstaclesSO : ScriptableObject
{
    [Range(20, 200)] public float ObstacleForce;
}

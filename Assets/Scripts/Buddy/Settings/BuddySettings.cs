using UnityEngine;

[CreateAssetMenu(fileName = "BuddySettings", menuName = "VR/Buddy Settings", order = 1)]
public class BuddySettings : ScriptableObject
{
    [Header("Buddy Position Settings")]
    [Tooltip("Distance to the left side of the player.")]
    public float distanceToLeft = 1.5f;

    [Tooltip("Distance forward or backward relative to the player.")]
    public float distanceForward = 0.0f;

    [Tooltip("Height at which the buddy floats (eye level).")]
    public float height = 1.6f;

    [Header("Buddy Follow Behavior")]
    [Tooltip("Smoothness of buddy movement following the player.")]
    public float followSmoothness = 5f;

    [Header("Idle Animation")]
    [Tooltip("Vertical amplitude of idle bobbing movement.")]
    public float idleBobAmplitude = 0.1f;

    [Tooltip("Frequency of the idle bobbing animation.")]
    public float idleBobFrequency = 1f;
}

using UnityEngine;

public class BuddyMovement : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField, Tooltip("Reference to the player's XR camera (head position).")]
    private Transform playerCamera;

    [Header("Buddy Settings")]
    [SerializeField, Tooltip("Assign the BuddySettings ScriptableObject with all movement and animation parameters.")]
    private BuddySettings settings;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private void Update()
    {
        if (playerCamera == null || settings == null)
            return;

        UpdateTargetPosition();
        MoveBuddy();
        RotateBuddy();
    }

    private void UpdateTargetPosition()
    {
        var leftOffset = playerCamera.TransformDirection(Vector3.left) * settings.distanceToLeft;
        var forwardOffset = playerCamera.TransformDirection(Vector3.forward) * settings.distanceForward;

        targetPosition = playerCamera.position + leftOffset + forwardOffset;
        targetPosition.y = settings.height + Mathf.Sin(Time.time * settings.idleBobFrequency) * settings.idleBobAmplitude;
    }

    private void MoveBuddy()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * settings.followSmoothness);
    }

    private void RotateBuddy()
    {
        targetRotation = Quaternion.LookRotation(playerCamera.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * settings.followSmoothness);
    }
}

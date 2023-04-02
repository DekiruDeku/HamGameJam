using System;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target; // The target to follow
    public float damping = 5f; // The damping to apply to the camera movement
    public float height = 0.5f; // The height of the camera above the target

    private Vector3 _currentVelocity; // The current velocity of the camera movement

    private void Start()
    {
        // If no target is specified, try to find one with the "Player" tag
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    private void FixedUpdate()
    {
        // If no target is specified, return
        if (!target) return;

        // Calculate the target position with the offset
        var targetPosition = target.position + new Vector3(0f, height, target.position.z - 0.5f);

        // Move the camera towards the target position with damping
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity,
            damping * Time.fixedDeltaTime);
    }
}
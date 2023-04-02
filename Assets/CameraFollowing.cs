using System;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public float dumping = 1.5f;
    public Transform player;
    public Vector2 offset = new Vector2(1f, 0.5f);
    public bool isLeft;
    public int lastX;

    private void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    private void FindPlayer(bool playerIsLeft)
    {
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y,
                transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y,
                transform.position.z);
        }
    }

    private void Update()
    {
        if (!player) return;
        var currentX = Mathf.RoundToInt(player.position.x);
        isLeft = currentX <= lastX;

        lastX = Mathf.RoundToInt(player.position.x);

        Vector3 target;

        if (isLeft)
        {
            target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }

        var currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
        transform.position = currentPosition;
    }
}
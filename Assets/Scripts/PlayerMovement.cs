using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public float stathemStrength = 5;
    public float stopSpeed = 10;
    private Vector2 _currentAction = Vector2.zero;

    private readonly Dictionary<KeyCode, Vector2> _keyActions = new()
    {
        { KeyCode.A, Vector2.left },
        { KeyCode.D, Vector2.right },
    };
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        // make the detective walk over the NPCs and not behind
        Renderer myRenderer = GetComponent<Renderer>();
        myRenderer.sortingOrder = 2;
    }

    // Update is called once per frame
    void Update()
    {
        _currentAction = Vector2.zero;

        foreach (var keyAction in _keyActions)
        {
            if (Input.GetKey(keyAction.Key))
            {
                _currentAction += keyAction.Value;
            }
        }

        if (_currentAction.magnitude > 0)
        {
            myRigidbody.velocity = _currentAction.normalized * stathemStrength;
        }
        else
        {
            myRigidbody.velocity = Vector2.MoveTowards(myRigidbody.velocity, Vector2.zero, stopSpeed * Time.deltaTime);
        }
    }
}
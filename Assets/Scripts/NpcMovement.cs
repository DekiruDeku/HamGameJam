using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed = 2.5f;
    public float minMoveTime = 0.5f;
    public float maxMoveTime = 1f;
    public float minStandTime = 5f;
    public float maxStandTime = 15f;

    private float _moveTime;
    private float _standTime;
    private Vector2 _moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        SetNewMoveTime();
        SetNewStandTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (_standTime > 0)
        {
            // NPC is standing
            _standTime -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (_standTime <= 0)
            {
                SetNewMoveTime();
            }
        }
        else if (_moveTime > 0)
        {
            // NPC is moving
            _moveTime -= Time.deltaTime;
            myRigidbody.velocity = _moveDirection * speed;
            if (_moveTime <= 0)
            {
                SetNewStandTime();
            }
        }
    }

    private void MoveRandomly()
    {
        var randomDirection = Random.Range(0f, 1f);
        if (randomDirection < 0.5f)
        {
            _moveDirection = Vector2.left;
        }
        else
        {
            _moveDirection = Vector2.right;
        }
    }

    private void SetNewMoveTime()
    {
        _moveTime = Random.Range(minMoveTime, maxMoveTime);
        MoveRandomly();
    }

    private void SetNewStandTime()
    {
        _standTime = Random.Range(minStandTime, maxStandTime);
    }
}

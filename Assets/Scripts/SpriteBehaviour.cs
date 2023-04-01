using UnityEngine;

public class SpriteBehaviour : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public GameObject entitySprite;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myRigidbody.velocity.x > 0)
        {
            entitySprite.transform.right = Vector3.right;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            entitySprite.transform.right = Vector3.left;
        }
    }
}

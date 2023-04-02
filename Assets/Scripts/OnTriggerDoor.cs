using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerDoor : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene(sceneName: $"{scene}");
            Debug.Log($"Moved to scene {scene}");
        }
    }
}

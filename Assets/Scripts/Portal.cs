using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneToLoad;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player would like to reach next leveellll zbogom ljubavi reci cu ti stooo!");

            // placehoder for scene transition
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (!col.GetComponent<PlayerMovement>().isHidden)
            {
                //placeholder
                Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            }
        }
    }
}

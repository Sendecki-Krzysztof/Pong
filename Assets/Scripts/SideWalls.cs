using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            Manager.Score(wallName);
            hitInfo.gameObject.SendMessage("resetGame", 1, SendMessageOptions.RequireReceiver);
        }
    }
}

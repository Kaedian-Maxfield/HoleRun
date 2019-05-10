using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseArea : MonoBehaviour
{
    public bool playerFallen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerFallen = true;
        }
    }
}

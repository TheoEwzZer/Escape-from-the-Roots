using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float slow = 2;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
            player.GetComponent<CharactereMotor>().speed = slow;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
            player.GetComponent<CharactereMotor>().speed = 5;
    }
}

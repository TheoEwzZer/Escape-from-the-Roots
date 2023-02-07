using UnityEngine;

public class PickUpTotem : MonoBehaviour
{
    public bool alreadyPickedUp = false;
    public AudioSource totemSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && !alreadyPickedUp) {
            Destroy(gameObject);
            GameManager.instance.AddTotems(1);
            totemSound.Play();
            alreadyPickedUp = true;
        }
    }
}

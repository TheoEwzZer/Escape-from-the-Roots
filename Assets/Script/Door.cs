using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    public AudioSource backgroundSound;
    public GameObject story;
    public AudioSource doorSound;
    public GameObject doorText;
    public GameObject player;
    private GameManager manager;
    private PlayerInput inputs;
    private InputAction doorAction;
    public SpriteRenderer door;

    public void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        door.enabled = false;
        doorAction = inputs.actions.FindAction("Interact");
        story.SetActive(false);
    }

    private void Update()
    {
        if (manager.totemCount >= manager.maxTotems && !door.enabled) {
            doorSound.Play();
            door.enabled = true;
        }
        if (Vector2.Distance(player.transform.position, transform.position) < 1f
        && door.enabled && !story.activeSelf) {
            doorText.SetActive(true);
            if (doorAction.IsPressed() && doorAction.WasPressedThisFrame()) {
                doorText.SetActive(false);
                story.SetActive(true);
                backgroundSound.volume = 0.01f;
            }
        } else if (doorText.activeSelf) {
            doorText.SetActive(false);
        }
    }
}

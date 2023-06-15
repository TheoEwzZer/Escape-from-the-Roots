using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    private GameObject joystick;
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
        joystick = GameObject.Find("Variable Joystick");
    }

    private void Update()
    {
        if (manager.totemCount >= manager.maxTotems && !door.enabled) {
            doorSound.Play();
            door.enabled = true;
        }
        if (Vector2.Distance(player.transform.position, transform.position) < 1f
        && door.enabled && !story.activeSelf) {
            if (GameManager.instance.isMobile)
                doorText.GetComponent<TextMeshProUGUI>().text = "Touch the screen to continue";
            else
                doorText.GetComponent<TextMeshProUGUI>().text = "Press E to continue";
            doorText.SetActive(true);
            if (GameManager.instance.isMobile) {
                if (UnityEngine.Input.GetMouseButtonDown(0)) {
                    doorText.SetActive(false);
                    story.SetActive(true);
                    joystick.SetActive(false);
                    backgroundSound.volume = 0.01f;
                }
            } else {
                if (doorAction.IsPressed() && doorAction.WasPressedThisFrame()) {
                    doorText.SetActive(false);
                    story.SetActive(true);
                    joystick.SetActive(false);
                    backgroundSound.volume = 0.01f;
                }
            }
        } else if (doorText.activeSelf) {
            doorText.SetActive(false);
        }
    }
}

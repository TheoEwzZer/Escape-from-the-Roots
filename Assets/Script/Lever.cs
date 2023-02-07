using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    public AudioSource leverSound;
    public GameObject leverText;
    public GameObject player;
    private GameManager manager;
    private PlayerInput inputs;
    private InputAction leverAction;
    public SpriteRenderer lever;
    public Sprite leverOn;
    public SpriteRenderer door;

    public void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        door.enabled = false;
        leverAction = inputs.actions.FindAction("Interact");
    }

    private void Update()
    {
        if (transform.position.y >= player.transform.position.y && Vector2.Distance(player.transform.position, transform.position) < 1f && !door.enabled) {
            leverText.SetActive(true);
            if (leverAction.IsPressed() && leverAction.WasPressedThisFrame()) {
                leverSound.Play();
                lever.sprite = leverOn;
                door.enabled = true;
                leverText.SetActive(false);
            }
        } else if (leverText.activeSelf) {
            leverText.SetActive(false);
        }
    }
}

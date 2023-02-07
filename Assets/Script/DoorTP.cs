using UnityEngine;
using UnityEngine.InputSystem;

public class DoorTP : MonoBehaviour
{
    public GameObject tpUp;
    public GameObject tpDown;
    public GameObject doorText;
    public GameObject player;
    private GameManager manager;
    private PlayerInput inputs;
    private InputAction doorAction;
    public SpriteRenderer door;
    private float distance = 1f;

    public void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        door.enabled = false;
        doorAction = inputs.actions.FindAction("Interact");
    }

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < distance && door.enabled) {
            doorText.SetActive(true);
            if (doorAction.IsPressed() && doorAction.WasPressedThisFrame()) {
                if (player.transform.position.y > transform.position.y)
                    player.transform.position = tpDown.transform.position;
                else
                    player.transform.position = tpUp.transform.position;
            }
        } else if (doorText.activeSelf) {
            doorText.SetActive(false);
        }
    }
}

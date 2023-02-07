using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class CharactereMotor : MonoBehaviour
{
    public AudioSource stepSound;
    public AudioSource torchSound;
    private PlayerInput inputs;
    private InputAction moveAction;
    private InputAction flashlightAction;
    public Animator anim;
    private GameManager manager;
    private Vector2 velocity = Vector2.zero;
    private int direction = 0;
    public float speed = 5f;
    public Light2D flashlight;
    public Light2D vignette;
    public bool idle = false;
    void Start()
    {
        stepSound.volume = 0.15f;
        stepSound.Play();
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        moveAction = inputs.actions.FindAction("Move");
        flashlightAction = inputs.actions.FindAction("Flashlight");
    }

    private void Update() {
        if (idle)
            stepSound.volume = 0f;
        else
            stepSound.volume = 0.15f;
        if (flashlightAction.IsPressed() && flashlightAction.WasPressedThisFrame() && GameManager.instance.hasFlashlight) {
            if (!flashlight.enabled)
                torchSound.Play();
            flashlight.enabled = !flashlight.enabled;
            vignette.enabled = !vignette.enabled;
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        moveValue = ChooseDirection(moveValue);
        velocity = moveValue * speed;
        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0);
        anim.SetInteger("Direction", direction);
    }

    private Vector2 ChooseDirection(Vector2 value)
    {
        Vector2 result = Vector2.zero;
        if (Mathf.Abs(value.x) > Mathf.Abs(value.y))
            result = new Vector2(value.x, 0);
        else
            result = new Vector2(0, value.y);
        direction = SetDirection(result, direction);
        return result;
    }

    private int SetDirection(Vector2 vector, int direction)
    {
        if (vector.x > 0) {
            idle = false;
            flashlight.transform.rotation = Quaternion.Euler(0, 0, -90);
            return 6;
        }
        if (vector.x < 0) {
            idle = false;
            flashlight.transform.rotation = Quaternion.Euler(0, 0, 90);
            return 4;
        }
        if (vector.y > 0) {
            idle = false;
            flashlight.transform.rotation = Quaternion.Euler(0, 0, 0);
            return 8;
        }
        if (vector.y < 0) {
            idle = false;
            flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
            return 2;
        }
        if (idle == false) {
            idle = true;
            return direction + 10;
        }
        return direction;
    }
}

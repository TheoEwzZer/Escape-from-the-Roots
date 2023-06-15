using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isMobile;
    public bool isPaused;
    public TextMeshProUGUI totemText;
    public int maxTotems = 4;
    public static GameManager instance;
    private InputAction escapeAction;
    public PlayerInput inputs;
    public int totemCount = 0;
    public bool hasFlashlight;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        instance = this;
    }

    private void Start()
    {
        isPaused = false;
        hasFlashlight = false;
        totemText.text = totemCount + "/" + maxTotems;
        inputs = instance.GetInputs();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public PlayerInput GetInputs()
    {
        return inputs;
    }

    public void AddTotems(int totem)
    {
        totemCount += totem;
        totemText.text = totemCount + "/" + maxTotems;
    }

    public void SetFlashlight(bool hasFlashlight)
    {
        this.hasFlashlight = hasFlashlight;
    }

    public void setPause(bool pause)
    {
        isPaused = pause;
    }
}

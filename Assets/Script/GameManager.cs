using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
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
}

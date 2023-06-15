using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBackground;
    public Vector2 joystickVector;
    private Vector2 joystickTouchPosition;
    private Vector2 joystickOrigin;
    private float joystickRadius;

    void Start()
    {
        if (GameManager.instance.isMobile)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
        joystickOrigin = joystick.transform.position;
        joystickRadius = joystickBackground.GetComponent<RectTransform>().rect.width / 4;
    }

    public void PointerDown()
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = Vector2.Distance(mousePos, joystickOrigin);

        if (distance < joystickRadius) {
            joystick.transform.position = joystickOrigin;
            joystickBackground.transform.position = joystickOrigin;
            joystickTouchPosition = joystickOrigin;
        }
    }

    public void Drag(BaseEventData baseEventData)
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = Vector2.Distance(mousePos, joystickTouchPosition);

        if (distance < joystickRadius * 5f) {
            PointerEventData pointerData = baseEventData as PointerEventData;
            Vector2 dragPos = pointerData.position;
            joystickVector = (dragPos - joystickTouchPosition).normalized;
            float distanceFromTouch = Vector2.Distance(dragPos, joystickTouchPosition);
            if (distanceFromTouch < joystickRadius)
                joystick.transform.position = joystickTouchPosition + joystickVector * distanceFromTouch;
            else
                joystick.transform.position = joystickTouchPosition + joystickVector * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVector = Vector2.zero;
        joystick.transform.position = joystickOrigin;
        joystickBackground.transform.position = joystickOrigin;
    }
}

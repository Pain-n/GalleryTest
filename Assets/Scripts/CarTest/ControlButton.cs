using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ControlButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected CarController carController;
    bool isPressed;
    private void Start()
    {
        carController = CarController.Instance;
    }

    private void FixedUpdate()
    {
        if (isPressed) OnPressed();
    }

    public abstract void OnPressed();

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}

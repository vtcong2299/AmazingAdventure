using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : Singleton<Joystick>, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private RectTransform background;
    private RectTransform handle;
    private Vector2 inputVector;
    public void StartJoystick()
    {
        background = GetComponent<RectTransform>();
        handle = transform.GetChild(0).GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / background.sizeDelta.x);

            inputVector = new Vector2(pos.x * 2, 0);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            handle.anchoredPosition = new Vector2(inputVector.x * (background.sizeDelta.x / 2), 0);
        }
    }
    public void OnPointerDown(PointerEventData eventData) 
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
    public float Horizontal()
    {
        return inputVector.x;
    }
}


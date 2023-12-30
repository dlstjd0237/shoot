using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rect;
    private Vector2 touch = Vector2.zero;
    [Header("조이스틱이 있는 패널")]
    [SerializeField] private RectTransform handle;
    private float widthHalf;
    [SerializeField] JoystickValue value;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        widthHalf = rect.sizeDelta.x * 0.5f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        touch = (eventData.position - rect.anchoredPosition) / widthHalf;
        if (touch.magnitude > 1)
        {
            touch = touch.normalized;
        }
        value.joyTouch = touch;
        handle.anchoredPosition = touch * widthHalf;
    }

    private void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    private void OnPointerUp(PointerEventData eventData)
    {
        value.joyTouch = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }



}

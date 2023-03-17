using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private bool moveJoystick;
    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (moveJoystick)
        {
            EventSystem.SendMovePlayer(handle.anchoredPosition.x,handle.anchoredPosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        moveJoystick = true;
        EventSystem.SendStopPlayer(!moveJoystick);
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        moveJoystick = false;
        EventSystem.SendStopPlayer(!moveJoystick);
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }
}
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : ControlButton
{
    public override void OnPressed()
    {
        carController.TurnAround(-1);
    }
}

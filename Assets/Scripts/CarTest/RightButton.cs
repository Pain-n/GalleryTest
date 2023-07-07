using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : ControlButton
{
    public override void OnPressed()
    {
        carController.TurnAround(1);
    }
}

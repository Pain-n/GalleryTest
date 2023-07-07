using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardButton : ControlButton
{
    public override void OnPressed()
    {
        carController.Move(1);
    }
}

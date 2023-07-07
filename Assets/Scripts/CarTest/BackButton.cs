using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : ControlButton
{
    public override void OnPressed()
    {
        carController.Move(-1);
    }
}

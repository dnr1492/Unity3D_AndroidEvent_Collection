using UnityEngine;

public class UIMain : MonoBehaviour
{
    public UIEventController uIEventController;

    private void Update()
    {
        uIEventController.InitUIEvent();
    }
}

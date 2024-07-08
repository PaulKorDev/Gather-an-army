using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Architecture.EventBus
{
    public class TestMyEvents : MonoBehaviour
    {
        EventHandler eventHandler = new EventHandler();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) {
                eventHandler.OnKeyAPressed.Trigger();
            }
        }
    }
    public class EventHandler
    {

        public CustomEvent OnKeyAPressed = new();
        public EventHandler()
        {
            OnKeyAPressed.Subscribe(MethodA);
            OnKeyAPressed.Subscribe(MethodB, 10);
            OnKeyAPressed.Subscribe(MethodC, 5);
        }

        private void MethodA() => Debug.Log("A");
        private void MethodB()
        {
            Debug.Log("B");
            OnKeyAPressed.Unsubscribe(MethodB);

        }
        private void MethodC()
        {
            Debug.Log("C");
        }

    }
}

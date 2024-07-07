using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;

public class BootstrapServiceLocator
{

    public void RegisterAllServices()
    {
        RegisterEventBus();
    }

    private void RegisterEventBus() => ServiceLocator.Register(new EventBus());
}


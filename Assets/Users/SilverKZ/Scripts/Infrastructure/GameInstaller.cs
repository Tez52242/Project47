using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private UIView _uiView;
    [SerializeField] private PickupTextPanel _pickupTextPanel;
    [SerializeField] private SafeLogicView _safeLogicView;

    public override void InstallBindings()
    {
        Container.Bind<PauseHandler>().FromInstance(_pauseHandler).AsSingle();
        Container.Bind<UIView>().FromInstance(_uiView).AsSingle();
        Container.Bind<PickupTextPanel>().FromInstance(_pickupTextPanel).AsSingle();
        Container.Bind<SafeLogicView>().FromInstance(_safeLogicView).AsSingle();
    }
}

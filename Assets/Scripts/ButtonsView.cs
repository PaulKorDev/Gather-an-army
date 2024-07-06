using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsView : MonoBehaviour, IService
{
    [SerializeField] private Button _buttClearUnitsField;
    [SerializeField] private Button _buttSpawnUnit1;
    [SerializeField] private Button _buttSpawnUnit2;
    [SerializeField] private Button _buttSpawnUnit3;

    private GameplayPresenter _presenter;

    public void Init() { 

        _presenter = ServiceLocator.Get<GameplayPresenter>();

        _buttClearUnitsField.onClick.AddListener(OnClearButtonClicked);
        _buttSpawnUnit1.onClick.AddListener(() => OnSpawnButtonClicked(1));
        _buttSpawnUnit2.onClick.AddListener(() => OnSpawnButtonClicked(2));
        _buttSpawnUnit3.onClick.AddListener(() => OnSpawnButtonClicked(3));
    }

    private void OnSpawnButtonClicked(int id)
    {
        _presenter.CreateUnit(id);
    }
    private void OnClearButtonClicked()
    {
        _presenter.ClearUnitField();
    }


}

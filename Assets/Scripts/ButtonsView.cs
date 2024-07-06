using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsView : MonoBehaviour, IService
{
    [SerializeField] private Button _buttClearUnitsField;
    [SerializeField] private Button[] _buttsSpawnUnit = new Button[3];

    private Button[] _unitButtons;
    private GameplayPresenter _presenter;

    public void Init() {

        _presenter = ServiceLocator.Get<GameplayPresenter>();

        UpdateUnitButtonSprites();

        _buttClearUnitsField.onClick.AddListener(OnClearButtonClicked);
        _buttsSpawnUnit[0].onClick.AddListener(() => OnSpawnButtonClicked(1));
        _buttsSpawnUnit[1].onClick.AddListener(() => OnSpawnButtonClicked(2));
        _buttsSpawnUnit[2].onClick.AddListener(() => OnSpawnButtonClicked(3));
    }

    private void OnSpawnButtonClicked(int id)
    {
        _presenter.CreateUnit(id);
    }
    private void OnClearButtonClicked()
    {
        _presenter.ClearUnitField();
    }

    public void UpdateUnitButtonSprites()
    {
        //Subsribe to reactive property
        UnitSpritesSetter spritesSetter = ServiceLocator.Get<UnitSpritesSetter>();

        for (int i = 0; i < _buttsSpawnUnit.Length; i++) {
            _buttsSpawnUnit[i].transform.GetChild(0).GetComponent<Image>().sprite = spritesSetter.GetSpriteOfUnit(i+1);
        }
    }

}
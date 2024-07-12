using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonsView : MonoBehaviour, IService
{
    [SerializeField] private Button _buttClearUnitsField;
    [SerializeField] private Button[] _buttsSpawnUnit = new Button[3];

    private Button[] _unitButtons;
    private GameplayPresenter _presenter;

    private UnitSpritesSetter _unitSpritesSetter;

    [Inject]
    public void Construct(GameplayPresenter presenter, EventBus eventBus, IUnitStats unitStats, UnitSpritesSetter unitSpritesSetter) {

        _presenter = presenter;
        _unitSpritesSetter = unitSpritesSetter;

        DisplayUnitButtonSprites();
        DisplayUnitButtonStats(unitStats);
        AddListeners(eventBus);
        Debug.Log("ButtonView");
    }

    private void AddListeners(EventBus eventBus)
    {
        #region Buttons
        _buttClearUnitsField.onClick.AddListener(OnClearButtonClicked);
        _buttsSpawnUnit[0].onClick.AddListener(() => OnSpawnButtonClicked(1));
        _buttsSpawnUnit[1].onClick.AddListener(() => OnSpawnButtonClicked(2));
        _buttsSpawnUnit[2].onClick.AddListener(() => OnSpawnButtonClicked(3));
        #endregion
        eventBus.UnitsTypeChanged.Subscribe(DisplayUnitButtonSprites);
    }
    private void OnSpawnButtonClicked(int id)
    {
        _presenter.CreateUnit(id);
    }
    private void OnClearButtonClicked()
    {
        _presenter.ClearUnitField();
    }
    public void DisplayUnitButtonSprites()
    {
        for (int i = 0; i < _buttsSpawnUnit.Length; i++) {
            _buttsSpawnUnit[i].transform.GetChild(0).GetComponent<Image>().sprite = _unitSpritesSetter.GetSpriteOfUnit(i+1);
        }
    }

    private void DisplayUnitButtonStats(IUnitStats unitStats)
    {
        for (int i = 0; i < _buttsSpawnUnit.Length; i++) {
            Text[] texts = _buttsSpawnUnit[i].GetComponentsInChildren<Text>();
            //Set stats to text on buttons
            texts[0].text = unitStats.GetPowerOfUnit(i + 1).ToString();
            texts[1].text = unitStats.GetSpecialCostOfUnit(i + 1).ToString();
            texts[2].text = unitStats.GetBaseCostOfUnit(i + 1).ToString();
        }
    }

}

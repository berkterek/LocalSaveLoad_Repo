using UnityEngine;
using UnityEngine.UI;

public class IncreaseButton : MonoBehaviour
{
    [SerializeField] StatsType _statsType;
    [SerializeField] Button _button;
    [SerializeField] Sample2CanvasController _sample2CanvasController;

    void OnValidate()
    {
        if (_button == null)
        {
            _button = GetComponent<Button>();
        }
    }

    void OnEnable()
    {
        _button.onClick.AddListener(HandleOnButtonClicked);
    }

    void OnDisable()
    {
        _button.onClick.RemoveListener(HandleOnButtonClicked);
    }
    
    void HandleOnButtonClicked()
    {
        _sample2CanvasController.IncreaseStats(_statsType);
    }
}

public enum StatsType : byte
{
    Vitality,
    Dexterity,
    Intelligence,
    Strength
}

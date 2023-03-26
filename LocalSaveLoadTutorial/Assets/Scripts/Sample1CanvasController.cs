using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sample1CanvasController : MonoBehaviour
{
    const string SAMPLE_CANVAS_KEY = "sample_canvas_key";

    [SerializeField] int _currentCounter = 0;
    [SerializeField] TMP_Text _valueText;
    [SerializeField] Button _increaseButton;
    [SerializeField] Button _decreaseButton;
    [SerializeField] Button _saveButton;

    void Start()
    {
        if (PlayerPrefs.HasKey(SAMPLE_CANVAS_KEY))
        {
            _currentCounter = PlayerPrefs.GetInt(SAMPLE_CANVAS_KEY);    
        }
        
        _valueText.SetText(_currentCounter.ToString());
    }

    void OnEnable()
    {
        _increaseButton.onClick.AddListener(HandleOnIncreaseButtonClicked);
        _decreaseButton.onClick.AddListener(HandleOnDecreaseButtonClicked);
        _saveButton.onClick.AddListener(HandleOnSaveButtonClicked);
    }

    void OnDisable()
    {
        _increaseButton.onClick.RemoveListener(HandleOnIncreaseButtonClicked);
        _decreaseButton.onClick.RemoveListener(HandleOnDecreaseButtonClicked);
        _saveButton.onClick.RemoveListener(HandleOnSaveButtonClicked);
    }

    void HandleOnIncreaseButtonClicked()
    {
        IncreaseDecreaseCurrentValueValue(1);
    }

    void HandleOnSaveButtonClicked()
    {
        Debug.Log($"Key:{SAMPLE_CANVAS_KEY} Value:{_currentCounter}");
        PlayerPrefs.SetInt(SAMPLE_CANVAS_KEY, _currentCounter);
    }

    void HandleOnDecreaseButtonClicked()
    {
        IncreaseDecreaseCurrentValueValue(-1);
    }

    void IncreaseDecreaseCurrentValueValue(int value)
    {
        _currentCounter += value;
        _valueText.SetText(_currentCounter.ToString());
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using RoddGames.Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sample2CanvasController : MonoBehaviour
{
    const string SAMPLE_KEY_2 = "sample_key_2";

    [SerializeField] TMP_Text _vitalityText;
    [SerializeField] TMP_Text _dexterityText;
    [SerializeField] TMP_Text _intelligenceText;
    [SerializeField] TMP_Text _strangthText;
    [SerializeField] Button _saveButton;

    PlayerStats _playerStats;

    void Awake()
    {
        if (PlayerPrefs.HasKey(SAMPLE_KEY_2))
        {
            string encryptValue = PlayerPrefs.GetString(SAMPLE_KEY_2);
            string jsonValue = EncryptHelper.GetDecrypt(encryptValue);
            _playerStats = JsonConvert.DeserializeObject<PlayerStats>(jsonValue);
        }
        else
        {
            _playerStats = new PlayerStats
            {
                Dexterity = 15,
                Intelligence = 15,
                Strength = 15,
                Vitality = 15
            };
        }
    }

    void Start()
    {
        SetValueToText(_playerStats.Dexterity, _dexterityText);
        SetValueToText(_playerStats.Vitality, _vitalityText);
        SetValueToText(_playerStats.Intelligence, _intelligenceText);
        SetValueToText(_playerStats.Strength, _strangthText);
    }

    void OnEnable()
    {
        _saveButton.onClick.AddListener(HandleOnSaveButtonClicked);
    }

    void OnDisable()
    {
        _saveButton.onClick.RemoveListener(HandleOnSaveButtonClicked);
    }

    public void IncreaseStats(StatsType statsType)
    {
        switch (statsType)
        {
            case StatsType.Dexterity:
                _playerStats.Dexterity += 1;
                SetValueToText(_playerStats.Dexterity, _dexterityText);
                break;
            case StatsType.Intelligence:
                _playerStats.Intelligence += 1;
                SetValueToText(_playerStats.Intelligence, _intelligenceText);
                break;
            case StatsType.Strength:
                _playerStats.Strength += 1;
                SetValueToText(_playerStats.Strength, _strangthText);
                break;
            case StatsType.Vitality:
                _playerStats.Vitality += 1;
                SetValueToText(_playerStats.Vitality, _vitalityText);
                break;
        }
    }

    private void SetValueToText(int value, TMP_Text text)
    {
        text.SetText(value.ToString());
    }

    void HandleOnSaveButtonClicked()
    {
        string jsonValue = JsonConvert.SerializeObject(_playerStats);
        string encryptValue = EncryptHelper.SetEncrypt(jsonValue);
        PlayerPrefs.SetString(SAMPLE_KEY_2, encryptValue);
    }
}

public class PlayerStats
{
    // public string CharacterName { get; set; }
    public int Vitality { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }

    public int Strength { get; set; }
    //public Inventory Inventory { get; set; }
}

public struct Inventory
{
    public List<Item> Item { get; set; }
}

public struct Item
{
    public int ID { get; set; }
    public string ItemName { get; set; }
}
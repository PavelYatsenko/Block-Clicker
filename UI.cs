using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Image _pickaxe;
    [SerializeField] private int _currentLevelPickaxe;
    [SerializeField] private Sprite[] _spritePickaxe;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _needUpPickexe;

    public int CurrentPickaxe => _currentLevelPickaxe;

    private Blok _blok;
    private void Awake()
    {
        _pickaxe.sprite = _spritePickaxe[0];


    }

    private void OnEnable()
    {
        
        _spawner.UpLevel += ChangedLevel;
    }
    public void BuyGoods(Goods item)
    {
        _currentLevelPickaxe = item.LevelPickaxe;
        _pickaxe.sprite = item.ImageItem;
        _needUpPickexe.gameObject.SetActive(false);
    }
    public void Alert“eedUpPickexe()
    {
        _needUpPickexe.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        _spawner.UpLevel -= ChangedLevel;
    }
    


    private void ChangedLevel(int money)
    {
        _levelText.text = money.ToString();
        _needUpPickexe.gameObject.SetActive(false);

    }
    // Update is called once per frame


    public void OpenPanel(GameObject panel)
    {

        panel.SetActive(true);
        Time.timeScale = 0f;
        _pickaxe.gameObject.SetActive(false);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        _pickaxe.gameObject.SetActive(true);
    }
}

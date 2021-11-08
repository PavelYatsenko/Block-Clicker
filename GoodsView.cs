using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoodsView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _sellButton;

    public UnityAction<Goods,GoodsView> BuyButtonClick;

    private int _intCost;
    private Spawner _spawner;
    private Shop _shop;
    private Goods _item;
    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>();
        
    }
    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }
    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Goods item)
    {

        _item = item;
        _image.sprite = item.ImageItem;
        _name.text = item.NameItem;
        _cost.text = item.Cost.ToString();
        


    }
    private void OnButtonClick()
    {
        BuyButtonClick?.Invoke(_item, this);
    }
    private void TryLockItem()
    {
        print(_intCost);
        if (_item.Cost <= _spawner.Level)
        {
            _sellButton.interactable = false;
            _sellButton.transform.GetComponentInChildren<TMP_Text>().text = "Куплено";
            _cost.gameObject.SetActive(false);
        }
        else
        {

            _name.text = "Недостаточно блоков!";
            _name.color = Color.red;
            Invoke("ActiveObject",1.5f);

        }
    }


    private void ActiveObject()
    {

        print("fiks");
        _name.color = Color.black;
        _name.text = _item.NameItem;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Goods[] _goods;
    [SerializeField] private GameObject _conteiner;
    [SerializeField] private GoodsView _template;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private UI _ui;

    private void Start()
    {
        for (int i = 0; i < _goods.Length; i++)
        {
            AddItem(_goods[i]);
        }
    }


    private void AddItem(Goods item)
    {
        var view = Instantiate(_template, _conteiner.transform);
        view.Render(item);
        view.BuyButtonClick += OnSellButtonCick;

    }

    private void OnSellButtonCick(Goods item, GoodsView view)
    {
        TryBuyGoods(item, view);
    }
    private void TryBuyGoods(Goods item, GoodsView view)
    {
        if(item.Cost <= _spawner.Level)
        {
            _ui.BuyGoods(item);
            item.Buy();
            view.BuyButtonClick -= OnSellButtonCick;
        }
    }




}

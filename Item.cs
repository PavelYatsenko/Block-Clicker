using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite _imageItem;
    [SerializeField] private string _nameItem;
    [SerializeField] private int _cost;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] private int _levelPickaxe;


    public Sprite ImageItem => _imageItem;
    public string NameItem => _nameItem;
    public int Cost => _cost;
    public int LevelPickaxe => _levelPickaxe;


    public void Buy()
    {
        _isBuyed = true;
    }
}

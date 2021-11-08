using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public  class Blok : MonoBehaviour
{
    [SerializeField] private TMP_Text  _label;
    [SerializeField] private int _fullNumberHeath;
    [SerializeField] private GameObject _TouchEffect;
    [SerializeField] private GameObject _destroyeffect;
    [SerializeField] private int _needLevelPikcaxe;

    private float _destroySpeed;
    private float _range;
    private float color = 0;
    private float _numberHeath;
    private UI _ui;
    private SpriteRenderer _spriteRenderer;


    public UnityAction CreateBlok;


    private void Start()
    {       
        _ui = FindObjectOfType<UI>();
        _numberHeath = _fullNumberHeath;
        _label.text = _numberHeath.ToString();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _range = 1f / _fullNumberHeath;
    }

     
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_ui.CurrentPickaxe == _needLevelPikcaxe)
            {
                _destroySpeed = 1f;


            }
            else if (_ui.CurrentPickaxe > _needLevelPikcaxe)
            {
                _destroySpeed = 2f;


            }
            else if(_ui.CurrentPickaxe < _needLevelPikcaxe)
            {
                _ui.AlertÒeedUpPickexe();
                _destroySpeed = 0.5f;
                
            }
            ClickOnBlock();
        }
    }
    private void ClickOnBlock()
    {

        _range = 1f / _fullNumberHeath * (_destroySpeed  - 0.2f);

        _numberHeath -= _destroySpeed;

        color += _range;
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(_TouchEffect, new Vector3(position.x, position.y, position.z), Quaternion.identity);
        _spriteRenderer.material.color = Color32.Lerp(_spriteRenderer.material.color, Color.black, color - 0.20f);
        _label.text = ((int)_numberHeath).ToString();
        if (_numberHeath < 1)
        {

            Instantiate(_destroyeffect, transform.position, Quaternion.identity);
            Invoke("Corot", 0.6f);
            gameObject.SetActive(false);



        }

    }
    private void  Corot()
    {

        CreateBlok?.Invoke();
        Destroy(gameObject);

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{


    [SerializeField] private Blok[] _bloks;
    [SerializeField] private UI _ui;

    private Blok _blok;
    private int _level;

    public int Level => _level;

    public UnityAction<int> UpLevel;
    private void Awake()
    {
        _blok = FindObjectOfType<Blok>();
    }
    private void OnEnable()
    {
        _blok.CreateBlok += SetBlok;
    }
    private void OnDisable()
    {
        _blok.CreateBlok -= SetBlok;
    }
    private void SetBlok()
    {
        _level++;
        

        UpLevel?.Invoke(_level);

        if(_level > 300)
        {
            int NumberBlock = Random.Range(0, 9);
            _blok = Instantiate(_bloks[NumberBlock], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }
        else if(_level > 190)
        {
            int NumberBlock = Random.Range(0, 8);
            _blok = Instantiate(_bloks[NumberBlock], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }
        else if (_level > 120)
        {
            int NumberBlock = Random.Range(0, 7);
            _blok = Instantiate(_bloks[NumberBlock], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }
        else  if (_level > 90)
        {
            int NumberBlock = Random.Range(0, 6);
            _blok = Instantiate(_bloks[NumberBlock], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }
        else if (_level > 50)
        {
            int NumberBlock = Random.Range(0, 5);
            _blok = Instantiate(_bloks[NumberBlock], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }
        else if (_level > 20)
        {
            int NumberBlock = Random.Range(0, 4);
            _blok = Instantiate(_bloks[NumberBlock], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }
        else if (_level > 10)
        {
            int NumberBlock = Random.Range(0, 3);
            _blok = Instantiate(_bloks[NumberBlock], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }
        else if (_level > 5)
        {
            int NumberBlock = Random.Range(0,2);
            _blok = Instantiate(_bloks[NumberBlock], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }
        else
        {
            _blok = Instantiate(_bloks[0], new Vector3(transform.rotation.x, transform.rotation.y, 0), transform.rotation).GetComponent<Blok>();
        }







        _blok.CreateBlok += SetBlok;

    }
 





}

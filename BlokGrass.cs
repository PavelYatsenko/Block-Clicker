using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlokGrass : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private int _numberHeath;
    void Start()
    {
        _label.text = _numberHeath.ToString();
    }

}

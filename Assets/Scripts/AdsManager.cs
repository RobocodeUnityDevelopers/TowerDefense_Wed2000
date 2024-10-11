using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdsManager : MonoBehaviour
{
    [SerializeField] private Button interstBut;

    private void Start()
    {
        AdInterstitial.S.LoadAd();
        interstBut.onClick.AddListener(() => AdInterstitial.S.ShowAd());
    }
}

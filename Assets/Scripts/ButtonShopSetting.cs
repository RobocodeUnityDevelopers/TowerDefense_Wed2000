using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShopSetting : MonoBehaviour
{
    [SerializeField] private Text costText;
    [Header("Вартість турелі")]
    [SerializeField] private int cost;
    [SerializeField] private int turretIndex;    
    private void Awake()
    {
        costText.text = cost.ToString();
        BuildManager manager = FindObjectOfType<BuildManager>();
        GetComponent<Button>().onClick.AddListener(()=>manager.SetBuildTurret(cost,turretIndex));
    }

}

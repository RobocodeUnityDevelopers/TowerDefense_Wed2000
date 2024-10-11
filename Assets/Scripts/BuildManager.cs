using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField]private Color startColor;
    [SerializeField]private Color hoverColor;
    private GameObject tempObj;

    [SerializeField] private GameObject[] turrets;

    private int turretIndex = 0;
    private int cost;
    private bool canBuild = false;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Node") && canBuild)
            {
                tempObj = hit.collider.gameObject;
                tempObj.GetComponent<MeshRenderer>().material.color = hoverColor;
                if (Input.GetMouseButtonDown(0))
                {
                    tempObj.GetComponent<NodeBuildSetting>().StartBuild(turrets[turretIndex], 0.35f, cost);
                    canBuild = false;
                    int chance = Random.Range(0, 101);
                    if(chance < 2)
                    {
                        AdInterstitial.S.LoadAd();
                        AdInterstitial.S.ShowAd();
                    }
                }
            }
            else if(tempObj != null)
            {
                tempObj.GetComponent<MeshRenderer>().material.color = startColor;
            }
        }
        else if(tempObj != null)
        {
            tempObj.GetComponent<MeshRenderer>().material.color = startColor;
        }
    }

    public void SetBuildTurret(int buildCost, int buildIndex)
    {
        turretIndex = buildIndex;
        cost = buildCost;
        canBuild = true;
    }
}


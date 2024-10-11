using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBuildSetting : MonoBehaviour
{
    private GameObject structure;

    public GameObject GetStructure()
    {
        return structure;
    }
    
    public void StartBuild(GameObject structure, float high, int cost)
    {
        if(this.structure == null && CoinController.SubtractCoin(cost))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + high, transform.position.z);
            this.structure = Instantiate(structure, pos, transform.rotation);
        }
    }
}

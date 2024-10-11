using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class HPController : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private int health;

    public int Health
    { 
        get 
        {
            return health;
        } 
        set 
        {
            health = value;
        }
    }

    private void LateUpdate()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
        hpText.text = health.ToString();
    }
}

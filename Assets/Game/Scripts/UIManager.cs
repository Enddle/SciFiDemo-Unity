using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text AmmoField = null;
    [SerializeField] GameObject coin = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAmmo(int ammo) {
        
        AmmoField.text = "Ammo  " + ammo;
    }

    public void CollectedCoin() {
        
        coin.SetActive(true);
    }
}

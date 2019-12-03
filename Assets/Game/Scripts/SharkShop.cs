using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.E)) {
                Player player = other.GetComponent<Player>();
                if (player != null) {
                    player.hasCoin = false;
                }
                UIManager UI = GameObject.Find("Canvas").GetComponent<UIManager>();
                if (UI != null) {
                    UI.RemoveCoin();
                }
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                player.EnableWeapon();
            }
        }
    }
}

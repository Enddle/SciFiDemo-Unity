using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioClip coinSound = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        
        if (other.tag == "Player")
            if (Input.GetKeyDown(KeyCode.E)) {

                Player p = other.GetComponent<Player>();
                if (p != null) p.hasCoin = true;

                UIManager UI = GameObject.Find("Canvas").GetComponent<UIManager>();
                UI.CollectedCoin();

                AudioSource.PlayClipAtPoint(coinSound, transform.position);

                Destroy(this.gameObject);
            }
    }
}

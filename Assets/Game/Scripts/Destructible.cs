using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    [SerializeField] private GameObject crateDestoryed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestoryCrate() {

        Instantiate(crateDestoryed, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}

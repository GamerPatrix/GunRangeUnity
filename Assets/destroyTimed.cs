using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTimed : MonoBehaviour
{

    [SerializeField] private float DestroyAfter=1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyObject), DestroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}

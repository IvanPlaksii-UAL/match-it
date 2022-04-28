using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (STATS.DIFFICULTY == "Easy") this.transform.position += new Vector3(0.25f, 0, 0);
        if (STATS.DIFFICULTY == "Normal") this.transform.position += new Vector3(0.3f, 0, 0);
        if (STATS.DIFFICULTY == "Hard") this.transform.position += new Vector3(0.35f, 0, 0);
        if (this.transform.position.x > 10) Destroy(this.gameObject);
    }
}

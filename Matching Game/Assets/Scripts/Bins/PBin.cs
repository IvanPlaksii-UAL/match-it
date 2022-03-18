using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBin : MonoBehaviour
{
    private GameManager reftoManager;
    private GameObject Green, Red, Blue, Yellow, Purple;
    // Start is called before the first frame update
    void Start()
    {
        reftoManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Green = GameObject.Find("Green");
        Red = GameObject.Find("Red");
        Blue = GameObject.Find("Blue");
        Yellow = GameObject.Find("Yellow");
        Purple = GameObject.Find("Purple");

        if (reftoManager.currentPos == "Circle") this.transform.position = new Vector3(7.5f, 0, 0);
        else this.transform.position = new Vector3(15, 0, 0);

        reftoManager.PointCheck(Green, false, gameObject);
        reftoManager.PointCheck(Red, false, gameObject);
        reftoManager.PointCheck(Blue, false, gameObject);
        reftoManager.PointCheck(Yellow, false, gameObject);
        reftoManager.PointCheck(Purple, true, gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameManager reftoManager;
    public GameObject PlayButton, HowToPlay, Easy, Medium, Hard, Mouse, Back;
    string MenuState; //Set, Difficulty, Controls
    //public string DifficultySet;// Easy, Normal, Hard;
    // Start is called before the first frame update
    void Start()
    {
        MenuState = "Set";
        reftoManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouse.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        Cursor.visible = false;

        if (MenuState == "Set")
        {
            PlayButton.transform.position = new Vector3(0, -1, 0);
            HowToPlay.transform.position = new Vector3(0, -3, 0);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(PlayButton.GetComponent<SpriteRenderer>().bounds))
            {
                PlayButton.GetComponent<SpriteRenderer>().color = new Vector4(0.7f, 0.9f, 0.9f, 1);
                if (Input.GetKeyUp(KeyCode.Mouse0)) MenuState = "Difficulty";
            }
            else PlayButton.GetComponent<SpriteRenderer>().color = new Vector4(0.94f, 0.94f, 0.94f, 1);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(HowToPlay.GetComponent<SpriteRenderer>().bounds))
            {
                HowToPlay.GetComponent<SpriteRenderer>().color = new Vector4(0.7f, 0.9f, 0.9f, 1);
                if (Input.GetKeyUp(KeyCode.Mouse0)) MenuState = "Controls";
            }
            else HowToPlay.GetComponent<SpriteRenderer>().color = new Vector4(0.94f, 0.94f, 0.94f, 1);
        }
        else
        {
            PlayButton.transform.position = new Vector3(-15, 2, 0);
            HowToPlay.transform.position = new Vector3(-15, -2, 0);
        }

        if (MenuState == "Difficulty")
        {
            Easy.transform.position = new Vector3(0, -0.25f, 0);
            Medium.transform.position = new Vector3(0, -2, 0);
            Hard.transform.position = new Vector3(0, -3.75f, 0);
            Back.transform.position = new Vector3(-7.5f, 4, 0);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(Easy.GetComponent<SpriteRenderer>().bounds))
            {
                Easy.GetComponent<SpriteRenderer>().color = new Vector4(0.5f, 0.85f, 0.5f, 1);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    STATS.DIFFICULTY = "Easy";
                    SceneManager.LoadScene("Game");
                }
            }
            else Easy.GetComponent<SpriteRenderer>().color = new Vector4(0.94f, 0.94f, 0.94f, 1);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(Medium.GetComponent<SpriteRenderer>().bounds))
            {
                Medium.GetComponent<SpriteRenderer>().color = new Vector4(1, 0.8f, 0.4f, 1);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    STATS.DIFFICULTY = "Normal";
                    SceneManager.LoadScene("Game");
                }
            }
            else Medium.GetComponent<SpriteRenderer>().color = new Vector4(0.94f, 0.94f, 0.94f, 1);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(Hard.GetComponent<SpriteRenderer>().bounds))
            {
                Hard.GetComponent<SpriteRenderer>().color = new Vector4(0.85f, 0.2f, 0.2f, 1);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    STATS.DIFFICULTY = "Hard";
                    SceneManager.LoadScene("Game");
                }
            }
            else Hard.GetComponent<SpriteRenderer>().color = new Vector4(0.94f, 0.94f, 0.94f, 1);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(Back.GetComponent<SpriteRenderer>().bounds) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                MenuState = "Set";
            }
        }
        else
        {
            Easy.transform.position = new Vector3(15, 1.75f, 0);
            Medium.transform.position = new Vector3(15, 1.75f, 0);
            Hard.transform.position = new Vector3(15, 1.75f, 0);
            Back.transform.position = new Vector3(15f, 4, 0);
        }
        
    }
}

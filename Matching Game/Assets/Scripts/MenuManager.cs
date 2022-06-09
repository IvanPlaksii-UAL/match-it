using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameManager reftoManager;
    public GameObject PlayButton, HowToPlay, Easy, Medium, Hard, Mouse, Back, Title, difficultyText;
    public TextMesh controlsText;
    string MenuState; //Set, Difficulty, Controls
    int titleColor;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        MenuState = "Set";
        reftoManager = FindObjectOfType<GameManager>();
        titleColor = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Mouse.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        Cursor.visible = false;


        if (titleColor > 10) titleColor--;
        if (titleColor == 10)titleColor = Random.Range(1, 6);
        if (titleColor == 1)
        {
            Title.GetComponent<TextMesh>().color = Color.green;
            titleColor = 130;
        }
        if (titleColor == 2)
        {
            Title.GetComponent<TextMesh>().color = Color.red;
            titleColor = 130;
        }
        if (titleColor == 3)
        {
            Title.GetComponent<TextMesh>().color = Color.blue;
            titleColor = 130;
        }
        if (titleColor == 4)
        {
            Title.GetComponent<TextMesh>().color = Color.yellow;
            titleColor = 130;
        }
        if (titleColor == 5)
        {
            Title.GetComponent<TextMesh>().color = Color.magenta;
            titleColor = 130;
        }

        if (MenuState == "Set")
        {
            PlayButton.transform.position = new Vector3(0, -1, 0);
            HowToPlay.transform.position = new Vector3(0, -3, 0);
            Title.transform.position = new Vector3(0, 2.5f, 0);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(PlayButton.GetComponent<SpriteRenderer>().bounds))
            {
                PlayButton.GetComponent<SpriteRenderer>().color = new Vector4(0.7f, 0.9f, 0.9f, 1);
                if (Input.GetKeyUp(KeyCode.Mouse0)) MenuState = "Difficulty";
            }
            else PlayButton.GetComponent<SpriteRenderer>().color = new Vector4(0.14f, 0.14f, 0.14f, 1);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(HowToPlay.GetComponent<SpriteRenderer>().bounds))
            {
                HowToPlay.GetComponent<SpriteRenderer>().color = new Vector4(0.7f, 0.9f, 0.9f, 1);
                if (Input.GetKeyUp(KeyCode.Mouse0)) MenuState = "Controls";
            }
            else HowToPlay.GetComponent<SpriteRenderer>().color = new Vector4(0.14f, 0.14f, 0.14f, 1);
        }
        else
        {
            PlayButton.transform.position = new Vector3(-15, 2, 0);
            HowToPlay.transform.position = new Vector3(-15, -2, 0);
            Title.transform.position = new Vector3(-15, 2.5f, 0);
        }

        if (MenuState == "Difficulty")
        {
            difficultyText.transform.position = new Vector3(0, 2.5f, 0);
            Easy.transform.position = new Vector3(0, -0.25f, 0);
            Medium.transform.position = new Vector3(0, -2, 0);
            Hard.transform.position = new Vector3(0, -3.75f, 0);
            Back.transform.position = new Vector3(-7.5f, 4, 0);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(Easy.GetComponent<SpriteRenderer>().bounds))
            {
                Easy.GetComponent<SpriteRenderer>().color = Color.green;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    STATS.DIFFICULTY = "Easy";
                    SceneManager.LoadScene("Game");
                }
            }
            else Easy.GetComponent<SpriteRenderer>().color = new Vector4(0.14f, 0.14f, 0.14f, 1);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(Medium.GetComponent<SpriteRenderer>().bounds))
            {
                Medium.GetComponent<SpriteRenderer>().color = Color.yellow;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    STATS.DIFFICULTY = "Normal";
                    SceneManager.LoadScene("Game");
                }
            }
            else Medium.GetComponent<SpriteRenderer>().color = new Vector4(0.14f, 0.14f, 0.14f, 1);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(Hard.GetComponent<SpriteRenderer>().bounds))
            {
                Hard.GetComponent<SpriteRenderer>().color = Color.red;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    STATS.DIFFICULTY = "Hard";
                    SceneManager.LoadScene("Game");
                }
            }
            else Hard.GetComponent<SpriteRenderer>().color = new Vector4(0.14f, 0.14f, 0.14f, 1);

            if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(Back.GetComponent<SpriteRenderer>().bounds) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                MenuState = "Set";
            }
        }
        else if (MenuState == "Controls")
        {
            Back.transform.position = new Vector3(-7.5f, 4, 0);
            controlsText.transform.position = new Vector3(0, 0, 0);

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
            controlsText.transform.position = new Vector3(-20, 0, 0);
            difficultyText.transform.position = new Vector3(25, 2.5f, 0);
        }
    }
}

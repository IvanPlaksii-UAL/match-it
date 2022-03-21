using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class STATS
{

    public static string DIFFICULTY = "NONE";

}

public class GameManager : MonoBehaviour
{
    public int timeLeft, frameCount, collected, highScore;
    public int spawnCD, spawnType;
    private int cooldown;
    public string currentPos; //Square, Triangle, Hexagon, Diamond, Circle
    public string currentState; //Menu, Reset, Playable, GameOver
    public TextMesh timer, counter, best;
    private GameObject Green, Red, Blue, Yellow, Purple;
    public Sprite Square, Triangle, Hexagon, Diamond, Circle;
    public GameObject GreenButton, RedButton, BlueButton, YellowButton, PurpleButton, playButton, menuButton, Mouse, Overlay;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        currentState = "Reset";
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState == "Reset")
        {
            currentPos = "";
            playButton.transform.position = new Vector3(-13, 1, 0);
            menuButton.transform.position = new Vector3(-13, -1, 0);
            Overlay.transform.position = new Vector3(-20, 0, 0);
            timeLeft = 12;
            frameCount = 0;
            spawnCD = 80;
            collected = 0;
            if (STATS.DIFFICULTY == "Easy") cooldown = 80;
            if (STATS.DIFFICULTY == "Normal") cooldown = 70;
            if (STATS.DIFFICULTY == "Hard") cooldown = 60;
            currentState = "Playable";
        }
        
        if (currentState == "Playable")
        {
            UserInterface();
            Controls();
            Spawn();
        }

        if (timeLeft <= -3) currentState = "Over";

        if (currentState == "Over")
        {
            if (collected > highScore) highScore = collected;
            best.text = ($"High Score: {highScore}");

            EndScreen();
        }

        Mouse.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        Cursor.visible = false;
    }

    void Controls()
    {
        SelectedShape(GreenButton, "Square");
        SelectedShape(RedButton, "Triangle");
        SelectedShape(BlueButton, "Hexagon");
        SelectedShape(YellowButton, "Diamond");
        SelectedShape(PurpleButton, "Circle");
    }

    void UserInterface()
    {
        counter.text = ($"{collected}");
        if(timeLeft >= 0) timer.text = ($"{timeLeft}");
        frameCount++;
        if (frameCount == 60)
        {
            timeLeft--;
            frameCount = 0;
        }
    }
    void EndScreen()
    {
        playButton.transform.position = new Vector3(0, 1, 0);
        menuButton.transform.position = new Vector3(0, -1, 0);
        Overlay.transform.position = new Vector3(0, 0, 0);

        if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(playButton.GetComponent<SpriteRenderer>().bounds))
        {
            playButton.GetComponent<SpriteRenderer>().color = new Vector4(0.7f, 0.9f, 0.9f, 1);
            if (Input.GetKeyUp(KeyCode.Mouse0)) currentState = "Reset";
        }
        else playButton.GetComponent<SpriteRenderer>().color = new Vector4(0.94f, 0.94f, 0.94f, 1);

        if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(menuButton.GetComponent<SpriteRenderer>().bounds))
        {
            menuButton.GetComponent<SpriteRenderer>().color = new Vector4(0.7f, 0.9f, 0.9f, 1);
            if (Input.GetKeyUp(KeyCode.Mouse0)) SceneManager.LoadScene("Menu");
        }
        else menuButton.GetComponent<SpriteRenderer>().color = new Vector4(0.94f, 0.94f, 0.94f, 1);
    }

    void Spawn()
    {
        spawnCD--;
        if (spawnCD == 0)
        {
            //Object Spawns
            spawnType = Random.Range(1, 6);
            ObjectSpawn(1, Green, "Green", Square, Color.green);
            ObjectSpawn(2, Red, "Red", Triangle, Color.red);
            ObjectSpawn(3, Blue, "Blue", Hexagon, Color.blue);
            ObjectSpawn(4, Yellow, "Yellow", Diamond, Color.yellow);
            ObjectSpawn(5, Purple, "Purple", Circle,  new Color(0.4f, 0.15f, 0.6f));
            
            //Spawn Rate
            if (timeLeft > 0) spawnCD = cooldown - (collected * 3);
        }
    }
    public void PointCheck(GameObject _colour, bool _addPoint = false, GameObject _other = null)
    {
        if (_colour != null)
        {

            if (_other.GetComponent<SpriteRenderer>().bounds.Intersects(_colour.GetComponent<SpriteRenderer>().bounds))
            {
                if (_addPoint) collected++;
                else timeLeft--;
                Destroy(_colour);
            }
        }
    }

    void SelectedShape(GameObject _shape, string _currentpos)
    {
        if (Mouse.GetComponent<SpriteRenderer>().bounds.Intersects(_shape.GetComponent<SpriteRenderer>().bounds) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentPos = _currentpos;
        }
    }

    void ObjectSpawn(int _spawnType, GameObject _color, string _objectName, Sprite _objectShape, Color _objectColor)
    {
        if (spawnType == _spawnType)
        {
            _color = new GameObject(_objectName);
            _color.AddComponent<SpriteRenderer>();
            _color.AddComponent<Movement>();
            _color.GetComponent<SpriteRenderer>().sprite = _objectShape;
            _color.GetComponent<SpriteRenderer>().color = _objectColor;
            _color.transform.position = new Vector3(-9, 0, 0);
        }
    }
}

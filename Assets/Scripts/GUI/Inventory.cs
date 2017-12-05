using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public GUIStyle invBox = new GUIStyle();
    public GUIStyle selectedInvBox = new GUIStyle();

    public GUIStyle wandFire = new GUIStyle();
    public GUIStyle wandWater = new GUIStyle();
    public GUIStyle wandGas = new GUIStyle();

    public SpriteRenderer spriteRend;
    public Sprite[] wandSelector;

    public float roundTimer = 300;
    public bool roundFail = false;

    PlayerMovement playerControl;

    GUIStyle boxOne;
    GUIStyle boxTwo;
    GUIStyle boxThree;

    bool boxOneSelected = true;
    bool boxTwoSelected = false;
    bool boxThreeSelected = false;

    int nextlevel = 1;
    int currentLevel = 0;
    float levelTimer = 0;

    float sW, sH;
    void Awake()
    {
        boxOne = invBox;
        boxTwo = invBox;
        boxThree = invBox;
    }
    void Update()
    {
        if (spriteRend == null)
        {
            spriteRend = GameObject.Find("Wand").GetComponent<SpriteRenderer>();
        }
        if (playerControl == null)
        {
            playerControl = GameObject.Find("Hero(Clone)").GetComponent<PlayerMovement>();
        }
        sW = Screen.width / 16;
        sH = Screen.height / 9;

        if (boxOneSelected)
        {
            boxOne = selectedInvBox;
            spriteRend.sprite = wandSelector[0];
            playerControl.attackID = 0;
        }
        else
        {
            boxOne = invBox;
        }
        if (boxTwoSelected)
        {
            boxTwo = selectedInvBox;
            spriteRend.sprite = wandSelector[1];
            playerControl.attackID = 1;
        }
        else
        {
            boxTwo = invBox;
        }
        if (boxThreeSelected)
        {
            boxThree = selectedInvBox;
            spriteRend.sprite = wandSelector[2];
            playerControl.attackID = 2;
        }
        else
        {
            boxThree = invBox;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            boxOneSelected = true;
            boxTwoSelected = false;
            boxThreeSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            boxTwoSelected = true;
            boxOneSelected = false;
            boxThreeSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            boxThreeSelected = true;
            boxOneSelected = false;
            boxTwoSelected = false;
        }

        if (!playerControl.endGame)
        {
            roundTimer -= Time.deltaTime;
            if (roundTimer <= 0)
            {
                roundFail = true;
                roundTimer = 0;
            }
        }
        if (playerControl.endGame || roundFail)
        {
            levelTimer += Time.deltaTime;
        }

    }
    void OnGUI()
    {
        Rect slotOne = new Rect(7 * sW, 8 * sH, sW, sH);
        Rect slotTwo = new Rect(8 * sW, 8 * sH, sW, sH);
        Rect slotThree = new Rect(9 * sW, 8 * sH, sW, sH);

        GUI.Label(new Rect(14*sW,sH,2*sW,sH),roundTimer.ToString("F0"));

        if (GUI.Button(slotOne, "", boxOne))
        {
            boxOneSelected = true;
            boxTwoSelected = false;
            boxThreeSelected = false;
        }
        if (GUI.Button(slotTwo, "", boxTwo))
        {
            boxTwoSelected = true;
            boxOneSelected = false;
            boxThreeSelected = false;
        }
        if (GUI.Button(slotThree, "", boxThree))
        {
            boxThreeSelected = true;
            boxOneSelected = false;
            boxTwoSelected = false;
        }
        GUI.Box(slotOne, "", wandFire);
        GUI.Box(slotTwo, "", wandWater);
        GUI.Box(slotThree, "", wandGas);

        // End Game
        if (playerControl.endGame)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(7 * sW, 2 * sH, 3 * sW, sH), "Level Complete!");
            
            if(levelTimer >= 3)
            {
                playerControl.endGame = false;
                SceneManager.LoadSceneAsync(nextlevel);
                nextlevel++;
            }
        }
        else if (roundFail)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(7 * sW, 2 * sH, 3 * sW, sH), "");
            playerControl.enabled = false;
            if (levelTimer >= 3)
            {
                currentLevel = nextlevel - 1;
                roundFail = false;
                SceneManager.LoadSceneAsync(currentLevel);
            }
        }
    }
}

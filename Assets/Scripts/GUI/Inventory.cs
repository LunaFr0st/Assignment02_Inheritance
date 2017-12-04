using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GUIStyle invBox = new GUIStyle();
    public GUIStyle selectedInvBox = new GUIStyle();

    public GUIStyle wandFire = new GUIStyle();
    public GUIStyle wandWater = new GUIStyle();
    public GUIStyle wandGas = new GUIStyle();

    public SpriteRenderer spriteRend;
    public Sprite[] wandSelector;
    PlayerMovement playerControl;

    GUIStyle boxOne;
    GUIStyle boxTwo;
    GUIStyle boxThree;

    bool boxOneSelected = true;
    bool boxTwoSelected = false;
    bool boxThreeSelected = false;



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


    }
    void OnGUI()
    {
        Rect slotOne = new Rect(7 * sW, 8 * sH, sW, sH);
        Rect slotTwo = new Rect(8 * sW, 8 * sH, sW, sH);
        Rect slotThree = new Rect(9 * sW, 8 * sH, sW, sH);

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
    }
}

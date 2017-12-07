using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customisation : MonoBehaviour
{
    SpriteRenderer c_spriteRend;
    SpriteRenderer h_spriteRend;
    public float color_Green = 1;
    public float color_Blue = 1;
    public float color_Red = 1;

    public int pointsLeft = 7;
    public int healthPoint = 1;
    public int speedPoint = 1;
    public int damagePoint = 1;

    Color customColor;
    float sW, sH;

    bool showMainMenu = true;
    bool showCharColour = false;
    bool showCharStats = false;

    void Start()
    {
        c_spriteRend = GameObject.Find("Menu Hero").GetComponent<SpriteRenderer>();
        h_spriteRend = GameObject.Find("ArmHero").GetComponent<SpriteRenderer>();
        Load();


        customColor = new Color(color_Red, color_Green, color_Blue);
        c_spriteRend.color = customColor;
        h_spriteRend.color = customColor;
    }
    void Update()
    {
        sW = Screen.width / 16;
        sH = Screen.height / 9;
    }
    void OnGUI()
    {
        #region Main Menu
        if (showMainMenu)
        {
            int index = 0;
            GUI.Label(new Rect(sW, index * sH, 5 * sW, sH), "Select Option");
            index++;
            if (GUI.Button(new Rect(sW, index * sH, 5 * sW, sH), "Character Stats"))
            {
                showMainMenu = false;
                showCharColour = false;
                showCharStats = true;
            }
            index++;
            if (GUI.Button(new Rect(sW, index * sH, 5 * sW, sH), "Character Customisation"))
            {
                showMainMenu = false;
                showCharStats = false;
                showCharColour = true;
            }
            index++;
            if (GUI.Button(new Rect(sW, index * sH, 5 * sW, sH), "Exit Game"))
            {
                Application.Quit();
            }
        }
        #endregion
        #region Character Stats
        if (showCharStats)
        {
            int index = 1;
            GUI.Box(new Rect(0.5f * sW, index * sH, 2 * sW, sH), "Health Points: " + healthPoint);
            if (GUI.Button(new Rect(3.75f * sW, index * sH, 0.5f * sW, 0.5f * sH), ">"))
            {
                if (pointsLeft > 0)
                {
                    healthPoint++;
                    pointsLeft--;
                }
            }
            if (GUI.Button(new Rect(3 * sW, index * sH, 0.5f * sW, 0.5f * sH), "<"))
            {
                if (healthPoint > 0)
                {
                    healthPoint--;
                    pointsLeft++;
                }
            }
            float healthBox = 5;
            for (int i = 0; i < healthPoint; i++)
            {
                GUI.Box(new Rect(healthBox * sW, index * sH, 0.5f * sW, 0.5f * sH), "");
                healthBox += 0.5f;
            }
            index++;
            GUI.Box(new Rect(0.5f * sW, index * sH, 2 * sW, sH), "Speed Points: " + speedPoint);
            if (GUI.Button(new Rect(3.75f * sW, index * sH, 0.5f * sW, 0.5f * sH), ">"))
            {
                if (pointsLeft > 0)
                {
                    speedPoint++;
                    pointsLeft--;
                }
            }
            if (GUI.Button(new Rect(3 * sW, index * sH, 0.5f * sW, 0.5f * sH), "<"))
            {
                if (speedPoint > 0)
                {
                    speedPoint--;
                    pointsLeft++;
                }
            }
            float speedBox = 5;
            for (int i = 0; i < speedPoint; i++)
            {
                GUI.Box(new Rect(speedBox * sW, index * sH, 0.5f * sW, 0.5f * sH), "");
                speedBox += 0.5f;
            }
            index++;
            GUI.Box(new Rect(0.5f * sW, index * sH, 2 * sW, sH), "Damage Points: " + damagePoint);
            if (GUI.Button(new Rect(3.75f * sW, index * sH, 0.5f * sW, 0.5f * sH), ">"))
            {
                if (pointsLeft > 0)
                {
                    damagePoint++;
                    pointsLeft--;
                }
            }
            if (GUI.Button(new Rect(3 * sW, index * sH, 0.5f * sW, 0.5f * sH), "<"))
            {
                if (damagePoint > 0)
                {
                    damagePoint--;
                    pointsLeft++;
                }
            }
            float damageBox = 5;
            for (int i = 0; i < damagePoint; i++)
            {
                GUI.Box(new Rect(damageBox * sW, index * sH, 0.5f * sW, 0.5f * sH), "");
                damageBox += 0.5f;
            }

            index++;
            GUI.Box(new Rect(0.5f * sW, index * sH, 2 * sW, sH), "Points left: " + pointsLeft);
        }
        #endregion
        #region Character Colours
        if (showCharColour)
        {
            int index = 1;

            customColor = new Color(color_Red, color_Green, color_Blue);
            // Color Sliders
            GUI.Label(new Rect(0.5f * sW, index * sH, 2 * sW, sH), "Red: ");
            color_Red = GUI.HorizontalSlider(new Rect(2.5f * sW, index * sH, 2 * sW, sH), color_Red, 0, 1);
            index++;
            GUI.Label(new Rect(0.5f * sW, index * sH, 2 * sW, sH), "Green: ");
            color_Green = GUI.HorizontalSlider(new Rect(2.5f * sW, 2 * sH, 2 * sW, sH), color_Green, 0, 1);
            index++;
            GUI.Label(new Rect(0.5f * sW, index * sH, 2 * sW, sH), "Blue: ");
            color_Blue = GUI.HorizontalSlider(new Rect(2.5f * sW, 3 * sH, 2 * sW, sH), color_Blue, 0, 1);
            c_spriteRend.color = customColor;
            h_spriteRend.color = customColor;
            index++;
            if (GUI.Button(new Rect(0.5f * sW, index * sH, 2 * sW, sH), "Back"))
            {
                showCharColour = false;
                showCharStats = false;
                showMainMenu = true;
            }
            if (GUI.Button(new Rect(3.5f * sW, index * sH, 2 * sW, sH), "Apply"))
            {
                SaveColour();
            }
        }
        #endregion


    }
    void SaveColour()
    {
        PlayerPrefs.SetFloat("Color Red", color_Red);
        PlayerPrefs.SetFloat("Color Green", color_Green);
        PlayerPrefs.SetFloat("Color Blue", color_Blue);
    }
    void SaveStats()
    {
        PlayerPrefs.SetInt("Points Left", pointsLeft);
        PlayerPrefs.SetInt("Health Point", healthPoint);
        PlayerPrefs.SetInt("Speed Point", speedPoint);
        PlayerPrefs.SetInt("Damage Point", damagePoint);
    }
    void Load()
    {
        color_Red = PlayerPrefs.GetFloat("Color Red");
        color_Green = PlayerPrefs.GetFloat("Color Green");
        color_Blue = PlayerPrefs.GetFloat("Color Blue");

        pointsLeft = PlayerPrefs.GetInt("Points Left", 7);
        healthPoint = PlayerPrefs.GetInt("Health Point", 1);
        speedPoint = PlayerPrefs.GetInt("Speed Point", 1);
        damagePoint = PlayerPrefs.GetInt("Damage Point", 1);
    }

}

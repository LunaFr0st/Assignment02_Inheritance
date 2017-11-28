using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
    [System.Serializable]
    public class ColorConverter
    {
        public Color color;
        public GameObject prefab;
    }

    public class LevelGenerator : MonoBehaviour
    {
        public Texture2D level;
        public ColorConverter[] colorAssign;
        void Start()
        {
            GenerateLevel();
        }
        void GenerateLevel()
        {
            for (int x = 0; x < level.width; x++)
            {
                for (int y = 0; y < level.height; y++)
                {
                    GenerateTile(x, y);
                }
            }
        }
        void GenerateTile(int x, int y)
        {
            Color pxCol = level.GetPixel(x, y);
            if (pxCol.a == 0)
            {
                return;
            }
            foreach (ColorConverter colorMap in colorAssign)
            {
                if (colorMap.color.Equals(pxCol))
                {
                    Vector2 pos = new Vector2(x, y);
                    Instantiate(colorMap.prefab, pos, Quaternion.identity, transform);
                }
            }
        }
    }

}


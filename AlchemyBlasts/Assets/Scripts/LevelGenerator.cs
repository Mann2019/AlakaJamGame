﻿using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D[] level_maps;
    public ColorToPrefab[] colorMappings;

    private Texture2D level_map;

    // Use this for initialization
    void Start()
    {
        int k = Random.Range(0, level_maps.Length);
        level_map = level_maps[k];
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < level_map.width; i++)
        {
            for (int j = 0; j < level_map.height; j++)
            {
                GenerateTile(i, j);
            }
        }
    }

    void GenerateTile(int i, int j)
    {
        Color pixelcolor = level_map.GetPixel(i, j);
        if (pixelcolor.a == 0)
        {
            //pixel is transparent, ignore it
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelcolor))
            {
                Vector2 position = new Vector2(i, j);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}

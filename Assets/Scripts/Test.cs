using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // using System.Collections;
    // using System.Collections.Generic;
    // using UnityEngine;

    // public class Tile : MonoBehaviour
    // {
    //     [SerializeField] private Color baseColor, offsetColor;
    //     [SerializeField] private SpriteRenderer renderer;
    //     [SerializeField] private GameObject highlight;
    //     public void Init(bool isOffset) {
    //         renderer.color = isOffset ? offsetColor : baseColor;
    //     }

    //     void OnMouseEnter() {
    //         highlight.SetActive(true);
    //     }
        
    //     void OnMouseExit() {
    //         highlight.SetActive(false);
    //     }
    // }



    // using System;
    // using System.Collections;
    // using System.Collections.Generic;
    // using UnityEngine;

    // public class GridManager : MonoBehaviour
    // {
    //     [SerializeField] private int width, height;
    //     [SerializeField] private Tile tilePrefab;
    //     [SerializeField] private Transform cam;

    //     void GenerateGrid() {
    //         for (int x = 0; x < width; x++) {
    //             for (int y = 0; y < height; y++) {
    //                 var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
    //                 spawnedTile.name = $"Tile {x} {y}";

    //                 // true if x is even && y is odd || x is odd && y is even
    //                 var isOffset = (x + y) % 2 == 1;
    //                 spawnedTile.Init(isOffset);
    //             }
    //         }

    //         cam.transform.position = new Vector3((float) width/2 -0.5f, (float) height/2 -0.5f, -10);
    //     }

    //     void Start() {
    //         GenerateGrid();
    //     }
    // }

    
}
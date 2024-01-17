using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Camera cam;

    [SerializeField] private int width = 40;
    [SerializeField] private int height = 40;
    [SerializeField] private Vector3 startPos = Vector3.zero;
    
    private int CamMoveX => (int)(cam.transform.position.x - startPos.x);
    private int CamMoveY => (int)(cam.transform.position.y - startPos.y);
    private int CamLocationX => (int)Mathf.Floor(cam.transform.position.x);
    private int CamLocationY => (int)Mathf.Floor(cam.transform.position.y);

    public Hashtable tiletable = new Hashtable();

    private void InitTile() {
        for (int x = -width; x < width; x++) {
            for (int y = -height; y < height; y++) {
                Vector3 pos = new Vector3(x,y);

                var tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                tile.name = "Tile ("+ x + ", " + y+ ")";

                // set Tile field
                tile.setName("Hidden tile");
                tile.setPos(pos);
                tile.setState(Tile.State.Hidden);

                tiletable.Add(pos, tile);
            }
        }
    }
    private void GenerateTile() {
        if (Mathf.Abs(CamMoveX) >= 1 || Mathf.Abs(CamMoveY) >= 1) {
            for (int x = -width; x < width; x++) {
                for (int y = -height; y < height; y++) {
                    Vector3 pos = new Vector3(x + CamLocationX,y + CamLocationY);

                    if (!tiletable.ContainsKey(pos)) {
                        var tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                        tile.name = "Tile ("+ x + ", " + y+ ")";

                        // set Tile field
                        tile.setName("Hidden tile");
                        tile.setPos(pos);
                        tile.setState(Tile.State.Hidden);

                        tiletable.Add(pos, tile);
                    }
                }
            }
        }
    }

    void Start() {
        InitTile();
    }

    void Update() {
        GenerateTile();
    }
}

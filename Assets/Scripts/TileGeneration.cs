using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Camera cam;

    private int length = 5;
    private Vector3 startPos = Vector3.zero;
    
    private int CamMoveX => (int)(cam.transform.position.x - startPos.x);
    private int CamMoveY => (int)(cam.transform.position.y - startPos.y);
    private int CamLocationX => (int)Mathf.Floor(cam.transform.position.x);
    private int CamLocationY => (int)Mathf.Floor(cam.transform.position.y);

    private Hashtable tiletable;

    private void GenerateTile() {

        Hashtable newTile = new Hashtable();
        float currentTime = Time.realtimeSinceStartup;

        for (int x = -length; x < length; x++) {
            for (int y = -length; y < length; y++) {
                Vector3 pos = new(x + CamLocationX,y + CamLocationY);

                if (!tiletable.ContainsKey(pos)) {
                    GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                    tile.name = "Tile ("+ x + ", " + y+ ")";

                    Tile t = gameObject.AddComponent<Tile>();
                    // set Tile field
                    t.setName("Hidden tile");
                    t.setPos(pos);
                    t.setState(Tile.State.Hidden);
                    t.setTimestamp(currentTime);
                    t.setObject(tile);

                    // add into hashtable
                    tiletable.Add(pos, t);
                } else { // if tile exist, update the timestamp;
                    ((Tile)tiletable[pos]).setTimestamp(currentTime);
                }
            }
        }

        foreach (Tile t in tiletable.Values) {
            if (!t.getTimestamp().Equals(currentTime)) {
                Destroy(t.tileObject);
            } else {
                newTile.Add(t.tileObject,t);
            }
        }

        tiletable = newTile;
        startPos = cam.transform.position;
    }

    void Start() {
        tiletable = new Hashtable();
        GenerateTile();
    }

    void Update() {
        if (Mathf.Abs(CamMoveX) >= 1 || Mathf.Abs(CamMoveY) >= 1) {
            GenerateTile();
        }
    }
}

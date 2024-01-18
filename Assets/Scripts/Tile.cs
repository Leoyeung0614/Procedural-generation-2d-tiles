using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

    public class Tile : MonoBehaviour
    {

        private string name;
        public enum State {
            Hidden, 
            Reveal, 
            Occured,
        }
        [SerializeField] private State state;
        [SerializeField] private UnityEngine.Vector3 position;
        [SerializeField] private GameObject highlight;
        private float Timestamp;
        public GameObject tileObject;



        public void setName(string name) {
            this.name = name;
        }
        public void setPos(UnityEngine.Vector3 pos) {
            this.position = pos;
        }
        public void setState(State state) {
            this.state = state;
        }
        public void setTimestamp(float time) {
            this.Timestamp = time;
        }
        public void setObject(GameObject obj) {
            this.tileObject = obj;
        }

        public float getTimestamp() {
            return this.Timestamp;
        }

        // public GameObject getObject() {
        //     return this.tileObject;
        // }

        void OnMouseEnter() {
            highlight.SetActive(true);
        }
        
        void OnMouseExit() {
            highlight.SetActive(false);

        }
    }

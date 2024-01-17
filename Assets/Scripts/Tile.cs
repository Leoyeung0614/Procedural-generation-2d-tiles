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

        public void setName(string name) {
            this.name = name;
        }
        public void setPos(UnityEngine.Vector3 pos) {
            this.position = pos;
        }
        public void setState(State state) {
            this.state = state;
        }

        void OnMouseEnter() {
            highlight.SetActive(true);
        }
        
        void OnMouseExit() {
            highlight.SetActive(false);

        }
    }

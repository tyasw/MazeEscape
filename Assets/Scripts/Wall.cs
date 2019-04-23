using UnityEngine;

class Wall {
    public float Thickness { get; set; }
    public float Width { get; set; }
    public GameObject Instance { get; set; }
    
    public Wall(float thickness, float width, GameObject instance) {
        Thickness = thickness;
        Width = width;
        Instance = instance;
    }
}
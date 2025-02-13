using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillNode
{
    public int id;
    public Vector2 position;
    public Sprite icon;
    public SerializableDictionary<string, string> properties;
    public List<int> neighbors;
    public bool unlocked;

    public SkillNode(int _id, Vector2 _position, SerializableDictionary<string, string> _properties, List<int> _neighbors, bool _unlocked = false)
    {
        id = _id; 
        position = _position;
        properties = _properties;
        neighbors = _neighbors;
        unlocked = _unlocked;
    }
}

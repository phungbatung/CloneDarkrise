using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillNode
{
    public int id;
    public Vector2 position;
    public string name;
    public string description;
    public int icon;
    public int powerLevel;
    public SerializableDictionary<string, string> properties;
    public List<int> neighbors;
    public bool unlocked;

    public SkillNode(int _id, Vector2 _position, string _name, string _description, int _icon, int _powerLevel, SerializableDictionary<string, string> _properties, List<int> _neighbors, bool _unlocked = false)
    {
        id = _id;
        position = _position;
        name = _name;
        description = _description;
        icon = _icon;
        powerLevel = _powerLevel;
        properties = _properties;
        neighbors = _neighbors;
        unlocked = _unlocked;
    }
    public void Unlock()
    {
        unlocked = true;
    }
}

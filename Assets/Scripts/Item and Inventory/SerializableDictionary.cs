using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<SerializedDictionaryKVPProps<TKey, TValue>> dictList = new();

    public void OnBeforeSerialize()
    {
        dictList.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            dictList.Add(pair);
        }
    }
    public void OnAfterDeserialize()
    {
        this.Clear();

        for (int i = 0; i < dictList.Count; i++)
        {
            this.Add(dictList[i].Key, dictList[i].Value);
        }
    }
    [System.Serializable]
    public class SerializedDictionaryKVPProps<TypeKey, TypeValue>
    {
        //public int index;
        public TypeKey Key;
        public TypeValue Value;


        public SerializedDictionaryKVPProps(TypeKey key, TypeValue value) { this.Key = key; this.Value = value; }

        public static implicit operator SerializedDictionaryKVPProps<TypeKey, TypeValue>(KeyValuePair<TypeKey, TypeValue> kvp)
            => new SerializedDictionaryKVPProps<TypeKey, TypeValue>(kvp.Key, kvp.Value);
        public static implicit operator KeyValuePair<TypeKey, TypeValue>(SerializedDictionaryKVPProps<TypeKey, TypeValue> kvp)
            => new KeyValuePair<TypeKey, TypeValue>(kvp.Key, kvp.Value);
    }
}
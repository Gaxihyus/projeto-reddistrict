using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Node Path", menuName = "Node Path")]
public class NodePathSO : ScriptableObject
{
    public List<NodeData> nodes = new List<NodeData>();

    [Header("Gizmo Colors")]
    public Color nodeColor;
    public Color pathColor;
}

[System.Serializable]
public class NodeData
{
    public Vector3 position;
    public enum NodeType { Default, Event, Medal }
    public NodeType type;
}

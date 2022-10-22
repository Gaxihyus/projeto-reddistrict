using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PathManager : MonoBehaviour
{
    [Header("Paths")]
    public NodePathSO mainPath;
    public NodePathSO[] altPaths;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        // Caminho principal
        for (int i = 0; i < mainPath.nodes.Count; i++)
        {
            //Desenhar node
            Gizmos.color = mainPath.nodeColor;
            Vector3 nodeGizmoPos = mainPath.nodes[i].position;
            Gizmos.DrawCube(nodeGizmoPos, Vector3.one);

            //Desenhar numero de node
            GUI.color = mainPath.pathColor;
            Handles.Label(nodeGizmoPos, i.ToString());

            //Desenhar linha entre nodes
            Gizmos.color = mainPath.pathColor;
            Vector3 nextNodePos = mainPath.nodes[i + 1].position;
            if (i + 1 != mainPath.nodes.Count) Gizmos.DrawLine(nodeGizmoPos, nextNodePos);

            //Desenhar "icones" especiais dependendo do tipo de node para diferenciar melhor
            if (mainPath.nodes[i].type == NodeData.NodeType.Event) { Gizmos.color = Color.green; Gizmos.DrawWireSphere(nodeGizmoPos, 1f); }
            else if (mainPath.nodes[i].type == NodeData.NodeType.Medal) { Gizmos.color = Color.yellow; Gizmos.DrawWireSphere(nodeGizmoPos, 1f); }

            
        }
    }
}

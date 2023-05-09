using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode()]
public class CustomTools : MonoBehaviour
{
    private static Vector3 copiedLocalPosition;
    private static Quaternion copiedLocalRotation;


    [MenuItem("MusicHeadTools/Transform/Rotate x 90", false, 1)]
    public static void RotateX90()
    {
        Transform t = Selection.activeTransform;

        if(t != null)
        {
            t.Rotate(0, 0, 90);
        } else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }

    }

    [MenuItem("MusicHeadTools/Transform/Rotate x 90 All &#r", false, 2)]
    public static void RotateX90All()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (selected.Length > 0)
        {
            for(int i =0; i< selected.Length; i++)
            {
                selected[i].Rotate(0, 0, 90);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("MusicHeadTools/Transform/Copy local position and rotation &#c", false, 1)]
    public static void CopyLocalPosition()
    {
        Transform t = Selection.activeTransform;
            
        if(t != null) 
        {
            copiedLocalPosition = t.localPosition;
            copiedLocalRotation = t.localRotation;
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("MusicHeadTools/Transform/Paste local position &#c", false, 1)]
    public static void PasteLocalPosition()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (selected.Length > 0)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i].localPosition = copiedLocalPosition;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("MusicHeadTools/Transform/Paste local rotation &#c", false, 1)]
    public static void PasteLocalRotation()
    {
            Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
            
            if(selected.Length > 0) 
            {
                for (int i = 0; i < selected.Length; i++)
                {
                    selected[i].localRotation = copiedLocalRotation;
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
            }
    }

    [MenuItem("MusicHeadTools/Transform/Create parent for selection", false, 1)]
    public static void CreateParentForSelection() 
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
        if (selected.Length > 0) 
        {
            GameObject parent = new GameObject("Parent");
                    
            for(int i=0; i < selected.Length; i++) 
            { 
                selected[i].parent = parent.transform;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("MusicHeadTools/Tama�o/Duplicar tama�o &#m", false, 1)]
    public static void DuplicarTama�o()
    {
        Transform t = Selection.activeTransform;

        if (t != null)
        {
            t.localScale = t.localScale * 2;
            
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }
    [MenuItem("MusicHeadTools/Tama�o/Alargar tama�o &#m", false, 1)]
    public static void AlargarTama�o()
    {
        Transform t = Selection.activeTransform;

        if (t != null)
        {
            t.localScale = new Vector3(t.localScale.x, t.localScale.y * 2, t.localScale.z);
            
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }
    [MenuItem("MusicHeadTools/Tama�o/Acortar tama�o &#m", false, 1)]
    public static void AcortarTama�o()
    {
        Transform t = Selection.activeTransform;

        if (t != null)
        {
            t.localScale = new Vector3(t.localScale.x, t.localScale.y/2, t.localScale.z);
            
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }
    [MenuItem("MusicHeadTools/Tama�o/Aumentar ancho &#m", false, 1)]
    public static void AumentarAnchoTama�o()
    {
        Transform t = Selection.activeTransform;

        if (t != null)
        {
            t.localScale = new Vector3(t.localScale.x * 2, t.localScale.y, t.localScale.z);
            
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }
    [MenuItem("MusicHeadTools/Tama�o/Disminuir ancho &#m", false, 1)]
    public static void DisminuirAnchoTama�o()
    {
        Transform t = Selection.activeTransform;

        if (t != null)
        {
            t.localScale = new Vector3(t.localScale.x/2, t.localScale.y, t.localScale.z);
            
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }
    [MenuItem("MusicHeadTools/Tama�o/Dividir tama�o &#t", false, 1)]
    public static void DividirTama�o()
    {
        Transform t = Selection.activeTransform;

        if (t != null)
        {
            t.localScale = t.localScale / 2;

        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }
}

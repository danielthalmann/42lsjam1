using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    public HeadControl headControl; // Référence à la tête pour obtenir la liste de positions et le nombre de corps

    public int queueIndex;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Obtient la liste de positions de la tête
        Queue<Vector3> positionList = headControl.GetPositionList();

        // Vérifie si la liste de positions et le corps sont disponibles
        if (positionList != null && positionList.Count > queueIndex)
        {
            // Obtient la position correspondante de la liste de positions
            Vector3 bodyPosition = positionList.ToArray()[positionList.Count - queueIndex];
            // Ajuste la position du corps
            transform.position = bodyPosition;
        }
    }
}
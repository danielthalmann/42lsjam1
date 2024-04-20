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
        // Obtient la liste de positions et de rotations de la tête
        Queue<PositionRotation> positionAndRotationList = headControl.GetPositionAndRotationList();

        // Vérifie si la liste de positions et de rotations et le corps sont disponibles
        if (positionAndRotationList != null && positionAndRotationList.Count > queueIndex)
        {
            // Obtient la position et la rotation correspondante de la liste
            PositionRotation positionRotation = positionAndRotationList.ToArray()[positionAndRotationList.Count - queueIndex];
            // Ajuste la position et la rotation du corps
            transform.position = positionRotation.position;
            transform.rotation = positionRotation.rotation;
        }
    }

}
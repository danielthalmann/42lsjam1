using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// Structure personnalisée pour stocker à la fois un Vector3 et un Quaternion
public struct PositionRotation
{
    public Vector3 position;
    public Quaternion rotation;

    // Constructeur pour initialiser la structure avec une position et une rotation
    public PositionRotation(Vector3 pos, Quaternion rot)
    {
        position = pos;
        rotation = rot;
    }
}

public class HeadControl : MonoBehaviour
{
    public InputActionReference move;

    private Vector3 moveDirection = Vector3.zero;

    private Queue<PositionRotation> positionAndRotationList = new Queue<PositionRotation>();

    private List<GameObject> bodyList = new List<GameObject>();
    public GameObject bodyPrefab; // Référence vers le prefab de corps à instancier
    public int bodySpacing = 8;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = move.action.ReadValue<Vector2>();

        moveDirection = new Vector3(direction.x, 0, direction.y);
    }

    private void FixedUpdate()
    {
        SetPositionAndRotationList();
    }

    private void SetPositionAndRotationList()
    {
        // Ajoute la position et la rotation actuelle à la Queue
        positionAndRotationList.Enqueue(new PositionRotation(transform.position, transform.rotation));
        Debug.Log(positionAndRotationList.Count);

        // Vérifie si la Queue dépasse la longueur maximale désirée
        if (positionAndRotationList.Count > bodySpacing * (bodyList.Count + 1))
        {
            // Si c'est le cas, retire le premier élément de la Queue
            positionAndRotationList.Dequeue();
        }
    }


    //Fonction pour obtenir les positions enregistrées pendant une seconde
    public Queue<PositionRotation> GetPositionAndRotationList()
    {
        return positionAndRotationList;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Collectable")) // Vérifie si l'objet collisionné est bien "coins"
        {
            Destroy(collider.gameObject); // Détruit l'objet "coins"
      
            GameObject newBody = Instantiate(bodyPrefab, CalculateNewBodyPosition(), transform.rotation);

            BodyController bc = newBody.GetComponent<BodyController>();
            bodyList.Add(newBody);
            bc.headControl = this;
            bc.queueIndex = bodySpacing * (bodyList.Count);

            GameManager.instance.Collecte(1);

        }

        // Collision avec un corps détectée
        if (collider.gameObject.CompareTag("Player"))
        {
            // Déclencher la condition de défaite
            GameManager.instance.GameLoose();
        }
    }

    private Vector3 CalculateNewBodyPosition()
    {
        // Vérifie si des corps existent déjà dans la chaîne
        if (bodyList.Count > 0)
        {
            // Récupère la position du dernier Body dans la chaîne
            Vector3 lastBodyPosition = bodyList[bodyList.Count - 1].transform.position;

            // Calcule une nouvelle position derrière le dernier Body dans la direction opposée à celle du mouvement du Head
            Vector3 newBodyPosition = lastBodyPosition - transform.forward * bodySpacing;

            return newBodyPosition;
    }
        else
        {
            // Si aucun corps n'existe encore dans la chaîne, place le nouveau Body directement derrière la tête
            return transform.position - transform.forward * bodySpacing;
}
    }
}
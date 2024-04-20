using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadControl : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed = 10f;
    public InputActionReference move;

    private Vector3 moveDirection = Vector3.zero;

    private Queue<Vector3> positionList = new Queue<Vector3>();
    private int stackLength = 50;

    private List<GameObject> bodyList = new List<GameObject>();
    public GameObject bodyPrefab; // Référence vers le prefab de corps à instancier
    public int bodySpacing = 2;

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
        rb.velocity = moveDirection * moveSpeed;

        SetPositionList();
    }

    private void SetPositionList()
    {
        positionList.Enqueue(transform.position);

        if (positionList.Count > stackLength * bodyList.Count + 1)
        {
            positionList.Dequeue();
        }
    }

    //Fonction pour obtenir les positions enregistrées pendant une seconde
    public Queue<Vector3> GetPositionList()
    {
        return positionList;
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
            bc.queueIndex = bodySpacing * (bodyList.Count + 1);

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
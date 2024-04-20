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
    public float bodySpacing = 1f;

    private int bodyCount = 1;

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
        //Debug.Log(positionList.ToArray()[0]);
        //Debug.Log("Positions in second: ");
        //Debug.Log(positionList.Count);
    }

    private void UpdateBodyCount()
    {
        bodyCount++;
    }

    private void SetPositionList()
    {
        positionList.Enqueue(transform.position);

        if (positionList.Count > stackLength * bodyCount)
        {
            positionList.Dequeue();
        }
    }

    // Fonction pour obtenir les positions enregistrées pendant une seconde
    public Queue<Vector3> GetPositionList()
    {
        return positionList;
    }

    public int GetBodyCount()
    {
        return bodyCount;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Collectable")) // Vérifie si l'objet collisionné est bien "coins"
        {
            Destroy(collider.gameObject); // Détruit l'objet "coins"
            UpdateBodyCount();
            GameObject newBody = Instantiate(bodyPrefab, transform.position, transform.rotation);

            BodyController bc = newBody.GetComponent<BodyController>();
            bc.headControl = this;
            bc.queueIndex = bodyList.Count + 1;

            bodyList.Add(newBody);
        }
    }
}
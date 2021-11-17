using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [Tooltip("move speed")] [SerializeField] private float moveSpeed;
    [SerializeField] private float steerSpeed;
    [Tooltip("Distance between body parts")] [SerializeField] private int gap;
    [Tooltip("the body speed")] [SerializeField] private int bodySpeed;

    [Tooltip("body prefab")] [SerializeField] private GameObject bodyPrefab;
    private List<GameObject> bodyParts; // the list of the body parts of the snake
    private List<Vector3> positionHistory; // list of position history
    private const float POSITION_HEIGHT_BODY = 0.5f;

    private void Awake()
    {
        bodyParts = new List<GameObject>();
        positionHistory = new List<Vector3>();
    }
    void Start()
    {
        GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;


        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime); // rotate

        
        positionHistory.Insert(0, transform.position + Vector3.up* POSITION_HEIGHT_BODY);
        
        int index = 0;

        foreach(var body in bodyParts)
        {
            Vector3 point = positionHistory[Mathf.Min(index * gap, positionHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }

        

    }

    public void GrowSnake() // add part of body to snake
    {
        GameObject body = Instantiate(bodyPrefab);
        body.transform.position = this.transform.position;

        bodyParts.Add(body);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionPlayer : MonoBehaviour
{
    [Tooltip("names of the tringers with the player")] [SerializeField] string[] triggeringTag;
    [SerializeField] private SnakeController snake;
    private SnakeHealth snakeHealth;
    [Tooltip("name of the scene to reload")] [SerializeField] private string reloadScene;
    [Tooltip("name of the next scene to reload")] [SerializeField] private string nextScene;
    private void Start()
    {
        snakeHealth = GetComponent<SnakeHealth>(); //get component of SnakeHealth
    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.tag == triggeringTag[0] && enabled) // colltion with correct answer
        {

            snake.GrowSnake();
            Destroy(other.gameObject);
            SceneManager.LoadScene(nextScene);
        }

        if (other.tag == triggeringTag[1] && enabled) // collision with wrong answer
        {
            snakeHealth.loseLife();
            transform.position = Vector3.zero;
            if (snakeHealth.getLife() < 0)
                SceneManager.LoadScene(reloadScene);
        }





    }
}

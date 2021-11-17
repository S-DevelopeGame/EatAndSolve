using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHealth : MonoBehaviour
{
    [Tooltip("hearts objects")] [SerializeField] private GameObject[] hearts;
    private int life;
    private void Start()
    {
        life = hearts.Length-1;
    }


    public int getLife()
    {
        return life;
    }

    public void loseLife() // lose life
    {
        Destroy(hearts[life].gameObject);
        life--;
    }
}

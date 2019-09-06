using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> leftPositions = new List<Transform>();
    [SerializeField]
    private List<Transform> midPositions = new List<Transform>();
    [SerializeField]
    private List<Transform> rightPositions = new List<Transform>();

    public delegate void Jumper();
    public static event Jumper OnCrash;
    public static event Jumper OnSave;

    public int currentPosition = 0;

    private List<Transform> pos;

    float lastMoveTime;
    float moveDelay = 1.0f;
    int rand;
    float deathDelay = 0.5f;
    bool isDead = false;

    private void Start()
    {
        rand = Random.Range(1, 4);
        transform.position = leftPositions[currentPosition].position;
        lastMoveTime = Time.time;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(moveDelay);
            RandomPaths();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Rescuer"))
        {
            Debug.Log("Rescued");
            OnSave();
        } else if (collision.gameObject.name.Equals("Sea"))
        {
            StartCoroutine(Crashed());
            Debug.Log("Dead");
            OnCrash();
        }
    }

    void MoveToNextPosition(List<Transform> position)
    {

        currentPosition++;

        if (currentPosition >= position.Count)
        {
            GameObject parent = transform.parent.gameObject;
            Destroy(parent);
        } else {

            transform.position = position[currentPosition].position;

        }

    }

    private void RandomPaths()
    {
        switch (rand)
        {
            case 1: MoveToNextPosition(leftPositions);
                break;

            case 2: MoveToNextPosition(midPositions);
                break;

            case 3: MoveToNextPosition(rightPositions);
                break;
        }
    }

    IEnumerator Crashed()
    {
        isDead = true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        
        yield return new WaitForSeconds(deathDelay);
        DestroyJumper();
        
    }

    void DestroyJumper()
    {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }

}

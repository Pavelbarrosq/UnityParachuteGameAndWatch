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

    public int currentPosition = 0;

    private List<Transform> pos;

    float lastMoveTime;
    float moveDelay = 1.0f;
    int rand;

    private void Start()
    {
        rand = Random.Range(1, 4);
        transform.position = leftPositions[currentPosition].position;
        lastMoveTime = Time.time;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            RandomPaths();
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


}

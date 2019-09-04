using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    [SerializeField]

    private List<Transform> positions = new List<Transform>();

    public int currentPosition = 0;

    float lastMoveTime;
    float moveDelay = 1.0f;

    private void Start()
    {
        transform.position = positions[currentPosition].position;
        lastMoveTime = Time.time;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
        }
    }

    void MoveToNextPosition()
    {

        currentPosition++;

        if (currentPosition >= positions.Count)
        {
            GameObject parent = transform.parent.gameObject;
            Destroy(parent);
        } else {

            transform.position = positions[currentPosition].position;

        }

    }


}

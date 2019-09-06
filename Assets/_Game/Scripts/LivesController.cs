using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{

    public float lifeDistance = 0.8f;
    private List<GameObject> lives = new List<GameObject>();


    public void StartingLives(int count)
    {
        GameObject firstLife = transform.GetChild(0).gameObject;
        lives.Add(firstLife);

        if (firstLife == null)
        {
            Debug.Log("No Lives");
            return;
        }

        for (int i = 0; i < count - 1; i++)
        {
            GameObject life = Instantiate(firstLife);
            lives.Add(life);
            life.transform.parent = transform;
            Vector3 pos = life.transform.position;
            pos.x += lifeDistance * (i + 1);
            life.transform.position = pos;
        }
    }


    public bool RemoveLife()
    {
        if (lives.Count < 1)
        {
            return false;
        }

        GameObject lastLife = lives[lives.Count - 1];
        lives.RemoveAt(lives.Count - 1);

        Destroy(lastLife);

        return true;
    }
}

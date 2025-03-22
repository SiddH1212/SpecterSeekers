using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent navMeshAgent;
    public float speed;
    public float minOffset;
    public float maxOffset;
    private float baseOffset;
    public Data killCountData;
    void Start() 
    {
        StartCoroutine(SetBaseOffset()); 
    }

    IEnumerator SetBaseOffset()
    {
        yield return new WaitForEndOfFrame(); 
        baseOffset = Random.Range(minOffset, maxOffset);
        navMeshAgent.baseOffset = baseOffset;
    }
    void Update()
    {
        Vector3 targetPosition =  Camera.main.transform.position;
        navMeshAgent.SetDestination(targetPosition);
        navMeshAgent.speed = speed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the Player has the correct tag
        {
            Lives playerLives = other.GetComponent<Lives>();
            if (playerLives != null)
            {
                playerLives.loseLife(); // Reduce a heart
            }
            killCountData.killCount -= 1;
            Kill();
        }
    }
    public void Kill()
    {
        navMeshAgent.enabled = false;
        animator.SetTrigger("Death");
        killCountData.killCount += 1;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

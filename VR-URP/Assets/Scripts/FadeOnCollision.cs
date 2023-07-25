using UnityEngine;
using UnityEngine.Events;

public class FadeOnCollision : MonoBehaviour
{
    [SerializeField] float collisionRadius;
    [SerializeField] LayerMask collisionLayers;
    public UnityEvent OnCollisionEnter = new UnityEvent();
    public UnityEvent OnCollisionExit = new UnityEvent();


    bool isCollided = false;

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, collisionRadius, collisionLayers, QueryTriggerInteraction.Ignore))
        {
            if (isCollided)
                return;
            isCollided = true;

            OnCollisionEnter.Invoke();
            Debug.Log("Collided with something.");
        }
        else
        {
            if (!isCollided)
                return;
            isCollided = false;

            OnCollisionExit.Invoke();
            Debug.Log("Exited collision");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.6f);
        Gizmos.DrawSphere(transform.position, collisionRadius);
    }
}

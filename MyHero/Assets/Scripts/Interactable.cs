using UnityEngine;

public class Interactable : MonoBehaviour
{
    bool hasInteracted = false;
    bool isFocus = false;
    Transform player;
    public float radius = 2f;
    public Transform interactionSpace;
    void OnDrawGizmosSelected()
    { 
        if(interactionSpace == null)
           interactionSpace = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionSpace.position, radius);
       
    }
    void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionSpace.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
        
    }
    public virtual void Interact()
    {
        Debug.Log("Interacting with" + transform.name);
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
}

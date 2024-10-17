using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectableBehaviou : MonoBehaviour
{
    public Animator collectableAnimator;
    public Transform collectableTransform;
    public CircleCollider2D collectableCollider;
    public SpriteRenderer collectableSprite;
    public GameObject collectable;

    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player"))
        {
            collectableAnimator.SetBool("IsCollected", true);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        DestroyCollectable();
    }

    void DestroyCollectable()
    {
        if(collectableAnimator.GetBool("IsCollected") == true)
        {
            Destroy(collectable.gameObject);
        }
    }

    IEnumerator AwaitAnimation (GameObject gameObject)
    {
        yield return new WaitUntil(collectableAnimator.GetBool("IsCollected"))
    }

}

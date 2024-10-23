using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectableBehaviou : MonoBehaviour
{
    public Animator collectableAnimator;
    public Transform collectableTransform;
    public CircleCollider2D collectableCollider;
    public SpriteRenderer collectableSprite;
    public GameObject collectable;
    ScoreManager _scoreManager;

    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _scoreManager = FindAnyObjectByType<ScoreManager>();
        _scoreManager.AddCollectable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player"))
        {
            collectableAnimator.SetTrigger("Collected");
            _scoreManager.IncreaseScore();
            StartCoroutine(DestroyCollectable());
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        DestroyCollectable();
    }

    public IEnumerator DestroyCollectable()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }

}

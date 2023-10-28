using Item;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public ItemType itemType;

    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHideParticle = .3f;

    public Collider itemCollider;

    public GameObject graphicItem;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
        
    }
    protected virtual void Collect()
    {
        if (itemCollider != null) itemCollider.enabled = false;
        if(graphicItem  != null)
        {
            graphicItem.SetActive(false);
        }
        Invoke("HideObject", timeToHideParticle);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }


    protected virtual void OnCollect()
    {
        if(particleSystem != null)
        {
            particleSystem.Play();
        }

        if(audioSource != null)
        {
            audioSource.Play();
        }

        ItemManager.Instance.AddByType(itemType);
    }

    
}

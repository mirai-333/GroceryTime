using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CartTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();

        if (item == null)
            return;

        if (item.IsAdded)
            return;

        item.MarkAsAdded();

        CartManager.Instance.AddItem(item.ItemData);
        StartCoroutine(ShowAddedUI());
        AudioManager.Instance.PlayAdded();

        other.transform.SetParent(transform);        
        StartCoroutine(FixItem(other.gameObject));

    }

/*
        other.enabled = false;
        other.transform.SetParent(transform);
    }*/

    private IEnumerator FixItem(GameObject obj)
    {
        yield return new WaitForSeconds(4f);

        Item item = obj.GetComponent<Item>();

        if (item == null || !item.IsAdded)
            yield break;

        Rigidbody rb = obj.GetComponent<Rigidbody>();

        if (rb != null)
            rb.isKinematic = true;
    }

    private IEnumerator ShowAddedUI()
    {
        yield return new WaitForSeconds(0.25f);

        ItemAddedUI.Instance.Show();
    }
}

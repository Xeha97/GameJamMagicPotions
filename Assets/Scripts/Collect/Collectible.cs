using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject collectedItem;
    [SerializeField] private TMP_Text collectedText;
    [SerializeField] private CollectManager cm;
    private PlayFSound playAudio;
    private void Awake()
    {
        playAudio = GetComponent<PlayFSound>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playAudio.PlaySound();
            cm.CollectPotion();
            collectedText.color = Color.green;
            Destroy(gameObject);
        }
    }
}

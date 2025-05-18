using UnityEngine;
using UnityEngine.UI;


public class HeadCollisionVignetteUI : MonoBehaviour
{
    public Image vignetteImage;

    private void OnTriggerEnter(Collider other)
    {
        vignetteImage.color = new Color(0, 0, 0, 1); // Czarny, pe³na przezroczystoœæ
    }

    private void OnTriggerExit(Collider other)
    {
        vignetteImage.color = new Color(0, 0, 0, 0); // Przezroczysty
    }
}

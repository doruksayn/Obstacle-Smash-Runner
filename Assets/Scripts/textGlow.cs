using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMPGlowOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI targetText;

    private Material targetMaterial;

    void Start()
    {
        // Text'in material'ını al
        targetMaterial = targetText.fontMaterial;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Glow'u aç
        targetMaterial.SetFloat("_GlowPower", 0.05f); // 1f = açık, değerini shader'dan ayarlayabilirsin
        targetMaterial.SetFloat("_UnderlayOffsetX", 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Glow'u kapat
        targetMaterial.SetFloat("_GlowPower", 0f); // 0f = kapalı
        targetMaterial.SetFloat("_UnderlayOffsetX", 0f);
    }
}

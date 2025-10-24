using UnityEngine;

public class PopUpSprite : MonoBehaviour
{
    public GameObject spriteObject; // Faites glisser votre GameObject Sprite ici depuis l'Inspector

    public void ShowSprite()
    {
        if (spriteObject != null)
        {
            spriteObject.SetActive(true);
        }
        else
        {
            Debug.LogError("L'objet Sprite à afficher n'est pas assigné !");
        }
    }

    public void HideSprite()
    {
        if (spriteObject != null)
        {
            spriteObject.SetActive(false);
        }
    }
}
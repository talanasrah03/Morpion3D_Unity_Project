using UnityEngine;
using UnityEngine.UI;

public class IconDropdownPreview : MonoBehaviour
{
    public Dropdown player1Dropdown;
    public Dropdown player2Dropdown;
    public Image player1IconPreview;
    public Image player2IconPreview;
    public Sprite[] iconSprites;

    void Start()
    {
        // Set initial preview
        UpdatePlayer1Icon(player1Dropdown.value);
        UpdatePlayer2Icon(player2Dropdown.value);

        // Add dropdown listeners
        player1Dropdown.onValueChanged.AddListener(UpdatePlayer1Icon);
        player2Dropdown.onValueChanged.AddListener(UpdatePlayer2Icon);
    }

    void UpdatePlayer1Icon(int index)
    {
        player1IconPreview.sprite = iconSprites[index];
    }

    void UpdatePlayer2Icon(int index)
    {
        player2IconPreview.sprite = iconSprites[index];
    }
}
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    [Header("Toggles")]
    public Toggle kitchen1;
    public Toggle kitchen2;
    public Button matchSettings;

    [Header("Menus")]
    public GameObject settings;
    public GameObject lobbyTemp;
    
    // Start is called before the first frame update
    void Start()
    {
        matchSettings.onClick.AddListener(() => {
            MatchSettings();
        });

        if (kitchen1.isOn)
        {
            // Save 
            // Load kitchen 1 scene when start game
        }

        if (kitchen2.isOn)
        {
            // Save 
            // Load kitchen 2 scene when start game
        }
    }
    
    public void MatchSettings() {
        lobbyTemp.SetActive(false);
        settings.SetActive(true);
    }
}

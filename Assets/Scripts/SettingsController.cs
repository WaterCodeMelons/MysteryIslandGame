using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider fovSlider; // slider field of view
    public Text fovValue; // Wartość field of view
    public Toggle vSync; // Przełącznik vSync
    public Toggle fullScreen; // Przełącznik fullScreen
    public Dropdown shadows; // Dropdown Menu dla cieni
    public Dropdown texturesQuality; // Dropdown Menu dla jakości tekstur
    public GameObject settingsPanel; // Panel ustawień
    public GameObject menu; // Panel Menu
    public Toggle statsDisplay; // Pokaz panel statystyk
    public Toggle timeDisplay; // Pokaz panel czasu
    public GameObject timePanel; // Panel czasu
    public GameObject statsPanel; // Panel Statystyk

    Settings settings; // Tworzę obiekt Settings na podstawie klasy Settings
    // Use this for initialization
    void Awake()
    {
        Debug.Log("Poczatkowe ustawienia:"); // Dodatek do Loga by łatwiej było z niego czytać
        logSettings(); // Wypisuje aktualne ustawienia w konsoli
        LoadSettings("savedSettings.json"); // Wczytuje aktualne ustawienia z pliku

    }

    void Update()
    {
        if (menu.activeInHierarchy == false)
        {
            LoadSettings("savedSettings.json");
        }
        else  // Jezeli menu jest włączone
        {
            if (settingsPanel.activeInHierarchy == true) // Jezeli panel ustawień jest włączony
            {
                fovValue.text = fovSlider.value.ToString(); // Ustawiam wartość fovValue na wartość slidera
            }
        }

    }

    public void LoadSettings(string fileName) // Ładowanie ustawień z pliku (string to nazwa pliku z folderu StreamingAssets)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName); // Określa nazwę na podstawie plików w folderze StreamingAssets
        if (File.Exists(filePath)) // Sprawdza czy plik istnieje
        {
            string dataAsJson = File.ReadAllText(filePath); // Wyczytuje wszystkie linijki z pliku json
            settings = JsonUtility.FromJson<Settings>(dataAsJson); // Przypisuje odpowiednie wartości z pliku json do obiektu settings
            QualitySettings.vSyncCount = settings.vsync; // Określam vsync na podstawie pliku
            QualitySettings.shadowCascades = settings.shadowCascades; // Określam kaskadowość cieni na podstawie pliku
            QualitySettings.shadowDistance = settings.shadowDistance; // Określam długość cieni na podstawie pliku
            QualitySettings.masterTextureLimit = settings.masterTextureLimit; // Określam maksymalny limit tekstury (im mniejszy tym lepiej)
            Camera.main.fieldOfView = settings.fov; // Określam fov na podstawie pliku
            Screen.fullScreen = settings.fullScreen; // Określam fullscreen na podstawie pliku
            statsPanel.SetActive(settings.statsDisplay); // Ustawiam aktywność panelu statystyk na podstawie pliku
            timePanel.SetActive(settings.timeDisplay); // Ustawiam aktywność panelu czasu na podstawie pliku

            if (statsPanel.activeInHierarchy) // Sprawdzam czy panel statystyk jest aktywny w hierarchii
            {
                statsDisplay.isOn = true; // Zmieniam toggle w ustawieniach na ON
            }
            else
            {
                statsDisplay.isOn = false; // Zmieniam toggle w ustawieniach na OFF
            }
            if (timePanel.activeInHierarchy) // Sprawdzam czy panel czasu jest aktywny w hierachii
            {
                timeDisplay.isOn = true; // Zmieniam toggle w ustawieniach na ON
            }
            else 
            {
                timeDisplay.isOn = false; // Zmieniam toggle w ustawieniach na OFF
            }
            if (QualitySettings.vSyncCount == 0) // Sprawdzam czy vsync jest wyłączone
            {
                vSync.isOn = false; // Zmieniam toggle w ustawieniach na OFF
            }
            else
            {
                vSync.isOn = true; // Zmieniam toggle w ustaiweniach na ON
            }
            if (Screen.fullScreen) // Sprawdzam czy fullscreen jest włączony
            {
                fullScreen.isOn = true; // Zmieniam toggle w ustawieniach na ON
            }
            else
            {
                fullScreen.isOn = false; // Zmieniam toggle w ustawieniach na OFF
            }
            fovSlider.value = settings.fov;
            //Ustawianie odpowiedniej opcji w Cieniach
            if (settings.shadowCascades==0 && settings.shadowDistance==0)
            {
                shadows.value = 0;
            }
            if (settings.shadowCascades == 2 && settings.shadowDistance == 75)
            {
                shadows.value = 1;
            }
            if (settings.shadowCascades == 4 && settings.shadowDistance == 150)
            {
                shadows.value = 2;
            }
            if (settings.shadowCascades == 4 && settings.shadowDistance == 500)
            {
                shadows.value = 3;
            }
            //Ustawienie odpowiedniej opcji w Teksturach
            if (settings.masterTextureLimit == 2)
            {
                texturesQuality.value = 0;
            }
            if (settings.masterTextureLimit == 1)
            {
                texturesQuality.value = 1;
            }
            if (settings.masterTextureLimit == 0)
            {
                texturesQuality.value = 2;
            }
            Debug.Log("Wczytane ustawienia:");
            logSettings();
        }
        else {
            Debug.LogError("Brak pliku ustawień!");
        }
    }

	void logSettings()  // Wypisuje odpowiednie rzeczy z konsoli
	{
		Debug.Log("Vsync: " + QualitySettings.vSyncCount);
		Debug.Log("Cienie: " + QualitySettings.shadowCascades);
		Debug.Log("Długość cieni: " + QualitySettings.shadowDistance);
		Debug.Log("Jakość tekstur: " + QualitySettings.masterTextureLimit);
		Debug.Log("FOV: " + Camera.main.fieldOfView);
		Debug.Log("FullScreen: " + Screen.fullScreen);
        Debug.Log("Panel statystyk: " + statsPanel.activeInHierarchy);
        Debug.Log("Panel czasu:"+ timePanel.activeInHierarchy);
	}

    public void SaveSettings(string fileName) // Zapisuje ustawienia
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
        {
            settings.fov = fovSlider.value;
            settings.fullScreen = fullScreen.isOn;
            //Ustawiam vsync
            if(vSync.isOn==true)
            {
                settings.vsync = 1;
            }
            else
            {
                settings.vsync = 0;
            }
            //Ustawiam jakość tekstur
            if (texturesQuality.value == 0)
            {
                settings.masterTextureLimit = 2;
            }
            if (texturesQuality.value == 1)
            {
                settings.masterTextureLimit = 1;
            }
            if (texturesQuality.value == 2)
            {
                settings.masterTextureLimit = 0;
            }
            //Ustawiam jakość cieni
            if (shadows.value == 0)
            {
                settings.shadowCascades = 0;
                settings.shadowDistance = 0;
            }
            if (shadows.value == 1)
            {
                settings.shadowCascades = 2;
                settings.shadowDistance = 75;
            }
            if (shadows.value == 2)
            {
                settings.shadowCascades = 4;
                settings.shadowDistance = 150;
            }
            if (shadows.value == 3)
            {
                settings.shadowCascades = 4;
                settings.shadowDistance = 500;
            }
            settings.statsDisplay = statsDisplay.isOn;
            settings.timeDisplay = timeDisplay.isOn;
            string currentSettings = JsonUtility.ToJson(settings);
            File.WriteAllText(filePath, currentSettings);
            LoadSettings(fileName);
        }
    }
}
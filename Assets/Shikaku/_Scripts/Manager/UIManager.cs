using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] UIScreen[] screens;
    [SerializeField] Popup[] popups;
    [SerializeField, Space(10)] ScreenType _defaultScreen;
    UIScreen _activeScreen;
    public UIScreen ActiveScreen => _activeScreen;
    Popup _activePopup;

    private void Start()
    {
        Input.multiTouchEnabled = false;
        Init();
    }
    void Init()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].Disable();
        }
        for (int i = 0; i < popups.Length; i++)
        {
            popups[i].Disable();
        }

        if (_defaultScreen != ScreenType.None)
            ChangeScreen(_defaultScreen);
    }

    public static UIScreen GetScreen(ScreenType screenType)
    {
        for (int i = 0; i < Instance.screens.Length; i++)
        {
            if (Instance.screens[i].screenType.Equals(screenType)) return Instance.screens[i];
        }
        return null;
    }

    public static Popup GetPopup(PopupType popupType)
    {
        for (int i = 0; i < Instance.popups.Length; i++)
        {
            if (Instance.popups[i].popupType.Equals(popupType)) return Instance.popups[i];
        }
        return null;
    }

    public static void ChangeScreen(ScreenType toScreenType)
    {
        Instance._activeScreen?.Hide();
        UIScreen toScreen = GetScreen(toScreenType);

        if (toScreen)
            Instance._activeScreen = toScreen;

        Instance._activeScreen?.Show();
    }

    public static void ShowPopup(PopupType popupType)
    {
        Instance._activePopup?.Hide();
        if (popupType == PopupType.None) return;

        Popup popupToOpen = GetPopup(popupType);
        if (popupToOpen) Instance._activePopup = popupToOpen;

        Instance._activePopup.Show();
    }
    public static void ShowOverlayPopup(PopupType popupType)
    {
        if (popupType == PopupType.None) return;

        Popup popupToOpen = GetPopup(popupType);

        popupToOpen.Show();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : UIBase
{
    public ScreenType screenType;
}
public enum ScreenType
{
    None,
    Gameplay,
    ProductActivation,
    CreateUser,
    WelcomeScreen,
    LoginScreen,
    MainMenuScreen,
    ExerciseMenuScreen,
    LoadingScreen

}
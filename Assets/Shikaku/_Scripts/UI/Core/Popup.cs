using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : UIBase
{
    public PopupType popupType;
}
public enum PopupType
{
    None,
    ExerciseOver,
    Instruction,
    // StartExcercise,
    SpeedIndexCalculator,
    AngleIndexCalculator,
    CloseExercise,
    DeleteUser,
    InternetNotWorkingPopup
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData {
	public static int Score = 0;
	public static bool IsFirstLevelLoaded = false;	// Para que cuando pasemos a la siguiente escena, como la puntucación puede que no haya cambiado, que no se cargue continuamente la escena
	public static bool IsSecondLevelLoaded = false;
	public static bool IsThirdLevelLoaded = false;
	public static bool IsGameOverScreenLoaded = false;
	public static bool IsWinScreenLoaded = false;
	public static bool IsPlayerDead = false;
	public static bool IsBossDead = false;
	public static int Lifes = 3;
}

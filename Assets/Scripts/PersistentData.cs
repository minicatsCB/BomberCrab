using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData {
	public static int Score = 0;
	public static bool _isFirstLevelLoaded = false;	// Para que cuando pasemos a la siguiente escena, como la puntucación puede que no haya cambiado, que no se cargue continuamente la escena
	public static bool _isSecondLevelLoaded = false;
	public static bool _isThirdLevelLoaded = false;
	public static bool _isGameOverScreenLoaded = false;
	public static bool _isWinScreenLoaded = false;
	public static bool _isPlayerDead = false;
	public static bool _isBossDead = false;
	public static int Lifes = 3;
}

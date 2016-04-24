using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeGamePage : UIView
{
	[SerializeField]
	private GameView gameView;

	private IEnumerator Start()
	{
		var instance = Instantiate(gameView);
		var gameScene = SceneManager.GetSceneByName("Game");
		SceneManager.SetActiveScene(gameScene);

		// TODO DO STUFF FOR GAMESCENE.

		// TODO LEVEL SCENE

		// TODO ENABLE STUFF

		yield return null;
		UIStack.ReplaceInstance(instance);
	}
}

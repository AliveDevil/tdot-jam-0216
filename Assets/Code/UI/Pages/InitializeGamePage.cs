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
        yield return SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
		var gameScene = SceneManager.GetSceneByName("Game");
		SceneManager.SetActiveScene(gameScene);
        instance.Player = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        // TODO DO STUFF FOR GAMESCENE.

        // TODO LEVEL SCENE

        // TODO ENABLE STUFF

        yield return null;
		UIStack.ReplaceInstance(instance);
	}
}

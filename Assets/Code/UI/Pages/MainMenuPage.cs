using UnityEngine;

public class MainMenuPage : UIView
{
	[SerializeField]
	private UIView gameView;
	[SerializeField]
	private UIView highscoreView;

	public void Exit()
	{
		Application.Quit();
	}

	public void OpenHighscore()
	{
		UIStack.Push(highscoreView);
	}

	public void StartGame()
	{
		UIStack.Replace(gameView);
	}
}

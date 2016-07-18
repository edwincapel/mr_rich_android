using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public AudioClip coinSound;
	public Text scoreText;
	public Text highScoreText;
	public Text currentScore;
	public GameObject EnemyPrefab;
	public GameObject money;
	public int moneyValue;
	public static int score;
	public int highScore;
	public float currentScale = 0.5f;
	public string fileNameShare;
	string ScoreText;


	public void TweetLove(){

		int unicode = 10084;
		char character = (char) unicode;
		string text = character.ToString();

		string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
		string TWEET_LANGUAGE = "en";

		Application.OpenURL(TWITTER_ADDRESS +
			"?text=" + WWW.EscapeURL("I " + text + " Mr Rich !" + "\nDownload Mr Rich from the appstore now !  \n\nhttp://mrrichthega.me/\nhttp://gph.is/1MIkOaI")) ;

	}
		
	public void Reset(){

		score = 0;
	}
		

	// Use this for initialization
	void Start () {
		EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		money.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		UpdateScore ();
		if(PlayerPrefs.HasKey("HighScore")){
			highScore = PlayerPrefs.GetInt("HighScore");
			highScoreText.text = "" + highScore;
		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.name == "moneymo" || col.gameObject.name == "moneymo(Clone)") {
			AudioSource.PlayClipAtPoint (coinSound, transform.position);
			score += moneyValue;
			UpdateScore ();
		}

	}

	void UpdateScore(){
		scoreText.text = "" + score;
		currentScore.text = "" + score;
		if (score > highScore) {
			highScore = score;
			highScoreText.text = "" + highScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}
		if (score >= 10 && score<=20) {
			currentScale = 0.7f;
			EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = currentScale;
			money.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		}
		else if (score >= 21 && score<=30) {
			currentScale = 0.9f;
			EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = currentScale;
			money.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		}
		else if (score >= 31 && score<=1000) {
			currentScale = 1.1f;
			EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = currentScale;
			money.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		}

	}
}

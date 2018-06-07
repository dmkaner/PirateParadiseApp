using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using System.Threading;
using System;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour {

	private bool levelUp = true;

	private float Speed = 6;
	private Rigidbody2D rigi;
	private int direction = 1;
	public Sprite forward;
	public Sprite backward;
	public Sprite leftward;
	public Sprite rightward;
	public SpriteRenderer spriteParent;
	private int count = 0;
	private bool play = false;
	private bool showScreen = false;
	private bool pauseCheck = false;
	private bool overState = false;
	Vector2 pos; 

	public Canvas CanvasStart;
	public Canvas CanvasPauseBtnLayer;
	public Canvas CanvasPauseMenu;
	public Canvas CanvasGameovrMenu;
	public Canvas CanvasSettingsMenu;
	public Canvas CanvasStatsMenu;
	public Canvas CanvasTipMenu;

	public Button Play;
	public Button Settings;
	public Button Stats;
	public Button Pause;

	public Button pauseSettings;
	public Button pausePlay;
	public Button overPlay;
	public Button overStats;
	public Button overSettings;
	public Button settingsReturn;
	public Button statsReturn;

	public Button tipPauseMenu;
	public Button tipGameOverMenu;
	public Button tipReturnBTN;

	public Animator anim;

	public Text endLevelTxt;
	public Text highScoreTxt;
	public Text levelCountTxt;
	public Text levelCountPauseTxt;
	public Text levelTimePauseTxt;

	private int levelCount = 0;
	private int highScore = 0;

	public Text gamesPlayedStat;
	public Text highScoreStat;
	public Text turnCountStat;
	public Text mysteryNumberStat;
	private int gamesPlayedInt = 0;
	private int highScoreInt = 0;
	private int mysteryNumberInt = 0;
	private int turnCountInt = 0;

	public Toggle song1;
	public Toggle song2;
	public Toggle song3;
	public Toggle song4;

	public Collider2D end1;
	public Collider2D end2;
	public Collider2D end3;
	public Collider2D end4;
	public Collider2D end5;
	public Collider2D end6;
	public Collider2D end7;
	public Collider2D end8;
	public Collider2D end9;
	public Collider2D end10;
	public Collider2D end11;
	public Collider2D end12;
	public Collider2D end13;
	public Collider2D end14;
	public Collider2D end15;
	public Collider2D end16;
	public Collider2D end17;
	public Collider2D end18;
	public Collider2D end19;
	public Collider2D end20;
	public Collider2D end21;
	public Collider2D end22;
	public Collider2D end23;
	public Collider2D end24;
	public Collider2D end25;
	public Collider2D end26;
	public Collider2D end27;
	public Collider2D end28;
	public Collider2D end29;
	public Collider2D end30;
	public Collider2D end31;

	private int turnAdCount = 0;

	private Stopwatch timer = new Stopwatch();

	private void Awake()
	{
		rigi = GetComponent<Rigidbody2D>();
	}

	void Start(){
		spriteParent = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator> ();

		Button btnMainSettings = Settings.GetComponent<Button> ();
		btnMainSettings.onClick.AddListener (TaskOnClickSettings);
		Button btnMainStats = Stats.GetComponent<Button> ();
		btnMainStats.onClick.AddListener (TaskOnClickStats);
		Button btnPause = Pause.GetComponent<Button>();
		btnPause.onClick.AddListener(TaskOnClickPause);
		Button btnPlay = Play.GetComponent<Button>();
		btnPlay.onClick.AddListener(TaskOnClickPlay);
		Button statBack = statsReturn.GetComponent<Button> ();
		statBack.onClick.AddListener (TaskOnClickStatReturn);
		Button pauseSettings2 = pauseSettings.GetComponent<Button>();
		pauseSettings2.onClick.AddListener(TaskOnClickPauseSettings);
		Button pausePlay2 = pausePlay.GetComponent<Button>();
		pausePlay2.onClick.AddListener(TaskOnClickPausePlay);
		Button overPlay2 = overPlay.GetComponent<Button>();
		overPlay2.onClick.AddListener(TaskOnClickOverPlay);
		Button overStats2 = overStats.GetComponent<Button>();
		overStats2.onClick.AddListener(TaskOnClickOverStats);
		Button overSettings2 = overSettings.GetComponent<Button>();
		overSettings2.onClick.AddListener(TaskOnClickOverSettings);
		Button settingsReturn2 = settingsReturn.GetComponent<Button>();
		settingsReturn2.onClick.AddListener(TaskOnClickSettingsReturn);
		Button tipPause = tipPauseMenu.GetComponent<Button>();
		tipPause.onClick.AddListener(TaskOnClickTipBTN);
		Button tipGameOver = tipGameOverMenu.GetComponent<Button>();
		tipGameOver.onClick.AddListener(TaskOnClickTipBTN);
		Button settingsReturnTip = tipReturnBTN.GetComponent<Button>();
		settingsReturnTip.onClick.AddListener(TaskOnClickTipReturn);

		CanvasStatsMenu.GetComponent<Canvas> ().enabled = false;
		CanvasPauseMenu.GetComponent<Canvas> ().enabled = false;
		CanvasGameovrMenu.GetComponent<Canvas> ().enabled = false;
		CanvasSettingsMenu.GetComponent<Canvas> ().enabled = false;
		CanvasPauseBtnLayer.GetComponent<Canvas> ().enabled = false;
		CanvasTipMenu.GetComponent<Canvas> ().enabled = false;

		turnCountInt = PlayerPrefs.GetInt ("turnCount", turnCountInt);
		turnCountStat.text = PlayerPrefs.GetInt ("turnCount", turnCountInt).ToString();
		gamesPlayedStat.text = PlayerPrefs.GetInt ("gamesPlayed", gamesPlayedInt).ToString();
		highScoreStat.text = PlayerPrefs.GetInt ("highscore", highScore).ToString();
		highScoreTxt.text = PlayerPrefs.GetInt ("highscore", highScore).ToString();

		rigi.isKinematic = true;
	}

	void TaskOnClickTipReturn(){
		CanvasTipMenu.GetComponent<Canvas> ().enabled = false;
	}
	void TaskOnClickTipBTN(){
		CanvasTipMenu.GetComponent<Canvas> ().enabled = true;
	}
	void TaskOnClickStatReturn(){
		CanvasStatsMenu.GetComponent<Canvas> ().enabled = false;
	}
	void TaskOnClickPlay(){
		play = true;
		rigi.isKinematic = false;
		CanvasStart.GetComponent<Canvas> ().enabled = false;
		CanvasPauseBtnLayer.GetComponent<Canvas> ().enabled = true;
		this.transform.position = pos;
		direction = 1;
		anim.SetBool ("movingUp", true);
		anim.SetBool ("movingDown", false);
		anim.SetBool ("movingLeft", false);
		anim.SetBool ("movingRight", false);
		timer.Start();
	}
	void TaskOnClickPause(){
		timer.Stop ();
		levelTimePauseTxt.text = timer.Elapsed.ToString();
		levelCountPauseTxt.text = levelCount.ToString ();
		TimeSpan ts = timer.Elapsed;
		levelTimePauseTxt.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
		if (showScreen == false) {
			CanvasPauseMenu.GetComponent<Canvas> ().enabled = true;
			showScreen = true;
			pauseCheck = true;
			Speed = 0;
		} else if (showScreen == true) {
			CanvasPauseMenu.GetComponent<Canvas> ().enabled = false;
			showScreen = false;
			Speed = 6;
			pauseCheck = false;
		}
	}
	void TaskOnClickSettings(){
		CanvasSettingsMenu.GetComponent<Canvas> ().enabled = true;
	}
	void TaskOnClickStats(){
		mysteryNumberInt = Random.Range(0,10000);
		mysteryNumberStat.text = mysteryNumberInt.ToString ();
		turnCountStat.text = PlayerPrefs.GetInt ("turnCount", turnCountInt).ToString();
		CanvasStatsMenu.GetComponent<Canvas> ().enabled = true;
		gamesPlayedStat.text = PlayerPrefs.GetInt ("gamesPlayed", gamesPlayedInt).ToString();
		highScoreStat.text = PlayerPrefs.GetInt ("highscore", highScore).ToString();
	}

	void TaskOnClickPausePlay(){
		timer.Start ();
		CanvasPauseMenu.GetComponent<Canvas> ().enabled = false;
		showScreen = false;
		Speed = 6;
		pauseCheck = false;
	}
	void TaskOnClickPauseSettings(){
		CanvasSettingsMenu.GetComponent<Canvas> ().enabled = true;
	}
	void TaskOnClickOverPlay(){
		CanvasGameovrMenu.GetComponent<Canvas> ().enabled = false;
		this.transform.position = pos;
		direction = 1;
		anim.SetBool ("movingUp", true);
		anim.SetBool ("movingDown", false);
		anim.SetBool ("movingLeft", false);
		anim.SetBool ("movingRight", false);
		Speed = 6;
		overState = false;
		levelCount = 0;
		levelCountTxt.text = levelCount.ToString();
		timer.Start();
		end1.isTrigger = true;
		end2.isTrigger = true;
		end3.isTrigger = true;
		end4.isTrigger = true;
		end5.isTrigger = true;
		end6.isTrigger = true;
		end7.isTrigger = true;
		end8.isTrigger = true;
		end9.isTrigger = true;
		end10.isTrigger = true;
		end11.isTrigger = true;
		end12.isTrigger = true;
		end13.isTrigger = true;
		end14.isTrigger = true;
		end15.isTrigger = true;
		end16.isTrigger = true;
		end17.isTrigger = true;
		end18.isTrigger = true;
		end19.isTrigger = true;
		end20.isTrigger = true;
		end21.isTrigger = true;
		end22.isTrigger = true;
		end23.isTrigger = true;
		end24.isTrigger = true;
		end25.isTrigger = true;
		end26.isTrigger = true;
		end27.isTrigger = true;
		end28.isTrigger = true;
		end29.isTrigger = true;
		end30.isTrigger = true;
		end31.isTrigger = true;
	}
	void TaskOnClickOverSettings(){
		CanvasSettingsMenu.GetComponent<Canvas> ().enabled = true;
	}
	void TaskOnClickOverStats(){
		mysteryNumberInt = Random.Range(0,10000);
		mysteryNumberStat.text = mysteryNumberInt.ToString ();
		turnCountStat.text = PlayerPrefs.GetInt ("turnCount", turnCountInt).ToString();
		CanvasStatsMenu.GetComponent<Canvas> ().enabled = true;
		gamesPlayedStat.text = PlayerPrefs.GetInt ("gamesPlayed", gamesPlayedInt).ToString();
		highScoreStat.text = PlayerPrefs.GetInt ("highscore", highScore).ToString();
	}
	void TaskOnClickSettingsReturn(){
		CanvasSettingsMenu.GetComponent<Canvas> ().enabled = false;
	}

	void Update(){

		if (count == 0) {
			pos = this.transform.position;
			count++;
		}

		if (Speed == 0 && pauseCheck == false && overState == false) {

			CanvasGameovrMenu.GetComponent<Canvas> ().enabled = true;
			endLevelTxt.text = levelCount.ToString();
			if (turnAdCount >= 75) {
				//ShowAd ();
				turnAdCount = 0;
			}
			if (levelCount > PlayerPrefs.GetInt ("highscore", highScore)) {
				highScore = levelCount;
				PlayerPrefs.SetInt ("highscore", highScore);
			}
			gamesPlayedInt = PlayerPrefs.GetInt ("gamesPlayed", gamesPlayedInt);
			gamesPlayedInt++;
			PlayerPrefs.SetInt ("gamesPlayed", gamesPlayedInt);

			PlayerPrefs.Save ();


			highScoreTxt.text = PlayerPrefs.GetInt ("highscore", highScore).ToString();

			overState = true;

		}

		if (direction == 1) {
			rigi.transform.position += Vector3.up *Time.deltaTime * Speed;
		}
		if (direction == 2) {
			rigi.transform.position += Vector3.down *Time.deltaTime * Speed;
		}
		if (direction == 3) {
			rigi.transform.position += Vector3.left *Time.deltaTime * Speed;
		}
		if (direction == 4) {
			rigi.transform.position += Vector3.right *Time.deltaTime * Speed;
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			direction = 1;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			direction = 2;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			direction = 3;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			direction = 4;
		}

		if (play == true && pauseCheck == false && overState == false) {
			for (var i = 0; i < Input.touchCount; ++i) {
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began) {
					// Need to put .x
					if (touch.position.x > (Screen.width / 2) && touch.position.y < (Screen.height / 2)) {
						if (direction == 1) {
							direction = 4;
							anim.SetBool ("movingRight", true);
							anim.SetBool ("movingUp", false);
							anim.SetBool ("movingDown", false);
							anim.SetBool ("movingLeft", false);
						} else if (direction == 2) {
							direction = 3;
							anim.SetBool ("movingLeft", true);
							anim.SetBool ("movingUp", false);
							anim.SetBool ("movingDown", false);
							anim.SetBool ("movingRight", false);
						} else if (direction == 3) {
							direction = 1;
							anim.SetBool ("movingUp", true);
							anim.SetBool ("movingDown", false);
							anim.SetBool ("movingLeft", false);
							anim.SetBool ("movingRight", false);
						} else if (direction == 4) {
							direction = 2;
							anim.SetBool ("movingDown", true);
							anim.SetBool ("movingUp", false);
							anim.SetBool ("movingLeft", false);
							anim.SetBool ("movingRight", false);
						}
						turnCountInt++;
						turnAdCount++;
					}
					if (touch.position.x < (Screen.width / 2) && touch.position.y < (Screen.height / 2)) {
						if (direction == 1) {
							direction = 3;
							anim.SetBool ("movingLeft", true);
							anim.SetBool ("movingUp", false);
							anim.SetBool ("movingDown", false);
							anim.SetBool ("movingRight", false);
						} else if (direction == 2) {
							direction = 4;
							anim.SetBool ("movingRight", true);
							anim.SetBool ("movingUp", false);
							anim.SetBool ("movingDown", false);
							anim.SetBool ("movingLeft", false);
						} else if (direction == 3) {
							direction = 2;
							anim.SetBool ("movingDown", true);
							anim.SetBool ("movingUp", false);
							anim.SetBool ("movingLeft", false);
							anim.SetBool ("movingRight", false);
						} else if (direction == 4) {
							direction = 1;
							anim.SetBool ("movingUp", true);
							anim.SetBool ("movingDown", false);
							anim.SetBool ("movingLeft", false);
							anim.SetBool ("movingRight", false);
						}
						turnCountInt++;
						turnAdCount++;
					}
					PlayerPrefs.SetInt ("turnCount", turnCountInt);
					PlayerPrefs.Save ();

				}
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if (play == true) {
			Speed = 0;
			timer.Reset();
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (play == true && other.isTrigger && levelUp) {
			levelUp = false;
			levelCount++;
			levelCountTxt.text = levelCount.ToString();
			StartCoroutine(ExecuteAfterTime(1, other));

		}
	}

	IEnumerator ExecuteAfterTime(float time, Collider2D other)
	{
		yield return new WaitForSeconds(time);

		other.isTrigger = false;
		levelUp = true;
	}

//	public void ShowAd()
//	{
//		if (Advertisement.IsReady())
//		{
//			Advertisement.Show();
//		}
//	}
}

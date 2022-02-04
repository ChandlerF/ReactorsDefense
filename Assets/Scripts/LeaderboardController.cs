using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderboardController : MonoBehaviour
{

	const string privateCode = "-dwKiceVzk6IIGwXIsi83AZVui0D29aUu9SeiO365oNA";
	const string publicCode = "61f7b4fd8f40bb1058bc2913";
	const string webURL = "http://dreamlo.com/lb/";

	DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;
	public static LeaderboardController instance;

	void Awake()
	{
		highscoreDisplay = GetComponent<DisplayHighscores>();
		instance = this;
	}

	public void AddNewHighscore(string username, int score)
	{
		instance.StartCoroutine(instance.UploadNewHighscore(username, score));
	}

	IEnumerator UploadNewHighscore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			print("Upload Successful");
			DownloadHighscores();
		}
		else
		{
			print("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			FormatHighscores(www.text);
            try
			{
				highscoreDisplay.OnHighscoresDownloaded(highscoresList);
			}
            catch
            {
				Debug.Log("No Display");
            }
		}
		else
		{
			print("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username, score);
			print(highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}

}




/*
	using LootLocker.Requests;
    [SerializeField] private TMPro.TMP_InputField MemberID, PlayerScore;
    [SerializeField] private int ID = 1427;


    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) => 
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }*/





/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderboardController : MonoBehaviour
{

	const string privateCode = "-dwKiceVzk6IIGwXIsi83AZVui0D29aUu9SeiO365oNA";
	const string publicCode = "61f7b4fd8f40bb1058bc2913";
	const string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoresList;

	void Awake()
	{
		//AddNewHighscore("Sebastian", 50);

		DownloadHighscores();
	}

	public void AddNewHighscore(string username, int score)
	{
		StartCoroutine(UploadNewHighscore(username, score));
	}

	private IEnumerator UploadNewHighscore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			print("Upload Successful");
		else
		{
			print("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	private IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			FormatHighscores(www.text);
		else
		{
			print("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username, score);
			print(highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}

}*/
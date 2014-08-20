using UnityEngine;
using System.Collections;
using HTTP;

public class habitCheck : MonoBehaviour {

	private string bUrl = "https://beta.habitrpg.com/api/v2/status";
	private string url = "https://beta.habitrpg.com/api/v2/user";
	private string key = "45482a67-8c71-4595-bfa5-f19ddeca8d95";
	private string uid = "b2f17791-3247-462b-8cfe-86e9f9bca28f";
	// Use this for initialization
	void Start () {
		StartCoroutine (CheckServer());
		StartCoroutine (LoginRequest ());
		Debug.Log ("start");
		}
	public IEnumerator CheckServer()
	{
		Debug.Log ("CheckServer");
		var request = new HTTP.Request("GET", bUrl);
		
		
		//request.headers.Set("Content-Type", "application/json");
		request.Send();
		while (!request.isDone) yield return new WaitForEndOfFrame();
		
		
		if (request.exception != null)
		{
			Debug.LogError(request.exception);
			//error = true;
			
		}
		else
		{
			var response = request.response;
			//inspect response code
			Debug.Log(response.status);
			//inspect headers
			
			//uniweb
			Debug.Log(response.GetHeaders("Content-Type"));
			
			//unityhttp
			//Debug.Log (response.GetHeaders("Content-Type"));
			
			//Get the body as a byte array
			//Debug.Log(response.bytes);
			//Or as a string
			Debug.Log(response.Text);
			//string authResponse = response.Text;
			//Type t = authResponse.GetType();
			//			Hashtable authResponse = JsonSerializer.Decode(response.Text) as Hashtable;
			//Debug.Log("Type is " + t.FullName);
			//Debug.Log(authObject["id"]);
			
			/*if (response.status == 200)
			{
				serverUp = true;				
			}
			else
			{
				serverUp = false;
			}*/
		}
	}

	public IEnumerator LoginRequest()
	{
		Debug.Log ("LoginRequest");
		var request = new HTTP.Request("GET", url);
		//set headers
		
		//uniweb
		//request.headers.Set("x-api-key", key);
		//request.headers.Set("x-api-user", uid);
		
		//unityhttp
		request.SetHeader("x-api-key", key);
		request.SetHeader("x-api-user", uid);
		
		
		request.Send();
		while (!request.isDone) yield return new WaitForEndOfFrame();
		
		
		if (request.exception != null)
		{
			Debug.LogError(request.exception);
			//error = true;
			
		}
		else
		{
			
			var response = request.response;
			//inspect response code
			Debug.Log(response.status);
			//inspect headers
			
			//uniweb
			//Debug.Log(response.headers.Get("Content-Type"));
			
			//unityhttp
			Debug.Log(response.GetHeaders("Content-Type"));
			
			//Get the body as a byte array
			//Debug.Log(response.bytes);
			//Or as a string
			Debug.Log(response.Text);
			/*if(response.status == 200)
			{
				//possibly not secure
				PlayerPrefs.SetString("uid", uid);
				PlayerPrefs.SetString("key", key);
				Application.LoadLevel("Main");
			}
			else
			{
				error = true;
			}
			*/
			//userData = new HabitDatav1(response.Text);
			//object ht = userData.ht;
			
		}
	}



	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{

		if (GUI.Button (new Rect (Screen.width / 2 - 10, Screen.height / 2 - Screen.height / 4 + 220, 320, 35), "Click me") || 
					(Event.current.isKey && Event.current.keyCode == KeyCode.Return)) 
		{
			StartCoroutine (LoginRequest ());
		}
	}

}

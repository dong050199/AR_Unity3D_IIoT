using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class Dashboard : MonoBehaviour,ITrackableEventHandler
{
    public GameObject imageTarget;
    public GameObject canvas;
    public GameObject imageTarget1;
    public GameObject canvas1;
    public GameObject imageTarget2;
    public GameObject canvas2;
    public GameObject imageTarget3;
    public GameObject canvas3;
    public Text timeText;
    public Text time1Text;
    public Text time2Text;
    public Text time3Text;
    //public Text time4Text;

    public Text flowspText;
    public float flowspVal;

    public Text flowpvText;
    public float flowpvVal;

    public Text p3timeText;
    public float p3timeVal;

    public Text valveText;
    public float valveVal;

    public Text sensorText;
    public float sensorVal;

    public Text flowpv1Text;
    public Text flowsp1Text;




    //khai bao bien tu unity o cho nay;

    int index;
	public GameObject[] Buttons =new GameObject[3];
    
    private bool targetFound = false;
    private TrackableBehaviour mTrackableBehaviour;
    private TrackableBehaviour m1TrackableBehaviour;
    private TrackableBehaviour m2TrackableBehaviour;
    private TrackableBehaviour m3TrackableBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = imageTarget.GetComponent<TrackableBehaviour> ();
        m1TrackableBehaviour = imageTarget1.GetComponent<TrackableBehaviour> ();
        m2TrackableBehaviour = imageTarget2.GetComponent<TrackableBehaviour> ();
        m3TrackableBehaviour = imageTarget3.GetComponent<TrackableBehaviour> ();

        if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
        if (m1TrackableBehaviour)
        {
            m1TrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        if (m2TrackableBehaviour)
        {
            m2TrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        if (m3TrackableBehaviour)
        {
            m3TrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(targetFound){
            canvas.SetActive (true);
            canvas1.SetActive(true);
            canvas2.SetActive(true);
            canvas3.SetActive(true);
            
            //Debug.Log("Target found");
            timeText.text = System.DateTime.Now.ToString ("h:mm:ss tt");
            time1Text.text = timeText.text;
            time2Text.text = timeText.text;
            time3Text.text = timeText.text;
            //time4Text.text = System.DateTime.Now.ToString("h:mm:ss tt");
            //chinh sua bien cho nay;
            flowspText.text = flowspVal.ToString();
            flowpvText.text = flowpvVal.ToString();
            flowpv1Text.text = flowpvVal.ToString();
            flowsp1Text.text = flowspVal.ToString();
            p3timeText.text = p3timeVal.ToString();
            sensorText.text = sensorVal.ToString();
            valveText.text = valveVal.ToString();
            //cai nay dung de thay doi mau cua button;
            //flowspBT.GetComponent<UnityEngine.UI.Image>().color = Color.red;


        }
             else{
           canvas.SetActive (false);
           canvas1.SetActive(false);
           canvas2.SetActive(false);
           canvas3.SetActive(false);

        }

         
    }

    public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			targetFound = true; //when target is found
		} else {
			targetFound = true; //when target is lost
		}
	}

    private void greenButtonColor (int i) { 
		//Debug.Log ("Green");
		Color greenColor = new Color (0.00f, 0.94f, 0.12f, 1.0f);
		Button b = Buttons[i].GetComponent<Button>(); 
		ColorBlock cb = b.colors;
		cb.normalColor = greenColor;
		b.colors = cb;
		//EffectColor.GetComponent<LineRenderer> ().material.SetColor ("_TintColor",greenColor);
	}
	private void orangeButtonColor (int i) {
		//Debug.Log ("Orange"); // yellow
		Color redColor = new Color (1.0f, 0.48f, 0.16f, 1.0f);
		Button b = Buttons[i].GetComponent<Button>(); 
		ColorBlock cb = b.colors;
		cb.normalColor = redColor;
		b.colors = cb;
	}

	private void blueButtonColor (int i) {
		//Debug.Log ("Blue");
		Color blueColor = new Color (0.27f, 0.43f, 1.0f, 1.0f);
		Button b = Buttons[i].GetComponent<Button> (); 
		ColorBlock cb = b.colors;
		cb.normalColor = blueColor;
		b.colors = cb;
	}

    private void changeButtonBgColor(int i, Color color){
        Button b = Buttons[i].GetComponent<Button> (); 
		ColorBlock cb = b.colors;
		cb.normalColor = color;
		b.colors = cb;
    }
}

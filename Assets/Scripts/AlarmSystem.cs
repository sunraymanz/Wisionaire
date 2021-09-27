using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AirFishLab.ScrollingList;

public class AlarmSystem : MonoBehaviour
{
    public int savedHr = 0;
    public int savedMin = 0;
    public int inputType = 0;
    [Space]
    [Header("Reference")]
    [SerializeField] Button playButton;
    [SerializeField] Button saveButton;
    [SerializeField] NotiSystem notiToken;
    [SerializeField] InputField hrInput;
    [SerializeField] InputField minInput;
    [SerializeField] CircularScrollingList hrScroll;
    [SerializeField] CircularScrollingList minScroll;
    [Space]
    [Header("CheckUI")]
    [SerializeField] Text hrSelected;
    [SerializeField] Text minSelected;
    [SerializeField] Text savedTime;
    [SerializeField] Text alertText;

    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        //savedHr = DateTime.Now.Hour;
        //savedMin = DateTime.Now.Minute;
        Debug.Log("HR Now = " + System.DateTime.Now.Hour);
        Debug.Log("Min Now = " + System.DateTime.Now.Minute);
        hrInput.text = "00";
        minInput.text = "00";
        CheckSave();
        CheckTime();
        FindObjectOfType<NotiSystem>().CreateNoti();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CheckTime();
        }
    }

    void LateUpdate()
    {
        CheckTime();
        
    }

    void CheckSave()
    {
        if (PlayerPrefs.HasKey("savedHr") && PlayerPrefs.HasKey("savedMin"))
        {
            Debug.Log("Save Detected");
            savedHr = PlayerPrefs.GetInt("savedHr"); 
            savedMin = PlayerPrefs.GetInt("savedMin");
        }
        else
        {
            Debug.Log("Save Not Found");
            PlayerPrefs.SetInt("savedHr",0);
            PlayerPrefs.SetInt("savedMin",0);
        }
        Debug.Log("Saved Time = " + savedHr.ToString("d2") + ":" + savedMin.ToString("d2"));
    }
    void CheckTime()
    {
        savedTime.text = "Current Time = " + System.DateTime.Now.Hour.ToString("d2") + "." + System.DateTime.Now.Minute.ToString("d2") + 
                         "\nSaved Time = "+savedHr.ToString("d2")+"."+savedMin.ToString("d2");
        if (savedHr > System.DateTime.Now.Hour)
        {
            //Debug.Log("It's not time yet!");
            playButton.interactable = false;
        }
        else if (savedHr < System.DateTime.Now.Hour)
        {        
            //Debug.Log("You can play!");
            playButton.interactable = true;
        }
        else 
        {
            if (savedMin < System.DateTime.Now.Minute)
            {
                //Debug.Log("You can play!");
                playButton.interactable = true;
            }
            else
            {
                //Debug.Log("It's not time yet!");
                playButton.interactable = false;
            }
        }
        if (playButton.interactable)
        { alertText.text = "It's time! Let's Play"; }
        else { alertText.text = "It's not time yet!"; }
    }

    public void CheckInputField(bool isHr)
    {
        
        if (isHr)
        {
            if (hrInput.text == "")
            { hrInput.text = "00"; }
            int tempHr = int.Parse(hrInput.text);
            if (tempHr >= 0 && tempHr <= 23)
            {
                Debug.Log("Correct Input");
            }
            else
            {
                Debug.Log("Invalid Input");
                hrInput.text = "00";
            }
        }
        else
        {
            if (minInput.text == "")
            { minInput.text = "00"; }
            int tempMin = int.Parse(minInput.text);
            if (tempMin >= 0 && tempMin <= 59)
            {
                Debug.Log("Correct Input");
            }
            else
            {
                Debug.Log("Invalid Input");
                minInput.text = "00";
            }
        }
    }

    public void UsingInputType(int type)
    {
        inputType = type;
    }

    public void OnHrCenteredContentChanged()
    {
        try 
        {
            var content = hrScroll.GetCenteredContentID();
            hrSelected.text = "Hr = " + content;
        }
        catch 
        {
            hrSelected.text = "Hr = " + 0;
        }  
    }

    public void OnMinCenteredContentChanged()
    {
        try
        {
            var content = minScroll.GetCenteredContentID();
            minSelected.text = "Min = " + content;
        }
        catch 
        {
            minSelected.text = "Min = " + 0;
        }
    }

    public void SavedTime()
    {
        if (inputType == 0)
        {
            savedHr = hrScroll.GetCenteredContentID();
            savedMin = minScroll.GetCenteredContentID();
            Debug.Log("Record Via Scroll Field");
        }
        else
        {
            savedHr = int.Parse(hrInput.text);
            savedMin = int.Parse(minInput.text);
            Debug.Log("Record Via Input Field");
        }
        PlayerPrefs.SetInt("savedHr", savedHr);
        PlayerPrefs.SetInt("savedMin", savedMin);
        Debug.Log("Change Playtime to " + savedHr + "." + savedMin);
        FindObjectOfType<NotiSystem>().UpdateNoti();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;


public class NotiSystem : MonoBehaviour
{
    int id;
    [SerializeField] AlarmSystem alarmToken;
    AndroidNotification notification;
    [SerializeField] Text notiText;

    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        alarmToken = FindObjectOfType<AlarmSystem>();
        SetupNoti();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetupNoti()
    {
        //Clear Noti
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        //Create Noti Channel
        var defaultChannel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);
    }
    public void CreateNoti()
    {
        //Create Noti push
        notification = new AndroidNotification();
        notification.Title = "Hey you!";
        notification.Text = "Yes~ YOU! Come! and Play~";
        notification.SmallIcon = "default";
        notification.LargeIcon = "default";
        //notification.FireTime = DateTime.Now.AddSeconds(15);
        notification.FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, alarmToken.savedHr, alarmToken.savedMin, 0);
        id = AndroidNotificationCenter.SendNotification(notification, "default_channel");
        UpdateLog();
    }

    public void UpdateNoti()
    {
        AndroidNotificationCenter.CancelAllNotifications();
        notification.FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, alarmToken.savedHr, alarmToken.savedMin, 0);
        id = AndroidNotificationCenter.SendNotification(notification, "default_channel");
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Delivered)
        { AndroidNotificationCenter.CancelAllDisplayedNotifications(); }
        UpdateLog();
    }

    void UpdateLog()
    {
        Debug.Log("Noti will show @ " + alarmToken.savedHr + "." + alarmToken.savedMin);
        notiText.text = "Noti will show @ " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "\n" + alarmToken.savedHr.ToString("d2") + "." + alarmToken.savedMin.ToString("d2");
    }
}


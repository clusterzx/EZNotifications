# EZNotifications

Simple and easy to use notifications for your .NET Projects.

# Installation / How to use

1. Open up your Project
2. Add a dependency to the EZNotifications.dll
3. Imports EZNotifications
4. Add code to Initilize the Class

```
        Dim notify As New EZNotification
        Dim style As EZNotification.Style
        Dim design As EZNotification.FormDesign

        style = EZNotification.Style.Information
        design = EZNotification.FormDesign.Dark

```
5. To Show a notification use this :
```
        notify.Show("Title", "Text", style, design)
```

![alt text](https://i.imgur.com/TS0tTL3.gif)

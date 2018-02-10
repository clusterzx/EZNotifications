'     _____          _          _   _                                
'    / ____|        | |        | | | |                               
'   | |     ___   __| | ___  __| | | |__  _   _                      
'   | |    / _ \ / _` |/ _ \/ _` | | '_ \| | | |                     
'   | |___| (_) | (_| |  __/ (_| | | |_) | |_| |                     
'    \_____\___/ \__,_|\___|\__,_| |_.__/ \__, |                     
'    _____                   _       ____  __/ |     _               
'   |  __ \                 (_)     |  _ \|___/     | |              
'   | |  | | ___ _ __  _ __  _ ___  | |_) | ___  ___| |__   ___ _ __ 
'   | |  | |/ _ \ '_ \| '_ \| / __| |  _ < / _ \/ __| '_ \ / _ \ '__|
'   | |__| |  __/ | | | | | | \__ \ | |_) |  __/ (__| | | |  __/ |   
'   |_____/ \___|_| |_|_| |_|_|___/ |____/ \___|\___|_| |_|\___|_|   
'    ................................................................                                                                
'   |----------------------------------------------------------------|
'   | LICENSE : MIT https://choosealicense.com/licenses/mit/         |
'   | DATE : 27.01.2018                                              |
'   | WEBSITE : https://bech0r.net                                   |
'   | GITHUB : https://github.com/clusterzx                          |
'   |----------------------------------------------------------------|
'    """"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
'

Imports System.Runtime.InteropServices
Imports System.Drawing.Color
Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports System.Drawing
Imports System.Windows.Forms

Public Class EZNotification
    Public Shared image_info As String = "iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAMAAACdt4HsAAAAA3NCSVQICAjb4U/gAAAACXBIWXMAABG3AAARtwGaY1MrAAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAWtQTFRF////Var/TZnmQKrVTKHZSpzeSKLdRqHdSKDbSZ/dR6HbR5/dSZ/dSaDcSKHcSKDdSKDbSJ/cR6DcSKDcSJ/cSKDcSKDcSKHcSKDcSKDcSKDcSKDcSKDcSKDcSKDcSaDcSaHcSqHcTKLdTaPdTqPdT6TdUKTeUaXeUqXeU6beVKbeVafeWKjfWanfWqnfW6rgXKrgXqvgX6zgYK3hY67hbLPjbbPjbrTjcLXkdLfldbfleLnlebnlerrle7rmfLvmfrzmf73ngL3ngb7nhL/nhsDoicLojcTpjsXpj8XqksbqlMfrlcjrl8nroM7toc7tos/to8/tpdDup9HuqdLvqtPvstfwtdnxt9rxu9zyvNzyvt3zv97zwd/zwt/zxOD0yOL0y+T1z+b20Ob20uj20+j32Ov32Ov45vL65/L65/P67PX77vb88vj99Pn99fr99/v9+Pv++fz++/3+/P7+/f7//v7//v//////PvbU6gAAAB50Uk5TAAMKDBsfPExOYmRocHSKjqSwtr7Ay9XY5ery+Pn+bfME6gAAAoRJREFUWMOtV+lfElEUvTjsuyyOsjygqDBaTCvLClpp1xZtp9UWUTFM9Pz5fUCJ6a384Hxi7rn3DXPfXYkksPzhaDxpZzJ2Mh4N+y0aCu5QIsscyCZCblPriUg6zwTIpyMTBuau4DSTYjro0tn7ppgSUz6luSfFtEh55PbeGWaAGa/MPpBjRsgFxN6LMWPEBL50TbIhMMmfIHr/2fryp88rN2ZF/4H7fl5n9i16OHh9kmf/84OX99+tTQDY2QaAjau8Jx134eHv7wmA77fnC2zh3k9gv8Hf5mA88PFzcRedp4Xe79LKH7Qv8BE1EL8cWfoB1P89NoD1IqfUj2oXH/+PgDeDz03gPp8XR3cZ5H3cRLsy+Fz9jfe8VvAw/wX5u4GvTsE6WoLs7tWHCM9UgTWnZA04w+tFiIgozRMLwF2n5AGwyOuliYjcovr1bLXsFCwDc4Iq5yaikFH2fEC3JBCHiChhYl/p4JtIniCysiYHvAAaInnWIr+J/VIXrbKQ8VPYwL6xi70rYipMUa154SWw/1hCRimusz/eBDp3ZGyckroDXgFbl6VskmyN/bUD/JqX0zZl1PbFFvYWFXxGd8B1YJUpD9B8wjt0z6t4W+fENr4o+aTmGqvAc6VCXBNIl4CHSoWoJpRrwE2lQliTTHVHdRcmkzqddQdkLU1BqQE1FZ/QlbTqztacig/JimofJ06r2LxbUtZNkZY1FlNEpK3NDIetTdRcj1BufizK2aC8vffLCbAkJfvtXTBgGAWSTzXiGARSSj1k9VDZ3jwnoRxDlmjM6+HYKQmR82oHTTUCJqOuArHxD9sjj/ujLxxjWHlGX7pGX/vGsHiOvvqOYfkebv3/CzCZqzmM+GhtAAAAAElFTkSuQmCC"
    Public Shared image_error As String = "iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAMAAACdt4HsAAAAA3NCSVQICAjb4U/gAAAACXBIWXMAABG3AAARtwGaY1MrAAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAHtQTFRF/////1VVzGZN1VVA2V5M1lpK2VlI11tK2FxL2FtJ1llK2FtK1ltL11pL1ltK11pK11pL1lpK1lpK11pK11pK11pK11pK11pK11pJ11pK11pK11pK11pK11pK11pK4YJ24ol944yB5JCG8snE8svG/vz8/v39//39////kP4UBwAAAB50Uk5TAAMKDBsfPExOYmRocHSKjqSwtr7Ay9XY5ery+Pn+bfME6gAAAZ1JREFUWMOtV9e2gkAMjBcL0gWR6iid///C+3DLUdgCxHnMcUY2m50kRBIYpuMFUZLnSRR4jmnQKuztsMAbitDeL2V/ufEdAtxj92sBfWelkCK1djr+6QYlbicl/XCFFteDnH/MsADZUcY/l1iE8izOno/F8AW53F2wApe5go9V8Gfnx0pM8nAs1wqUb3dxyLAa2Ws9XLEB15f6xSb8V/Xutk3g9neXFjbC+n3/6VaB9Mcf3Gn80TxFP6/axzTkEhFRPA23Y1fP+XU3NtNYTES0n/lX1QkU6m7sZh923xORLfyzqULdCT/LJqIQCxQkfIRERgG9goyPwiBTfENvFCkfMMmBVkHBh0MedAoqPjwKoFFQ8hFQBLWCmo+IEigVhl7JR0K56rXUwzj2Kj5yjUA/joNGQHOEftAdgZ1E9jWyC4ldyuzHxH7ObEPhW9rcVJ8yU62Epjq39UZm6+00FksaS1uJEvZsJI2F3drYzZXf3tkDBn/E4Q9Z7DGPP2jyR13+sM0e9/kLxwdWHv7SxV/7PrB48lffDyzf69b/b8tHe0SmdNyrAAAAAElFTkSuQmCC"
    Public Shared image_warning As String = "iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAMAAACdt4HsAAAAA3NCSVQICAjb4U/gAAAACXBIWXMAABG3AAARtwGaY1MrAAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAKtQTFRF/////6pV5sxN6tVA7NBM785K7sxI7s1K785L785J8M9K7s5K781L8M9L7s1K789K781L785K8M5K781K785K785K785K7s1K785J785K781K785K785K785K785K785L789O8NBQ8NBR8NBT8NFU8NFW8NFX8dNc8dNe8dVi8tdq89p189p289p389t689x89Nx9+u7C+u/D/frs/vvv/vzy/vz1//79////3PKBWwAAAB50Uk5TAAMKDBsfPExOYmRocHSKjqSwtr7Ay9XY5ery+Pn+bfME6gAAAY1JREFUWMOtl9dywkAMRWVcMO64Y2OR3hNIxf//ZXkIyUBAu+uV7yvozFjSSlcAhEw3iJKsapoqS6LANWGQLD9t8UBt6luq0ZOw6PCEuiKcKIQbXo2kas+QxU9LFKqcCsPtHKXKbTreWaCCFg4VP1uikpaz09mLUVnxiVwacxyg+TEhxkGKj76f+OPjE/HDvzw4RP4ettt7IpMHtbCp+m36fkNVc78fyP4RADDf61/UAeBfVxulHqD8raWHegD0du+/1gXUP/MhRF0AhgAAUOgDCgAAq9MHdBYA+KgPQB8AUg4gBTBbDqA1wUUOAF0IeIAAIh4ggoQHSCDjATKoeIAKGh6g4QPYn8BOIruM7EZitzL7MbGfs3igrPt+LRko4pF28/VxJxtpwqGKF9coG6rCsS5RIV0sEoXS1SbWbrWJluv569tKulxF6/2l75/l651tMAQWR9RIuYrJuvp8v1UxWaTNw7NLVLF5tNEkNRvb6vLNNtvu8w+OEU4e/tHFP/tGODz5p+8Ix/ew8/8bEhOBJwRHGvQAAAAASUVORK5CYII="
    Public Shared image_choosen As String = ""
    Public Shared f_title As String = ""
    Public Shared f_message As String = ""
    Public n_info As String = ""
    Public Enum Style
        Information
        CriticalError
        Exclamation
    End Enum
    Public Enum FormDesign
        Bright
        Colorful
        Dark
    End Enum
    Public Sub Show(ByVal title As String, ByVal msg As String, ByVal notification_style As Style, ByVal notification_design As FormDesign)
        Dim fstyle As Style
        Dim fdesign As FormDesign
        f_message = msg
        f_title = title

        Select Case notification_style
            Case Style.Information
                fstyle = Style.Information
            Case Style.CriticalError
                fstyle = Style.CriticalError
            Case Style.Exclamation
                fstyle = Style.Exclamation
        End Select

        Select Case notification_design
            Case FormDesign.Bright
                fdesign = FormDesign.Bright
            Case FormDesign.Colorful
                fdesign = FormDesign.Colorful
            Case FormDesign.Dark
                fdesign = FormDesign.Dark
        End Select
        CreateForm(fstyle, fdesign)
    End Sub
    Private Sub CreateForm(notification_style As Style, ByVal notification_design As FormDesign)
        If notification_style.ToString = "CriticalError" Then
            image_choosen = image_error
        ElseIf notification_style.ToString = "Exclamation" Then
            image_choosen = image_warning
        ElseIf notification_style.ToString = "Information" Then
            image_choosen = image_info
        End If

        If notification_design.ToString = "Bright" Then
            FormDesign1.frm_background = Color.White
            FormDesign1.frm_text_field = Color.White
            FormDesign1.frm_title_bar = Color.Gray
            FormDesign1.frm_fontcolor = Color.Black
            Dim ini As New FormDesign1
            ini.Initialize()
        ElseIf notification_design.ToString = "Colorful" Then
            FormDesign1.frm_background = Color.LightBlue
            FormDesign1.frm_text_field = Color.LightBlue
            FormDesign1.frm_title_bar = Color.LightSeaGreen
            FormDesign1.frm_fontcolor = Color.White
            Dim ini As New FormDesign1
            ini.Initialize()
        ElseIf notification_design.ToString = "Dark" Then
            FormDesign1.frm_background = Color.FromArgb(83, 79, 75)
            FormDesign1.frm_text_field = Color.FromArgb(83, 79, 75)
            FormDesign1.frm_title_bar = Color.FromArgb(60, 57, 54)
            FormDesign1.frm_fontcolor = Color.White
            Dim ini As New FormDesign1
            ini.Initialize()
        End If
    End Sub
End Class

'Here begins the Form Design

Public Class FormDesign1
    Inherits System.Windows.Forms.Form
    'Controls
    Private panel_title As New Panel
    Private lbl_title As New Label
    Private lbl_close As New Label
    Private pb_image As New PictureBox
    Private panel_spacer As New Panel
    Private txt_msg As New RichTextBox
    Public Shared frm_background As Color
    Public Shared frm_title_bar As Color
    Public Shared frm_text_field As Color
    Public Shared frm_fontcolor As Color
    Private close_thread As Thread

    Public Sub Initialize()
        With Me
            .MaximizeBox = False
            .MinimizeBox = False
            .BackColor = frm_background
            .ForeColor = frm_fontcolor
            '.Size = New System.Drawing.Size(1, 138)
            .Size = New System.Drawing.Size(504, 138)
            .FormBorderStyle = FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
        End With
        Me.Show()

    End Sub

    Private Sub FormDesign1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 0.1

        With Me.lbl_close
            Me.lbl_close.AutoSize = True
            Me.lbl_close.BackColor = frm_title_bar
            Me.lbl_close.ForeColor = frm_fontcolor
            Me.lbl_close.Location = New System.Drawing.Point(478, 9)
            Me.lbl_close.Name = "lbl_close"
            Me.lbl_close.Size = New System.Drawing.Size(14, 13)
            Me.lbl_close.TabIndex = 1
            Me.lbl_close.Text = "X"
        End With

        With Me.panel_spacer
            Me.panel_spacer.BackColor = frm_title_bar
            Me.panel_spacer.Location = New System.Drawing.Point(119, 36)
            Me.panel_spacer.Name = "panel_spacer"
            Me.panel_spacer.Size = New System.Drawing.Size(1, 92)
            Me.panel_spacer.TabIndex = 2
        End With

        With Me.pb_image
            Me.pb_image.BackColor = System.Drawing.Color.Transparent
            Me.pb_image.Location = New System.Drawing.Point(12, 36)
            Me.pb_image.Name = "pb_image"
            Me.pb_image.Size = New System.Drawing.Size(92, 92)
            Me.pb_image.TabIndex = 1
            Me.pb_image.TabStop = False
        End With

        With Me.panel_title
            Me.panel_title.BackColor = frm_title_bar
            Me.panel_title.Controls.Add(Me.lbl_close)
            Me.panel_title.Controls.Add(Me.lbl_title)
            Me.panel_title.Location = New System.Drawing.Point(0, -1)
            Me.panel_title.Name = "panel_title"
            Me.panel_title.Size = New System.Drawing.Size(505, 29)
            Me.panel_title.TabIndex = 0
        End With

        With Me.lbl_title
            Me.lbl_title.AutoSize = True
            Me.lbl_title.BackColor = frm_title_bar
            Me.lbl_title.ForeColor = frm_fontcolor
            Me.lbl_title.Location = New System.Drawing.Point(11, 9)
            Me.lbl_title.Name = "lbl_title"
            Me.lbl_title.Size = New System.Drawing.Size(27, 13)
            Me.lbl_title.TabIndex = 0
            Me.lbl_title.Text = EZNotification.f_title
        End With

        With Me.txt_msg
            Me.txt_msg.BackColor = frm_text_field
            Me.txt_msg.ForeColor = frm_fontcolor
            Me.txt_msg.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txt_msg.Location = New System.Drawing.Point(133, 37)
            Me.txt_msg.Multiline = True
            Me.txt_msg.Name = "txt_msg"
            Me.txt_msg.Size = New System.Drawing.Size(361, 90)
            Me.txt_msg.TabIndex = 3
            Me.txt_msg.ReadOnly = True
            Me.txt_msg.Text = EZNotification.f_message
            Me.txt_msg.SelectionProtected = True
            Me.txt_msg.Cursor = Cursors.Arrow
        End With


        With Me.Controls
            .Add(lbl_title)
            .Add(lbl_close)
            .Add(panel_spacer)
            .Add(panel_title)
            .Add(txt_msg)
            .Add(pb_image)
        End With

        Me.ActiveControl = Me.Controls.Item(1)

        'Change Position to lower right corner
        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 50

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            x = x - 1
            Me.Location = New Point(x, y)
        Loop
        pb_image.Image = Image.FromStream(Base64ToImage(EZNotification.image_choosen.ToString))
        pb_image.SizeMode = PictureBoxSizeMode.StretchImage
        pb_image.Refresh()
        AddHandler lbl_close.Click, AddressOf lbl_close_Click
        '-----------------------------------------

        'Fade In-------------------------
        Dim iCount As Integer
        For iCount = 10 To 100 Step +15
            Me.Opacity = iCount / 100
            Me.Refresh()
            Threading.Thread.Sleep(60)
        Next
        '--------------------------------

        'Start Thread for autoclose popup after 5 Sec.
        close_thread = New Thread(AddressOf AutoClose)
        close_thread.IsBackground = True
        close_thread.Start()
        '----------------------------------------------
    End Sub
    '------------------Convert Base64 to imagestream------------------------------
    Public Function Base64ToImage(ByVal base64String As String) As MemoryStream
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As MemoryStream = New MemoryStream(imageBytes, 0, imageBytes.Length)
        Return ms
    End Function
    Private Sub AutoClose()
        Thread.Sleep(5000)
        closeForm()
    End Sub
    Sub closeForm()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Me.closeForm))
        Else
            Me.Close()
        End If
    End Sub
    Private Sub FormDesign1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Threading.Thread.Sleep(150)
        Dim iCount As Integer
        For iCount = 90 To 10 Step -15
            Me.Opacity = iCount / 110
            Me.Refresh()
            Threading.Thread.Sleep(60)
        Next
    End Sub
    Private Sub lbl_close_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class

﻿''----------------------------------------------------------------------------------------------
''
'' LicielRsync -  A multi-threaded interface for Rsync on Windows
'' By Arnaud Dovi - ad@heapoverflow.com
'' Rsync - http://rsync.samba.org
''
'' FrameMain
''
'' Primary interface
''----------------------------------------------------------------------------------------------
Option Explicit On


Imports System
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading


Public Class FrameMain

    Private _fab As FrameAboutBox
    Private _isReset As Boolean = False
    ''--------------------------------------------------------------------
    '' Init Form
    ''--------------------------------------------------------------------

    Private Sub FrameMainLoad(sender As System.Object, e As EventArgs) Handles MyBase.Load
        Size = My.Settings.Size_Frame
        Location = My.Settings.Location_Frame
        SplitContainer1.SplitterDistance = My.Settings.SplitterDistance_Splitter1
        StatusBar.Padding = New Padding(StatusBar.Padding.Left, StatusBar.Padding.Top, StatusBar.Padding.Left, StatusBar.Padding.Bottom)
        NotifyIcon1.Icon = AppIcon
        _isReset = False
        'Dim s = Application.
    End Sub

    ''--------------------------------------------------------------------
    '' ButtonClick
    ''
    '' Stub function used to handle all button clicks
    ''--------------------------------------------------------------------

    Private Sub ButtonClick(sender As System.Object, e As EventArgs) Handles ButtonTest.Click, ButtonStop.Click, ButtonSrcOpen.Click, ButtonPause.Click, ButtonExec.Click, ButtonDstOpen.Click, _
                                                                             ButtonDel.Click, ButtonAdd.Click, AboutToolStripMenuItem.Click, ResetToolStripMenuItem.Click, ToggleToolStripMenuItem.Click, _
                                                                             ExitToolStripMenuItem1.Click, ExitToolStripMenuItem2.Click
        Try
            Select Case sender.name
                Case ButtonExec.Name, ButtonTest.Name
                    If File.Exists(RsyncPath) And TextBoxSrc.Text <> "" And TextBoxDst.Text <> "" Then
                        TextBoxLogs.Text = ""
                        TextBoxErrors.Text = ""
                        ResetProgress()
                        Dim thd As Thread = New Thread(AddressOf ThreadProcessStart)
                        thd.IsBackground = True
                        thd.Start({RsyncPath, sender.name = ButtonTest.Name})
                        If IsWin7 Then
                            If IsNothing(TaskBar) Then TaskBar = CType(New CTaskbarList, ITaskbarList4)
                            TaskBar.SetProgressState(CType(Handle, Integer), Tbpflag.TbpfNormal)
                        End If
                    End If
                Case ButtonSrcOpen.Name
                    TextBoxSrc.Text = GetDirectory(TextBoxSrc.Text)
                Case ButtonDstOpen.Name
                    TextBoxDst.Text = GetDirectory(TextBoxDst.Text)
                Case ButtonAdd.Name
                    Dim newProfile As String = ComboProfiles.Text
                    newProfile = Regex.Replace(newProfile, "^\s+", "")
                    newProfile = Regex.Replace(newProfile, "\s+$", "")
                    If newProfile = "" Or My.Settings.ProfilesList.Contains(newProfile) Or Regex.Match(newProfile, "^\s+$").Success Then Exit Sub
                    My.Settings.ProfilesList.Add(newProfile)
                    My.Settings.Save()
                    ComboProfiles.Items.AddRange(New Object() {newProfile})
                    LoadProfile(newProfile)
                Case ButtonDel.Name
                    Dim todeleteProfile As String = ComboProfiles.Text
                    If todeleteProfile = "" Or todeleteProfile = My.Settings.Properties.Item("CurrentProfile").DefaultValue Or Not My.Settings.ProfilesList.Contains(todeleteProfile) Or Regex.Match(todeleteProfile, "^\s+$").Success Then Exit Sub
                    My.Settings.ProfilesList.Remove(todeleteProfile)
                    My.Settings.P(todeleteProfile) = Nothing
                    My.Settings.Save()
                    ComboProfiles.Items.Remove(todeleteProfile)
                    ComboProfiles.SelectedIndex = 0
                Case ButtonPause.Name
                    Select Case ProcessusSuspended
                        Case True
                            ResumeProcess(Processus)
                            ProcessusSuspended = False
                            ButtonPause.Text = "Pause"
                            If IsWin7 Then
                                If IsNothing(TaskBar) Then TaskBar = CType(New CTaskbarList, ITaskbarList4)
                                TaskBar.SetProgressState(CType(Handle, Integer), Tbpflag.TbpfNormal)
                            End If
                        Case False
                            SuspendProcess(Processus)
                            ProcessusSuspended = True
                            ButtonPause.Text = "Resume"
                            If IsWin7 Then
                                If IsNothing(TaskBar) Then TaskBar = CType(New CTaskbarList, ITaskbarList4)
                                TaskBar.SetProgressState(CType(Handle, Integer), Tbpflag.TbpfPaused)
                            End If
                    End Select
                Case ButtonStop.Name
                    If ProcessusSuspended Then
                        ButtonPause.Text = "Pause"
                        ProcessusSuspended = False
                    End If
                    Processus.Kill()
                    Processus.Close()
                    If IsWin7 Then
                        If IsNothing(TaskBar) Then TaskBar = CType(New CTaskbarList, ITaskbarList4)
                        TaskBar.SetProgressState(CType(Handle, Integer), Tbpflag.TbpfError)
                    End If
                Case AboutToolStripMenuItem.Name
                    _fab = New FrameAboutBox()
                    _fab.Show()
                Case ResetToolStripMenuItem.Name
                    If LicielMessage.Send("The settings will reset to default and LicielRsync will close, do you confirm to continue ?", "LicielRsync settings reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                    My.Settings.Reset()
                    My.Settings.ShouldReset = True
                    My.Settings.Save()
                    NotifyIcon1.Visible = False
                    _isReset = True
                    Application.Restart()
                Case ToggleToolStripMenuItem.Name
                    Visible = Not Visible
                    If Visible AndAlso WindowState = FormWindowState.Minimized Then WindowState = FormWindowState.Normal
                Case ExitToolStripMenuItem1.Name, ExitToolStripMenuItem2.Name
                    SaveFormSettings()
                    NotifyIcon1.Visible = False
                    Environment.Exit(0)
            End Select
            UpdateStatusBarCommand(sender.name = ButtonTest.Name)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    ''--------------------------------------------------------------------
    '' CheckBoxChanged
    ''
    '' Stub function used to handle all checkbox checks
    ''--------------------------------------------------------------------

    Private Sub CheckBoxChanged(sender As Object, e As EventArgs) Handles CbFrench.CheckedChanged, CbEnglish.CheckedChanged, CbVerbose.CheckedChanged, CbSizeOnly.CheckedChanged, CbShowCmd.CheckedChanged, CbRedir.CheckedChanged, CbRecurse.CheckedChanged, CbReadable.CheckedChanged, CbProgress.CheckedChanged, CbPerm.CheckedChanged, CbOwner.CheckedChanged, CbNewer.CheckedChanged, CbIgnoreTimes.CheckedChanged, CbHideWindows.CheckedChanged, CbGroup.CheckedChanged, CbExistingOnly.CheckedChanged, CbExisting.CheckedChanged, CbDelta.CheckedChanged, CbDelete.CheckedChanged, CbDate.CheckedChanged, CbChecksum.CheckedChanged, CbWinCompat.CheckedChanged, CbPermWin.CheckedChanged, CbFS.CheckedChanged, TrayIconEnabledToolStripMenuItem.CheckedChanged, TrayIconNoticeStartToolStripMenuItem.CheckedChanged
        Select Case sender.Name
            Case CbEnglish.Name
                If Not sender.checked Then Exit Sub
                ChangeLanguage(sender.Tag)
                My.Settings.Locales = "English"
                My.Settings.Save()
                CbEnglish.CheckOnClick = Not CbEnglish.Checked
                CbFrench.CheckOnClick = CbEnglish.Checked
                CbFrench.Checked = Not sender.Checked
                Exit Sub
            Case CbFrench.Name
                If Not sender.Checked Then Exit Sub
                ChangeLanguage(sender.Tag)
                My.Settings.Locales = "French"
                My.Settings.Save()
                CbFrench.CheckOnClick = Not CbFrench.Checked
                CbEnglish.CheckOnClick = CbFrench.Checked
                CbEnglish.Checked = Not sender.Checked
                Exit Sub
            Case CbShowCmd.Name
                My.Settings.P(My.Settings.CurrentProfile)("OptionsVar")("showcmd") = sender.Checked
                My.Settings.Save()
                UpdateStatusBarCommand(False)
                Exit Sub
            Case CbHideWindows.Name
                My.Settings.P(My.Settings.CurrentProfile)("OptionsVar")("hidewnd") = sender.Checked
                My.Settings.Save()
                Exit Sub
            Case CbRedir.Name
                My.Settings.P(My.Settings.CurrentProfile)("OptionsVar")("redir") = sender.Checked
                My.Settings.Save()
                Exit Sub
            Case TrayIconNoticeStartToolStripMenuItem.Name
                My.Settings.TrayNoticeStart = sender.Checked
                My.Settings.Save()
                Exit Sub
            Case TrayIconEnabledToolStripMenuItem.Name
                My.Settings.ShowInTray = sender.Checked
                NotifyIcon1.Visible = sender.Checked
                TrayIconNoticeToolStripMenuItem.Enabled = sender.Checked
                If sender.Checked AndAlso My.Settings.TrayNoticeStart Then LicielMessage.SendTray("LicielRsync started", "LicielRsync", ToolTipIcon.Info, 500)
                My.Settings.Save()
                Exit Sub
        End Select
        My.Settings.P(My.Settings.CurrentProfile)("OptionsSwitch")(sender.Tag) = sender.Checked
        My.Settings.Save()
        If sender.Name = CbVerbose.Name Then ComboVerbose.Enabled = CbVerbose.Checked
        UpdateStatusBarCommand(False)
    End Sub

    ''--------------------------------------------------------------------
    '' ComboSelectedIndexChanged
    ''
    '' Stub function used to handle all listbox changes
    ''--------------------------------------------------------------------

    Private Sub ComboSelectedIndexChanged(sender As System.Object, e As EventArgs) Handles ComboVerbose.SelectedIndexChanged, ComboRsync.SelectedIndexChanged, ComboProfiles.SelectedIndexChanged
        Select Case sender.name
            Case ComboVerbose.Name
                My.Settings.P(My.Settings.CurrentProfile)("OptionsVar")(sender.tag) = sender.Text
                My.Settings.Save()
            Case ComboProfiles.Name
                Dim selectedProfile = ComboProfiles.Items(ComboProfiles.SelectedIndex)
                LoadProfile(selectedProfile)
            Case ComboRsync.Name
                RsyncPath = RsyncPaths(ComboRsync.Items(ComboRsync.SelectedIndex)) & "\bin\rsync.exe"
        End Select
        UpdateStatusBarCommand(False)
    End Sub

    ''--------------------------------------------------------------------
    '' TextBoxTextChanged
    ''
    '' Stub function used to handle all textbox changes
    ''--------------------------------------------------------------------

    Private Sub TextBoxTextChanged(sender As System.Object, e As EventArgs) Handles TextBoxSrc.TextChanged, TextBoxOptions.TextChanged, TextBoxDst.TextChanged
        Select Case sender.name
            Case TextBoxSrc.Name
                My.Settings.P(My.Settings.CurrentProfile)("OptionsVar")("srcpath") = TextBoxSrc.Text
                My.Settings.Save()
            Case TextBoxDst.Name
                My.Settings.P(My.Settings.CurrentProfile)("OptionsVar")("dstpath") = TextBoxDst.Text
                My.Settings.Save()
            Case TextBoxOptions.Name
                My.Settings.P(My.Settings.CurrentProfile)("OptionsVar")("customoptions") = TextBoxOptions.Text
                My.Settings.Save()
                UpdateStatusBarCommand(False)
        End Select
    End Sub

    ''--------------------------------------------------------------------
    '' To work around Visual Studio problems while using DataBindings events
    ''
    '' The MS Team did not added the ability to databind the variable Size of a Form 
    '' and this code demonstrate you can save the Location and Size of a form without
    '' the need of the ugly OnPropertyChanged event
    ''--------------------------------------------------------------------

    Private Sub BetterDataBindings(sender As System.Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _isReset Then Exit Sub
        If NotifyIcon1.Visible AndAlso My.Settings.CloseToTray = -1 Then
            My.Settings.CloseToTray = Convert.ToInt32(LicielMessage.Send("LicielRsync can minimize to the system tray. Would you like to do this ?", "LicielRsync - Did you know", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)
        End If
        If Not (NotifyIcon1.Visible AndAlso My.Settings.CloseToTray) Then NotifyIcon1.Visible = False
        SaveFormSettings()
        If NotifyIcon1.Visible AndAlso My.Settings.CloseToTray Then
            e.Cancel = True
            Hide()
        End If
    End Sub

    Private Sub OnMinimize(sender As System.Object, e As EventArgs) Handles MyBase.Resize
        If WindowState <> FormWindowState.Minimized Then Exit Sub
        If NotifyIcon1.Visible AndAlso My.Settings.MinimizeToTray = -1 Then
            My.Settings.MinimizeToTray = Convert.ToInt32(LicielMessage.Send("LicielRsync can close to the system tray. Would you like to do this ?", "LicielRsync - Did you know", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)
            SaveFormSettings()
        End If
        Visible = Not (NotifyIcon1.Visible AndAlso My.Settings.MinimizeToTray = 1)
    End Sub

    Private Sub OnControlDoubleClick(sender As System.Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        Select Case sender.Tag
            Case NotifyIcon1.Tag
                Visible = Not Visible
                If Visible AndAlso WindowState = FormWindowState.Minimized Then WindowState = FormWindowState.Normal
        End Select
    End Sub

    Private Sub SaveFormSettings()
        My.Settings.Size_Frame = Size
        My.Settings.Location_Frame = Location
        My.Settings.SplitterDistance_Splitter1 = SplitContainer1.SplitterDistance
        My.Settings.Save()
    End Sub

End Class

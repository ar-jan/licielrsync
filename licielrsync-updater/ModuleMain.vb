﻿''----------------------------------------------------------------------------------------------
''
'' licielrsync-updater -  the licielrsync updater used to unpack updates compressed with 7-Zip
'' licielrsync -  a multi-threaded interface for rsync on windows
'' by Arnaud Dovi - dev@heapoverflow.com
'' licielrsync - http://licielrsync.googlecode.com
''
'' rsync is maintained by Wayne Davison at - http://rsync.samba.org
''
'' modulemain
''
'' primary module
''----------------------------------------------------------------------------------------------



Friend Module ModuleMain


    ''--------------------------------------------------------------------
    ''                        L O C A L E S
    ''--------------------------------------------------------------------

    Private ReadOnly AppPath As String = My.Application.Info.DirectoryPath & "\"
    Private ReadOnly LicielRsyncPathPacked As String = AppPath & "licielrsync"
    Private ReadOnly LicielRsyncPath As String = AppPath & "..\"
    Private _retryTimer As Diagnostics.Stopwatch = Nothing

    ''--------------------------------------------------------------------
    '' Main
    ''
    '' program entry point
    ''--------------------------------------------------------------------

    Friend Sub Main()
        ''
        '' Validate
        ''
        Try
            If Not My.Application.CommandLineArgs.Contains("--update") Then End
            Dim p() As Diagnostics.Process = Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess().ProcessName)
            If p.Length > 1 Then
                SafeNativeMethods.MessageBox(IntPtr.Zero, "Another instance of licielrsync-updater.exe is running. Please close it", "licielrsync-updater error", &H10)
                Environment.Exit(0)
            End If
        Catch ex As Exception
            SafeNativeMethods.MessageBox(IntPtr.Zero, ex.ToString, "licielrsync-updater error", &H10)
        End Try
        ''
        '' Copy with timeout
        ''
        _retryTimer = New Diagnostics.Stopwatch()
        Dim copied As Boolean = False
        While Not copied
            Try
                For Each dirPath In IO.Directory.GetDirectories(LicielRsyncPathPacked, "*", IO.SearchOption.AllDirectories)
                    IO.Directory.CreateDirectory(dirPath.Replace(LicielRsyncPathPacked, LicielRsyncPath))
                Next

                For Each newPath In IO.Directory.GetFiles(LicielRsyncPathPacked, "*.*", IO.SearchOption.AllDirectories)
                    IO.File.Copy(newPath, newPath.Replace(LicielRsyncPathPacked, LicielRsyncPath), True)
                Next
                copied = True
            Catch ex As Exception
                If Not Sleep(True) Then End
            End Try
        End While
        ''
        '' Execute with timeout
        ''
        _retryTimer.Reset()
        Dim started As Boolean = False
        While Not started
            Try
                Diagnostics.Process.Start(LicielRsyncPath & "licielrsync.exe")
                started = True
            Catch ex As Exception
                If Not Sleep() Then End
            End Try
        End While
        ''
        '' Delete to the blind
        ''
        Try
            IO.Directory.Delete(LicielRsyncPathPacked, True)
        Catch
        End Try
    End Sub

    Private Function Sleep(Optional ByVal copy As Boolean = False) As Boolean
        ''
        '' Timeout 15 seconds
        ''
        If Not _retryTimer.IsRunning Then _retryTimer.Start()
        Threading.Thread.Sleep(500)
        If _retryTimer.ElapsedMilliseconds > 15000 Then
            SafeNativeMethods.MessageBox(IntPtr.Zero, If(copy, "The updater has failed after attempting 15 sec. to replace files. One of them is probably in use.", "The updater installed the files successfully but it has failed to restart licielrsync"), "licielrsync-updater error", &H10)
            Return False
        End If
        Return True
    End Function

End Module

Friend NotInheritable Class SafeNativeMethods
    Friend Declare Function MessageBox Lib "user32.dll" Alias "MessageBoxA" (ByVal hWnd As IntPtr, ByVal msg As String, ByVal title As String, ByVal lParam As Integer) As Integer
End Class

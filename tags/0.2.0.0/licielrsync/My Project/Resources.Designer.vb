﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.239
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("licielrsync.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Special thanks to :
        '''rsync - synchronization tool - rsync.samba.org
        '''famfamfam - free icons - www.famfamfam.com
        '''cygwin - a linux api layer providing substantial linux api functionality to windows - www.cygwin.com
        '''    .
        '''</summary>
        Friend ReadOnly Property about() As String
            Get
                Return ResourceManager.GetString("about", resourceCulture)
            End Get
        End Property
        
        Friend ReadOnly Property application_form() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("application_form", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property application_put() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("application_put", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property connect() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("connect", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property delete() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("delete", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property door_in() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("door_in", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property folder_go() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("folder_go", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property fr() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("fr", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property information() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("information", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property licielrsync_32px() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("licielrsync_32px", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        Friend ReadOnly Property licielrsync_80px() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("licielrsync_80px", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The settings will reset to default and licielrsync will restart. Do you confirm to continue ?.
        '''</summary>
        Friend ReadOnly Property msg1() As String
            Get
                Return ResourceManager.GetString("msg1", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to licielrsync - update.
        '''</summary>
        Friend ReadOnly Property msg10() As String
            Get
                Return ResourceManager.GetString("msg10", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Your version is already up to date ({0}).
        '''</summary>
        Friend ReadOnly Property msg11() As String
            Get
                Return ResourceManager.GetString("msg11", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to A new version is available ({0}). Do you want to deploy it ?.
        '''</summary>
        Friend ReadOnly Property msg12() As String
            Get
                Return ResourceManager.GetString("msg12", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Can&apos;t create the update directory (see {0}{1}_errors.log for details).
        '''</summary>
        Friend ReadOnly Property msg13() As String
            Get
                Return ResourceManager.GetString("msg13", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Error while downloading the updates (see {0}{1}_errors.log for details).
        '''</summary>
        Friend ReadOnly Property msg14() As String
            Get
                Return ResourceManager.GetString("msg14", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Error while starting the process (see {0}{1}_errors.log for details).
        '''</summary>
        Friend ReadOnly Property msg15() As String
            Get
                Return ResourceManager.GetString("msg15", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 7-Zip returned an error while unpacking the update.
        '''</summary>
        Friend ReadOnly Property msg16() As String
            Get
                Return ResourceManager.GetString("msg16", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to licielrsync settings reset.
        '''</summary>
        Friend ReadOnly Property msg2() As String
            Get
                Return ResourceManager.GetString("msg2", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to licielrsync is started.
        '''</summary>
        Friend ReadOnly Property msg3() As String
            Get
                Return ResourceManager.GetString("msg3", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to licielrsync will close to the system tray. Do you confirm to always do this ?.
        '''</summary>
        Friend ReadOnly Property msg4() As String
            Get
                Return ResourceManager.GetString("msg4", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to licielrsync will minimize to the system tray. Do you confirm to always do this ?.
        '''</summary>
        Friend ReadOnly Property msg5() As String
            Get
                Return ResourceManager.GetString("msg5", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to licielrsync - did you know ?.
        '''</summary>
        Friend ReadOnly Property msg6() As String
            Get
                Return ResourceManager.GetString("msg6", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to No rsync found. You can add your own rsync compilations if you keep the directories structure of licielrsync as seen in the official 7-zip release..
        '''</summary>
        Friend ReadOnly Property msg7() As String
            Get
                Return ResourceManager.GetString("msg7", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to licielrsync - error !.
        '''</summary>
        Friend ReadOnly Property msg8() As String
            Get
                Return ResourceManager.GetString("msg8", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The update check procedure has failed.
        '''</summary>
        Friend ReadOnly Property msg9() As String
            Get
                Return ResourceManager.GetString("msg9", resourceCulture)
            End Get
        End Property
        
        Friend ReadOnly Property us() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("us", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace

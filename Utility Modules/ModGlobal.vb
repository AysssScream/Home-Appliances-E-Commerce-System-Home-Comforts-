Imports System.Xml
Imports System.Collections.Specialized
Imports System.IO
Imports System.Reflection

Public Module ModGlobal

    Public Delegate Sub CrossThreadMethodInvokerDelegate(ByVal Param As Object)
    Public Delegate Sub CreateGridColumnsCrossThreadDelegate(ByVal grid As Control, ByVal columns As Collection)

    Public AppMainForm As MainForm2
    Public Data As DBHelper
    Public AppData As DataManager
    Public BackDoorPass As String = ""
    Public ActiveUser As User
    Public SystemSettings As XmlDocument
    Public DBConnectionString As String

    Public Const skinSaveFileName As String = "skinSettings.bin"
    Public Const Yes As Boolean = True
    Public Const No As Boolean = False
    Public Const CompanyName As String = "[companyname]"
    Public ControlTypes() As String = New String() {"textinput",
                                                          "userpkinput",
                                                          "comboboxinput",
                                                          "accesssoftgridlookupedit",
                                                          "memoinput",
                                                          "accesssoftdateedit",
                                                          "accesssoftpictureedit"}

    Public Structure ColumnInfo
        Dim Caption As String
        Dim FieldName As String
        Dim Width As Integer
        Dim OutputCtrl As String
        Dim Format As String
        Dim CustProperty As String
        Dim OutputField As String
        Dim DefaultValue As String
        Dim Fixed As Boolean
        Dim Locked As Boolean
    End Structure

    Public Enum EditorState
        AddMode
        EditMode
        DeleteMode
        ViewMode
        NullMode
    End Enum

    Public Structure FilterParam
        Dim Value As Object
        Dim FieldName As String
    End Structure

    Public Enum UserPkTypeEnum
        System
        Custom
    End Enum
    Public Enum SequentialGuidType

        SequentialAsString

        SequentialAsBinary

        SequentialAtEnd

    End Enum

    Public Structure PayInfo
        Public EntriesSL As String
        Public TitleCOA As String
    End Structure

    Public AppExeName As String = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)
End Module

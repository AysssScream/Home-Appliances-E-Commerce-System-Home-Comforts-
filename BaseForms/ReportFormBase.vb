Imports System.ComponentModel
Imports FontAwesome.Sharp
Public Class ReportFormBase
    Private _DateField As String
    Private _ShowDateFilter As Boolean
    Private ReportWrappers As Collection
    Private FilterControlsCollection As Collection
    Private ReportsCollection As Collection
    Protected rptSelected As String
    Public _meReportWhere As String
    Public _datewhere As String
    Public tempvalue As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        HeaderPanel.BackColor = Colors.pageColor
        RightSidePanel.BackColor = Colors.pageColor
        LeftSidePanel.BackColor = Colors.pageColor
        ReportPanel.BackColor = Colors.panelColor
        FilterPanel.BackColor = Colors.panelColor

    End Sub
    Public Property DateField() As String
        Get
            Return _DateField
        End Get
        Set(ByVal value As String)
            _DateField = value
        End Set
    End Property

    Private Sub LoadControlsToCollection(ByVal ctrlContainer As Control)
        Try
            For Each ctrl As Control In ctrlContainer.Controls
                Dim ctrlName As String = ctrl.Name
                'Debug.Print(TypeName(ctrl))
                If TypeOf ctrl Is TextInput Or
                        TypeOf ctrl Is ComboBoxInput Or
                            TypeOf ctrl Is DateFilter Or
                            TypeOf ctrl Is GridLookupEdit Then

                    If TypeOf ctrl Is ComboBoxInput Then
                        CType(ctrl, ComboBoxInput).LoadData()
                    End If

                    If TypeOf ctrl Is GridLookupEdit Then
                        CType(ctrl, GridLookupEdit).LoadData()
                    End If

                    FilterControlsCollection.Add(ctrl, ctrlName)

                End If

                If ctrl.HasChildren Then
                    LoadControlsToCollection(ctrl)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadReportsToCollection(ByVal ctrlContainer As Control)
        Try
            For Each ctrl As Control In ctrlContainer.Controls
                Dim ctrlName As String = ctrl.Name
                If TypeOf ctrl Is IconButton Then

                    ReportsCollection.Add(ctrl, ctrlName)

                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AttachReports()
        Try

            Dim filteredFields = From ctrl In ReportsCollection
                                 Select ctrl

            For Each rptItem As IconButton In filteredFields
                If Not IsNothing(rptItem.Tag) AndAlso rptItem.Tag <> String.Empty Then
                    'MsgBox(rptItem.Caption)
                    Dim rptCaption As String = rptItem.Text
                    Dim rptClass As String = rptItem.Tag

                    Dim rptObj As ReportBase = CreateObject(rptClass)
                    Dim rptWrapper As New ReportWrapper(rptObj, rptCaption, ReportWrapper.ReportOwnerTypeEnum.ReportForm)
                    AddHandler rptWrapper.AdditionalWhere, AddressOf Me.Report_AdditionalWhere
                    AddHandler rptWrapper.OverrideSQL, AddressOf Me._OVerrideSQL

                    ReportWrappers.Add(rptWrapper, rptCaption)

                    AddHandler rptItem.Click, AddressOf Me.RptItem_Click
                End If
            Next

            '    For Each rptItem As DevExpress.XtraNavBar.NavBarItem In Me.NavReports.Items
            '        If Not IsNothing(rptItem.Tag) AndAlso rptItem.Tag <> String.Empty Then
            '            'MsgBox(rptItem.Caption)
            '            Dim rptCaption As String = rptItem.Caption
            '            Dim rptClass As String = rptItem.Tag

            '            Dim rptObj As ReportBase = CreateObject(rptClass)
            '            Dim rptWrapper As New ReportWrapper(rptObj, rptCaption, ReportWrapper.ReportOwnerTypeEnum.ReportForm)
            '            AddHandler rptWrapper.AdditionalWhere, AddressOf Me.Report_AdditionalWhere
            '            AddHandler rptWrapper.OverrideSQL, AddressOf Me._OVerrideSQL

            '            ReportWrappers.Add(rptWrapper, rptCaption)

            '            AddHandler rptItem.LinkClicked, AddressOf Me.RptItem_LinkClicked
            '        End If
            '    Next
        Catch ex As Exception

        End Try

    End Sub
    Protected Overridable Sub _OVerrideSQL(ByRef rQuery As String, ByRef rpttitle As String)

    End Sub

    Private Sub Report_AdditionalWhere(ByRef AdditionalWhere As String)

        If AdditionalWhere <> "" Then
            AdditionalWhere &= IIf(BuildReportWhere() <> "", " AND " + BuildReportWhere(), "")
        Else
            AdditionalWhere &= IIf(BuildReportWhere() <> "", BuildReportWhere(), "")
        End If
    End Sub

    Private ReportFilters As Collection
    Private Function BuildReportWhere() As String
        Dim ReportWhere As String = ""

        ReportFilters = New Collection
        ' If IsNothing(ReportFilters) Then ReportFilters = New Collection
        Try
            ReportFilters.Clear()
            Dim filteredFields = From ctrl In FilterControlsCollection
                                 Where ctrl.TableField <> String.Empty _
                                    AndAlso ctrl.TableName <> String.Empty _
                                        AndAlso Not IsNothing(ctrl.EditValue)
                                 Select ctrl

            For Each FilteredField In filteredFields
                Dim filter As New FilterParam
                Select Case TypeName(FilteredField)
                    Case "TextInput"

                        With CType(FilteredField, TextInput)
                            If .Text.Trim <> "" Then
                                ReportWhere &= String.Format(" {0} = '{1}' AND", .TableField, .EditValue)
                                filter.FieldName = .TableField.ToLower
                                filter.Value = .EditValue
                            End If
                        End With

                    Case "ComboBoxInput"
                        With CType(FilteredField, ComboBoxInput)
                            If .Text.Trim <> "" Then
                                If InStr(.EditValue, "'") <> 0 Then

                                    ReportWhere &= String.Format(" {0} = '{1}' AND", .TableField, .EditValue.split("'")(0) & "''" & .EditValue.split("'")(1))
                                Else

                                    ReportWhere &= String.Format(" {0} = '{1}' AND", .TableField, .EditValue.ToString.Trim)
                                End If

                                filter.FieldName = .TableField.ToLower
                                filter.Value = .EditValue
                            End If

                        End With
                    Case "DateFilter"
                        With CType(FilteredField, DateFilter)
                            If Not .IsBlankDate Then

                                If .EditValue.ToString <> "" Then
                                    ReportWhere &= String.Format(" {0} AND", .EditValue)
                                    filter.FieldName = .TableField.ToLower
                                    filter.Value = .EditValue

                                    _datewhere &= String.Format(" {0} AND", .EditValue)
                                End If
                            End If


                        End With
                    Case "GridLookupEdit"
                        With CType(FilteredField, GridLookupEdit)
                            If .EditValue.ToString <> "" Then
                                ReportWhere &= String.Format(" {0} = '{1}' AND", .TableField, .EditValue.ToString)
                                filter.FieldName = .TableField.ToLower
                                filter.Value = .EditValue
                            End If

                        End With
                End Select
                ReportFilters.Add(filter)
            Next
            If ReportWhere <> "" Then
                ReportWhere = ReportWhere.Substring(0, ReportWhere.Length - 3) 'remove trailing AND
            End If
        Catch ex As Exception
            ReportWhere = ""
        End Try
        _meReportWhere = ReportWhere
        Return ReportWhere
    End Function

    Private Sub ReportFormBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FilterControlsCollection = New Collection
            ReportsCollection = New Collection
            ReportWrappers = New Collection
            LoadControlsToCollection(Me)
            LoadReportsToCollection(Me.Controls("LeftSidePanel").Controls("ReportPanel"))
            AttachReports()
        Catch ex As Exception
            'MsgBox(ex.Message)
            'Clipboard.SetText(ex.StackTrace)
        End Try

    End Sub

    Private Sub RptItem_Click(sender As Object, e As EventArgs)
        Try
            Dim selItem As String = CType(sender, IconButton).Text
            Dim SelectedReport As ReportWrapper = DirectCast(ReportWrappers(selItem), ReportWrapper)
            rptSelected = selItem
            BuildReportWhere()

            SelectedReport.ReportObject.SetFilterParamsCollection(ReportFilters)
            SelectedReport.SetReportDate(DateFilter.Tag)
            SelectedReport.PreviewReport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

End Class

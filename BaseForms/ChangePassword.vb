Imports FontAwesome.Sharp
Public Class ChangePassword

    Dim accountType As String = Project.Instance.ActiveAccountType
    Dim userPK As String = Project.Instance.ActiveUserPK
    Dim username As String = ""
    Dim password As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        HeaderPanel.BackColor = Colors.black
        MainPanel.BackColor = Colors.whiteSecondary

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
    Private Function IsValidNewPassword(password As String) As Boolean
        ' Check if the password is at least 8 characters long
        If password.Length < 8 Then
            Return False
        End If

        ' Check if the password contains at least one uppercase letter, one lowercase letter, and one number
        Dim hasUpper As Boolean = False
        Dim hasLower As Boolean = False
        Dim hasNumber As Boolean = False

        For Each ch As Char In password
            If Char.IsUpper(ch) Then
                hasUpper = True
            ElseIf Char.IsLower(ch) Then
                hasLower = True
            ElseIf Char.IsDigit(ch) Then
                hasNumber = True
            End If
        Next

        Return hasUpper And hasLower And hasNumber
    End Function

    Private Sub ButtonEnter_Click(sender As Object, e As EventArgs) Handles ButtonEnter.Click
        Try
            If txtPassword.Text <> password Then
                MsgBox("Incorrect current password.")
            ElseIf txtPassword.Text = txtNewPassword.Text Then
                MsgBox("New password should not be the same as the current password")
            ElseIf txtPassword.Text <> password Then
                MsgBox("Incorrect current password.")
            ElseIf Not IsValidNewPassword(txtNewPassword.Text) Then
                MsgBox("New password must be more than 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number.")
            Else
                Dim updatePassword As String = ""
                    If accountType = "Customer" Then
                        updatePassword = String.Format("Update universal_masters SET Password_UM = '{0}' Where PK_UM = '{1}'", txtNewPassword.Text, userPK)
                    Else
                        updatePassword = String.Format("Update users SET Password_Usr = '{0}' Where PK_Usr = '{1}'", txtNewPassword.Text, userPK)
                    End If

                    AppData.ExecuteNonQuery(updatePassword)
                    MsgBox("Password Successfully changed!")


                    Dim sqlAddAuditTrail As String = String.Format("Insert Into audit_trails (PK_AT,UserType_AT,Name_AT,Action_AT,Remarks_AT) VALUES('{0}','{1}','{2}','{3}','{4}')", GetSysPK(), Project.Instance.ActiveAccountType, Project.Instance.ActiveUser.Name, "Change Password", "")
                    AppData.ExecuteNonQuery(sqlAddAuditTrail)

                    Me.Close()
                End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim sql As String = ""
            Dim dt As DataTable = New DataTable
            If accountType = "Customer" Then
                sql = String.Format("Select * from universal_masters where PK_UM = '{0}'", userPK)
                dt = AppData.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    username = dt.Rows(0)("Username_UM").ToString
                    password = dt.Rows(0)("Password_UM").ToString
                End If
            ElseIf accountType = accountType = "System Admin" Then
                sql = String.Format("Select * from users where PK_Usr = '{0}'", userPK)
                dt = AppData.GetDataTable(sql)

                If dt.Rows.Count > 0 Then
                    username = dt.Rows(0)("UserName_Usr").ToString
                    password = dt.Rows(0)("Password_Usr").ToString
                End If
            End If

            txtUsername.Text = username
        Catch ex As Exception

        End Try
    End Sub


    Private Sub chkCurrentPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkCurrentPass.CheckedChanged
        If chkCurrentPass.Checked Then
            ' Show the password
            txtPassword.Properties.PasswordChar = New Char()
        Else
            ' Hide the password
            txtPassword.Properties.PasswordChar = "*"
        End If
    End Sub

    Private Sub chkNewPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkNewPass.CheckedChanged
        If chkNewPass.Checked Then
            ' Show the password
            txtNewPassword.Properties.PasswordChar = New Char()
        Else
            ' Hide the password
            txtNewPassword.Properties.PasswordChar = "*"
        End If
    End Sub

    Private Sub chkConfirmPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfirmPass.CheckedChanged
        If chkConfirmPass.Checked Then
            ' Show the password
            txtConfirmPassword.Properties.PasswordChar = New Char()
        Else
            ' Hide the password
            txtConfirmPassword.Properties.PasswordChar = "*"
        End If
    End Sub

    Private Sub txtConfirmPassword_EditValueChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.EditValueChanged

    End Sub

    Private Sub txtUsername_EditValueChanged(sender As Object, e As EventArgs) Handles txtUsername.EditValueChanged

    End Sub
End Class
Imports System.IO
Imports MySql.Data.MySqlClient
Public Class UserPopup

    Public Property ECommerce As Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ActionPanel.BackColor = Colors.whiteSecondary
        Me.BackColor = Colors.white
        btnChangePassword.BackColor = Colors.orange
        ButtonClose.BackColor = Colors.orange
        btnLogout.BackColor = Colors.orange


    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub UserPopup_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, 70)
        Try
            Dim sqlCust As String = String.Format("Select * from universal_masters where pk_um = '{0}'", Project.Instance.ActiveUserPK)
            Dim dtC As DataTable = AppData.GetDataTable(sqlCust)
            Dim imagebyte() As Byte

            imagebyte = dtC.Rows(0)("Picture_UM")
            Dim ms As New MemoryStream(imagebyte)

            pbxUserPic.Image = Image.FromStream(ms)
            lblPopCustName.Text = dtC.Rows(0)("Name_UM")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonLogout_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Dim oform As New ChangePassword

        Me.Hide()

        oform.ShowDialog(Me)


        'Dim vUser As User = New User("", Nothing)
        'Project.Instance.ActiveUser = vUser
        'Me.Close()

        'Dim LoginFrm As New Login
        'LoginFrm.Show()
        'AppMainForm.LoginVerified = False
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Establish a connection to your database
        Dim connection As New MySqlConnection(AppData.ConnectionString)
        connection.Open()

        Dim dialogAns As Byte
        dialogAns = MessageBox.Show("Are you sure you want to leave?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialogAns = vbYes Then


            ' Replace the following placeholder values with the actual data you want to insert
            'Dim dateTimeValue As DateTime = DateTime.Now
            Dim userTypeValue As String = Project.Instance.ActiveAccountType
            Dim nameValue As String = Project.Instance.ActiveUser.Name
            Dim actionValue As String = "Logout"
            Dim remarksValue As String = "User logged out"

            ' Prepare the INSERT statement for the audit_trails table
            Dim command As String = String.Format("INSERT INTO audit_trails (PK_AT, UserType_AT, Name_AT, Action_AT, Remarks_AT) VALUES ('{0}','{1}','{2}','{3}','{4}')", GetSysPK, userTypeValue, nameValue, actionValue, remarksValue)
            AppData.ExecuteNonQuery(command)

            '' Add the parameters to the command
            'insertAudit.Parameters.AddWithValue("@dateTime", dateTimeValue)
            'insertAudit.Parameters.AddWithValue("@userType", userTypeValue)
            'insertAudit.Parameters.AddWithValue("@name", nameValue)
            'insertAudit.Parameters.AddWithValue("@action", actionValue)
            'insertAudit.Parameters.AddWithValue("@remarks", remarksValue)

            '' Execute the command
            'insertAudit.ExecuteNonQuery()

            Me.Close()

            For i As Integer = 0 To AppMainForm.XtraTabControl1.TabPages.Count - 1
                AppMainForm.XtraTabControl1.TabPages.RemoveAt(i)
            Next

            Dim LoginFrm As New Login
            LoginFrm.Show(AppMainForm)
            AppMainForm.LoginVerified = False


        End If

    End Sub
    Private Sub Panel1_Click(sender As Object, e As EventArgs)
        Try
            Dim ordersForm As New frmOrders
            ordersForm.Tag = "COMPLETED"
            ordersForm.Show(AppMainForm)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs)
        Try
            Dim ordersForm As New frmOrders
            ordersForm.Tag = "RETURNED"
            ordersForm.Show(AppMainForm)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Topay_Click(sender As Object, e As EventArgs) Handles Topay.Click, PictureBox4.Click
        Try
            Dim ordersForm As New frmOrders
            ordersForm.Tag = "TO PAY"
            ordersForm.Show(AppMainForm)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToShip_Click(sender As Object, e As EventArgs) Handles ToShip.Click
        Try
            Dim ordersForm As New frmOrders
            ordersForm.Tag = "TO SHIP"
            ordersForm.Show(AppMainForm)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ToReceive.Click
        Try
            Dim ordersForm As New frmOrders
            ordersForm.Tag = "TO RECEIVE"
            ordersForm.Show(AppMainForm)
            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub COMPLETED_Click(sender As Object, e As EventArgs) Handles COMPLETED.Click
        Try
            Dim ordersForm As New frmOrders
            ordersForm.Tag = "COMPLETED"
            ordersForm.Show(AppMainForm)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim ordersForm As New frmOrders
            ordersForm.Tag = "CANCELLED"
            ordersForm.Show(AppMainForm)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim ordersForm As New frmOrders
            ordersForm.Tag = "RETURNED"
            ordersForm.Show(AppMainForm)
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim frm As New frmUserInfo
        frm.Show()
    End Sub

    Private Sub lblPopCustName_Click(sender As Object, e As EventArgs) Handles lblPopCustName.Click

    End Sub
End Class

Imports FontAwesome.Sharp
Public Class SettlePayment
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        HeaderPanel.BackColor = Colors.black
        MainPanel.BackColor = Colors.whiteSecondary

        txtTender.Focus()


    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles ButtonDot.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button1.Click, Button0.Click, Button00.Click
        txtTender.Text += CType(sender, IconButton).Text
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click, Button500.Click, Button50.Click, Button200.Click, Button100.Click
        txtTender.Text = CType(sender, IconButton).Text
    End Sub

    Private Sub ButtonC_Click(sender As Object, e As EventArgs) Handles ButtonC.Click
        txtTender.Text = ""
        txtTender.Focus()
    End Sub

    Private Sub SettlePayment_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtTender.Focus()
    End Sub

    Private Sub txtTender_EditValueChanged(sender As Object, e As EventArgs) Handles txtTender.EditValueChanged
        txtChange.Text = StrVal9(txtTender.Text) - StrVal9(txtTotal.Text)
        lblChange.Text = StrVal9(StrVal9(txtTender.Text) - StrVal9(txtTotal.Text)).ToString("n2")
        If txtTender.Text = "" Then
            txtChange.Text = ""
        End If
    End Sub

    Private Sub ButtonEnter_Click(sender As Object, e As EventArgs) Handles ButtonEnter.Click
        If StrVal9(txtTender.Text) >= StrVal9(txtTotal.Text) Then
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("Tender amount should be greater than or equal to Total Sales.")
        End If
    End Sub

    Private Sub lblChange_Click(sender As Object, e As EventArgs) Handles lblChange.Click

    End Sub
End Class
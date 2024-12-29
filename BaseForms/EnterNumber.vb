Public Class EnterNumber

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Done()
    End Sub

    Private Sub Done()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub EnterNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Done()
        End If
    End Sub

    Private Sub EnterNumber_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtInput.Focus()
        txtInput.SelectAll()
    End Sub

    Private Sub EnterNumber_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtInput.Focus()
        txtInput.SelectAll()
    End Sub
End Class

Public Class BaseForm

    Private Const CS_DROPSHADOW As Integer = 131072

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.BackColor = Colors.pageColor

    End Sub
End Class
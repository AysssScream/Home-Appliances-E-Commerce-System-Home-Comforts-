Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Public Class AuditReportLists
    Private Sub SearchBox_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
        GridView1.FindFilterText = SearchBox.Text
    End Sub
End Class

Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
Public Class Dashboard

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Panel1.BackColor = Colors.whiteSecondary
        Me.Label1.ForeColor = Colors.blackSecondary

    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim totalProducts As String = String.Format("Select COUNT(PK_Invty) as cnt From inventories")
            Dim dtTotalProducts As DataTable = AppData.GetDataTable(totalProducts)
            lblInventory.Text = dtTotalProducts.Rows(0)("cnt")

            Dim dateToday As DateTime = Now()
            Dim dailySales As String = String.Format("Select SUM(TotalAmount_TransH) as sumSales From transaction_headers Where Module_TransH = 'Order' AND Date_TransH LIKE '%{0}%'", dateToday.ToString("yyyy-MM-dd"))
            Dim dtSales As DataTable = AppData.GetDataTable(dailySales)
            lblSales.Text = StrVal9(dtSales.Rows(0)("sumSales")).ToString("n2")

            Dim totalOnHand As String = String.Format("Select SUM(Quantity_Invty) as totalOnHand From inventories")
            Dim dtTotalOnHand As DataTable = AppData.GetDataTable(totalOnHand)
            lblOnhand.Text = StrVal9(dtTotalOnHand.Rows(0)("totalOnHand")).ToString("n0")

            Dim totalCritical As String = String.Format("Select COUNT(PK_Invty) as cnt From inventories Where CAST(IFNULL(quantity_invty,0) AS UNSIGNED) <= CAST(IFNULL(reorderlevel_invty,0) AS UNSIGNED)")
            Dim dtTotalCritical As DataTable = AppData.GetDataTable(totalCritical)
            lblCritical.Text = dtTotalCritical.Rows(0)("cnt")

            Dim sideBySideBarChart As New ChartControl()
            sideBySideBarChart.Font = New System.Drawing.Font("Verdana", 12.0!)

            Dim series1 As New Series("Side-by-Side Bar Series 1", ViewType.Bar)
            For i As Integer = 14 To 0 Step -1
                Dim dateSales = DateAdd("d", i * -1, dateToday)
                Dim dateLabel = DateAdd("d", i * -1, dateToday)
                Dim sales As String = String.Format("Select SUM(TotalAmount_TransH) as sumSales From transaction_headers Where Module_TransH = 'Order' AND Date_TransH LIKE '%{0}%'", dateSales.ToString("yyyy-MM-dd"))
                Dim dtTotalSales As DataTable = AppData.GetDataTable(sales)
                series1.Points.Add(New SeriesPoint(dateLabel, StrVal9(dtTotalSales.Rows(0)("sumSales")).ToString("n2")))
            Next
            sideBySideBarChart.Series.Add(series1)

            ' Add the series to the chart.

            ' Hide the legend (if necessary).
            sideBySideBarChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

            ' Rotate the diagram (if necessary).
            CType(sideBySideBarChart.Diagram, XYDiagram).Rotated = False

            ' Add a title to the chart (if necessary).
            Dim chartTitle1 As New ChartTitle()
            chartTitle1.Font = New System.Drawing.Font("Verdana", 16.0!)
            chartTitle1.Text = "Sales For The Last 15 Days"
            sideBySideBarChart.Titles.Add(chartTitle1)

            ' Add the chart to the form.
            sideBySideBarChart.Dock = DockStyle.Fill
            BarChartPanel.Controls.Add(sideBySideBarChart)

        Catch ex As Exception

        End Try
    End Sub


End Class

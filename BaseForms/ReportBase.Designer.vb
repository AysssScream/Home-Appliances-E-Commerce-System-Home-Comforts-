<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportBase
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportBase))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.lblAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.Line = New POS4U.ReportLabel()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.Logo = New POS4U.PictureEdit()
        Me.lblCompanyName = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblContactNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReportTitle = New POS4U.ReportLabel()
        Me.lblReportDate = New POS4U.ReportLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.lblPrintSig = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        CType(Me.Logo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 33.0!
        Me.Detail.MultiColumn.ColumnCount = 10
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 40.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.HeightF = 23.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblAddress
        '
        Me.lblAddress.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.LocationFloat = New DevExpress.Utils.PointFloat(104.1667!, 26.0!)
        Me.lblAddress.Multiline = True
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAddress.SizeF = New System.Drawing.SizeF(346.875!, 20.0!)
        Me.lblAddress.StylePriority.UseFont = False
        Me.lblAddress.StylePriority.UseTextAlignment = False
        Me.lblAddress.Text = "Mandaue City, Philippines 6014"
        Me.lblAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GroupHeader1
        '
        Me.GroupHeader1.HeightF = 32.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Line, Me.WinControlContainer1, Me.lblCompanyName, Me.lblContactNo, Me.lblReportTitle, Me.lblReportDate, Me.lblAddress})
        Me.ReportHeader.HeightF = 96.95835!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseTextAlignment = False
        Me.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'Line
        '
        Me.Line.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.Line.FieldName = Nothing
        Me.Line.LocationFloat = New DevExpress.Utils.PointFloat(0!, 72.99998!)
        Me.Line.Name = "Line"
        Me.Line.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Line.SizeF = New System.Drawing.SizeF(750.0!, 6.333351!)
        Me.Line.StylePriority.UseBorders = False
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(104.1667!, 72.99998!)
        Me.WinControlContainer1.WinControl = Me.Logo
        '
        'Logo
        '
        Me.Logo.BackgroundImage = CType(resources.GetObject("Logo.BackgroundImage"), System.Drawing.Image)
        Me.Logo.Location = New System.Drawing.Point(553, 62)
        Me.Logo.Name = "Logo"
        Me.Logo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Logo.Properties.Appearance.Options.UseBackColor = True
        Me.Logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Logo.Properties.NullText = "Double click to add pic"
        Me.Logo.Properties.ReadOnly = True
        Me.Logo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.Logo.Properties.ShowMenu = False
        Me.Logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.Logo.Size = New System.Drawing.Size(100, 70)
        Me.Logo.TabIndex = 9
        Me.Logo.TableField = "logo_set"
        Me.Logo.TableName = "settings"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyName.LocationFloat = New DevExpress.Utils.PointFloat(104.1667!, 6.0!)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCompanyName.SizeF = New System.Drawing.SizeF(346.875!, 20.0!)
        Me.lblCompanyName.StylePriority.UseFont = False
        Me.lblCompanyName.StylePriority.UseTextAlignment = False
        Me.lblCompanyName.Text = "CompanyName"
        Me.lblCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblContactNo
        '
        Me.lblContactNo.CanGrow = False
        Me.lblContactNo.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblContactNo.ForeColor = System.Drawing.Color.Black
        Me.lblContactNo.LocationFloat = New DevExpress.Utils.PointFloat(104.1667!, 45.99999!)
        Me.lblContactNo.Name = "lblContactNo"
        Me.lblContactNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblContactNo.SizeF = New System.Drawing.SizeF(346.875!, 20.0!)
        Me.lblContactNo.StylePriority.UseFont = False
        Me.lblContactNo.StylePriority.UseTextAlignment = False
        Me.lblContactNo.Text = "(032)111-1111"
        Me.lblContactNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblContactNo.WordWrap = False
        '
        'lblReportTitle
        '
        Me.lblReportTitle.FieldName = Nothing
        Me.lblReportTitle.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(476.0417!, 0!)
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReportTitle.SizeF = New System.Drawing.SizeF(273.9583!, 20.0!)
        Me.lblReportTitle.StylePriority.UseFont = False
        Me.lblReportTitle.StylePriority.UseTextAlignment = False
        Me.lblReportTitle.Text = "ReportTitle"
        Me.lblReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblReportDate
        '
        Me.lblReportDate.FieldName = Nothing
        Me.lblReportDate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblReportDate.LocationFloat = New DevExpress.Utils.PointFloat(476.0417!, 20.0!)
        Me.lblReportDate.Name = "lblReportDate"
        Me.lblReportDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReportDate.SizeF = New System.Drawing.SizeF(273.9583!, 20.0!)
        Me.lblReportDate.StylePriority.UseFont = False
        Me.lblReportDate.StylePriority.UseTextAlignment = False
        Me.lblReportDate.Text = "ReportDate"
        Me.lblReportDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 48.0!
        Me.TopMargin.Name = "TopMargin"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblPrintSig, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 35.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPrintSig
        '
        Me.lblPrintSig.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrintSig.LocationFloat = New DevExpress.Utils.PointFloat(0!, 21.99999!)
        Me.lblPrintSig.Name = "lblPrintSig"
        Me.lblPrintSig.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrintSig.SizeF = New System.Drawing.SizeF(568.75!, 13.00001!)
        Me.lblPrintSig.StylePriority.UseFont = False
        Me.lblPrintSig.StylePriority.UseTextAlignment = False
        Me.lblPrintSig.Text = "print signature"
        Me.lblPrintSig.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblPrintSig.Visible = False
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(667.0834!, 21.99999!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(72.91663!, 13.00001!)
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrPageInfo1.TextFormatString = "Page {0} of {1}"
        '
        'XrControlStyle1
        '
        Me.XrControlStyle1.Name = "XrControlStyle1"
        '
        'ReportBase
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.BottomMargin, Me.PageHeader, Me.GroupHeader1, Me.ReportHeader, Me.TopMargin, Me.PageFooter})
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Italic)
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 48, 40)
        Me.ShowPrintMarginsWarning = False
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
        Me.Version = "17.2"
        CType(Me.Logo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected Friend WithEvents lblReportTitle As POS4U.ReportLabel
    Protected Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    'Protected Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Protected Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Protected Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Protected Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Protected Friend WithEvents lblReportDate As POS4U.ReportLabel
    Protected Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Protected Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Protected Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Protected Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Protected Friend WithEvents lblPrintSig As DevExpress.XtraReports.UI.XRLabel
    Protected Friend WithEvents lblCompanyName As DevExpress.XtraReports.UI.XRLabel
    Protected Friend WithEvents lblAddress As DevExpress.XtraReports.UI.XRLabel
    Protected Friend WithEvents lblContactNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Protected Friend WithEvents Line As ReportLabel
    Protected Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Protected Friend WithEvents Logo As PictureEdit
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
End Class

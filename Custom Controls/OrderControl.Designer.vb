<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OrderControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPaymentStatus = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblModeOfPayment = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblOrderNo = New System.Windows.Forms.Label()
        Me.btnViewOrder = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.Black
        Me.Guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Guna2Panel1.BorderThickness = 2
        Me.Guna2Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Guna2Panel1.ShadowDecoration.Parent = Me.Guna2Panel1
        Me.Guna2Panel1.Size = New System.Drawing.Size(279, 239)
        Me.Guna2Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblPaymentStatus, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalAmount, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblQuantity, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblModeOfPayment, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDate, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOrderNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnViewOrder, 0, 7)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(269, 229)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblPaymentStatus
        '
        Me.lblPaymentStatus.AutoSize = True
        Me.lblPaymentStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPaymentStatus.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblPaymentStatus.Location = New System.Drawing.Point(3, 168)
        Me.lblPaymentStatus.Name = "lblPaymentStatus"
        Me.lblPaymentStatus.Size = New System.Drawing.Size(263, 28)
        Me.lblPaymentStatus.TabIndex = 6
        Me.lblPaymentStatus.Text = "lblPaymentStatus"
        Me.lblPaymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblStatus.Location = New System.Drawing.Point(3, 140)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(263, 28)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalAmount.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblTotalAmount.Location = New System.Drawing.Point(3, 112)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(263, 28)
        Me.lblTotalAmount.TabIndex = 4
        Me.lblTotalAmount.Text = "lblTotalAmount"
        Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQuantity.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblQuantity.Location = New System.Drawing.Point(3, 84)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(263, 28)
        Me.lblQuantity.TabIndex = 3
        Me.lblQuantity.Text = "lblQuantity"
        Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModeOfPayment
        '
        Me.lblModeOfPayment.AutoSize = True
        Me.lblModeOfPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblModeOfPayment.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblModeOfPayment.Location = New System.Drawing.Point(3, 56)
        Me.lblModeOfPayment.Name = "lblModeOfPayment"
        Me.lblModeOfPayment.Size = New System.Drawing.Size(263, 28)
        Me.lblModeOfPayment.TabIndex = 2
        Me.lblModeOfPayment.Text = "lblModeOfPayment"
        Me.lblModeOfPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblDate.Location = New System.Drawing.Point(3, 28)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(263, 28)
        Me.lblDate.TabIndex = 1
        Me.lblDate.Text = "lblDate"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOrderNo
        '
        Me.lblOrderNo.AutoSize = True
        Me.lblOrderNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOrderNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrderNo.Location = New System.Drawing.Point(3, 0)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(263, 28)
        Me.lblOrderNo.TabIndex = 0
        Me.lblOrderNo.Text = "lblOrderNo"
        Me.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnViewOrder
        '
        Me.btnViewOrder.CheckedState.Parent = Me.btnViewOrder
        Me.btnViewOrder.CustomImages.Parent = Me.btnViewOrder
        Me.btnViewOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnViewOrder.FillColor = System.Drawing.Color.Red
        Me.btnViewOrder.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnViewOrder.ForeColor = System.Drawing.Color.White
        Me.btnViewOrder.HoverState.Parent = Me.btnViewOrder
        Me.btnViewOrder.Location = New System.Drawing.Point(3, 199)
        Me.btnViewOrder.Name = "btnViewOrder"
        Me.btnViewOrder.ShadowDecoration.Parent = Me.btnViewOrder
        Me.btnViewOrder.Size = New System.Drawing.Size(263, 27)
        Me.btnViewOrder.TabIndex = 7
        Me.btnViewOrder.Text = "View Order"
        '
        'OrderControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Name = "OrderControl"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Size = New System.Drawing.Size(299, 259)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblPaymentStatus As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblModeOfPayment As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblOrderNo As Label
    Friend WithEvents btnViewOrder As Guna.UI2.WinForms.Guna2Button
End Class

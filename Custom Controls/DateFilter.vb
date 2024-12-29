Imports DevExpress.XtraEditors

Public Class DateFilter
    Private _FieldName As String
    Private _TableName As String
    Private _EditValue As String
    Private useTable As Boolean = False
    Private FirstLoad As Boolean = True
    Private pDefaultDate As Boolean

    Public Property TableField() As String
        Get
            Return _FieldName
        End Get
        Set(ByVal value As String)
            _FieldName = value
        End Set
    End Property

    Public Property TableName() As String
        Get
            Return _TableName
        End Get
        Set(ByVal value As String)
            _TableName = value
        End Set
    End Property

    Public Property EditValue() As String
        Get
            Return _EditValue
        End Get
        Set(ByVal value As String)
            _EditValue = value
        End Set
    End Property
    'Public WriteOnly Property UseTableName() As Boolean
    '    Set(ByVal value As Boolean)
    '        useTable = value
    '    End Set
    'End Property
    Public Property UseTableName() As Boolean
        Get
            Return useTable
        End Get
        Set(ByVal value As Boolean)
            useTable = value

        End Set
    End Property
    <System.ComponentModel.DefaultValue(False)> _
Public Property IsBlankDate() As Boolean
        Get
            Return pDefaultDate
        End Get
        Set(ByVal value As Boolean)
            pDefaultDate = value
        End Set
    End Property

    Private Sub ComboBoxInput1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilterType.TextChanged
        Dim txtFilterType As String = cboFilterType.Text.Trim
        'If cboFilterType.Properties.Items.Count = 0 Then cboFilterType.LoadData()
        If cboFilterType.Properties.Items.Contains(txtFilterType) OrElse txtFilterType = "" Then
            Select Case txtFilterType.ToLower
                Case "as of", "today", "equals"
                    LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    DateStart.EditValue = Now
                Case "period from"
                    LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    DateStart.EditValue = Now
                    DateEnd.EditValue = Now
                Case else
                    LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    me.DateEnd.EditValue=""
                    Me.DateStart.EditValue = ""
            End Select
            
            'ChangeDateFilterValue()
        Else
            If Not FirstLoad Then XtraMessageBox.Show("Invalid Date Filter type, please select one from the dropdown...", "Invalid Filter Type", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FirstLoad = False
        End If

    End Sub

    Private Sub ChangeDateFilterValue()
        If pDefaultDate Then
            _EditValue = ""
            Exit Sub
        End If

        Try
            'Dim SenderCtrl As DateEdit = DirectCast(sender, DateEdit)
            _EditValue = ""
            'DateStart.EditValue = Now
            If useTable Then
                Select Case cboFilterType.Text.ToLower
                    Case "today", "equals"

                        _EditValue = String.Format("{2}.{0} Like '%{1:yyyy-MM-dd}%'", Me.TableField, DateValue(DateStart.EditValue), Me.TableName)
                        '_EditValue = String.Format("{0} >= '{1:yyyy-MM-dd}' AND {0} < '{2:yyyy-MM-dd}'", Me.TableField, DateValue(Now),Now.AddDays(1))
                        ' Me.Tag = Now.ToString("d")
                        Me.Tag = DateValue(DateStart.EditValue).ToString("d")
                    Case "as of"
                        _EditValue = String.Format("{2}.{0} < '{1:yyyy-MM-dd}'", Me.TableField, DateValue(DateStart.EditValue).AddDays(1), Me.TableName)
                        Me.Tag = "As Of " & DateValue(DateStart.EditValue).ToString("d")
                        'Case "equals"
                        '    _EditValue = String.Format("{0} >= '{1:yyyy-MM-dd}' AND {0} < '{2:yyyy-MM-dd}'", Me.TableField, DateValue(DateStart.EditValue),DateValue(DateStart.EditValue).AddDays(1)) 'String.Format("{0} = '{1:yyyy-MM-dd}'", Me.TableField, DateValue(DateStart.EditValue))
                        '    Me.Tag = DateValue(DateStart.EditValue).ToString("d")
                    Case "period from"
                        _EditValue = String.Format("{3}.{0} >= '{1:yyyy-MM-dd}' AND {3}.{0} < '{2:yyyy-MM-dd}'", Me.TableField, DateValue(Me.DateStart.EditValue), DateValue(Me.DateEnd.EditValue).AddDays(1), TableName)
                        Me.Tag = String.Format("{0} To {1}", DateValue(DateStart.EditValue).ToString("d"), DateValue(Me.DateEnd.EditValue).ToString("d"))
                End Select
            Else
                Select Case cboFilterType.Text.ToLower
                    Case "today", "equals"

                        _EditValue = String.Format("{0} Like '%{1:yyyy-MM-dd}%'", Me.TableField, DateValue(DateStart.EditValue))
                        '_EditValue = String.Format("{0} >= '{1:yyyy-MM-dd}' AND {0} < '{2:yyyy-MM-dd}'", Me.TableField, DateValue(Now),Now.AddDays(1))
                        ' Me.Tag = Now.ToString("d")
                        Me.Tag = DateValue(DateStart.EditValue).ToString("d")
                    Case "as of"
                        _EditValue = String.Format("{0} < '{1:yyyy-MM-dd}'", Me.TableField, DateValue(DateStart.EditValue).AddDays(1))
                        Me.Tag = "As Of " & DateValue(DateStart.EditValue).ToString("d")
                        'Case "equals"
                        '    _EditValue = String.Format("{0} >= '{1:yyyy-MM-dd}' AND {0} < '{2:yyyy-MM-dd}'", Me.TableField, DateValue(DateStart.EditValue),DateValue(DateStart.EditValue).AddDays(1)) 'String.Format("{0} = '{1:yyyy-MM-dd}'", Me.TableField, DateValue(DateStart.EditValue))
                        '    Me.Tag = DateValue(DateStart.EditValue).ToString("d")
                    Case "period from"
                        _EditValue = String.Format("{0} >= '{1:yyyy-MM-dd}' AND {0} < '{2:yyyy-MM-dd}'", Me.TableField, DateValue(Me.DateStart.EditValue), DateValue(Me.DateEnd.EditValue).AddDays(1))
                        Me.Tag = String.Format("{0} To {1}", DateValue(DateStart.EditValue).ToString("d"), DateValue(Me.DateEnd.EditValue).ToString("d"))
                End Select
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateEnd_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateStart.EditValueChanged, DateEnd.EditValueChanged
        ChangeDateFilterValue()
    End Sub

    Private Sub DateFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.cboFilterType.LoadData()
        System.Threading.Thread.Sleep(100)
        DateStart.EditValue = Now
        DateEnd.EditValue = Now
        cboFilterType.Text = "Today"
        If pDefaultDate Then
            Me.DateEnd.EditValue = ""
            Me.DateStart.EditValue = ""
        End If
     
    End Sub

    Private Sub DateFilter_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        ChangeDateFilterValue()
    End Sub

    Private DateCaption As String
    Public Property Caption() As String
        Get
            Return LayoutControlItem1.Text
        End Get
        Set(ByVal value As String)
            LayoutControlItem1.Text = value
        End Set
    End Property
End Class

Imports System.Data.Common
Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports MySql.Data.MySqlClient



Public Module ModUtils
    Public SearchGridData As DataSet ''hansel
    Public UserName As String

    Public dbconn As New MySqlConnection

    Public dbcomm As MySqlCommand

    Public Sub AdditionalWhere9(ByVal ControlCriteria As TextInput, ByRef Criteria As String)

        With ControlCriteria
            If Not IsEmptyString(.TableField) AndAlso Not IsEmptyString(.TableName) _
                AndAlso Not IsEmptyString(.Text) Then
                If Not IsEmptyString(Criteria) Then
                    Criteria = String.Format("{0} AND {1}={2}", Criteria, .TableField, AddQuote9(.Text))
                Else
                    Criteria = String.Format("{0}={1}", .TableField, AddQuote9(.Text))
                End If
            End If
        End With

    End Sub

    Public Sub AdditionalWhere9(ByVal AdditionaCriteria As String, ByRef Criteria As String)

        If Not String.IsNullOrEmpty(AdditionaCriteria) Then
            If Not IsEmptyString(Criteria) Then
                Criteria = String.Format("{0} AND {1}", Criteria, AdditionaCriteria)
            Else
                Criteria = AdditionaCriteria
            End If
        End If

    End Sub

    Public Function AddQuote9(ByVal StrValue As String) As String
        If IsDate(StrValue) Then
            If AppData.DBProvider = DataProviderType.Mysql Then
                StrValue = DateValue(StrValue).ToString("yyyy-MM-dd")
                StrValue = String.Format("'{0}'", StrValue)
            Else
                String.Format("#{0}#", StrValue)
            End If
        Else
            StrValue = String.Format("'{0}'", StrValue)
        End If
        Return StrValue
    End Function

    Public Function SafeValues(ByVal Value As String) As String
        Dim res As String = ""
        If Not IsEmptyString(Value) Then
            If AppData.DBProvider = DataProviderType.SqlServer Then
                res = Value.Replace("'", "''")
            Else
                res = Value.Replace("'", "\'")
            End If
        End If

        Return res
    End Function

    Public Function ForceRoundUpTo1Dec(ByVal value As Object) As Double
        Try
            Dim res As Double
            Dim decPart As String
            Dim GivenValue As String = value.ToString.Replace("$", "").Replace(",", "").Trim
            Dim tens, ones As Integer
            Dim numPart As Double
            Select Case True
                Case InStr(value, "%") <> 0
                    res = Val(GivenValue.Replace("%", "")) / 100
                Case Else
                    res = Val(GivenValue)
            End Select


            If res.ToString.Contains(".") Then
                decPart = res.ToString.Split(".")(1)
                numPart = Val(res.ToString.Split(".")(0))
                tens = CInt(decPart.Substring(0, 1))
                ones = CInt(decPart.Substring(1, 1))
                If ones > 0 Then
                    tens += 1
                    ones = 0
                End If

                If tens > 9 Then
                    numPart += 1
                    tens = 0
                End If

                res = numPart
                res += (tens * 10) / 100

            End If

            Return res
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function StrVal9(ByVal ValueExpression As Object, Optional ByVal CustomNumberFormat As Boolean = False) As Decimal
        Try
            Dim GivenValue As String = ValueExpression.ToString.Replace("$", "").Replace(",", "").Trim
            Select Case True
                Case InStr(ValueExpression, "%") <> 0
                    GivenValue = CDec(GivenValue.Replace("%", "")) / 100
                Case Else
                    GivenValue = CDec(GivenValue)
            End Select


            Return Convert.ToDecimal(GivenValue)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function IsEmptyString(ByVal Str As String) As Boolean
        Return String.IsNullOrEmpty(Trim(Str))
    End Function

    Public Function ProperCase(ByVal Str As String) As String
        Dim tmpStrArr() As String = Str.Split(" ")
        Dim res As String = ""
        If Not IsNothing(tmpStrArr) Then
            For i As Integer = 0 To UBound(tmpStrArr)
                Dim tmp As String = tmpStrArr(i)
                If Not IsEmptyString(tmp) Then
                    tmp = Left(tmp, 1).ToUpper + Right(tmp, Len(tmp) - 1).ToLower
                    res &= tmp + " "
                End If
            Next
            res.TrimEnd(" ")
        End If

        Return res
    End Function

    Public Function GetColumnInfo(ByVal ColumnDefinitionString As String) As Collection
        Dim Columns As Collection
        Dim ColStr() As String
        Try
            If Not IsEmptyString(ColumnDefinitionString) Then
                Columns = New Collection
                ColStr = ColumnDefinitionString.Split("@")

                For i As Integer = 1 To UBound(ColStr)
                    Dim column As New ColumnInfo
                    Dim colInfoString() As String = ColStr(i).Split("|")

                    With column
                        .Caption = colInfoString(1).TrimEnd(ChrW(Keys.Tab))
                        .FieldName = colInfoString(2).TrimEnd(ChrW(Keys.Tab)).ToLower
                        If colInfoString(3).TrimEnd(ChrW(Keys.Tab)).Contains("*") Then
                            .Fixed = True
                        Else
                            .Fixed = False
                        End If
                        If colInfoString(3).TrimEnd(ChrW(Keys.Tab)).Contains("-") Then
                            .Locked = True
                        Else
                            .Locked = False
                        End If
                        .Width = colInfoString(3).TrimEnd(ChrW(Keys.Tab)).Replace("*", "").Replace("-", "")
                        .OutputCtrl = colInfoString(4).TrimEnd(ChrW(Keys.Tab))
                        .Format = colInfoString(5).TrimEnd(ChrW(Keys.Tab))
                        Select Case .Format.ToLower
                            Case "currency"
                                .Format = "n2"
                            Case "int", "integer"
                                .Format = "n0"
                            Case "date"
                                .Format = "d"
                            Case "time"
                                .Format = "t"
                            Case "percent", "p"
                                .Format = "p"
                            Case "bool"
                                .Format = "bool"
                            Case "memo"
                                .Format = "memo"
                            Case "datetime"
                                .Format = "datetime"
                            Case Else
                                .Format = .Format.ToLower
                        End Select
                        .CustProperty = colInfoString(6).TrimEnd(ChrW(Keys.Tab))
                        .OutputField = colInfoString(7).TrimEnd(ChrW(Keys.Tab))
                        .DefaultValue = colInfoString(8).TrimEnd(ChrW(Keys.Tab)).Trim
                    End With

                    Columns.Add(column, column.FieldName)
                Next
            End If
        Catch ex As Exception

        End Try


        Return Columns

    End Function

    Public Function GenerateSystemPK() As Integer
        Return System.Guid.NewGuid.GetHashCode()
    End Function

    Public Function GetSysPK() As String
        Return SequentialGUID.Create(IIf(AppData.DBProvider = DataProviderType.Mysql, SequentialGuidType.SequentialAsString, SequentialGuidType.SequentialAtEnd)).ToString
    End Function

    Public Function CreateObject(ByVal ObjectName As String, ByVal ParamArray Params() As Object) As Object
        Try
            'Dim FormName1 As String
            Dim FullTypeName As String
            Dim FormInstanceType As Type

            Dim st As New StackTrace()
            FullTypeName = st.GetFrame(1).GetMethod().DeclaringType.FullName
            FullTypeName = String.Format("{0}.{1}", FullTypeName.Split(".")(0), ObjectName)

            'FullTypeName = FormName1
            FormInstanceType = Type.GetType(FullTypeName, True, True)
            If Params.Length = 0 Then
                Return Activator.CreateInstance(FormInstanceType)
            Else
                Return Activator.CreateInstance(FormInstanceType, Params)
            End If


        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Function getPickListData(ByVal FromString As String, ByVal ColumnDefString As String) As DataSet
        Dim pickdata As DataSet
        Try

            If Not IsNothing(ColumnDefString) AndAlso Not IsEmptyString(ColumnDefString) Then
                Dim sqlQry As String
                Dim sqlSelect As String = "", sqlFrom As String = "", sqlWhere As String = "", sqlOrderBy As String = "", sqlAdditionalCriteria As String = ""
                Dim pColumns As Collection = GetColumnInfo(ColumnDefString)
                If Not IsNothing(pColumns) Then
                    For Each col As ColumnInfo In pColumns
                        sqlSelect &= col.FieldName + ","
                    Next

                    sqlSelect = "SELECT " + sqlSelect.TrimEnd(",")
                    '''''''''''''''''BUILD QUERY'''''''''''''''''
                    'Build FROM SQL
                    Dim tmp() As String = FromString.Split("|")

                    For i As Integer = 0 To UBound(tmp)
                        If tmp(i) <> "" Then
                            With tmp(i).ToUpper
                                Select Case True
                                    Case .Contains("FROM")
                                        sqlFrom = tmp(i).Trim
                                    Case .Contains("WHERE")
                                        sqlWhere = tmp(i).Trim
                                    Case .Contains("ORDER BY")
                                        sqlOrderBy = tmp(i).Trim
                                End Select
                            End With
                        End If
                    Next

                    'BUILD SQL QUERY STRING
                    sqlQry = String.Format("{0} {1} {2} {3}", sqlSelect, sqlFrom, sqlWhere, sqlOrderBy)

                    Dim tmpCommand As DbCommand
                    Dim tmpConnection As DbConnection
                    Dim tmpDataAdapter As DbDataAdapter


                    tmpConnection = Data.GetConnection
                    tmpConnection.ConnectionString = Data.GetConnectionString

                    tmpCommand = Data.GetCommand
                    tmpCommand.CommandText = sqlQry 'IIf(ApplyFilter, String.Format("{0} WHERE {1}", pQueryString, FilterString), pQueryString)
                    tmpCommand.Connection = tmpConnection

                    tmpDataAdapter = Data.GetDataAdapter
                    tmpDataAdapter.SelectCommand = tmpCommand

                    pickdata = New DataSet
                    pickdata.Tables.Add("lookupsource")
                    pickdata.EnforceConstraints = False

                    pickdata.Tables("lookupsource").BeginLoadData()
                    tmpDataAdapter.Fill(pickdata.Tables("lookupsource"))
                    pickdata.Tables("lookupsource").EndLoadData()

                    Application.DoEvents()
                    Return pickdata
                End If

            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetApplicationPath() As String
        Try
            Dim _AppPath As String, _ExeName As String
            _AppPath = System.Reflection.Assembly.GetExecutingAssembly.Location
            _ExeName = Dir(_AppPath)
            _AppPath = Path.GetFullPath((Left(_AppPath, (Len(_AppPath) - Len(_ExeName)))))

            Return _AppPath
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function ShowSaveFileDialog(ByVal title As String, ByVal DefaultFilename As String, ByVal filter As String) As String
        Dim dlg As SaveFileDialog = New SaveFileDialog()
        Dim name As String = DefaultFilename
        Dim n As Integer = name.LastIndexOf(".") + 1
        If n > 0 Then
            name = name.Substring(n, name.Length - n)
        End If
        dlg.Title = title
        dlg.FileName = name
        dlg.Filter = filter
        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Return dlg.FileName
        End If
        Return ""
    End Function

    Public Function ShowOpenFileDialog(ByVal title As String, ByVal DefaultFilename As String, ByVal filter As String) As String
        Try
            Dim dlg As OpenFileDialog = New OpenFileDialog()
            Dim name As String = DefaultFilename
            Dim n As Integer = name.LastIndexOf(".") + 1
            If n > 0 Then
                name = name.Substring(n, name.Length - n)
            End If
            dlg.Title = title
            dlg.FileName = name
            dlg.Filter = filter
            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Return dlg.FileName
            End If
            Return ""
        Catch ex As Exception

        End Try

    End Function

    Public Sub AutosizeImage(ByVal Img As Bitmap, ByVal picBox As DevExpress.XtraEditors.PictureEdit, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            Dim imgOrg As Bitmap
            Dim imgShow As Bitmap
            Dim g As Graphics
            Dim divideBy, divideByH, divideByW As Double
            imgOrg = Img

            divideByW = imgOrg.Width / picBox.Width
            divideByH = imgOrg.Height / picBox.Height
            If divideByW > 1 Or divideByH > 1 Then
                If divideByW > divideByH Then
                    divideBy = divideByW
                Else
                    divideBy = divideByH
                End If

                imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                g = Graphics.FromImage(imgShow)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                g.Dispose()
            Else
                imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                g = Graphics.FromImage(imgShow)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                g.Dispose()
            End If
            imgOrg.Dispose()

            picBox.Image = imgShow


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub AutosizeImage(ByVal ImagePath As String, ByVal picBox As DevExpress.XtraEditors.PictureEdit, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            If System.IO.File.Exists(ImagePath) Then
                Dim imgOrg As Bitmap
                Dim imgShow As Bitmap
                Dim g As Graphics
                Dim divideBy, divideByH, divideByW As Double
                imgOrg = DirectCast(Bitmap.FromFile(ImagePath), Bitmap)

                divideByW = imgOrg.Width / picBox.Width
                divideByH = imgOrg.Height / picBox.Height
                If divideByW > 1 Or divideByH > 1 Then
                    If divideByW > divideByH Then
                        divideBy = divideByW
                    Else
                        divideBy = divideByH
                    End If

                    imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                Else
                    imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                End If
                imgOrg.Dispose()

                picBox.Image = imgShow
            Else
                picBox.Image = Nothing
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Function ImageToByte(ByVal img As Bitmap) As Byte()
        Try
            Dim imgStream As MemoryStream = New MemoryStream()

            img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Png)
            imgStream.Close()

            Dim byteArray As Byte() = imgStream.ToArray()

            imgStream.Dispose()

            Return byteArray

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ImageToByte(ByVal imgPath As String) As Byte()
        Try
            Dim imgStream As MemoryStream = New MemoryStream()

            Dim img As Bitmap
            img = DirectCast(Bitmap.FromFile(imgPath), Bitmap)

            img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Png)
            imgStream.Close()

            Dim byteArray As Byte() = imgStream.ToArray()

            imgStream.Dispose()

            Return byteArray

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function GetLowerCaseString(ByVal str As String)
        Dim res = ""
        Try
            If Not (IsNothing(str) OrElse String.IsNullOrEmpty(str)) Then
                res = str.ToLower
            End If

        Catch ex As Exception
        End Try
        Return res
    End Function

    Public Sub AutosizeImage(ByVal image As MemoryStream, ByVal picBox As DevExpress.XtraEditors.PictureEdit, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            If Not IsNothing(image) Then
                Dim imgOrg As Bitmap
                Dim imgShow As Bitmap
                Dim g As Graphics
                Dim divideBy, divideByH, divideByW As Double
                imgOrg = DirectCast(Bitmap.FromStream(image), Bitmap)

                divideByW = imgOrg.Width / picBox.Width
                divideByH = imgOrg.Height / picBox.Height
                If divideByW > 1 Or divideByH > 1 Then
                    If divideByW > divideByH Then
                        divideBy = divideByW
                    Else
                        divideBy = divideByH
                    End If

                    imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                Else
                    imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                End If
                imgOrg.Dispose()

                picBox.Image = imgShow
            Else
                picBox.Image = Nothing
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub AutosizeImage(ByVal image As MemoryStream, ByVal picBox As XRPictureBox, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            If Not IsNothing(image) Then
                Dim imgOrg As Bitmap
                Dim imgShow As Bitmap
                Dim g As Graphics
                Dim divideBy, divideByH, divideByW As Double
                imgOrg = DirectCast(Bitmap.FromStream(image), Bitmap)

                divideByW = imgOrg.Width / picBox.Width
                divideByH = imgOrg.Height / picBox.Height
                If divideByW > 1 Or divideByH > 1 Then
                    If divideByW > divideByH Then
                        divideBy = divideByW
                    Else
                        divideBy = divideByH
                    End If

                    imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                Else
                    imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                End If
                imgOrg.Dispose()

                picBox.Image = imgShow
            Else
                picBox.Image = Nothing
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Public Sub CreateGridColumns(ByVal Grid As Control, ByVal ColumnsCollection As Collection, Optional ByVal ContainerForm As Form = Nothing)

        Dim OwnerForm As Form
        If IsNothing(ContainerForm) Then
            OwnerForm = Grid.FindForm
        Else
            OwnerForm = ContainerForm
        End If
        Try
            If OwnerForm.InvokeRequired Then
                OwnerForm.Invoke(New CreateGridColumnsCrossThreadDelegate(AddressOf CreateGridColumns), Grid, ColumnsCollection)
            Else
                Dim myGrid As GridControl = CType(Grid, GridControl)
                Dim columnView As GridView = DirectCast(myGrid.MainView, GridView)
                With columnView
                    .Columns.Clear()

                    If Not IsNothing(ColumnsCollection) Then
                        For Each col As ColumnInfo In ColumnsCollection
                            Dim tempFieldName As String = col.FieldName
                            If tempFieldName.ToLower.Contains(" as ") Then
                                tempFieldName = tempFieldName.ToLower.Replace(" as ", "|").Split("|")(1)
                            ElseIf tempFieldName.ToLower.Contains(" ") Then
                                If OwnerForm.Name = "PickListBase4" Then
                                    tempFieldName = tempFieldName.Split(" ")(tempFieldName.Split(" ").Length - 1)
                                End If

                            End If
                            .Columns.AddField(tempFieldName)
                            With .Columns(tempFieldName)
                                .AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                                .OptionsColumn.FixedWidth = False
                                If col.Caption.ToUpper.Contains("\") Then
                                    .Caption = col.Caption.ToUpper.Split("\")(0) & Global.Microsoft.VisualBasic.ChrW(10) & col.Caption.ToUpper.Split("\")(1)
                                Else
                                    .Caption = col.Caption.ToUpper
                                End If

                                .Width = col.Width

                                If Not IsEmptyString(col.Format) Then

                                    Select Case col.Format.ToLower
                                        Case "p", "p2"

                                            Dim repEdit As New RepositoryItemTextEdit
                                            repEdit.ReadOnly = False
                                            myGrid.RepositoryItems.Add(repEdit)

                                            repEdit.Mask.EditMask = "p"
                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                                            repEdit.Mask.UseMaskAsDisplayFormat = True

                                            .ColumnEdit = repEdit
                                        Case "image"
                                            Dim repEdit As New RepositoryItemPictureEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            repEdit.SizeMode = Controls.PictureSizeMode.Zoom
                                            repEdit.NullText = " "
                                            .ColumnEdit = repEdit
                                        Case "button"
                                            Dim repEdit As New RepositoryItemButtonEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            repEdit.TextEditStyle = Controls.TextEditStyles.HideTextEditor

                                            .ColumnEdit = repEdit
                                        Case "memo"
                                            Dim repEdit As New RepositoryItemMemoEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            repEdit.AutoHeight = True
                                            repEdit.WordWrap = True
                                            .ColumnEdit = repEdit

                                            columnView.OptionsView.RowAutoHeight = True

                                        Case "n0"

                                            Dim repEdit As New RepositoryItemTextEdit
                                            repEdit.ReadOnly = False
                                            myGrid.RepositoryItems.Add(repEdit)

                                            repEdit.Mask.EditMask = "n0"
                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                                            repEdit.Mask.UseMaskAsDisplayFormat = True

                                            .ColumnEdit = repEdit

                                        Case "n1", "n2", "n3", "n4"

                                            Dim repEdit As New RepositoryItemTextEdit
                                            repEdit.ReadOnly = False
                                            myGrid.RepositoryItems.Add(repEdit)

                                            repEdit.Mask.EditMask = col.Format
                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                                            repEdit.Mask.UseMaskAsDisplayFormat = True

                                            .ColumnEdit = repEdit

                                        Case "d"
                                            Dim repEdit As New RepositoryItemDateEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            repEdit.Mask.EditMask = "d"
                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
                                            repEdit.Mask.UseMaskAsDisplayFormat = True
                                            .ColumnEdit = repEdit
                                        Case "t"
                                            Dim repEdit As New RepositoryItemTimeEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            repEdit.Mask.EditMask = "t"
                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
                                            repEdit.Mask.UseMaskAsDisplayFormat = True
                                            .ColumnEdit = repEdit

                                        Case "datetime"
                                            Dim repEdit As New RepositoryItemTimeEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            repEdit.Mask.EditMask = "yyyy-MM-dd HH:mm"
                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
                                            repEdit.Mask.UseMaskAsDisplayFormat = True
                                            .ColumnEdit = repEdit

                                        Case "mm/yyyy"
                                            Dim repEdit As New RepositoryItemTimeEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            repEdit.Mask.EditMask = "MM/yyyy"
                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
                                            repEdit.Mask.UseMaskAsDisplayFormat = True
                                            .ColumnEdit = repEdit

                                        Case "MMMM yyyy"
                                            Dim repEdit As New RepositoryItemTimeEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            repEdit.Mask.EditMask = "MMMM yyyy"
                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
                                            repEdit.Mask.UseMaskAsDisplayFormat = True
                                            .ColumnEdit = repEdit
                                        Case "bool"
                                            Dim repEdit As New RepositoryItemCheckEdit
                                            myGrid.RepositoryItems.Add(repEdit)
                                            With repEdit
                                                repEdit.ValueChecked = 1
                                                repEdit.ValueUnchecked = 0
                                                repEdit.AllowGrayed = False

                                                repEdit.DisplayValueChecked = CBool(1)
                                                repEdit.DisplayValueGrayed = CBool(0)
                                                repEdit.DisplayValueUnchecked = CBool(0)
                                                repEdit.NullStyle = Controls.StyleIndeterminate.Unchecked
                                            End With
                                            .ColumnEdit = repEdit


                                        Case Else
                                            Dim repEdit As New RepositoryItemTextEdit()
                                            myGrid.RepositoryItems.Add(repEdit)

                                            repEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom
                                            repEdit.Mask.EditMask = col.Format
                                            repEdit.Mask.UseMaskAsDisplayFormat = True

                                            .ColumnEdit = repEdit
                                    End Select

                                End If
                                .Fixed = col.Fixed
                                .OptionsColumn.AllowEdit = Not col.Locked
                                .Visible = IIf(col.Width > 0, True, False)
                                Dim valueSource As String = col.CustProperty.ToLower.Split(":")(0)
                                If valueSource = "total" Then
                                    columnView.OptionsView.ShowFooter = True
                                    .SummaryItem.FieldName = col.FieldName
                                    .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                    .SummaryItem.DisplayFormat = "{0:n2}"
                                ElseIf valueSource = "combo" Then
                                    Try
                                        Application.DoEvents()
                                        Dim cbEdit As New RepositoryItemComboBox
                                        If col.CustProperty.ToLower.Split(":")(1).Contains(",") Then
                                            Dim strcombo As String() = col.CustProperty.Split(":")(1).Split(",")
                                            For i As Integer = 0 To strcombo.Length - 1
                                                cbEdit.Items.Add(strcombo(i))
                                            Next
                                        Else
                                            Dim srcCombo As ComboBoxInput = CType(CType(Grid.FindForm, EditorBase).GetControl(col.CustProperty.ToLower.Split(":")(1)), ComboBoxEdit)

                                            With srcCombo.Properties
                                                For i As Integer = 0 To .Items.Count - 1
                                                    cbEdit.Items.Add(.Items(i))
                                                Next
                                            End With
                                        End If

                                        .ColumnEdit = cbEdit
                                    Catch ex As Exception

                                    End Try
                                    '.ColumnEdit = CType(CType(myGrid.FindForm, EditorBase).GetControl(col.CustProperty), RepositoryItemComboBox)
                                    'If Me.GridMode <> GridModeEnum.Navigation Then .ColumnEdit = CType(pComboEdit(col.FieldName), RepositoryItemComboBox)
                                ElseIf valueSource = "picklist" Then
                                    .Tag = "picklist"
                                    .OptionsColumn.AllowEdit = False
                                ElseIf valueSource = "gridlookup" Then
                                    Dim GridLookUpInfo As GridPickListInfo = DirectCast(CType(OwnerForm, EditorBase).GetControl(col.CustProperty.ToLower.Split(":")(1)), GridPickListInfo)
                                    Dim repEdit As New RepositoryItemGridLookUpEdit
                                    With repEdit
                                        '.ValueMember = col.FieldName
                                        '.DisplayMember = col.FieldName
                                        .NullText = ""
                                        .PopupFilterMode = PopupFilterMode.Contains
                                        .TextEditStyle = Controls.TextEditStyles.Standard
                                        .AutoComplete = True
                                        .ImmediatePopup = True
                                        .PopupSizeable = True
                                        .View.OptionsView.ShowAutoFilterRow = True

                                        ''''''GO HERE

                                        PrepareGridLookUpEdit(repEdit, GridLookUpInfo, OwnerForm)

                                    End With
                                    .ColumnEdit = repEdit
                                End If

                                .OptionsFilter.AutoFilterCondition = IIf(col.Format <> "", AutoFilterCondition.Default, AutoFilterCondition.Contains)

                            End With


                        Next

                    End If

                End With
            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Sub CreateLookUpEditColumns(ByVal Grid As RepositoryItemGridLookUpEdit, ByVal ColumnsCollection As Collection, ByVal ownerForm As Form)

        Try
            If ownerForm.InvokeRequired Then
                ownerForm.Invoke(New CreateGridColumnsCrossThreadDelegate(AddressOf CreateGridColumns), Grid, ColumnsCollection)
            Else
                Dim columnView As GridView = DirectCast(Grid.View, GridView)
                With columnView
                    .Columns.Clear()

                    If Not IsNothing(ColumnsCollection) Then
                        For Each col As ColumnInfo In ColumnsCollection
                            'Dim ncol As GridColumn = New GridColumn
                            .Columns.AddField(col.FieldName)

                            With .Columns(col.FieldName)
                                '.FieldName = col.FieldName

                                .OptionsColumn.FixedWidth = False
                                .Caption = ProperCase(col.Caption)
                                .Width = col.Width

                                If Not IsEmptyString(col.Format) Then

                                    Select Case col.Format
                                        Case "p"
                                            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                            .DisplayFormat.FormatString = col.Format

                                        Case "n0"
                                            .DisplayFormat.FormatString = col.Format
                                            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                                        Case "n2"
                                            .DisplayFormat.FormatString = col.Format
                                            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                                        Case "d", "date"
                                            .DisplayFormat.FormatString = col.Format
                                            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                                        Case Else
                                            .DisplayFormat.FormatString = col.Format
                                            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                    End Select

                                    '.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                End If
                                .Fixed = col.Fixed
                                .Visible = IIf(col.Width > 0, True, False)
                                .OptionsFilter.AutoFilterCondition = IIf(col.Format <> "", AutoFilterCondition.Default, AutoFilterCondition.Contains)

                            End With


                        Next

                    End If

                End With
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function BuildGridLookUpData(ByVal LookUpInfo As GridPickListInfo) As DataTable
        Try
            Dim dsResult As DataSet
            Dim displaySelectString As String = ""
            Dim DisplayFromString As String = ""
            Dim DisplayWhereString As String = ""
            Dim DisplayOrderByString As String = ""
            Dim DetailDataConnection As DbConnection

            'BUILD QUERY INFO
            Dim DetailColumns As Collection
            DetailColumns = GetColumnInfo(LookUpInfo._PickColumnsInfo)

            If Not DetailColumns Is Nothing Then

                Dim FieldNames = From Column As ColumnInfo In DetailColumns
                                 Select Column.FieldName

                For Each FieldName As Object In FieldNames
                    Dim Field As String = DirectCast(FieldName, String)
                    displaySelectString &= Field + ","
                Next

                displaySelectString = "SELECT " + displaySelectString.TrimEnd(",")
                '''''NEXT HERE
                Dim tmp() As String = LookUpInfo._PickTableFromInfo.Split("|")

                For i As Integer = 0 To UBound(tmp)
                    If tmp(i) <> "" Then
                        With tmp(i).ToUpper
                            Select Case True
                                Case .Contains("FROM")
                                    DisplayFromString = tmp(i).Trim
                                Case .Contains("WHERE")
                                    DisplayWhereString = tmp(i).Trim
                                Case .Contains("ORDER BY")
                                    DisplayOrderByString = tmp(i).Trim
                            End Select
                        End With
                    End If
                Next

                displaySelectString &= " " & DisplayFromString
                If DisplayWhereString <> "" Then displaySelectString &= " " & DisplayWhereString
                If DisplayOrderByString <> "" Then displaySelectString &= " " & DisplayOrderByString

            End If
            'END OF BUILD QUERY INFO


            'BUILD LOOKUP DATA
            dsResult = New DataSet

            If DetailDataConnection Is Nothing Then
                DetailDataConnection = New MySqlConnection() ''DBFactory.GetConnection(AppData.DBProvider)
                DetailDataConnection.ConnectionString = AppData.ConnectionString
            End If

            Dim tmpDataAdapter = New MySqlDataAdapter() ''DBFactory.GetDataAdapter(AppData.DBProvider)
            With tmpDataAdapter
                .SelectCommand = New MySqlCommand() ''DBFactory.GetCommand(AppData.DBProvider)
                .SelectCommand.CommandType = CommandType.Text
                .SelectCommand.CommandText = displaySelectString
                .SelectCommand.Connection = DetailDataConnection
            End With

            If DetailDataConnection.State <> System.Data.ConnectionState.Open Then _
                DetailDataConnection.Open()
            tmpDataAdapter.Fill(dsResult, "TableData")

            Return dsResult.Tables("TableData")
            'END OF BUILD LOOKUP DATA


        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub PrepareGridLookUpEdit(ByVal LookUpEditor As RepositoryItemGridLookUpEdit, ByVal GridLookUpInfo As GridPickListInfo, ByVal ownerForm As Form)
        Try
            CreateLookUpEditColumns(LookUpEditor, GetColumnInfo(GridLookUpInfo._PickColumnsInfo), ownerForm)
            LookUpEditor.DataSource = BuildGridLookUpData(GridLookUpInfo)

            LookUpEditor.ValueMember = GridLookUpInfo.ValueMember.ToLower
            LookUpEditor.DisplayMember = GridLookUpInfo.ValueMember.ToLower
            LookUpEditor.Tag = GridLookUpInfo.Name
            LookUpEditor.PopupFormSize = New Size(650, LookUpEditor.PopupFormMinSize.Height)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub WriteValueToRegistry(ByVal Section As String, ByVal Key As String, ByVal data As Object, ByVal ValueType As Microsoft.Win32.RegistryValueKind)
        Try
            Dim regHive As String = "HKEY_CURRENT_USER\SOFTWARE\KENTNOBLE"
            My.Computer.Registry.SetValue(String.Format("{0}\{1}\{2}", regHive, Project.Instance.ExeName, Section), Key, data, ValueType)
        Catch ex As Exception

        End Try

    End Sub

    Public Function GetValueFromRegistry(ByVal Section As String, ByVal Key As String) As Object
        Try

            Dim regHive As String = "HKEY_CURRENT_USER\SOFTWARE\KENTNOBLE"
            'MsgBox(Project.Instance.ExeName)
            Return My.Computer.Registry.GetValue(String.Format("{0}\{1}\{2}", regHive, Project.Instance.ExeName, Section), Key, Nothing)
        Catch ex As Exception

        End Try
    End Function

    Public Sub ShowControl(ByVal ctrl As Control)
        Try
            If ctrl.FindForm.InvokeRequired Then
                ctrl.FindForm.Invoke(New CrossThreadMethodInvokerDelegate(AddressOf HideControl), ctrl)
            Else
                ctrl.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub HideControl(ByVal ctrl As Control)
        Try
            If ctrl.FindForm.InvokeRequired Then
                ctrl.FindForm.Invoke(New CrossThreadMethodInvokerDelegate(AddressOf HideControl), ctrl)
            Else
                ctrl.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UpdateInventory(ByVal FK_Invty As String)
        If FK_Invty = "" Then Exit Sub 'dont continue if no sysFK_Invy

        Try
            Dim SQL As String = ""
            SQL = "UPDATE inventories SET Quantity_Invty=" &
                    "(SELECT IFNULL(SUM(QtyIn_LdgrInvty),0) - IFNULL(SUM(QtyOut_LdgrInvty),0) FROM Transaction_Ledger_Inventories WHERE Module_LdgrInvty IN('IN','OUT') AND FK_Invty_LdgrInvty=" & AddQuote9(FK_Invty) & ")"
            SQL &= " WHERE PK_Invty=" & AddQuote9(FK_Invty)

            AppData.ExecuteNonQuery(SQL)

            'End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub UpdatePOItemStatus(ByVal popk_ldgrinvty As String, ByVal po_qty As Double)
        Try
            Dim sqlRRItem As String = String.Format("Select SUM(QtyIn_LdgrInvty) as DisplayQtyIn_LdgrInvty " +
                                                    "FROM transaction_ledger_inventories WHERE FK_LdgrinvtySL_LdgrInvty = '{0}' AND Module_Ldgrinvty = 'IN'", popk_ldgrinvty)
            Dim dtRRItem As DataTable = AppData.GetDataTable(sqlRRItem)

            Dim rr_qty As Double = StrVal9(dtRRItem.Rows(0)("DisplayQtyIn_LdgrInvty"))
            Dim status = "OPEN"

            If rr_qty > 0 Then
                If po_qty > rr_qty Then
                    status = "PARTIALLY RECEIVED"
                ElseIf rr_qty = po_qty Then
                    status = "RECEIVED"
                Else
                    status = "SURPLUS"
                End If
            End If

            Dim sqlUpdate As String = String.Format("Update transaction_ledger_inventories SET Status_LdgrInvty = '{0}', QtyReceived_LdgrInvty = '{1}' Where PK_LdgrInvty = '{2}'", status, rr_qty, popk_ldgrinvty)
            AppData.ExecuteNonQuery(sqlUpdate)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdatePOStatus(ByVal po_pk As String)
        Try
            If po_pk <> "" Then

                Dim sqlPOItems As String = String.Format("Select PK_LdgrInvty, IFNULL(QtyIn_LdgrInvty,0) as DisplayQtyIn_LdgrInvty,FK_TransH_LdgrInvty,FK_Invty_LdgrInvty " +
                               "FROM transaction_ledger_inventories WHERE FK_TransH_LdgrInvty = '{0}'", po_pk)
                Dim dtPOItems As DataTable = AppData.GetDataTable(sqlPOItems)

                For i As Integer = 0 To dtPOItems.Rows.Count - 1
                    UpdatePOItemStatus(dtPOItems.Rows(i)("PK_LdgrInvty"), StrVal9(dtPOItems.Rows(i)("DisplayQtyIn_LdgrInvty")))
                    UpdateInventory(dtPOItems.Rows(i)("FK_Invty_LdgrInvty"))
                Next

                Dim sqlUpdatedPOItems As String = String.Format("Select Status_LdgrInvty " +
                               "FROM transaction_ledger_inventories WHERE FK_TransH_LdgrInvty = '{0}'", po_pk)
                Dim dtUpdatedPOItems As DataTable = AppData.GetDataTable(sqlUpdatedPOItems)

                Dim partialCount As Integer = 0
                Dim openCount As Integer = 0
                Dim receivedCount As Integer = 0

                For x As Integer = 0 To dtUpdatedPOItems.Rows.Count - 1
                    Dim ledgerStatus = dtUpdatedPOItems.Rows(x)("Status_LdgrInvty")
                    If ledgerStatus = "OPEN" Then
                        openCount += 1
                    ElseIf ledgerStatus = "PARTIALLY RECEIVED" Then
                        partialCount += 1
                    Else
                        receivedCount += 1
                    End If
                Next

                Dim status As String = "OPEN"

                If partialCount = 0 And receivedCount = 0 Then
                    status = "OPEN"
                ElseIf partialCount > 0 Then
                    status = "PARTIALLY RECEIVED"
                ElseIf openCount = 0 And partialCount = 0 Then
                    status = "FULLY RECEIVED"
                End If

                Dim sqlUpdate As String = String.Format("Update transaction_headers SET Status_TransH = '{0}' WHERE PK_TransH = '{1}'", status, po_pk)
                AppData.ExecuteNonQuery(sqlUpdate)

            End If


            'Dim dtPOitems, dtRRitems As DataTable
            'Dim dtSQL, dtsql1, status As String

            'Dim balance, served, ordered As Double

            'If po_pk <> "" Then

            '    dtSQL = "SELECT SUM(DisplayQtyIn_LdgrInvty) as DisplayQtyIn_LdgrInvty " &
            '                "FROM Transaction_ledger_InvtyLog " &
            '                "WHERE SysFK_TransH_LdgrInvty=" & AddQuote9(po_pk)

            '    dtsql1 = "SELECT SUM(BaseUnitQtyIn_LdgrInvty) as BaseUnitQtyIn_LdgrInvty " &
            '               "FROM Transaction_ledger_Invty " &
            '               "WHERE SysFK_TransHLog_LdgrInvty=" & AddQuote9(po_pk)
            '    Try
            '        dtPOitems = AppData.GetDataTable(dtSQL)
            '        dtRRitems = AppData.GetDataTable(dtsql1)

            '        If Not IsNothing(dtPOitems) AndAlso dtPOitems.Rows.Count > 0 Then
            '            ordered = StrVal9(dtPOitems.Rows(0)("DisplayQtyIn_LdgrInvty"))
            '        End If

            '        If Not IsNothing(dtRRitems) AndAlso dtRRitems.Rows.Count > 0 Then
            '            served = StrVal9(dtRRitems.Rows(0)("BaseUnitQtyIn_LdgrInvty"))
            '        End If

            '        balance = ordered - served

            '        Select Case True
            '            Case balance = 0 And ordered = served
            '                status = "Closed"
            '            Case balance = ordered And served = 0
            '                status = "Open"
            '            Case ordered <> served And balance > 0
            '                status = "Partial"

            '            Case balance < 0
            '                status = "Surplus"
            '        End Select


            '        Dim updatePO As String
            '        Try
            '            updatePO = "UPDATE Transaction_HeaderLog " &
            '                        "SET Status_TransH = " & AddQuote9(status) & " " &
            '                       "WHERE SysPK_Transh=" & AddQuote9(po_pk)

            '            AppData.ExecuteNonQuery(updatePO)
            '        Catch ex As Exception

            '        End Try

            '        Dim updatePoItems As String = "SELECT SysPK_LdgrInvty,SysFK_Invty_ldgrInvty " &
            '                                         "FROM Transaction_ledger_InvtyLog " &
            '                                             "WHERE SysFK_TransH_LdgrInvty=" & AddQuote9(po_pk)

            '        dtPOitems = New DataTable

            '        dtPOitems = AppData.GetDataTable(updatePoItems)

            '        Try
            '            If Not IsNothing(dtPOitems) AndAlso dtPOitems.Rows.Count > 0 Then

            '                For i As Integer = 0 To dtPOitems.Rows.Count - 1
            '                    UpdatePOItemStatus(dtPOitems.Rows(i)("SysPK_LdgrInvty"), dtPOitems.Rows(i)("SysFK_Invty_ldgrInvty"))
            '                Next
            '            End If

            '        Catch ex As Exception

            '        End Try


            '    Catch ex As Exception

            '    End Try
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module

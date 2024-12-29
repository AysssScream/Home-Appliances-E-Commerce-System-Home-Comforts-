Imports DevExpress.XtraEditors
Imports DevExpress.XtraTab
Imports FontAwesome.Sharp
Imports MySql.Data.MySqlClient
Public Class MainForm2

    Private _LoginVerified As Boolean
    Private currentButton As IconButton
    Private leftBorderButton As Panel
    Private currentChildForm As Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size

        Clock.Visible = False
        UserPicture.Visible = False
        lblUser.Visible = False

        HeaderPanel.Visible = True
        HeaderPanel.BackColor = Color.FromArgb(236, 236, 236)

        SideMenuPanel.Visible = False
        SideMenuPanel.BackColor = Colors.black

        ButtonClose.IconColor = Colors.black
        ButtonMinimized.IconColor = Colors.black
        ButtonMaximized.IconColor = Colors.black

        leftBorderButton = New Panel()
        leftBorderButton.Size = New Size(4, 40)
        SideMenuPanel.Controls.Add(leftBorderButton)

        Me.DoubleBuffered = True

        If Me.WindowState = FormWindowState.Normal Then
            ButtonMaximized.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        Else
            ButtonMaximized.IconChar = FontAwesome.Sharp.IconChar.WindowRestore
        End If

    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Application.Exit()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Timer1.Enabled = True
        Dim vUser As User = New User("", Nothing)
        Project.Instance.ActiveUser = vUser

        LoginVerified = False

        Dim LoginFrm As New Login
        LoginFrm.Show(Me)

    End Sub

    Public Property LoginVerified() As Boolean
        Set(ByVal value As Boolean)
            _LoginVerified = value
            Me.SuspendLayout()
            If value Then
                LoadSettings()
                HideMenus(False)
                LoadUserMenu()
                Clock.Visible = True
                UserPicture.Visible = True
                lblUser.Visible = True
                lblUser.Text = Project.Instance.ActiveUser.Name

                Dim sqlAddAuditTrail As String = String.Format("Insert Into audit_trails (PK_AT,UserType_AT,Name_AT,Action_AT,Remarks_AT) VALUES('{0}','{1}','{2}','{3}','{4}')", GetSysPK(), Project.Instance.ActiveAccountType, Project.Instance.ActiveUser.Name, "LOGIN", "")
                AppData.ExecuteNonQuery(sqlAddAuditTrail)

            Else
                HideMenus(True)

                Clock.Visible = False
                UserPicture.Visible = False
                lblUser.Visible = False
                lblUser.Text = ""

                Dim vUser As User = New User("", Nothing)
                Project.Instance.ActiveUser = vUser

            End If
            Me.ResumeLayout()
        End Set
        Get
            Return _LoginVerified
        End Get
    End Property

    Public Sub AddMenu(ByVal menuName As String, ByRef Icon As FontAwesome.Sharp.IconChar, Optional ByVal MnuItems() As String = Nothing)
        Try
            Dim Menu = New FontAwesome.Sharp.IconButton()
            Menu.Dock = System.Windows.Forms.DockStyle.Top
            Menu.FlatAppearance.BorderSize = 0
            Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Menu.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
            Menu.Font = New System.Drawing.Font("Verdana", 9.0!)
            Menu.ForeColor = Colors.whiteSecondary
            Menu.BackColor = Color.Transparent
            Menu.IconChar = Icon
            Menu.IconColor = Colors.whiteSecondary
            Menu.IconFont = FontAwesome.Sharp.IconFont.[Auto]
            Menu.IconSize = 26
            Menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Menu.Location = New System.Drawing.Point(0, 450)
            Menu.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
            Menu.Size = New System.Drawing.Size(192, 40)
            Menu.TabIndex = 8
            Menu.Text = " " + menuName.Split(":")(0)
            Menu.Tag = menuName.Split(":")(1)
            Menu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Menu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Menu.UseVisualStyleBackColor = True
            AddHandler Menu.Click, AddressOf Me.MenuClick
            AddHandler Menu.MouseHover, AddressOf Me.ButtonLogout_MouseHover
            AddHandler Menu.MouseLeave, AddressOf Me.ButtonLogout_MouseLeave
            MenuPanel.Controls.Add(Menu)
            MenuPanel.Controls.SetChildIndex(Menu, 0)
            If Not IsNothing(MnuItems) Then
                'AddHandler Menu.Click, AddressOf Me.MenuClick
                Dim SubMenu = New System.Windows.Forms.Panel
                SubMenu.Name = menuName.Split(":")(1)
                SubMenu.Visible = False
                SubMenu.Dock = System.Windows.Forms.DockStyle.Top
                SubMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink
                SubMenu.Size = New Size(192, MnuItems.Length * 40 + 2)
                MenuPanel.Controls.Add(SubMenu)
                MenuPanel.Controls.SetChildIndex(SubMenu, 0)
                For Each Item As String In MnuItems
                    Dim Menu2 = New FontAwesome.Sharp.IconButton()
                    Menu2.UseMnemonic = False
                    Menu2.Dock = System.Windows.Forms.DockStyle.Top
                    Menu2.FlatAppearance.BorderSize = 0
                    Menu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                    Menu2.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
                    Menu2.Font = New System.Drawing.Font("Verdana", 9.0!)
                    Menu2.ForeColor = Colors.whiteSecondary
                    Menu2.BackColor = Color.Transparent
                    Menu2.IconColor = Colors.whiteSecondary
                    Menu2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
                    Menu2.IconSize = 26
                    Menu2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
                    Menu2.Location = New System.Drawing.Point(0, 450)
                    Menu2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
                    Menu2.Size = New System.Drawing.Size(192, 40)
                    Menu2.TabIndex = 8
                    Menu2.Text = " " + Item.Split(":")(0)
                    Menu2.Tag = Item.Split(":")(1)
                    Menu2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                    Menu2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
                    Menu2.UseVisualStyleBackColor = True
                    AddHandler Menu2.Click, AddressOf Me.MenuClick
                    AddHandler Menu2.MouseHover, AddressOf Me.ButtonLogout_MouseHover
                    AddHandler Menu2.MouseLeave, AddressOf Me.ButtonLogout_MouseLeave
                    SubMenu.Controls.Add(Menu2)
                    SubMenu.Controls.SetChildIndex(Menu2, 0)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadSettings()
        Try
            Dim settings As String = String.Format("Select * from settings")
            Dim dtSettings As DataTable = AppData.GetDataTable(settings)

            With Project.Instance
                ''.CompanyName = IIf(IsDBNull(dtSettings.Rows(0)("StoreName_Set")), "", dtSettings.Rows(0)("StoreName_Set"))
                ''.CompanyAddress = IIf(IsDBNull(dtSettings.Rows(0)("Address_Set")), "", dtSettings.Rows(0)("Address_Set"))
                '.TIN = IIf(IsDBNull(dtSettings.Rows(0)("TIN_Set")), "", dtSettings.Rows(0)("TIN_Set"))
                '.Logo = IIf(IsDBNull(dtSettings.Rows(0)("Logo_Set")), "", dtSettings.Rows(0)("Logo_Set"))
                '.ContactNumber = IIf(IsDBNull(dtSettings.Rows(0)("ContactNo_Set")), "", dtSettings.Rows(0)("ContactNo_Set"))

                AppMainForm.Text = .CompanyName
                CompanyName.Text = .CompanyName
                'Logo.EditValue = .Logo
            End With
        Catch ex As Exception
            AppMainForm.Text = Project.Instance.CompanyName
            CompanyName.Text = Project.Instance.CompanyName
        End Try
    End Sub

    Private Sub HideMenus(Optional ByVal hideMenus As Boolean = True)
        If hideMenus Then
            SideMenuPanel.Visible = False
        Else
            SideMenuPanel.Visible = True
        End If
    End Sub

    Private Sub LoadUserMenu()
        If Project.Instance.ActiveAccountType = "Cashier" Then
            Me.SideMenuPanel.Visible = False
            OpenChildForm("Cashier", " Cashier", FontAwesome.Sharp.IconChar.Calculator)
        ElseIf Project.Instance.ActiveAccountType = "Customer" Then
            Me.SideMenuPanel.Visible = False
            OpenChildForm("ECommerce", " ECommerce", FontAwesome.Sharp.IconChar.Calculator)
        Else
            Me.SideMenuPanel.Visible = True
            OpenChildForm("Dashboard", " Dashboard", FontAwesome.Sharp.IconChar.Home)
        End If
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Dim dialogAns As Byte
        dialogAns = MessageBox.Show("Are you sure you want to leave?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialogAns = vbYes Then
            Application.Exit()
        End If

    End Sub

    Private Sub ButtonMaximized_Click(sender As Object, e As EventArgs) Handles ButtonMaximized.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            ButtonMaximized.IconChar = FontAwesome.Sharp.IconChar.WindowRestore
        Else
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.WindowState = FormWindowState.Normal
            ButtonMaximized.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        End If
    End Sub

    Private Sub ButtonMinimized_Click(sender As Object, e As EventArgs) Handles ButtonMinimized.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MenuClick(sender As Object, e As EventArgs) Handles ButtonLogout.Click
        Try
            If sender.Tag.ToString.ToLower = "logout" Then
            Else
                ActivateButton(sender, Colors.whiteSecondary)
                OpenChildForm(sender.Tag, sender.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Public Sub ActivateButton(senderButton As Object, customColor As Color)
        If senderButton IsNot Nothing Then
            DisableButton()
            currentButton = CType(senderButton, IconButton)
            currentButton.BackColor = customColor
            currentButton.ForeColor = Colors.black
            currentButton.IconColor = Colors.black

            leftBorderButton.BackColor = Colors.red
            leftBorderButton.Location = New Point(0, IIf(currentButton.UseMnemonic, LogoPanel.Height + currentButton.Location.Y, LogoPanel.Height + currentButton.Location.Y + currentButton.Parent.Location.Y))
            leftBorderButton.Visible = True
            leftBorderButton.BringToFront()
        End If
    End Sub

    Private Sub DisableButton()
        If currentButton IsNot Nothing Then
            currentButton.BackColor = Color.Transparent
            currentButton.ForeColor = Colors.white
            currentButton.IconColor = Colors.white
        End If
    End Sub

    Public Sub OpenChildForm(FormName As String, FormCaption As String, Optional ByRef Icon As FontAwesome.Sharp.IconChar = IconChar.None)
        If FormName.Contains("Sub") Then
            Dim controlPanel As System.Windows.Forms.Panel = CType(Me.Controls("SideMenuPanel").Controls("MenuPanel").Controls(FormName), System.Windows.Forms.Panel)

            controlPanel.Visible = Not controlPanel.Visible
        Else
            Dim childForm As BaseForm
            If FormCaption.Contains("Lists") Then
                childForm = New Lists
            Else
                childForm = New EditorBase
            End If
            Dim FormName1 As String
            Dim FullTypeName As String
            Dim FormInstanceType As Type

            Dim st As New StackTrace()
            FormName1 = st.GetFrame(1).GetMethod().DeclaringType.FullName
            FormName1 = String.Format("{0}.{1}", FormName1.Split(".")(0), FormName)

            FullTypeName = FormName1
            FormInstanceType = Type.GetType(FullTypeName, True, True)
            childForm = Activator.CreateInstance(FormInstanceType)
            childForm.Text = FormCaption

            childForm.TopLevel = False


            'If currentChildForm IsNot Nothing Then
            '    currentChildForm.Close()
            'End If

            currentChildForm = childForm


            Dim tabpage As XtraTabPage = New XtraTabPage()

            For i As Integer = 0 To XtraTabControl1.TabPages.Count - 1
                XtraTabControl1.TabPages.RemoveAt(i)
                XtraTabControl1.TabPages.Add(tabpage)
                XtraTabControl1.SelectedTabPageIndex = XtraTabControl1.TabPages.Count - 1
            Next
            Dim con = AppMainForm.TopLevelControl
            childForm.FormBorderStyle = FormBorderStyle.None
            childForm.Dock = DockStyle.Fill

            ''TAB
            TabPage.Controls.Add(childForm)
            tabpage.Tag = childForm
            tabpage.Text = childForm.Text

            XtraTabControl1.TabPages.Add(tabpage)
            XtraTabControl1.SelectedTabPageIndex = XtraTabControl1.TabPages.Count - 1

            ''TAB

            'childForm.BringToFront()
            childForm.Show()
        End If
    End Sub

    Private Sub ButtonLogout_MouseHover(sender As Object, e As EventArgs) Handles ButtonLogout.MouseHover
        If currentButton IsNot CType(sender, IconButton) Then
            CType(sender, IconButton).BackColor = Colors.whiteSecondary
            CType(sender, IconButton).ForeColor = Colors.black
            CType(sender, IconButton).IconColor = Colors.black
        End If
    End Sub

    Private Sub ButtonLogout_MouseLeave(sender As Object, e As EventArgs) Handles ButtonLogout.MouseLeave
        If currentButton IsNot CType(sender, IconButton) Then
            CType(sender, IconButton).BackColor = Color.Transparent
            CType(sender, IconButton).ForeColor = Colors.white
            CType(sender, IconButton).IconColor = Colors.white
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Clock.Text = Date.Now.ToString("MMM dd, yyyy h:mm:ss tt")
    End Sub

    Private Sub UserPicture_Click(sender As Object, e As EventArgs) Handles UserPicture.Click
        Dim oform As New UserPopup
        oform.ShowDialog(Me)
    End Sub

    Private Sub XtraTabControl1_Click(sender As Object, e As EventArgs) Handles XtraTabControl1.Click

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub
End Class
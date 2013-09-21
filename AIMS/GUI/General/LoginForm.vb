Imports WeifenLuo.WinFormsUI
Imports System.Data.SqlClient
Imports OpenErp.Net
Imports CookComputing.XmlRpc

Imports System.Data.OleDb
Imports Numeria
Imports Numeria.IO
Imports System.IO
Imports System.Linq


Public Class LoginForm
    Inherits DockContent



#Region "Event Handlers"

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each appSetting As String In System.Configuration.ConfigurationSettings.AppSettings.AllKeys
            MsgBox(appSetting)
            Console.WriteLine(appSetting)
        Next

        'Display the applicaiton title
        If My.Application.Info.Title <> String.Empty Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Display the application description
        ApplicationDescriptionLabel.Text = My.Application.Info.Description

        'Display the application version
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Display the copyright info for the application
        Copyright.Text = My.Application.Info.Copyright

        'Clear the login information variables before each login
        currentUserId = String.Empty
        BaseForm.LoginToolStripStatusLabel.Text = "Not Logon"

        'Hide the menu when user is not logged in
        BaseForm.MainMenuStrip.Visible = False

        'Close all the children forms when user is not logged in
        For Each form As Form In MdiChildren
            form.Close()
        Next


    End Sub

    Private Sub LoginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        If My.Settings.access_db = 1 Then
            LoginClick_AccessDB()
        Else
            LoginClick_OpenErp()
        End If

    End Sub



    Private Function Login() As Boolean
        Dim val As Boolean
        Try
            'Dim OELogin As New OpenErp.Net.LoginInfo(My.Settings.HostUrl _
            '                                          , My.Settings.Database _
            '                                          , UserIDTextBox.Text.Trim _
            '                                          , PasswordTextBox.Text.Trim)

            Dim OELogin As New OpenErp.Net.LoginInfo(My.Settings.HostUrl _
                                          , My.Settings.Database _
                                          , My.Settings.uid _
                                          , My.Settings.pwd)
            OELogin.login()

            If OELogin.LoginUserId > 0 Then
                currentUserId = UserIDTextBox.Text.Trim
                BaseForm.LoginToolStripStatusLabel.Text = "User ID: " & currentUserId
                val = True
                Me.Close()

            Else
                MsgBox("Error while verifying user login. Please contact your System Administrator.", MsgBoxStyle.Critical, "Error encountered")
                val = False
            End If


        Catch ex As Exception
            WriteErrorLog(ex.Source, ex.Message, ex.ToString)
        End Try
    End Function

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Application.Exit()
    End Sub

#End Region

#Region "Private Methods"

    Private Function IsUserInputValid() As Boolean
        IsUserInputValid = True

        If Trim(UserIDTextBox.Text) = String.Empty Then
            MsgBox("User ID cannot be empty", MsgBoxStyle.Exclamation, "Invalid Value")
            UserIDTextBox.SelectAll()
            UserIDTextBox.Focus()
            IsUserInputValid = False
            Exit Function
        End If

        If Trim(PasswordTextBox.Text) = String.Empty Then
            MsgBox("Password cannot be empty", MsgBoxStyle.Exclamation, "Invalid Value")
            PasswordTextBox.SelectAll()
            PasswordTextBox.Focus()
            IsUserInputValid = False
            Exit Function
        End If
    End Function

    Private Function VerifyUserLogin() As Boolean
        'Try
        '    Dim tcWebRef As New AIMS.TCWebRef.Service
        '    If tcWebRef.Testing(UserIDTextBox.Text.Trim, PasswordTextBox.Text.Trim) = 1 Then
        '        If tcWebRef.checkRole(UserIDTextBox.Text.Trim) = 1 Then
        '            Return True
        '        Else
        '            MsgBox("User does not have access to ASRS.", MsgBoxStyle.Critical, "Error encountered")
        '            Return False
        '        End If
        '    Else
        '        MsgBox("Invalid password.", MsgBoxStyle.Critical, "Error encountered")
        '        Return False
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error while verifying user login. Please contact your System Administrator.", MsgBoxStyle.Critical, "Error encountered")
        '    Return False
        'End Try

    End Function

    Private Sub ControlModuleAccess()
        'Dim dataAdaptor As New DMAccessTableAdapter
        'Dim dataTable As New DMAccessDataTable
        'Try
        '    dataTable = dataAdaptor.GetAccessibleModules(UserIDTextBox.Text.Trim)

        '    Dim userGroupId As String
        '    If dataTable.Rows.Count > 0 Then
        '        userGroupId = dataTable.Rows(0)(dataTable.user_group_idColumn)
        '        Dim parentNodeIndex As Integer
        '        Dim childNodeIndex As Integer

        BaseForm.MenuStrip.Visible = True
        '        For Each level1ToolStripItem As ToolStripMenuItem In BaseForm.MenuStrip.Items
        '            ' Skip those menu
        '            If level1ToolStripItem.Text = "System" Or level1ToolStripItem.Text = "Quick Menu" Then
        '                Continue For
        '            Else
        '                level1ToolStripItem.Visible = IIf(dataTable.FindBymodule_iduser_group_id(level1ToolStripItem.Text, userGroupId) Is Nothing, False, True)
        '            End If
        '            For Each level2ToolStripItem As ToolStripMenuItem In DirectCast(level1ToolStripItem, ToolStripMenuItem).DropDownItems
        '                If Not level2ToolStripItem.HasDropDownItems Then
        '                    level2ToolStripItem.Visible = IIf(dataTable.FindBymodule_iduser_group_id(level2ToolStripItem.Text, userGroupId) Is Nothing, False, True)
        '                    Continue For
        '                End If

        '                For Each level3ToolStripItem As ToolStripMenuItem In DirectCast(level2ToolStripItem, ToolStripMenuItem).DropDownItems
        '                    If level3ToolStripItem.Text <> "" Then
        '                        dataTable.Rows.Find(level3ToolStripItem.Text)
        '                        level3ToolStripItem.Enabled = IIf(dataTable.Rows.Count = 0, False, True)
        '                    End If
        '                Next
        '                childNodeIndex += 1
        '            Next
        '            childNodeIndex = 0
        '            parentNodeIndex += 1
        '        Next
        '    Else
        '        BaseForm.MenuStrip.Visible = False
        '        MsgBox("There is no access rights applied to this user. Please check with your System Administrator.", MsgBoxStyle.Exclamation)
        '    End If

        'Catch sqlEx As SqlException
        '    HandleSqlException(sqlEx)
        'Catch ex As Exception
        '    Call WriteErrorLog(ex.Source, ex.Message, ex.ToString)
        '    MsgBox("Error while checking module access. Please contact your System Administrator.", MsgBoxStyle.Critical, "Error encountered")
        'End Try
    End Sub


    Private Sub LoginClick_OpenErp()
        If OELogin(UserIDTextBox.Text.Trim, PasswordTextBox.Text.Trim) Then

            Dim prds As New List(Of ProductProduct)
            Dim oep As New OpenErp.Net.Openerp

            Dim conditions As New ArrayList

            conditions.Add(New String() {"active", "=", "True"})
            conditions.Add(New String() {"to_weight", "=", "True"})
            conditions.Add(New String() {"available_in_mrppos", "=", "True"})

            Dim products As Object() = oep.LoadPosProducts(conditions)
            If products.Length > 0 Then
                For Each product As Object In products
                    Dim prods As XmlRpcStruct = TryCast(product, XmlRpcStruct)
                    Dim prd As New ProductProduct
                    For Each p As DictionaryEntry In prods

                        If isDictKey(p, "active") Then
                            prd.active = p.Value
                        End If
                        If isDictKey(p, "id") Then
                            prd.id = p.Value
                        End If
                        If isDictKey(p, "default_code") Then
                            prd.default_code = p.Value
                        End If
                        If isDictKey(p, "to_weight") Then
                            prd.to_weight = p.Value
                        End If
                        If isDictKey(p, "available_in_pos") Then
                            prd.available_in_pos = p.Value
                        End If

                        If isDictKey(p, "image") Then
                            prd.image = IIf(p.Value = "False", "", p.Value)
                        End If
                        If isDictKey(p, "name") Then
                            prd.name = p.Value
                        End If
                        If isDictKey(p, "ean13") Then
                            prd.ean13 = p.Value
                        End If

                    Next
                    prds.Add(prd)

                Next

                shareProducts = prds
            End If

            Dim img As System.Drawing.Image
            Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream
            Dim imgLst As New ImageList

            For Each prd As ProductProduct In shareProducts
                If prd.image.Length > 0 Then
                    Dim b64 As String = prd.image.Replace(" ", "+")
                    Dim b() As Byte
                    b = Convert.FromBase64String(b64)
                    MS = New System.IO.MemoryStream(b)

                    img = System.Drawing.Image.FromStream(MS)
                    imgLst.Images.Add(prd.id, img)
                Else
                    imgLst.Images.Add(prd.id, My.Resources.placeholder)
                End If
            Next
            imgLst.ImageSize = New Size(117, 109)
            shareImageList = imgLst

            currentUserId = UserIDTextBox.Text.Trim
            BaseForm.LoginToolStripStatusLabel.Text = "User ID: " & currentUserId
            Call ControlModuleAccess()
            Me.Close()
        End If

    End Sub

    Private Sub LoginClick_AccessDB()

        Using db As New MrpPosEntities
            Dim query As IEnumerable(Of user_user) = From f In db.user_user Where f.user_name = "admin" And f.password = "ta300886" Select f

            If query.ToList.Count > 0 Then
                currentUserId = UserIDTextBox.Text.Trim
                BaseForm.LoginToolStripStatusLabel.Text = "User ID: " & currentUserId
                loginUser = query.ToList()(0)
                Call ControlModuleAccess()
                Me.Close()
            End If
        End Using


        ''LUNA.LunaContext.OpenDbConnection(My.Settings.POSConnString)
        'Dim Cn As New OleDbConnection(My.Settings.POSConnString)
        'Cn.Open()
        'LUNA.LunaContext.Connection = Cn

        'Dim par As New LUNA.LunaSearchParameter("user_name", "admin")
        'Dim users As List(Of User_user) = (New User_userDAO).Find(par)

        'loginUser = users(0)

        ''LoadImages()

        'currentUserId = UserIDTextBox.Text.Trim
        'BaseForm.LoginToolStripStatusLabel.Text = "User ID: " & currentUserId
        'Call ControlModuleAccess()
        'Me.Close()
    End Sub

    Private Sub LoadImages()
        'Dim opt As New LUNA.LunaSearchOption
        'opt.OrderBy = "code"

        'Dim dao As New Product_productDAO
        'Dim lstProducts As New List(Of Product_product)
        'lstProducts = dao.GetAll

        'Dim imgLst As New ImageList

        'For Each Product As Product_product In lstProducts

        '    If Product.image.Length > 0 Then
        '        Dim memSteam As New MemoryStream
        '        Dim info = FileDB.Read(getFileDbPath, Guid.Parse(Product.image), memSteam)
        '        imgLst.Images.Add(Product.image, System.Drawing.Image.FromStream(memSteam))
        '    Else
        '        imgLst.Images.Add(My.Resources.placeholder)
        '    End If
        'Next



        'If lstProducts.Count > 0 Then
        '    sharedProducts = lstProducts
        '    imgLst.ImageSize = New Size(117, 109)
        '    shareImageList = imgLst
        'End If

    End Sub
#End Region

End Class
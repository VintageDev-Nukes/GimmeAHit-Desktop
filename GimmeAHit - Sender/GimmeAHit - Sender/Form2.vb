Imports System.Threading
Public Class frmLogin

    Private Sub ExitApp() Handles MyBase.FormClosed
        If System.Diagnostics.Process.GetCurrentProcess().Threads.Count > 0 Then
            For Each t As System.Diagnostics.ProcessThread In System.Diagnostics.Process.GetCurrentProcess().Threads
                t.Dispose()
            Next t
        End If
        Application.Exit()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim thLogin As New Thread(AddressOf Login)
        thLogin.Start()
    End Sub

    Public Sub Login()
        Dim user As String = txtUsername.Text
        Dim pass As String = txtPassword.Text
        Dim code As String = ePHP.customGUID()
        'MsgBox(ePHP.checkUser(user, pass, code))
        If ePHP.checkUser(user, pass, code) Then
            UserInfo.logedIn = True
            UserInfo.username = user
            UserInfo.password = pass
            UserInfo.code = code
            If Me.InvokeRequired Then Me.Invoke(Sub() Me.Hide()) Else Me.Hide()
            Dim frm As New frmMain()
            frm.ShowDialog()
        Else
            MsgBox("Usuario erróneo o no encontrado.")
        End If
    End Sub

End Class
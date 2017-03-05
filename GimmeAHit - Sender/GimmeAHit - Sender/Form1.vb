Public Class frmMain

    Private Sub ExitApp() Handles MyBase.FormClosed
        If System.Diagnostics.Process.GetCurrentProcess().Threads.Count > 0 Then
            For Each t As System.Diagnostics.ProcessThread In System.Diagnostics.Process.GetCurrentProcess().Threads
                t.Dispose()
            Next t
        End If
        Application.Exit()
    End Sub

    Public Shadows Sub Load() Handles MyBase.Load
        If Not UserInfo.logedIn Or String.IsNullOrEmpty(UserInfo.username) Or String.IsNullOrEmpty(UserInfo.password) Or Not ePHP.checkUser(UserInfo.username, UserInfo.password, UserInfo.code) Then
            Me.Close()
        End If
        UsuarioToolStripMenuItem.Text = UserInfo.username
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

End Class

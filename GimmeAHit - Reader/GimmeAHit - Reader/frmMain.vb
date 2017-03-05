Imports System.Threading

Public Class frmMain

    Private Shadows Sub Load() Handles MyBase.Load
        Reader.LoadEverything()
        Console.WriteLine(System.Guid.NewGuid.ToString.ToUpper) 'Intentar encontrar un valor que sea invariable
    End Sub

    Private Shadows Sub Shown() Handles MyBase.Shown

    End Sub

    Private Sub OpcionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpcionesToolStripMenuItem.Click

    End Sub

    Private Sub btnSeeChannels_Click(sender As Object, e As EventArgs) Handles btnSeeChannels.Click
        Reader.SeeChannels()
    End Sub

    Private Sub btnStartStopReading_Click(sender As Object, e As EventArgs) Handles btnStartStopReading.Click
        If Reader.currentState = States.Reading Then
            Dim thStop As New Thread(AddressOf Reader.StopReading)
            btnStartStopReading.Text = "Parando todo..."
            btnStartStopReading.Enabled = False
            thStop.Start()
            btnStartStopReading.Text = "Comenzar a leer"
            btnStartStopReading.Enabled = True
        ElseIf Reader.currentState = States.Stopped Then
            Dim thRead As New Thread(AddressOf Reader.StartReading)
            btnStartStopReading.Text = "Comenzado a leer..."
            btnStartStopReading.Enabled = False
            thRead.Start()
            btnStartStopReading.Text = "Parar todo"
            btnStartStopReading.Enabled = True
        End If
    End Sub

End Class

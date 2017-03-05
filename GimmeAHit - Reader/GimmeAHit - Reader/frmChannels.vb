Imports System.Threading

Public Class frmChannels

    Dim WithEvents panel As Panel
    Dim channelGroup As GroupBox
    Dim WithEvents channelButton As Button
    Dim WithEvents channelCaption As RichTextBox
    Shadows WithEvents scroll As VScrollBar
    Const ScrollChange As Integer = 10

    Private Shadows Sub Shown() Handles MyBase.Shown
        VirtualizeChannels()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub VirtualizeChannels()
        Reader.channelGroups = New List(Of ChannelGroup)
        Dim r As Reader = New Reader()
        scroll = New VScrollBar() With {.Top = 12, .Left = 552, .Width = 23, .Height = 441, .Maximum = If(Reader.channelNumber > 12, 103 * (Math.Ceiling(Reader.channelNumber / 3) - 4), 1), .Visible = Reader.channelNumber > 12}
        Me.Controls.Add(scroll)
        AddHandler scroll.ValueChanged, AddressOf ChangeScroll
        panel = New Panel() With {.Top = 12, .Left = 12, .Width = If(Reader.channelNumber > 12, 537, 560), .Height = 106 * Math.Ceiling(Reader.channelNumber / 3) + 9}
        Me.Controls.Add(panel)
        AddHandler panel.MouseWheel, AddressOf Panel_MouseWheel
        For i As Integer = 0 To Reader.channelNumber - 1
            channelGroup = New GroupBox() With {.Name = "gbChannel" & i, .Text = "Canal " & (i + 1), .Width = 170, .Height = 100, .Top = (12 + 100 * Math.Round((i - 1) / 3) + 6 * Math.Round((i - 1) / 3)), .Left = (If(Reader.channelNumber > 12, 3, 19) + 170 * (i Mod 3) + 6 * (i Mod 3))}
            panel.Controls.Add(channelGroup)
            channelCaption = New RichTextBox() With {.Top = 16, .Left = 6, .Height = 50, .Width = 160, .Text = "Descripción", .BorderStyle = BorderStyle.None, .BackColor = Control.DefaultBackColor} '(255, 240, 240, 240)}
            channelGroup.Controls.Add(channelCaption)
            channelButton = New Button() With {.Name = i, .Top = 69, .Left = 18, .Height = 25, .Width = 134, .Text = If(Reader.channels(i).currentState = States.Reading, "Parar todo", "Comenzar a leer")}
            channelGroup.Controls.Add(channelButton)
            AddHandler channelButton.Click, AddressOf StartStopReading
            Reader.channelGroups.Add(New ChannelGroup() With {.attachedGroup = channelGroup})
        Next
        panel.SendToBack()
    End Sub

    Private Sub ChangeScroll()
        panel.Top = -scroll.Value
    End Sub

    Private Sub Panel_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
        Select Case Math.Sign(e.Delta)
            Case Is > 0 : panel.Top += ScrollChange
            Case Is < 0 : panel.Top -= ScrollChange
        End Select
    End Sub

    Private Sub StartStopReading(sender As Object, e As EventArgs)
        Dim myButton As Button = DirectCast(sender, Button)
        Dim index As Integer = Convert.ToInt32(myButton.Name)
        If Reader.channels(index) IsNot Nothing Then
            If Reader.channels(index).currentState = States.Reading Then
                Reader.selectedChannel = index
                Dim thStop As New Thread(AddressOf Reader.StopReadingChannel)
                myButton.Text = "Parando todo..."
                myButton.Enabled = False
                thStop.Start()
                myButton.Text = "Comenzar a leer"
                myButton.Enabled = True
            ElseIf Reader.channels(index).currentState = States.Stopped Then
                Reader.selectedChannel = index
                Dim thRead As New Thread(AddressOf Reader.StartReadingChannel)
                myButton.Text = "Comenzado a leer..."
                myButton.Enabled = False
                thRead.Start()
                myButton.Text = "Parar todo"
                myButton.Enabled = True
            End If
        End If
    End Sub

End Class
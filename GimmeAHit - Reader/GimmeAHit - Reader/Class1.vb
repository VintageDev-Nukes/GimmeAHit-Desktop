Imports System.Collections.Generic
Imports System.Net

Public Enum States
    Reading
    Stopped
End Enum

Public Enum ListAction
    None
    Added
    Deleted
End Enum

Public Enum LabelTypes
    Request
    Proxy
End Enum

Public Class Reader

    Public Shared requestLines As List(Of Request)

    Public Shared channels As List(Of Channel)

    Public Shared channelGroups As List(Of ChannelGroup)

    Public Shared currentState As States = States.Stopped

    'This isn't necessary because when the event is handled the listbox is updated...
    'Public Shared currentListAction As ListAction = ListAction.None 'This is for when the event is raised, now we have to delete or add a item to the selected list

    Public Shared proxyList As List(Of Proxy)

    Public Shared readingRanges As ReadingRanges 'This have to be setted with the config file

    Public Shared channelNumber As Integer = readingRanges.diff, MaxTime = 20, RequestCheckTime = 10
    '{channelNumber}: Maybe this could be setted using a config file and updated using a message input box (and a list)
    '{MaxTime}: The max time of a request... Maybe it can be setted with the config file

    Public Shared Event RequestListChanged As EventHandler
    Public Shared Event ProxyListChanges As EventHandler

    'The problem with this variable is that It can cause conflicts because this is used for a big amount of functions
    Public Shared selectedChannel As Integer 'This is the selected Channels that is setted with threads

    Public Shared Sub LoadEverything()
        requestLines = New List(Of Request)
        'Download proxy (maybe it's better to use a thread because this function has a lot of overload)
        LoadAllChannels()
    End Sub

    Public Shared Sub LoadAllChannels()
        channels = New List(Of Channel)
        For i As Integer = 0 To channelNumber - 1
            channels.Add(New Channel(i))
        Next
    End Sub

    Public Shared Sub DownloadProxies() 'There we have to download all the proxies from the DB that is in gimmeahit.x10host.com
        proxyList = New List(Of Proxy)
        Dim sc As String = New System.Net.WebClient().DownloadString("http://gimmeahit.x10host.com/actionMaker.php?go=get-proxies") 'The problem is that somebody can get all the actions from the php an get proxy free.. So I have to ask to drvy and ivan cea...
        For Each proxyLine As String In sc.Split(Environment.NewLine.ToCharArray)
            If Not proxyList.Contains(New Proxy(proxyLine)) Then 'Add a new request if it doesn't exist
                proxyList.Add(New Proxy(proxyLine))
                RaiseEvent ProxyListChanges(Nothing, Nothing)
            End If
        Next
    End Sub

    'This is for instantiate new channels without causing a error
    Public Shared Sub UpdateChannel()
        'Use there a reading range for say to the script how many channels we have to create
        'Later we have to make a for with the diff property to add to the channels list the new channels
    End Sub

    Public Shared Sub ReadRequests() 'This function read the request from a channel, now the only thing I have to do is protect the read of strings (I need to protect else the deletion of every request)
        Dim sc As String = New System.Net.WebClient().DownloadString("http://gimmeahit.x10host.com/actionMaker.php?go=read-requests&channel=" & selectedChannel)
        For Each lineRequest As String In sc.Split(Environment.NewLine.ToCharArray)
            If Not requestLines.Contains(New Request(lineRequest, selectedChannel)) Then 'Add a new request if it doesn't exist
                requestLines.Add(New Request(lineRequest, selectedChannel))
                RaiseEvent RequestListChanged(Nothing, Nothing)
            End If
        Next
    End Sub

    Public Shared Sub ProcessingRequest() 'This create a request to the url that a user writes in the web
        'Params: url, visits, proxies to use, selectedChannel
        'First we have to select a proxy from a downloaded list proxy that it's was setted before
        'Then we have to check the selected proxy and if it's works then we can make the next step
        '"http://gimmeahit.x10host.com/actionMaker.php?go=delete-requests&channel=" & selectedChannel 'Delete the request from the DB (and from the List)
        Dim proxyToUse As Integer = 10
        For i As Integer = 0 To proxyToUse - 1
            Dim Proxy As Proxy = proxyList(New Random().Next(proxyList.Count)) 'This is the proxy we selected, for this we have to select a quantity of proxies (everyone is random, there can't be repeated proxies) from the list 
            Dim URL As String = "http://gooogle.es/"
            'The proxy is working, so now we can visit the selected URL
            'We don't have to check the proxy because we have the while...
            Dim visitCounter As Integer = 0
            Dim VisitNumber As Integer = 10 'This is the number of visits that the user requested
            If channels(selectedChannel).currentState = States.Stopped Then
                Exit Sub
            End If
            While visitCounter < VisitNumber
                Try
                    Dim r As WebRequest = HttpWebRequest.Create(URL) 'We make a request, that counts as a hit, but I have to check it...
                    r.Timeout = MaxTime * 1000
                    r.Proxy = New WebProxy(Proxy.ip, Proxy.port)
                    Dim re As HttpWebResponse = CType(r.GetResponse(), HttpWebResponse)
                    If re.StatusCode = HttpStatusCode.OK Then
                        'If it worked...
                        visitCounter += 1 'Add one to the counter...
                    Else 'Maybe we have to add more status code, but...
                        'If the proxy doesn't work we have to remove it from the list (maybe, also from the DB)
                        proxyList.Remove(Proxy)
                        RaiseEvent ProxyListChanges(Nothing, Nothing)
                    End If
                    re.Close()
                Catch ex As Exception
                    Console.WriteLine(Proxy.ToString() & " is not working! Exception: " & ex.Message)
                    proxyList.Remove(Proxy) 'The same thing as before...
                    RaiseEvent ProxyListChanges(Nothing, Nothing)
                End Try
            End While
        Next
    End Sub

    Public Shared Sub StartReadingChannel()
        'Selectedchannel
        channels(selectedChannel).currentState = States.Reading
    End Sub

    Public Shared Sub StartReading()
        currentState = States.Reading
    End Sub

    Public Shared Sub StopReadingChannel()
        'Selectedchannel
        channels(selectedChannel).currentState = States.Stopped
    End Sub

    Public Shared Sub StopReading()
        currentState = States.Stopped
    End Sub

    Public Shared Sub SeeChannels()
        Dim frm As New frmChannels()
        frm.ShowDialog()
    End Sub

    Public Sub EditedProxyList() Handles Me.ProxyListChanges
        For Each proxy As Proxy In proxyList
            frmMain.lbProxy.Items.Add(proxy.ToString())
        Next
        Reader.ChangeText("(" & frmMain.lbProxy.Items.Count & ")")
    End Sub

    Public Sub EditedRequestList() Handles Me.RequestListChanged
        For Each request As Request In requestLines
            frmMain.lbRequests.Items.Add(request.stringRequest)
        Next
        Reader.ChangeText("(" & frmMain.lbRequests.Items.Count & ")")
    End Sub

    Public Shared Sub ChangeText(Optional ByVal str As String = "", Optional ByVal lblTypes As LabelTypes = LabelTypes.Request)
        Select Case lblTypes
            Case LabelTypes.Request
                frmMain.lbRequests.Text = "Peticiones a procesar " & str
            Case LabelTypes.Proxy
                frmMain.lbProxy.Text = "Proxy obtenidas " & str
        End Select
    End Sub

End Class

Public Class Request
    Public Sub New(ByVal strRqst As String, ByVal channelIndex As Integer)
        Me.stringRequest = strRqst
        Me.channel = channelIndex
    End Sub

    Public stringRequest As String
    Public channel As Integer
End Class

Public Class Channel
    Public Sub New(ByVal index As Integer)
        Me.i = index
    End Sub

    Public i As Integer
    Public readedRequests As Integer = 0
    Public currentState As States = States.Stopped

End Class

Public Class ChannelGroup
    Public attachedGroup As GroupBox
End Class

Public Class ReadingRanges
    Public Sub New(ByVal minChannel As Integer, ByVal maxChannel As Integer)
        Me.min = minChannel
        Me.max = maxChannel
    End Sub

    Public min As Integer
    Public max As Integer

    Public ReadOnly Property diff As Integer
        Get
            Return max - min
        End Get
    End Property

End Class

Public Class Proxy

    Public Sub New(ByVal completeProxy As String)
        Dim splittedIP() As String = completeProxy.Split(":")
        If splittedIP.Length > 2 Then
            Throw New Exception("Wrong proxy format")
        End If
        Me.ip = splittedIP(0)
        Me.port = Convert.ToInt32(splittedIP(1))
    End Sub

    Public Sub New(ByVal ip As String, ByVal port As Integer)
        Me.ip = ip
        Me.port = port
    End Sub

    Public ip As String
    Public port As Integer

    Public Overrides Function ToString() As String
        Return ip & ":" & port
    End Function

End Class
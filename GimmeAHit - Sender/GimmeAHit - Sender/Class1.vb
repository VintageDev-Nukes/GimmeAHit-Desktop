Imports System.Text

Public Class UserInfo
    Public Shared username As String
    Public Shared password As String
    Public Shared code As String
    Public Shared logedIn As Boolean
End Class

Public Class ePHP
    Public Shared Function md5(ByVal input As String) As String
        Dim x As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bs As Byte() = System.Text.Encoding.UTF8.GetBytes(input)
        bs = x.ComputeHash(bs)
        Dim s As New System.Text.StringBuilder()
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower())
        Next
        Dim password As String = s.ToString()
        Return password
    End Function

    Public Shared Function base64_encode(ByVal input As String) As String
        Dim bytesToEncode As Byte()
        bytesToEncode = Encoding.UTF8.GetBytes(input)

        Dim encodedText As String
        encodedText = Convert.ToBase64String(bytesToEncode)

        Return (encodedText)
    End Function

    Public Shared Function base64_decode(ByVal input As String) As String
        Dim decodedBytes As Byte()
        decodedBytes = Convert.FromBase64String(input)

        Dim decodedText As String
        decodedText = Encoding.UTF8.GetString(decodedBytes)

        Return (decodedText)
    End Function

    Public Shared Function getIP(Optional ByVal webPath As String = "http://gimmeahit.x10host.com/c/getip.php") As String
        Return New System.Net.WebClient().DownloadString(webPath)
    End Function

    Public Shared Function customGUID() As String
        Dim s As String = md5(base64_encode(getIP.Replace(".", ""))).ToUpper
        Dim guidText As String = s.Substring(0, 8) & "-" & s.Substring(8, 4) & "-" & s.Substring(12, 4) & "-" & s.Substring(16, 4) & "-" & s.Substring(20)
        Return guidText
    End Function

    Public Shared Function checkUser(ByVal username As String, ByVal password As String, ByVal code As String) As Boolean
        Return Convert.ToBoolean(New System.Net.WebClient().DownloadString("http://gimmeahit.x10host.com/actionMaker.php?go=user-check&u=" & username & "&p=" & password & "&c=" & code))
    End Function

    Public Shared Sub SendRequest()

    End Sub

End Class
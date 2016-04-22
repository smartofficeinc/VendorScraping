Imports System.Globalization
Imports System.Threading
Public Class Form1
    Public search As String

    Private Sub AxWebBrowser1_Click(sender As Object, e As EventArgs) Handles AxWebBrowser1.Click
        If False Then

        End If
    End Sub

    Private Sub browser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles browser.Navigating
        Dim filename As String = Application.StartupPath & "\..\..\TX\" + search + ".csv"

        If e.Url.Segments(e.Url.Segments.Length - 1).EndsWith(".csv") Then
            e.Cancel = True
            filename = e.Url.Segments(e.Url.Segments.Length - 1)
            Dim client As New System.Net.WebClient
            client.DownloadFileTaskAsync(e.Url, filename)
        Else
            Return
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        browser.Navigate("https://mycpa.cpa.state.tx.us/tpasscmblsearch/CmblHubSearch.do")
    End Sub

    Private Sub goButton_Click(sender As Object, e As EventArgs) Handles goButton.Click
        Dim coord As Point
        coord.X = 380
        coord.Y = 395

        For i As Int64 = 65 To 127
            For j As Int64 = 32 To 127
                search = Chr(i) + Chr(j)
                browser.Document.GetElementById("vendorName").InnerText = search
                browser.Document.GetElementFromPoint(coord).InvokeMember("Click")
            Next
        Next

    End Sub

End Class

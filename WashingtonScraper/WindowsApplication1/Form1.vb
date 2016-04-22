Imports System.Text.RegularExpressions

Public Class Form1

    Private Sub goButton_Click(sender As Object, e As EventArgs) Handles goButton.Click
        Dim iFrame = browser.Document.Window.Frames("bottom").Document.Body.OuterHtml
        Dim brwsr As WebBrowser
        Dim strHTML As String
        Dim str As String = ""
        Dim more As HtmlElement

        For i = 1 To 40000
            For j = 1 To (5 - Len(i.ToString))
                str = str + "0"
            Next
            Mid(iFrame, 212, 217) = str + i.ToString
            'brwsr.Document.Window.Frames("Bottom").Document = iFrame

            browser.Document.Window.Frames("bottom").Document.Body.OuterHtml = iFrame.ToString
            more = browser.Document.GetElementById("Imagebutton1")
            If more Is Nothing Then
                Exit For
            Else
                more.ScrollIntoView(True)
                more.InvokeMember("click")
                strHTML = browser.Document.Window.Frames("bottom").Document.Body.OuterHtml
                GetDataBetween(strHTML, "", "", i)
            End If
        Next



        '
        'strHTML = New System.Net.WebClient().DownloadString("https://fortress.wa.gov/ga/webs/Search_BidDetails.aspx?ID=31807")

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        browser.Navigate("https://fortress.wa.gov/ga/webs/home.html")
    End Sub

    Private Function GetDataBetween(ByVal data As String, ByVal strStart As String, ByVal strStop As String, intPage As Int32) As String

        Dim str As String = data
        Dim nIndexStart As Integer = data.IndexOf(strStart) 'Find the first occurrence of f1
        If nIndexStart < 0 Then
            Return " "
        End If

        Dim nIndexEnd As Integer = data.IndexOf(strStop, (nIndexStart + strStart.Length))  'Find the first occurrence of f2

        If nIndexStart > -1 And nIndexEnd > -1 Then '-1 means the word was not found.
            Dim res As String = Strings.Mid(data, nIndexStart + strStart.Length + 1, nIndexEnd - nIndexStart - strStart.Length)
            If intPage.Equals(1) Then
                res = res.Remove(0, 1)
                res = res.Remove((res.Length() - 1))
                res = "http://www.nj.gov" + res
                res = res.Replace(vbLf, "")
            ElseIf intPage.Equals(2) Then

            End If
            Return res
        Else
            Return " "
        End If

    End Function



End Class

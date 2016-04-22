Imports System.Globalization
Imports System.Threading
Public Class Form1

    Public url As String = "http://webprod.cio.sc.gov/SCContractWeb/contractDetail.do?contractNumber="
    Public page As String = "http://webprod.cio.sc.gov/SCContractWeb/contractSearch.do?"
    Public i As Int64 = 0
    Public strHTML As String
    Public strDoc As String

    ' Navigates to the given URL if it is valid.
    Private Sub Navigate(ByVal address As String)

        If String.IsNullOrEmpty(address) Then Return
        If address.Equals("about:blank") Then Return
        If Not address.StartsWith("http://") And
        Not address.StartsWith("https://") Then
            address = "http://" & address
        End If

        Try
            browser.Navigate(New Uri(address))
        Catch ex As System.UriFormatException
            Return
        End Try

    End Sub

    ' Updates the HTML in strDoc upon navigation.
    Private Sub browser_Navigated(ByVal sender As Object,
    ByVal e As WebBrowserNavigatedEventArgs) _
    Handles browser.Navigated

        strDoc = browser.DocumentText

    End Sub
    Private Function GetDataBetween(str As String, strBeg As String, strEnd As String)
        Dim out As String = ""
        Dim i As Int64 = str.IndexOf(strBeg) + strBeg.Length
        Dim j As Int64 = str.IndexOf(strEnd)
        If i > 0 And j > 0 Then
            out = Mid(str, (i + 1), (j - i))
            out.Trim()
        End If

        Return out
    End Function

    Private Function GetIt()
        Dim lstVendors As New List(Of String)
        Dim lstContacts As New List(Of String)
        Dim arData As Array
        Dim str As String
        Dim strCompany As String
        Dim strCompanyName As String
        Dim strContact As String
        Dim strPhone As String
        Dim strEmail As String
        Dim strFax As String
        Dim err As Boolean = False
        Dim address As Boolean = False
        Dim key As String = "Click to view contract "
        Dim j As Int64
        Dim pg As Int64
        Dim FileName As String
        Dim tag As String
        Dim splitter As String = "="
        Dim cnt As Int64
        Dim index As Int64
        Dim fails As Int64 = 0

        While i < 10000 And fails < 100
            countLabel.Text = i.ToString
            Update()
            If (i Mod 2) = 0 Then '14 contracts per page
                pg += 1
                Dim pageUrl As String = page + "d-49652-p=" + pg.ToString

                Navigate(pageUrl)
                Update()

                'For Each elem As HtmlElement In browser.Document.GetElementsByTagName("a")
                '    If elem.InnerText = "Next" Then
                '   'Invoke your event
                '  elem.ScrollIntoView(True)
                ' AddHandler(browser.DocumentCompleted), AddressOf WebpageLoaded
                'elem.InvokeMember("click")
                'browser.Refresh()
                'browser.Update()
                'Exit For
                'End If
                'Next

                'browser.Navigate(url)

                If Not strDoc.Contains("Contract Search") Then
                    countLabel.Text = "No 'Contract Search'"
                    Update()
                    End
                End If
            End If

            j = strDoc.IndexOf(key)
            tag = Mid(strDoc, j + 23, 11).Trim 'Get the contract #
            strDoc = strDoc.Remove(0, j + 34)

            'get the string of the contract page
            strHTML = New System.Net.WebClient().DownloadString(url + tag)

            If Not strHTML.Contains("mailto") Then
                i += 1
                fails += 1
                Continue While
            End If
            arData = strHTML.Split(New Char() {"="c})

            strCompany = ""
            strCompanyName = ""
            strContact = ""

            cnt = 0
            For Each line In arData
                If line.contains("Vendor Address") Or address Then 'mailing address
                    address = True
                    If line.Contains("District") Then 'district
                        address = False
                        strCompany += GetDataBetween(arData(cnt + 1).ToString, ">", "</TD>") + vbTab
                    ElseIf line(0) = "3" Then
                        strCompany += GetDataBetween(line, "3>", "</TD>") + vbTab
                        If strCompanyName.Length < 1 Then
                            strCompanyName = strCompany
                        End If
                    End If

                ElseIf line.Contains("mailto") Then 'email
                    strEmail = GetDataBetween(line, ">", "</a>")

                ElseIf line.Contains("Telephone") Then 'phone
                    strPhone = GetDataBetween(arData(cnt + 1).ToString, ">", "</TD>")

                ElseIf line.Contains("Fax Number") Then 'fax
                    strFax = GetDataBetween(arData(cnt + 1).ToString, ">", "</TD>")

                ElseIf line.Contains("contactName") Then
                    strContact += GetDataBetween(line, ">", "</td>") + vbTab
                    strContact += GetDataBetween(arData(cnt + 2).ToString, ">", "</td>") + vbTab
                    strContact += GetDataBetween(arData(cnt + 4).ToString, ">", "</a>") + vbCrLf
                End If
                cnt += 1
            Next

            strCompany += strPhone + vbTab + strFax + vbTab + strEmail + vbTab + tag
            strContact = vbTab + strCompanyName + tag + vbCrLf + strContact

            ' For Each line In lstVendors
            'If Not line.Contains(strCompanyName) Then
            '  lstVendors.Add(strCompany)
            '         lstContacts.Add(strContact)
            '  End If
            '  Next

            lstVendors.Add(strCompany)
            lstContacts.Add(strContact)

            If (lstVendors.Count Mod 1000) = 0 Then
                FileName = Application.StartupPath & "\..\..\..\SCVendors" + lstVendors.Count.ToString + ".txt"
                IO.File.WriteAllLines(FileName, lstVendors)
                FileName = Application.StartupPath & "\..\..\..\SCContacts" + lstContacts.Count.ToString + ".txt"
                IO.File.WriteAllLines(FileName, lstContacts)
            End If
            'Thread.Sleep(1000 * (CInt(Math.Ceiling(Rnd() * 2)) + 1))
            i += 1
        End While

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'load initial search page to get list
        browser.Navigate(page)
    End Sub

    Private Sub goButton_Click(sender As Object, e As EventArgs) Handles goButton.Click
        Dim FileName As String

        GetIt()

        countLabel.Text = "Done! "
        Update()

        'FileName = Application.StartupPath & "\..\..\..\SC" + lstVendors.Count.ToString + ".txt"
        'IO.File.WriteAllLines(FileName, lstVendors)
        Exit Sub
    End Sub

End Class

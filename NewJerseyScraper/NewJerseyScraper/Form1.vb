Imports System.Globalization
Imports System.Threading
Imports Microsoft.VisualBasic
Imports System.IO

Public Class Form1
    Public blnNav As Boolean = False
    Public lstVendors As New List(Of String)

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

    Private Function GetAddress(strAddress As String) As Boolean
        Dim arOut As Array
        Dim strOut As String = strAddress
        strOut = strOut.Remove(0, 14)
        strOut = strOut.Remove(strOut.Length() - 11)
        arOut = strOut.Split("<br>")
        strOut = arOut(0).ToString.Trim() + Chr(9) + arOut(1).ToString.Remove(0, 4).Trim() + Chr(9) + arOut(2).ToString.Remove(0, 4).Trim()
        For Each element In lstVendors
            If element.Contains(strOut) Then
                Return True
            End If
        Next
        lstVendors.Add(strOut)
        Return False
    End Function

    Private Function GetContact(strContact As String, i As Int32)
        Dim strOut As String = strContact
        strOut = strOut.Remove(0, 14).Trim()
        strOut = strOut.Remove(strOut.Length() - 11).Trim()
        lstVendors(i) = lstVendors(i) + Chr(9) + strOut
    End Function

    Private Function GetBusiness(strBusiness As String, i As Int32)
        Dim strOut As String = "0"
        If strBusiness.Contains("YES") Then
            strOut = "1"
        End If
        lstVendors(i) = lstVendors(i) + Chr(9) + strOut
    End Function

    Private Sub browser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles browser.DocumentCompleted

    End Sub

    Private Sub goButton_Click(sender As Object, e As EventArgs) Handles goButton.Click
        Dim strStart As String = "href="
        Dim strEnd As String = ">"
        Dim strData As String = browser.DocumentText()
        Dim arData As Array = strData.Split("<tr>")
        Dim strParsed As String
        Dim intCnt As Int32 = 0
        Dim lstLinks As New List(Of String)
        Dim strVendorInfo As String
        Dim strHTML As String
        Dim arHTML As Array
        Dim blnVendors As Boolean
        Dim strContract As String = ""
        Dim percent As Double

        For i = 168 To arData.Length() - 1
            'blnNav = False
            If arData(i).IndexOf("/treasury/purchase/noa/contracts/") < 0 Then
                Continue For
            End If

            strParsed = GetDataBetween(arData(i), strStart, strEnd, 1)
            lstLinks.Add(strParsed)
        Next

        For i = 0 To lstLinks.Count()
            percent = (i / lstLinks.Count())
            textBox.Text = percent.ToString("P1", CultureInfo.InvariantCulture)
            browser.Navigate(lstLinks(i))
            strHTML = New System.Net.WebClient().DownloadString(lstLinks(i).ToString)
            arHTML = strHTML.Split("font")

            For j = 0 To arHTML.Length() - 1
                If arHTML(j).ToString.Contains("<strong>CONTRACT ITEMS/SERVICES BY VENDOR</strong>") Then
                    Exit For
                End If
                If arHTML(j).ToString.Contains("<b>Term Contract(s)</b>") Then
                    strContract = arHTML(j + 4).ToString.Remove(0, 16)
                    strContract = strContract.Remove(strContract.Length - 7).Trim()
                End If
                If arHTML(j).ToString.Contains("<strong>VENDOR INFORMATION</strong>") Then
                    blnVendors = True
                End If
                If blnVendors And arHTML(j).ToString.Contains("Vendor Name & Address:") Then
                    If GetAddress(arHTML(j + 2).ToString()) Then 'Vendor name + Street address + City, State, Zip
                        Continue For
                    End If
                    GetContact(arHTML(j + 6), intCnt)       'Contact person
                    GetContact(arHTML(j + 10), intCnt)      'Phone
                    GetContact(arHTML(j + 14), intCnt)      'Fax
                    GetBusiness(arHTML(j + 34), intCnt)     'Small?
                    GetBusiness(arHTML(j + 38), intCnt)     'Minority?
                    GetBusiness(arHTML(j + 42), intCnt)     'Women?

                    lstVendors(intCnt) += Chr(9) + strContract
                    linksList.Items.Add(lstVendors(intCnt))
                    intCnt += 1
                End If
            Next
            blnVendors = False
        Next

        Dim FileName As String = Application.StartupPath & "\..\..\..\NJ.txt"
        IO.File.WriteAllLines(FileName, lstVendors)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        browser.Navigate("http://www.nj.gov/treasury/purchase/pricelists.shtml")
    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        Dim lst As New List(Of String)
        lst.Add("yo yo yo")
        Dim FileName As String = Application.StartupPath & "\..\TEST.txt"
        IO.File.WriteAllLines(FileName, lst)
    End Sub
End Class

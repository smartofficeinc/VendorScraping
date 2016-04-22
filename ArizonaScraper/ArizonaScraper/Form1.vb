Imports System.Threading

Public Class Form1
    Public lstVendors As New List(Of String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'browser.Navigate("https://procure.az.gov/bso/external/vendor/vendorProfileOrgInfo.sdo?external=true&vendorId=000000001")
    End Sub

    Private Sub goButton_Click(sender As Object, e As EventArgs) Handles goButton.Click
        Dim strHTML As String
        Dim blnGo As Boolean = True
        Dim strVendor As String
        Dim i As Int64 = 34396
        Dim str As String
        Dim strZero As String
        Dim arData As Array
        Dim FileName As String
        Dim strCompany As String
        Dim err As Boolean = False
        Dim lstErrors As New List(Of String)

        While (i < 51000)
            strZero = ""
                textBox.Text = i.ToString
                Update()

                For j = 1 To (9 - Len(i.ToString))
                    strZero = strZero + "0"
                Next
                str = "https://procure.az.gov/bso/external/vendor/vendorProfileOrgInfo.sdo?external=true&vendorId=" + strZero + i.ToString
                strHTML = New System.Net.WebClient().DownloadString(str)
            If Not strHTML.Contains("Vendor") Then
                i += 1
                Continue While
            End If

            arData = strHTML.Split("<tr>")

            Try
                strCompany = (arData(62).ToString).Remove(0, 40)
            Catch ex As Exception
                lstErrors.Add(str)
                'FileName = Application.StartupPath & "\..\..\..\Errors.txt"
                'IO.File.WriteAllLines(FileName, lstErrors)
                i += 1
                err = True
            End Try
            If err Then
                err = False
                Continue While
            End If

            strCompany = strCompany.Trim
                For Each element In lstVendors
                    If element.ToString.Contains(strCompany) Then
                        i += 1
                        Continue While
                    End If
                Next
                Dim strType As String = (arData(88).ToString).Remove(0, 40)
                If strType.Contains("class=") Then
                    strType = ""
                Else
                    strType = strType.Trim + vbTab
                End If

                Dim strContact As String = (arData(124).ToString).Remove(0, 40)
                strContact = vbTab + strContact.Trim + vbTab


                str = "https://procure.az.gov/bso/external/vendor/vendorProfileAddressInfo.sdo?external=true&vendorId=" + strZero + i.ToString
                strHTML = New System.Net.WebClient().DownloadString(str)
                arData = strHTML.Split("<tr>")
                Dim strAddressContact As String = (arData(80).ToString).Remove(0, 50)
                strAddressContact = strAddressContact.Trim
                Dim strAddress As String = vbTab
                For j = 81 To 90
                    If (((arData(j).ToString).Remove(0, 2)).Trim).Contains("Alt.") Or (((arData(j).ToString).Remove(0, 2)).Trim).Contains("class=") Then
                        Exit For
                    ElseIf (((arData(j).ToString).Remove(0, 2)).Trim).Contains("Email") Then
                        strAddress += (arData(j).ToString).Remove(0, 9).Trim + vbTab
                        If (((arData(j).ToString).Remove(0, 2)).Trim).Contains("Phone") Then
                            strAddress += (arData(j).ToString).Remove(0, 9).Trim + vbTab
                            If (((arData(j).ToString).Remove(0, 2)).Trim).Contains("FAX") Then
                                strAddress += (arData(j).ToString).Remove(0, 7).Trim + vbTab
                                Exit For
                            Else
                                Exit For
                            End If
                        Else
                            Exit For
                        End If
                    Else
                        strAddress += (arData(j).ToString).Remove(0, 3) + vbTab
                    End If
                Next

                strVendor = strCompany + strContact + strAddressContact + strAddress + strType + strZero + i.ToString
                lstVendors.Add(strVendor)
            If lstVendors.Count = 5000 Or lstVendors.Count = 10000 Then
                FileName = Application.StartupPath & "\..\..\..\AZ" + lstVendors.Count.ToString + ".txt"
                IO.File.WriteAllLines(FileName, lstVendors)
            End If
            'Thread.Sleep(1000 * (CInt(Math.Ceiling(Rnd() * 2)) + 1))
            i += 1
            End While

        textBox.Text = "Done! " + lstVendors.Count.ToString
        Update()

        FileName = Application.StartupPath & "\..\..\..\AZ" + lstVendors.Count.ToString + ".txt"
        IO.File.WriteAllLines(FileName, lstVendors)
        Exit Sub
    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        Dim FileName As String = Application.StartupPath & "\..\..\..\AZVendors.txt"
        IO.File.WriteAllLines(FileName, lstVendors)
    End Sub
End Class

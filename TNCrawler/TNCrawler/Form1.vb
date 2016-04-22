Imports System
Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Data
Imports Microsoft.VisualBasic

Public Class Form1


    Private Sub GrabVendors(ByVal VendorID As String)
        '     ListBox1.Items.Clear()
        Try



            Dim Loading As String = "Loading..."
            TextBox1.Text = Loading
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://tn.gov/assets/entities/generalservices/cpo/attachments/SWCWeb_Lines" & i & ".html")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

            Dim sourcecode As String = sr.ReadToEnd()
            TextBox1.Text = sourcecode
            ' WebBrowser1.DocumentText = TextBox1.Text
        '  ConvertHTMLTablesToDataSet(responseFromServer)

        '  Dim RegVendor As String = "(?:<br>)([\s\S]*?)(?=<br>)"

        'start Cash commented code
        '    Dim RegVendor As String = "(?:General Mailing Address)([\r\s\S]*?)(Yes)"
        '    Dim RegVendorName As String = "(?:Vendor Profile)([\r\s\S]*?)(td>)"

        '    Dim Names As MatchCollection = Regex.Matches(TextBox1.Text, RegVendorName)


        '    For Each Name1 In Names
        '        Dim NameTemp As String = Mid(Name1.ToString, 17)
        '        NameTemp = Microsoft.VisualBasic.Left(NameTemp, InStr(NameTemp, "</td>") - 1)

        '        'check for commas wrap in quotes
        '        If NameTemp.Contains(",") Then
        '            Dim NameTemp2 As String = """" & NameTemp & """"
        '            ListBox1.Items.Add(NameTemp2)
        '        Else
        '            ListBox1.Items.Add(NameTemp)
        '        End If
        '    Next

        '    Dim Vendors As MatchCollection = Regex.Matches(TextBox1.Text, RegVendor)

        '    For Each Vendor In Vendors
        '        Dim temp As String = Mid(Vendor.ToString, 149)
        '        Dim a As Integer = 0

        '        a = InStr(temp, "</td>")


        '        Dim newstring As String

        '        Dim atest As String = Microsoft.VisualBasic.Left(temp, a - 1)



        '        newstring = atest.Replace("<br>", "½")

        '        If Has2ndAddress(Trim(newstring)) = False Then

        '            Dim SplitStr As String() = newstring.Split("½")
        '            Dim test1 As String = SplitStr(1)
        '            ListBox3.Items.Add(SplitStr(0).Replace(",", ""))
        '            ListBox4.Items.Add(SplitStr(1).Replace(",", ""))
        '            ListBox5.Items.Add(" ")
        '            'ListBox6.Items.Add(SplitStr(2).Replace(",", ""))
        '            'split the City Sate Zip
        '            SplitCityStateZip(SplitStr(2))

        '            ListBox7.Items.Add(SplitStr(3).Replace(",", ""))
        '            If newstring.Contains("Email:") Then
        '                ListBox8.Items.Add(Mid(SplitStr(4), 7).Replace(",", ""))
        '            Else
        '                ListBox8.Items.Add(" ")
        '            End If

        '            If newstring.Contains("Phone:") Then
        '                'Format the phone number from "Phone: (000)000-000" to "(000) 000-0000"
        '                Dim SplitStrPhone As String = Mid(SplitStr(5), 8, 13)
        '                Dim SplitStrPhone2 As String = SplitStrPhone.Insert(5, " ")
        '                ListBox9.Items.Add(SplitStrPhone2)
        '            Else
        '                ListBox9.Items.Add(" ")
        '            End If

        '            If newstring.Contains("FAX:") Then
        '                Dim SplitStrFax As String = Mid(SplitStr(6), 6)
        '                Dim SplitStrFax2 As String = SplitStrFax.Insert(5, " ")
        '                ListBox10.Items.Add(SplitStrFax2)
        '            Else
        '                ListBox10.Items.Add(" ")
        '            End If

        '        Else

        '            Dim SplitStr As String() = newstring.Split("½")
        '            Dim test1 As String = SplitStr(1)
        '            ListBox3.Items.Add(SplitStr(0).Replace(",", ""))
        '            ListBox4.Items.Add(test1.Replace(",", ""))
        '            ListBox5.Items.Add(SplitStr(2).Replace(",", ""))

        '            'ListBox6.Items.Add(SplitStr(3).Replace(",", ""))
        '            'split the City Sate Zip
        '            SplitCityStateZip(SplitStr(3))

        '            ListBox7.Items.Add(SplitStr(4).Replace(",", ""))
        '            If newstring.Contains("Email:") Then
        '                ListBox8.Items.Add(Mid(SplitStr(5), 7).Replace(",", ""))
        '            Else
        '                ListBox8.Items.Add(" ")
        '            End If

        '            If newstring.Contains("Phone:") Then
        '                'Format the phone number from "Phone: (000)000-000" to "(000) 000-0000"
        '                Dim SplitStrPhone As String = Mid(SplitStr(6), 8, 13)
        '                Dim SplitStrPhone2 As String = SplitStrPhone.Insert(5, " ")
        '                ListBox9.Items.Add(SplitStrPhone2)
        '            Else
        '                ListBox9.Items.Add(" ")
        '            End If
        '            If newstring.Contains("FAX:") Then
        '                Dim SplitStrFax As String = Mid(SplitStr(7), 6)
        '                Dim SplitStrFax2 As String = SplitStrFax.Insert(5, " ")
        '                ListBox10.Items.Add(SplitStrFax2)
        '            Else
        '                ListBox10.Items.Add(" ")
        '            End If
        '        End If

        '        Dim completeString As String = atest.Replace("½", vbCrLf)


        '        ListBox2.Items.Add(newstring)
        '        ListBox11.Items.Add(VendorID)
        '        sr.Close()
        '    Next

        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub SplitCityStateZip(ByVal data As String)
        Try

            'Split up City, Sate ZIP 
            ListBox6.Items.Add(data.Replace(",", ""))
            Dim citystr As String = ""
            Dim statestr As String = ""
            Dim zipstr As String = ""

            citystr = Microsoft.VisualBasic.Left(data, data.LastIndexOf(","))
            statestr = Mid(Mid(data, data.LastIndexOf(","), 6), 5, 2)
            zipstr = Microsoft.VisualBasic.Right(data, 5)
            city.Items.Add(citystr)
            state.Items.Add(statestr)
            zip.Items.Add(zipstr)
        Catch ex As Exception

        End Try
    End Sub








    Private Function Has2ndAddress(ByVal data As String) As Boolean

        If data.Contains("FAX") = True Then


            Dim phrase As String = "½"
            Dim Occurrences As Integer = 0

            Dim intCursor As Integer = 0
            Do Until intCursor >= data.Length

                Dim strCheckThisString As String = Mid(LCase(data), intCursor + 1, (Len(data) - intCursor))

                Dim intPlaceOfPhrase As Integer = InStr(strCheckThisString, phrase)
                If intPlaceOfPhrase > 0 Then

                    Occurrences += 1
                    intCursor += (intPlaceOfPhrase + Len(phrase) - 1)

                Else

                    intCursor = data.Length

                End If

            Loop

            If Occurrences = 7 Then
                Return True
            End If


        ElseIf data.Contains("FAX:") = False Then
            Dim phrase As String = "½"
            Dim Occurrences As Integer = 0

            Dim intCursor As Integer = 0
            Do Until intCursor >= data.Length

                Dim strCheckThisString As String = Mid(LCase(data), intCursor + 1, (Len(data) - intCursor))

                Dim intPlaceOfPhrase As Integer = InStr(strCheckThisString, phrase)
                If intPlaceOfPhrase > 0 Then

                    Occurrences += 1
                    intCursor += (intPlaceOfPhrase + Len(phrase) - 1)

                Else

                    intCursor = data.Length

                End If

            Loop
            If Occurrences = 6 Then
                Return True
            End If

        Else : Return False

        End If


    End Function


    Private Sub createCSV()
        Dim csvFile As String = My.Application.Info.DirectoryPath & "\Vendors.csv"
        Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFile, False)


        outFile.WriteLine("VendorID, CompanyName, Contact Name, Street Addres, Street Address 2, City, State, Zip, Country, Email, Phone, Fax")

        For i = 0 To ListBox11.Items.Count - 1
            outFile.WriteLine(ListBox11.Items(i).ToString & "," & ListBox1.Items(i).ToString & "," & ListBox3.Items(i).ToString & "," & ListBox4.Items(i).ToString & "," & ListBox5.Items(i).ToString & "," & city.Items(i).ToString & "," & state.Items(i).ToString & "," & zip.Items(i).ToString & "," & ListBox7.Items(i).ToString & "," & ListBox8.Items(i).ToString & "," & ListBox9.Items(i).ToString & "," & Mid(ListBox10.Items(i).ToString, 1, 13))
        Next


        outFile.Close()

        Console.WriteLine(My.Computer.FileSystem.ReadAllText(csvFile))
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim VendorCount As Integer = 1
        For i = CInt(TextBox2.Text) To CInt(TextBox3.Text)
            GrabVendors(i)
            Label3.Text = "Vendors Borrowed: " & VendorCount.ToString
            VendorCount += 1
        Next i
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        MsgBox(ListBox2.SelectedItem.ToString)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        createCSV()
    End Sub

    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.SelectedIndexChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

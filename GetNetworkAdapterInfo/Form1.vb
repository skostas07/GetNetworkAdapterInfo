Imports System.Management

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Srctext As String = ""

        If CheckBox1.Checked = True Then
            Srctext = "SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true"
        Else
            Srctext = "SELECT * FROM Win32_NetworkAdapterConfiguration"
        End If

        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(Srctext)
        ListBox1.Items.Clear()

        Dim Veriler() As String = {"Description", "DHCPEnabled", "DHCPServer", "DNSDomain", "DNSHostName", "IPEnabled", "IPFilterSecurityEnabled", "IPPortSecurityEnabled",
"IPUseZeroBroadcast", "IPXAddress", "IPXEnabled", "MACAddress"}

        For Each wmi_HD As ManagementObject In searcher.Get
            For Each Veri As String In Veriler
                If Not IsNothing(wmi_HD(Veri)) Then
                    ListBox1.Items.Add(Veri & " :" & wmi_HD(Veri))
                End If
            Next
            ListBox1.Items.Add("---")
        Next
    End Sub
End Class

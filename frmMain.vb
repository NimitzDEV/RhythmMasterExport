Public Class frmMain

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName & " - " & Application.ProductVersion
        '首先进行自动检测
        autoScan()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmChoose.Show()
        Me.Hide()
    End Sub
    Private Sub autoScan()
        Dim drives As String()
        drives = Environment.GetLogicalDrives()
        For i As Short = 0 To drives.Length - 1
            Dim str_temp As String = drives(i)
            If Dir(str_temp & targetPath, vbDirectory) <> "" And Dir(str_temp & targetFile) <> "" Then
                finalFilePath = str_temp & targetFile
                finalTargetPath = str_temp & targetPath
                loadSongsInfo()
                Label1.Text = "√ 已经检测到 - " & finalTargetPath
                Label1.ForeColor = Color.Green
                Label2.Text = "√ 已加载列表"
                Label2.ForeColor = Color.Green
                Button1.Enabled = True
                Exit Sub
            End If
        Next
        Label1.Text = "× 未检测到"
        Label1.ForeColor = Color.Red
        Label2.Text = "× 请确保手机以USB储存的方式连接到电脑"
        Label2.ForeColor = Color.Red
        Button1.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        autoScan()
    End Sub
End Class

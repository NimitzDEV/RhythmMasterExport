Public Class frmChoose
    Dim buildStr As String
    Public player As New WMPLib.WindowsMediaPlayer
    Public songPath As String

    Private Sub frmChoose_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        player.controls.stop()
        frmMain.Close()
    End Sub
    Private Sub frmChoose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        currentId = -1
        Me.Text = frmMain.Text
        On Error Resume Next
        For cot = 0 To counts
            Dim lv As New ListViewItem()
            lv.SubItems(0).Text = songListArray(cot, 0) 'ID
            lv.SubItems.Add(songListArray(cot, 1)) '歌曲名
            '艺术家
            If songListArray(cot, 3) = "" Then
                lv.SubItems.Add("未知")
            Else
                lv.SubItems.Add(songListArray(cot, 3))
            End If
            '作曲家
            If songListArray(cot, 4) = "" Then
                lv.SubItems.Add("未知")
            Else
                lv.SubItems.Add(songListArray(cot, 4))
            End If
            lv.SubItems.Add(songListArray(cot, 5) & " 秒") '持续时间
            lv.SubItems.Add(songListArray(cot, 6)) 'BPM
            '难度
            lv.SubItems.Add("Lv." & songListArray(cot, 7) & " " & Split(songListArray(cot, 16), ",")(0)) '4KE
            lv.SubItems.Add("Lv." & songListArray(cot, 8) & " " & Split(songListArray(cot, 16), ",")(1)) '4KN
            lv.SubItems.Add("Lv." & songListArray(cot, 9) & " " & Split(songListArray(cot, 16), ",")(2)) '4KH
            lv.SubItems.Add("Lv." & songListArray(cot, 10) & " " & Split(songListArray(cot, 16), ",")(3)) '5KE
            lv.SubItems.Add("Lv." & songListArray(cot, 11) & " " & Split(songListArray(cot, 16), ",")(4)) '5KN
            lv.SubItems.Add("Lv." & songListArray(cot, 12) & " " & Split(songListArray(cot, 16), ",")(5)) '5KH
            lv.SubItems.Add("Lv." & songListArray(cot, 13) & " " & Split(songListArray(cot, 16), ",")(6)) '6KE
            lv.SubItems.Add("Lv." & songListArray(cot, 14) & " " & Split(songListArray(cot, 16), ",")(7)) '6KN
            lv.SubItems.Add("Lv." & songListArray(cot, 15) & " " & Split(songListArray(cot, 16), ",")(8)) '6KH
            '性质
            If songListArray(cot, 20) = "0x1" Then buildStr &= "免费;"
            If songListArray(cot, 17) = "0x1" Then buildStr &= "隐藏;"
            If songListArray(cot, 18) = "0x1" Then buildStr &= "奖励;"
            If songListArray(cot, 19) = "0x1" Then buildStr &= "等级;"
            If buildStr = "" Then buildStr = "未知"
            lv.SubItems.Add(buildStr) '性质
            '完成添加
            ListView1.Items.Add(lv)
            buildStr = ""
        Next
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        currentId = ListView1.SelectedIndices(0)
        playMusic()
    End Sub

    Private Sub playMusic()
        songPath = songListArray(currentId, 2)
        If Dir(finalTargetPath & "\" & songPath & "\" & songPath & ".mp3") = "" Then
            MsgBox("该歌曲没有下载")
            Exit Sub
        End If
        player.controls.stop()
        If Dir(finalTargetPath & "\" & songPath & "\" & songPath & ".png") <> "" Then
            artPic.Image = Image.FromFile(finalTargetPath & "\" & songPath & "\" & songPath & ".png")
        Else
            artPic.Image = My.Resources.noaa
        End If
        If Dir(finalTargetPath & "\" & songPath & "\" & songPath & "_title_hd.png") <> "" Then
            pbSmall.Image = Image.FromFile(finalTargetPath & "\" & songPath & "\" & songPath & "_title_hd.png")
        Else
            pbSmall.Image = My.Resources.notitle
        End If
        player.URL = (finalTargetPath & "\" & songPath & "\" & songPath & ".mp3")
        player.controls.play()
    End Sub

    Private Sub frmChoose_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        artPic.Left = 5
        artPic.Top = 5
        ListView1.Left = 5
        ListView1.Top = artPic.Height + 10
        ListView1.Height = Me.ClientRectangle.Height - artPic.Height - 15
        ListView1.Width = Me.ClientRectangle.Width - 10
        GroupBox1.Left = artPic.Left + artPic.Width + 5
        GroupBox1.Height = artPic.Height + 5
        GroupBox1.Top = 0
        If Me.ClientRectangle.Width < artPic.Width + GroupBox1.Width + 15 Then Me.Width = artPic.Width + GroupBox1.Width + 15
        If Me.ClientRectangle.Height < artPic.Height + 50 Then Me.Height = artPic.Width + 50
    End Sub

    Private Sub checker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checker.Tick
        On Error Resume Next
        If player.controls.currentPositionString = "" Then
            Label1.Text = "双击播放歌曲"
            Label2.Text = "歌曲名"
            Label3.Text = "艺术家"
            Label4.Text = "作曲家"
            TrackBar1.Enabled = False
            pbSmall.Image = My.Resources.initTitle
            artPic.Image = My.Resources.initBig
            currentId = -1
        Else
            TrackBar1.Enabled = True
            TrackBar1.Maximum = Split(player.currentMedia.durationString, ":")(0) * 60 + Split(player.currentMedia.durationString, ":")(1)
            TrackBar1.Value = Split(player.controls.currentPositionString, ":")(0) * 60 + Split(player.controls.currentPositionString, ":")(1)
            Label1.Text = "正在播放 " & player.controls.currentPositionString & " / " & player.currentMedia.durationString
            Label2.Text = songListArray(currentId, 1)
            Label3.Text = songListArray(currentId, 3)
            Label4.Text = songListArray(currentId, 4)
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        player.controls.currentPosition = TrackBar1.Value
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmExport.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If currentId = -1 Then
            currentId = 0
            playMusic()
            Exit Sub
        End If
        player.controls.play()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        player.controls.pause()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        player.controls.stop()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmAbout.Show()
    End Sub
End Class
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
            For addNoteNumber = 0 To 8
                lv.SubItems.Add("Lv." & songListArray(cot, 7 + addNoteNumber) & " " & Split(songListArray(cot, 16), ",")(addNoteNumber))
            Next
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
        Debug.Print(currentId)
        playMusic()
    End Sub

    Private Sub playMusic()
        TrackBar1.Value = 0
        checker.Enabled = False
        songPath = songListArray(currentId, 2)
        player.controls.stop()
        player.URL = (finalTargetPath & "\" & songPath & "\" & songPath & ".mp3")
        player.controls.play()
        If Dir(finalTargetPath & "\" & songPath & "\" & songPath & ".mp3") = "" Then
            MsgBox("该歌曲没有下载")
            Exit Sub
        End If
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
        Label2.Text = songListArray(currentId, 1)
        Label3.Text = songListArray(currentId, 3)
        Label4.Text = songListArray(currentId, 4)
        checker.Enabled = True
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
        If CheckBox1.Checked Then
            If TrackBar1.Value = TrackBar1.Maximum Then
                If RadioButton1.Checked Then
                    If currentId <> counts Then
                        currentId += 1
                        playMusic()
                        Exit Sub
                    End If
                End If
                If RadioButton2.Checked Then
                    playMusic()
                    Exit Sub
                End If
                If RadioButton3.Checked Then
                    If currentId <> counts Then
                        currentId += 1
                        playMusic()
                        Exit Sub
                    End If
                    If currentId = counts Then
                        currentId = 0
                        playMusic()
                        Exit Sub
                    End If
                End If
            End If
        End If
                If player.controls.currentPositionString = "" Then
                    Label1.Text = "双击播放歌曲"
                    Label2.Text = "歌曲名"
                    Label3.Text = "艺术家"
                    Label4.Text = "作曲家"
                    TrackBar1.Enabled = False
                    pbSmall.Image = My.Resources.initTitle
                    artPic.Image = My.Resources.initBig
                    currentId = -1
                    checker.Enabled = False
                Else
                    TrackBar1.Enabled = True
                    TrackBar1.Maximum = Split(player.currentMedia.durationString, ":")(0) * 60 + Split(player.currentMedia.durationString, ":")(1) - 1
                    TrackBar1.Value = Split(player.controls.currentPositionString, ":")(0) * 60 + Split(player.controls.currentPositionString, ":")(1)
                    Label1.Text = "正在播放 " & player.controls.currentPositionString & " / " & player.currentMedia.durationString
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub
End Class
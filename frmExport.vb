Public Class frmExport
    Dim prePath As String
    Dim destPath As String
    Public picPath As String
    Public songPath As String
    Private Sub frmExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If currentId = -1 Then
            MsgBox("未选中歌曲!")
            Me.Close()
            Exit Sub
        End If
        prePath = songListArray(currentId, 2)
        picPath = finalTargetPath & "\" & prePath & "\" & prePath & ".png"
        songPath = finalTargetPath & "\" & prePath & "\" & prePath & ".mp3"
        If Dir(picPath) = "" Then
            artPic.Image = My.Resources.noaa
            CheckBox1.Enabled = False
            CheckBox1.Checked = False
        Else
            artPic.Image = Image.FromFile(picPath)
        End If
        tbSongName.Text = songListArray(currentId, 1)
        tbAritist.Text = songListArray(currentId, 3)
        tbComposer.Text = songListArray(currentId, 4)
        tbSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        destPath = tbSavePath.Text & tbAritist.Text & " - " & tbSongName.Text & ".mp3"
        FileCopy(songPath, destPath)
        Dim mp3 As TagLib.File = TagLib.File.Create(destPath)
        mp3.Tag.Title = tbSongName.Text
        mp3.Tag.AlbumArtists = New String() {tbAritist.Text}
        mp3.Tag.Composers = New String() {tbComposer.Text}
        mp3.Tag.BeatsPerMinute = songListArray(currentId, 6)
        If CheckBox1.Checked Then
            Dim pictures As New TagLib.Picture(picPath)
            mp3.Tag.Pictures = New TagLib.Picture() {pictures}
        End If
        mp3.Save()
        mp3.Dispose()
        MsgBox("导出完成")
        Me.Close()
    End Sub

    Private Sub tbSavePath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSavePath.TextChanged
        If Microsoft.VisualBasic.Right(tbSavePath.Text, 1) <> "\" Then tbSavePath.Text &= "\"
        If Dir(tbSavePath.Text, vbDirectory) = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        fbdSel.ShowDialog()
        If fbdSel.SelectedPath = "" Then Exit Sub
        tbSavePath.Text = fbdSel.SelectedPath
    End Sub

End Class
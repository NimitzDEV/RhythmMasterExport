Public Class frmSearch
    Public searchSign As Integer
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
        Button2.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button2.Enabled = True
        searchSign = 0
        searchData(0)
    End Sub

    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        searchSign = 0
    End Sub

    Private Sub selectItem(ByVal index As Integer)
        With frmChoose
            .ListView1.Items(index).Selected = True
            .ListView1.EnsureVisible(index)
            .ListView1.Update()
            .Select()
        End With
    End Sub

    Private Sub searchData(ByVal sIndex As Integer)
        For srhKey = sIndex To counts
            searchSign += 1
            If songListArray(srhKey, 1).Contains(TextBox1.Text) Or songListArray(srhKey, 3).Contains(TextBox1.Text) Then
                selectItem(srhKey)
                Exit Sub
            End If
        Next
        MsgBox("没有搜索到指定的结果")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        searchData(searchSign)
    End Sub
End Class
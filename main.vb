Module main
    Public Const githubLink As String = "https://github.com/NimitzDEV/RhythmMasterExport"
    Public targetPath As String = "RM\res\song"
    Public targetFile As String = "RM\res\mrock_song_client_android.xml"
    Public finalFilePath As String
    Public finalTargetPath As String
    Public songListArray(0, 20) As String
    Public counts As Integer
    Public currentId As Integer
    '数组位置说明
    'ID0，歌曲名1，路径2，艺术家3，作曲家4，持续时间5，BPM6‘
    '4KE7,4KN8,4KH9,5KE10,5KN11,5KH12,6KE13,6KN14,6KH15，note数串16
    '隐藏标志17，奖励歌曲标志18，等级奖励标志19，免费标志20
    Public Sub loadSongsInfo()
        Dim Doc As New Xml.XmlDocument
        Doc.Load(finalFilePath)
        Dim xParent As Xml.XmlNode
        Dim xxParent As Xml.XmlNode
        xParent = Doc.SelectSingleNode("SongConfig_Client_Tab")
        counts = xParent.SelectNodes("SongConfig_Client").Count - 1
        ReDim songListArray(counts, 20)
        For i = 0 To counts
            xxParent = xParent.SelectNodes("SongConfig_Client")(i)
            Dim xmlInnerNode As Xml.XmlNode
            For sel = 1 To 21
                xmlInnerNode = xxParent.SelectSingleNode(returnNodeName(sel))
                songListArray(i, sel - 1) = xmlInnerNode.InnerText.Trim
            Next
        Next
        clearData()
    End Sub
    Public Sub clearData()
        For clear = 0 To counts
            If songListArray(clear, 3) = "" Then songListArray(clear, 3) = "未知艺术家"
            If songListArray(clear, 4) = "" Then songListArray(clear, 4) = "未知作曲家"
        Next
    End Sub
    Private Function returnNodeName(ByVal nodeNumber As Integer) As String
        Select Case nodeNumber
            Case 1
                Return "m_ushSongID"
            Case 2
                Return "m_szSongName"
            Case 3
                Return "m_szPath"
            Case 4
                Return "m_szArtist"
            Case 5
                Return "m_szComposer"
            Case 6
                Return "m_iGameTime"
            Case 7
                Return "m_szBPM"
            Case 8
                Return "m_ush4KeyEasy"
            Case 9
                Return "m_ush4KeyNormal"
            Case 10
                Return "m_ush4KeyHard"
            Case 11
                Return "m_ush5KeyEasy"
            Case 12
                Return "m_ush5KeyNormal"
            Case 13
                Return "m_ush5KeyHard"
            Case 14
                Return "m_ush6KeyEasy"
            Case 15
                Return "m_ush6KeyNormal"
            Case 16
                Return "m_ush6KeyHard"
            Case 17
                Return "m_szNoteNumber"
            Case 18
                Return "m_bIsHide"
            Case 19
                Return "m_bIsReward"
            Case 20
                Return "m_bIsLevelReward"
            Case 21
                Return "m_bIsFree"
        End Select
        Return ""
    End Function
End Module

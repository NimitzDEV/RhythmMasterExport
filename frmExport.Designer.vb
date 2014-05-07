<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.tbSongName = New System.Windows.Forms.TextBox()
        Me.tbAritist = New System.Windows.Forms.TextBox()
        Me.tbComposer = New System.Windows.Forms.TextBox()
        Me.tbSavePath = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.fbdSel = New System.Windows.Forms.FolderBrowserDialog()
        Me.artPic = New System.Windows.Forms.PictureBox()
        CType(Me.artPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 341)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "歌曲名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 377)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "艺术家"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 412)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "作曲家"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(245, 341)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "封面选项"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 445)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "保存位置"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(400, 469)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "导出歌曲..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(304, 340)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "嵌入歌曲封面"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'tbSongName
        '
        Me.tbSongName.Location = New System.Drawing.Point(59, 338)
        Me.tbSongName.Name = "tbSongName"
        Me.tbSongName.Size = New System.Drawing.Size(145, 21)
        Me.tbSongName.TabIndex = 10
        '
        'tbAritist
        '
        Me.tbAritist.Location = New System.Drawing.Point(59, 374)
        Me.tbAritist.Name = "tbAritist"
        Me.tbAritist.Size = New System.Drawing.Size(145, 21)
        Me.tbAritist.TabIndex = 11
        '
        'tbComposer
        '
        Me.tbComposer.Location = New System.Drawing.Point(59, 409)
        Me.tbComposer.Name = "tbComposer"
        Me.tbComposer.Size = New System.Drawing.Size(145, 21)
        Me.tbComposer.TabIndex = 12
        '
        'tbSavePath
        '
        Me.tbSavePath.Location = New System.Drawing.Point(71, 442)
        Me.tbSavePath.Name = "tbSavePath"
        Me.tbSavePath.Size = New System.Drawing.Size(355, 21)
        Me.tbSavePath.TabIndex = 13
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(432, 440)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(61, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "选择..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'fbdSel
        '
        Me.fbdSel.Description = "请选择歌曲保存的文件夹，歌曲名字将会自动生成"
        '
        'artPic
        '
        Me.artPic.Location = New System.Drawing.Point(12, 11)
        Me.artPic.Name = "artPic"
        Me.artPic.Size = New System.Drawing.Size(483, 320)
        Me.artPic.TabIndex = 2
        Me.artPic.TabStop = False
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 504)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.tbSavePath)
        Me.Controls.Add(Me.tbComposer)
        Me.Controls.Add(Me.tbAritist)
        Me.Controls.Add(Me.tbSongName)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.artPic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmExport"
        Me.Text = "歌曲导出选项"
        CType(Me.artPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents artPic As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents tbSongName As System.Windows.Forms.TextBox
    Friend WithEvents tbAritist As System.Windows.Forms.TextBox
    Friend WithEvents tbComposer As System.Windows.Forms.TextBox
    Friend WithEvents tbSavePath As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents fbdSel As System.Windows.Forms.FolderBrowserDialog
End Class

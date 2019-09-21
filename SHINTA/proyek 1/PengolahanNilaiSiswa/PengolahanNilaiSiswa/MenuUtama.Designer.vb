<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuUtama))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnKeluar = New System.Windows.Forms.Button()
        Me.BtnGuru = New System.Windows.Forms.Button()
        Me.BtnNilai = New System.Windows.Forms.Button()
        Me.BtnMapel = New System.Windows.Forms.Button()
        Me.BtnSiswa = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnKeluar)
        Me.GroupBox1.Controls.Add(Me.BtnGuru)
        Me.GroupBox1.Controls.Add(Me.BtnNilai)
        Me.GroupBox1.Controls.Add(Me.BtnMapel)
        Me.GroupBox1.Controls.Add(Me.BtnSiswa)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 285)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'BtnKeluar
        '
        Me.BtnKeluar.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnKeluar.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKeluar.Location = New System.Drawing.Point(3, 219)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.Size = New System.Drawing.Size(313, 50)
        Me.BtnKeluar.TabIndex = 5
        Me.BtnKeluar.Text = "Keluar"
        Me.BtnKeluar.UseVisualStyleBackColor = True
        '
        'BtnGuru
        '
        Me.BtnGuru.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnGuru.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuru.Location = New System.Drawing.Point(3, 163)
        Me.BtnGuru.Name = "BtnGuru"
        Me.BtnGuru.Size = New System.Drawing.Size(313, 56)
        Me.BtnGuru.TabIndex = 4
        Me.BtnGuru.Text = "Data Guru"
        Me.BtnGuru.UseVisualStyleBackColor = True
        '
        'BtnNilai
        '
        Me.BtnNilai.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnNilai.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNilai.Location = New System.Drawing.Point(3, 114)
        Me.BtnNilai.Name = "BtnNilai"
        Me.BtnNilai.Size = New System.Drawing.Size(313, 49)
        Me.BtnNilai.TabIndex = 3
        Me.BtnNilai.Text = "Pengolahan Data Nilai"
        Me.BtnNilai.UseVisualStyleBackColor = True
        '
        'BtnMapel
        '
        Me.BtnMapel.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnMapel.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMapel.Location = New System.Drawing.Point(3, 65)
        Me.BtnMapel.Name = "BtnMapel"
        Me.BtnMapel.Size = New System.Drawing.Size(313, 49)
        Me.BtnMapel.TabIndex = 2
        Me.BtnMapel.Text = "Data Mata Pelajaran"
        Me.BtnMapel.UseVisualStyleBackColor = True
        '
        'BtnSiswa
        '
        Me.BtnSiswa.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnSiswa.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSiswa.Location = New System.Drawing.Point(3, 16)
        Me.BtnSiswa.Name = "BtnSiswa"
        Me.BtnSiswa.Size = New System.Drawing.Size(313, 49)
        Me.BtnSiswa.TabIndex = 0
        Me.BtnSiswa.Text = "Data Siswa"
        Me.BtnSiswa.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "gedung tampak full.jpg")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(334, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(343, 243)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'MenuUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 300)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "MenuUtama"
        Me.Text = "MenuUtama"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuru As System.Windows.Forms.Button
    Friend WithEvents BtnNilai As System.Windows.Forms.Button
    Friend WithEvents BtnMapel As System.Windows.Forms.Button
    Friend WithEvents BtnSiswa As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnKeluar As System.Windows.Forms.Button
End Class

Imports MySql.Data.MySqlClient
Imports System.Drawing.Bitmap
Imports System.Data.SqlClient
Public Class Form1

    Private Sub frmdatakue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        koneksi()
        cari()
        'foto()
        view()
    End Sub

    Sub foto()
        OpenFileDialog1.Title = "Masukkan Foto Anda"
        OpenFileDialog1.Filter = "JPEG File |*.jpg;*.jpeg"
        OpenFileDialog1.ShowDialog()
        PictureBox1.Image = FromFile(OpenFileDialog1.FileName)
        PictureBox1.Visible = True
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        TextBox7.Text = OpenFileDialog1.FileName
    End Sub

    Sub cari()
        Try
            cmd = New MySqlCommand("select * from datakue where KodeKue ='" & TextBox1.Text & "'", database)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                textbox1.Text = rd.Item("KodeKue")
                TextBox2.Text = rd.Item("NamaKue")
                ComboBox1.Text = rd.Item("Jenis")
                TextBox4.Text = rd.Item("Stok")
                TextBox5.Text = rd.Item("HargaSatuan")
                TextBox6.Text = rd.Item("HargaJual")
                TextBox7.Text = rd.Item("GambarKue")
            End If
            rd.Close()
        Catch ex As Exception

        End Try
    End Sub

    Sub view()
        da = New MySqlDataAdapter("select * from datakue", database)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "datakue")
        DataGridView1.DataSource = (ds.Tables("datakue"))
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub textbox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            combobox1.Focus()
        End If
    End Sub

    Private Sub combobox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            TextBox4.Focus()
        End If
    End Sub

    Private Sub textbox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            TextBox5.Focus()
        End If
    End Sub


    Sub simpanfoto()

        'database.Open()
        Using cmd As New MySqlCommand
            cmd.Connection = database
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into datakue (KodeKue, NamaKue, Jenis, Stok, HargaSatuan, HargaJual, GambarKue)" & _
            "values (@KodeKue, @NamaKue, @Jenis, @Stok, @HargaSatuan, @HargaJual, @GambarKue)"
            cmd.Parameters.AddWithValue("@KodeKue", Me.TextBox1.Text)
            cmd.Parameters.AddWithValue("@NamaKue", Me.TextBox2.Text)
            cmd.Parameters.AddWithValue("@Jenis", Me.ComboBox1.Text)
            cmd.Parameters.AddWithValue("@Stok", Me.TextBox4.Text)
            cmd.Parameters.AddWithValue("@HargaSatuan", Me.TextBox5.Text)
            cmd.Parameters.AddWithValue("@HargaJual", Me.TextBox6.Text)
            cmd.Parameters.AddWithValue("@GambarKue", Me.OpenFileDialog1.FileName)
            cmd.ExecuteNonQuery()
        End Using

        database.Close()

        MsgBox("Data Tersimpan")
        view()
        Exit Sub
        ' bersih(Me)
        'pesan:  MsgBox("ulangi")
    End Sub

    Private Sub TextBox1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            cari()
            combobox1.Focus()
            TextBox1.Enabled = False
            combobox1.Enabled = False
            TextBox2.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
        End If
    End Sub

    Sub tom_mati()
        btnsimpan.Enabled = True
        Button2.Enabled = False
        Button5.Enabled = False
        btnbatal.Enabled = True
        Button3.Enabled = False
        btnhapus.Enabled = False
    End Sub

    Sub tom_hidup()
        btnsimpan.Enabled = False
        Button2.Enabled = True
        Button5.Enabled = False
        btnbatal.Enabled = False
        btnhapus.Enabled = False
        Button3.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tom_mati()
        TextBox1.Focus()
        GroupBox1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        foto()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call koneksi()
        GroupBox1.Enabled = False
        Call view()
        tom_hidup()
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        PictureBox1.Visible = False

        GroupBox1.Enabled = False
    End Sub

    Private Sub TextBox1_KeyPress2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            TextBox4.Focus()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox4_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            TextBox5.Focus()
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsimpan.Click
        simpanfoto()
        bersih()
        tom_hidup()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        Btnsimpan.Enabled = False
        Button2.Enabled = True
        Button5.Enabled = False
        btnbatal.Enabled = True
        Button3.Enabled = True
        btnhapus.Enabled = False
        bersih()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        TextBox1.Text = DataGridView1.SelectedCells(0).Value
        TextBox2.Text = DataGridView1.SelectedCells(1).Value
        ComboBox1.Text = DataGridView1.SelectedCells(2).Value
        TextBox4.Text = DataGridView1.SelectedCells(3).Value
        TextBox5.Text = DataGridView1.SelectedCells(4).Value
        TextBox6.Text = DataGridView1.SelectedCells(5).Value
        OpenFileDialog1.FileName = DataGridView1.SelectedCells(6).Value
        PictureBox1.Image = FromFile(OpenFileDialog1.FileName)
        PictureBox1.Visible = True
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        TextBox7.Text = OpenFileDialog1.FileName

        Button5.Enabled = True
        btnbatal.Enabled = True
        GroupBox1.Enabled = True
        btnhapus.Enabled = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ubahlagi()
        bersih()
    End Sub
    Sub ubahterakhir()
        koneksi()
        Using cmd As New MySqlCommand

            cmd.Connection = database
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update datakue set(NamaKue,Jenis,Stok, HargaSatuan,HargaJual,GambarKue)" & _
            "values(@NamaKue,@Jenis,@Stok,@HargaSatuan,@HargaJual,@GambarKue where KodeKue = @KodeKue)"
            cmd.Parameters.AddWithValue("@KodeKue", Me.TextBox1.Text)
            cmd.Parameters.AddWithValue("@NamaKue", Me.TextBox2.Text)
            cmd.Parameters.AddWithValue("@Jenis", Me.ComboBox1.Text)
            cmd.Parameters.AddWithValue("@Stok", Me.TextBox4.Text)
            cmd.Parameters.AddWithValue("@HargaSatuan", Me.TextBox5.Text)
            cmd.Parameters.AddWithValue("@HargaJual", Me.TextBox6.Text)
            cmd.Parameters.AddWithValue("@GambarKue", Me.OpenFileDialog1.FileName)
            cmd.ExecuteNonQuery()

        End Using

        database.Close()

        MsgBox("Data Tersimpan")
        view()
        Exit Sub

        ' Dim ubah As String
        '    ubah = "update datakue set KodeKue='" & @KodeKue & "', NamaKue='" & @NamaKue & "', Jenis = '" & @Jenis &"', Stok= '" & @Stok & "', HargaSatuan = '" & @HargaSatuan & "', HargaJual='"& @HargaJual &"', GambarKue ='" & @GambarKue &"' where KodeKue = '" & TextBox1.Text & "'"
        ' cmd = New MySqlCommand(ubah, database)
    End Sub
    Sub ubahlagi()
        Dim ubah As String
        ubah = "update datakue set NamaKue=@NamaKue, Jenis=@Jenis, Stok=@Stok, HargaSatuan=@HargaSatuan, HargaJual=@HargaJual, GambarKue =@GambarKue where KodeKue = '" & TextBox1.Text & "'"
        cmd = New MySqlCommand(ubah, database)
        With cmd
            .CommandText = ubah
            .Connection = database
            .Parameters.Add("@NamaKue", MySqlDbType.String, 30).Value = TextBox2.Text
            .Parameters.Add("@Jenis", MySqlDbType.String, 30).Value = ComboBox1.Text
            .Parameters.Add("@Stok", MySqlDbType.String, 30).Value = TextBox4.Text
            .Parameters.Add("@HargaSatuan", MySqlDbType.String, 30).Value = TextBox5.Text
            .Parameters.Add("@HargaJual", MySqlDbType.String, 30).Value = TextBox6.Text
            .Parameters.Add("@GambarKue", MySqlDbType.Text, 50).Value = OpenFileDialog1.FileName
            .ExecuteNonQuery()
        End With
        MsgBox("Berhasil Update")
        bersih()
        view()

    End Sub
    Sub ubah1()
        Dim cmd As New MySqlCommand("Update datakue set NamaKue='" & TextBox2.Text & "', Jenis = '" & ComboBox1.Text & "', Stok = '" & TextBox4.Text & "', HargaSatuan = '" & TextBox5.Text & "', HargaJual = '" & TextBox6.Text & "', GambarKue = '" & OpenFileDialog1.FileName & "' where KodeKue ='" & TextBox1.Text & "'", database)
        Try
            If cmd.ExecuteNonQuery() = 1 Then
                MsgBox("Update tidak berhasil")
                bersih()
                Call view()
                Exit Sub
            End If

        Catch ex As MySqlException
            MsgBox("update data berhasil")
        End Try



    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Function ubah() As Object
        Throw New NotImplementedException
    End Function

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        If TextBox1.Text = "" Then
            MsgBox("Isi kode barang terlebih dahulu")
            TextBox1.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New MySqlCommand("Delete from datakue where KodeKue='" & TextBox1.Text & "'", database)
                cmd.ExecuteNonQuery()
                Call bersih()
                Call view()
            Else
                Call bersih()
            End If
        End If
        tom_hidup()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        foto()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class

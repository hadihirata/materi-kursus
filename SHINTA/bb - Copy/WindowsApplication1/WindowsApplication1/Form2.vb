Imports MySql.Data.MySqlClient
Imports System.Drawing.Bitmap
Imports System.Data.SqlClient

Public Class Form2


    Sub view()
        da = New MySqlDataAdapter("select * from datakue", database)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "datakue")
        DGV.DataSource = (ds.Tables("datakue"))
        DGV.ReadOnly = True
    End Sub
  
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtbayar.Enabled = False
        txtkembali.Enabled = False
        Call koneksi()
        view()
        ' FakturOtomatis()
        Label13.Visible = False
        Label14.Visible = False
        sembunyi()
    End Sub
    Sub timbul()
        Button1.Enabled = True
        txttotal2.Visible = True
        txtstokakhir.Visible = True
        TextBox1.Visible = True
        txtgrand.Visible = True
        GroupBox1.Enabled = True
        txttotal1.Enabled = True
        txtgrand.Enabled = True
        txttotal.Enabled = True
    End Sub
    Sub sembunyi()
        Button1.Enabled = False
        txttotal2.Visible = False
        txtstokakhir.Visible = False
        TextBox1.Visible = False
        txtgrand.Visible = False
        GroupBox1.Enabled = False
        txttotal1.Enabled = False
        txtgrand.Enabled = False
        txttotal.Enabled = False
    End Sub
    Sub FakturOtomatis()
        cmd = New MySqlCommand("Select * from pembelian where NoFaktur in (select max(NoFaktur) from pembelian) order by NoFaktur desc", database)
        rd = cmd.ExecuteReader
        Dim urutan As String
        Dim hitung As Long
        rd.Read()
        If Not rd.HasRows Then
            urutan = Format(Now, "yyMMdd") + "0001"
        Else
            If Microsoft.VisualBasic.Left(rd.GetString(0), 6) <> Format(Now, "yyMMdd") Then
                urutan = Format(Now, "yyMMdd") + "0001"
            Else
                hitung = rd.GetString(0) + 1
                urutan = Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("0000" & hitung, 4)
            End If
        End If
        txtno.Text = urutan
        txtno.Enabled = False
        
    End Sub

    Private Sub DGV_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV.DoubleClick
        txtkode.Text = DGV.SelectedCells(0).Value
        txtnama.Text = DGV.SelectedCells(1).Value
        txtjenis.Text = DGV.SelectedCells(2).Value
        txtstok.Text = DGV.SelectedCells(3).Value
        TextBox1.Text = txtstok.Text
        txtharga.Text = DGV.SelectedCells(5).Value
        OpenFileDialog1.FileName = DGV.SelectedCells(6).Value
        PictureBox1.Image = FromFile(OpenFileDialog1.FileName)
        PictureBox1.Visible = True
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        GroupBox1.Enabled = True
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '  If (e.KeyChar = Chr(13)) Then
        'simpan()

        ' End If
    End Sub
    Sub simpan()

        'database.Open()
        Using cmd As New MySqlCommand
            cmd.Connection = database
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into pembelian (NoFaktur, Tanggal, KodeKue, NamaKue, Jenis, Stok, Harga, JumlahBeli, TotalBelanja, Bayar, Kembali, GambarKue)" & _
            "values (@NoFaktur, @Tanggal, @KodeKue, @NamaKue, @Jenis, @Stok, @Harga, @JumlahBeli, @TotalBelanja, @Bayar, @Kembali, @GambarKue)"
            cmd.Parameters.AddWithValue("@NoFaktur", Me.txtno.Text)
            cmd.Parameters.AddWithValue("@Tanggal", Me.DateTimePicker1.Value)
            cmd.Parameters.AddWithValue("@KodeKue", Me.txtkode.Text)
            cmd.Parameters.AddWithValue("@NamaKue", Me.txtnama.Text)
            cmd.Parameters.AddWithValue("@Jenis", Me.txtjenis.Text)
            cmd.Parameters.AddWithValue("@Stok", Me.txtstok.Text)
            cmd.Parameters.AddWithValue("@Harga", Me.txtharga.Text)
            cmd.Parameters.AddWithValue("@JumlahBeli", Me.txtjumlah.Text)
            cmd.Parameters.AddWithValue("@TotalBelanja", Me.txttotal.Text)
            cmd.Parameters.AddWithValue("@Bayar", Me.txtbayar.Text)
            cmd.Parameters.AddWithValue("@Kembali", Me.txtkembali.Text)
            cmd.Parameters.AddWithValue("@GambarKue", Me.OpenFileDialog1.FileName)
            cmd.ExecuteNonQuery()
       End Using

        database.Close()

        MsgBox("Data Tersimpan")
        view()
        Exit Sub
    End Sub
    Sub pindah()


        koneksi()

        Using cmd As New MySqlCommand
            cmd.Connection = database
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into pembelian (NoFaktur, Tanggal, KodeKue, NamaKue, Jenis, Stok, Harga, JumlahBeli, TotalBelanja, Bayar, Kembali, GambarKue)" & _
            "values (@NoFaktur, @Tanggal, @KodeKue, @NamaKue, @Jenis, @Stok, @Harga, @JumlahBeli, @TotalBelanja, @Bayar, @Kembali, @GambarKue)"
            cmd.Parameters.AddWithValue("@NoFaktur", Me.txtno.Text)
            cmd.Parameters.AddWithValue("@Tanggal", Me.DateTimePicker1.Value)
            cmd.Parameters.AddWithValue("@KodeKue", Me.txtkode.Text)
            cmd.Parameters.AddWithValue("@NamaKue", Me.txtnama.Text)
            cmd.Parameters.AddWithValue("@Jenis", Me.txtjenis.Text)
            cmd.Parameters.AddWithValue("@Stok", Me.txtstok.Text)
            cmd.Parameters.AddWithValue("@Harga", Me.txtharga.Text)
            cmd.Parameters.AddWithValue("@JumlahBeli", Me.txtjumlah.Text)
            cmd.Parameters.AddWithValue("@TotalBelanja", Me.txttotal.Text)
            cmd.Parameters.AddWithValue("@Bayar", Me.txtbayar.Text)
            cmd.Parameters.AddWithValue("@Kembali", Me.txtkembali.Text)
            cmd.Parameters.AddWithValue("@GambarKue", Me.OpenFileDialog1.FileName)
            cmd.ExecuteNonQuery()
           
           



            'cmd.Connection = database
            'cmd.CommandType = CommandType.Text
            'cmd.CommandText = "select * from DataKue where KodeKue = '" & txtkode.Text & "'"
            'rd = cmd.ExecuteReader
            ' rd.Read()

            ' If rd.HasRows Then
            'rd.Read()
            ' Dim kurangistok As String = "update DataKue set Stok ='" & rd.Item(3) - txtstok.Text & "' where KodeKue='" & txtkode.Text & "'"
            ' cmd = New MySqlCommand(kurangistok, database)
            ' cmd.ExecuteNonQuery()
            ' End If

        End Using
        

        database.Close()

        MsgBox("Data Tersimpan")
        view()
        Exit Sub

    End Sub
    Sub stok()
        koneksi()

        'rd.Read()
        ' da = New MySqlDataAdapter("select * from DataKue where KodeKue='" & txtkode.Text & "'", database)
        'ds = New DataSet
        ' ds.Clear()

        '  Dim mm As String
        '  mm = "select * from DataKue where KodeKue = '" & Me.txtkode.Text & "'"
        '  cmd = New MySqlCommand(mm, database)
        '  rd = cmd.ExecuteReader


        Dim kurangistok As String
        kurangistok = "update DataKue set Stok ='" & txtstokakhir.Text & "' where KodeKue='" & txtkode.Text & "'"
        cmd = New MySqlCommand(kurangistok, database)
        cmd.ExecuteNonQuery()


        ' cmd = New MySqlCommand("select * from DataKue where KodeKue='" & txtkode.Text & "'", database)
        ' rd = cmd.ExecuteReader
        ' rd.Read()
        '  Exit Sub

    End Sub
    Sub kurangi()
        Dim kurangistok As String = "update DataKue set Stok ='" & rd.Item(3) - Val(txtstok.Text) & "' where KodeKue='" & txtkode.Text & "'"
        cmd = New MySqlCommand(kurangistok, database)
        cmd.ExecuteNonQuery()


        rd.Close()

        database.Close()
    End Sub
    Sub catatanuntuklistview()
        ' rd.Read()

        ' cmd = New MySqlCommand("select * from Pembelian where NoFaktur = '" & txtno.Text & "'", database)
        ' rd = cmd.ExecuteReader
        'rd.Read()
        ' ListView1.Items.Clear()
        'ListView1.Items.Add(rd.Item(3) & rd.Item(6) & rd.Item(11))

    End Sub
   
    Sub bersih2()
        txtno.Text = ""
        txtkode.Text = ""
        txtnama.Text = ""
        txtjenis.Text = ""
        txtstok.Text = ""
        TextBox1.Text = ""
        txtharga.Text = ""
        txtjumlah.Text = ""
        ' If txtjumlah.Text = "" And txtharga.Text = "" Then
        'txttotal.Text = txtgrand.Text
        ' End If
        ' txttotal1.Text = Val(txttotal2.Text) + Val(txtgrand.Text)
        txtbayar.Text = ""
        txtkembali.Text = ""
    End Sub
    Sub bersih()
        txtno.Text = ""
        txtkode.Text = ""
        txtnama.Text = ""
        txtjenis.Text = ""
        txtstok.Text = ""
        txtharga.Text = ""
        txtjumlah.Text = ""
        txttotal.Text = ""
        txttotal1.Text = ""
        txttotal2.Text = ""
        txtgrand.Text = ""
        txtbayar.Text = ""
        txtkembali.Text = ""
        TextBox1.Text = ""
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub


    Private Sub txtbayar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbayar.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pindah()
            txtbayar.Enabled = False
            bersih()
            view()
        End If
        Exit Sub
    End Sub

    Private Sub txtbayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbayar.TextChanged
        txtkembali.Text = Val(txtbayar.Text) - Val(txttotal.Text)

        ' kurangi()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtbayar.Focus()
        txtbayar.Enabled = True
        txttotal.Enabled = False
        txttotal1.Enabled = False
        '  pindah()
        stok()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bersih()
        FakturOtomatis()
        timbul()
        txtbayar.Enabled = False
        txtkembali.Enabled = False
        Call koneksi()
        view()

        Label13.Visible = False
        Label14.Visible = False
        txttotal2.Visible = False
        txtgrand.Visible = False
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        pindah()
        'txttotal2.Text = txttotal1.Text
        'txttotal1.Text = "0"
        If txtjumlah.Text = "0" Then
            txttotal1.Text = "0"
            txttotal2.Text = "0"
            txttotal.Text = Val(txttotal1.Text) + Val(txttotal2.Text)
            txtgrand.Text = txttotal.Text
        ElseIf txttotal1.Text > 0 Then
            txttotal1.Text = Val(txtjumlah.Text) * Val(txtharga.Text)
            txttotal2.Text = txttotal1.Text
            txttotal1.Text = ""

            txttotal.Text = Val(txttotal2.Text) + Val(txtgrand.Text)
            txtgrand.Text = txttotal.Text
            'txttotal.Text = Val(txttotal1.Text) + Val(txttotal2.Text)
            ' txtgrand.Text = txtgrand.Text
        End If


        Exit Sub
    End Sub

    Private Sub txtjumlah_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtjumlah.TextChanged
        '  Dim cekstok As String
        '  cekstok = "select * from DataKue where KodeKue = '" & txtkode.Text & "'"
        '  cmd = New MySqlCommand(cekstok, database)
        '  cmd.ExecuteNonQuery()

        If txtstok.Text <= "0" Then
            MsgBox("Stok Tidak Cukup, Hubungi Operator")
            bersih()
            sembunyi()
        ElseIf txtjumlah.Text > Val(txtstok.Text) Then
            MsgBox("Jumlah Beli Anda Melebihi Stok")
            bersih()
            sembunyi()
        End If
        txttotal1.Text = Val(txtjumlah.Text) * Val(txtharga.Text)
        txttotal2.Text = txttotal1.Text
        txtstokakhir.Text = Val(txtstok.Text) - Val(txtjumlah.Text)
        Exit Sub
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form5.Show()
        Me.Hide()
    End Sub
End Class
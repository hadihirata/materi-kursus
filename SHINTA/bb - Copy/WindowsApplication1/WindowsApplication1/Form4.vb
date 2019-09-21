Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Imports System.Drawing.Bitmap
Public Class Form4
    Sub coba()
        koneksi2()

        Tabel1 = New Data.Odbc.OdbcDataAdapter("select * from DataKue where KodeKue = '" & ComboBox1.Text & "'", Database1)
        Data1 = New DataSet
        Tabel1.Fill(Data1)
        Record1.DataSource = Data1
        Record1.DataMember = Data1.Tables(0).ToString()
        Try

            Dim a As DataRow
            TextBox2.Clear()
            For Each a In Data1.Tables(0).Rows
                TextBox2.Text = a("NamaKue")
                TextBox3.Text = a("Jenis")
                TextBox4.Text = a("HargaSatuan")
                TextBox5.Text = a("HargaJual")
                TextBox7.Text = a("Stok")
                TextBox6.Text = a("GambarKue")
                OpenFileDialog1.FileName = a("GambarKue")
                PictureBox1.Image = FromFile(OpenFileDialog1.FileName)
                PictureBox1.Visible = True
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

            Next a
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
   
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        coba()
    End Sub
    
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ambil1()
        koneksi()
        bersih()
        'Data_Record()
        'coba()
        coba3()
    End Sub

    Sub bersih()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub
    Sub coba3()
        koneksi()
        da = New MySqlDataAdapter("select KodeKue from DataKue", database)
        ds = New DataSet
        da.Fill(ds, "DataKue")
        ComboBox1.DataSource = (ds.Tables("DataKue"))
        Me.ComboBox1.ValueMember = "KodeKue"

       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form5.Show()
        Me.Hide()
    End Sub
End Class
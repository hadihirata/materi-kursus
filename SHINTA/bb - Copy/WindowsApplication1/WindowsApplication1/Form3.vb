Imports System.Data.Odbc
Imports System.Drawing
Public Class Form3
    Dim Database As OdbcConnection
    Dim Tabel As OdbcDataAdapter
    Dim Data As DataSet
    Public Record As New BindingSource
    Dim DML As New OdbcCommand
    Dim Cari As OdbcDataReader
    Sub koneksi()
        Str = "Driver={MySQL ODBC 3.51 Driver};database=cakeshop;server=localhost;uid=root"
        Database = New OdbcConnection(Str)
        If Database.State = ConnectionState.Closed Then
            Database.Open()
        End If

    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call koneksi()
    End Sub

    Private Sub btntampil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntampil.Click


        DGV.Columns.Clear()
        Call koneksi()
        Tabel = New OdbcDataAdapter("select NamaKue,GambarKue from DataKue", Database)
        Data = New DataSet
        Data.Clear()
        Tabel.Fill(Data)
        DGV.DataSource = Data.Tables(0)
        Dim Cols As New DataGridViewImageColumn()
        DGV.Columns.Add(Cols)
        ' DataGridViewImageCellLayout.Stretch()


        Dim imagecolumn As System.Windows.Forms.DataGridViewImageColumn
        Cols.ImageLayout = DataGridViewImageCellLayout.Zoom
        Cols.Description = "default image layout"

        On Error Resume Next
        For baris As Integer = 0 To DGV.RowCount - 1
            DGV.Rows(baris).Cells(2).Value =
Image.FromFile(DGV.Rows(baris).Cells(1).Value)
            Cols.HeaderText = "Foto"
            Cols.Name = "Cols"

        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form5.Show()
        Me.Hide()
    End Sub
End Class


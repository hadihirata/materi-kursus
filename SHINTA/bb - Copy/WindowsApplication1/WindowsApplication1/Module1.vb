Imports Mysql.data.mysqlclient

Module Module1
    Public database As MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As MySqlCommand
    Public cmd2 As MySqlDataReader
    Public rd As MySqlDataReader
    Public rd2 As MySqlDataReader
    Public str As String
    Public hasil As Integer
    Public record As BindingSource


    Sub koneksi()
        str = "server=localhost;uid=root;password=;database=cakeshop"
        database = New MySqlConnection(str)
        If database.State = ConnectionState.Closed Then
            database.Open()
        End If

    End Sub

    Public koneksifoto
    ' Dim supernothing As New OdbcDatabaseection
    '    supernothing = New OdbcDatabaseection("server='localhost';user='root';pwd='';dabase='cakeshop';")
    '   supernothing.Open()
    ' Return (supernothing)
    ' End Function
End Module

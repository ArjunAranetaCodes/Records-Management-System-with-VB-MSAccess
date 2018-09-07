Imports System.Data.OleDb
Public Class Form1
    Dim conn As New OleDbConnection
    Dim dbProvider As String = "PROVIDER = Microsoft.JET.OLEDB.4.0;"
    Dim dbSource As String = "Data Source = D:\AccessDB\db_vbrecordsys.mdb;"
    Dim adapter As OleDbDataAdapter
    Dim ds As DataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = dbProvider & dbSource
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox4.Text = TextBox5.Text Then
            ds = New DataSet
            adapter = New OleDbDataAdapter("insert into [tbl_accounts] ([username], [password], [privilege]) VALUES " &
                                           "('" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "')", conn)
            adapter.Fill(ds, "tbl_accounts")
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.Text = ""
            MsgBox("User Registered!")
        Else
            MsgBox("Passwords do not match!")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New OleDbDataAdapter("select * from [tbl_accounts] where username = '" & TextBox1.Text &
                                       "' and password = '" & TextBox2.Text & "'", conn)
        adapter.Fill(ds, "tbl_accounts")
        TextBox1.Clear()
        TextBox2.Clear()

        If ds.Tables("tbl_accounts").Rows.Count > 0 Then
            MsgBox("Login successful!")
            Form2.Show()
            Me.Hide()
        Else
            MsgBox("Wrong combination of username and password")
        End If
    End Sub
End Class

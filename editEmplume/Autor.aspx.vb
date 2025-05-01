Imports System.Data.SqlClient
Imports System.Data
Partial Class Autor
    Inherits System.Web.UI.Page
    Dim conexion As SqlConnection

    Public Property LlblError As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim sqlAutor As SqlDataSource = CType(FindControl("sqlAutor"), SqlDataSource)
            sqlAutor.ConnectionString = ConfigurationManager.ConnectionStrings("MiconexionSQLServer").ConnectionString
            sqlAutor.SelectCommand = "SELECT * FROM Autor"
            sqlAutor.DataBind()
        End If
        'cargarAutor()
    End Sub
    Sub crearAutor()
        Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("MiconexionSQLServer").ConnectionString)
        Dim cmd As SqlCommand

        Try
            Dim nombre As String = txtNomAutor.Text.Trim().Replace("'", "''")
            Dim apellido As String = txtApelliAutor.Text.Trim().Replace("'", "''")
            Dim fechaNac As String = calFechaNac.SelectedDate.ToString("yyyy-MM-dd")
            Dim biografia As String = txtBiografia.Text.Trim().Replace("'", "''")

            conexion.Open()
            cmd = New SqlCommand
            cmd.CommandType = CommandType.Text
            cmd.Connection = conexion
            cmd.CommandText = "INSERT INTO Autor (nombreAutor, apellidoAutor, fechaNacimiento, biografiaAutor) " &
            "VALUES ('" & nombre & "', '" & apellido & "', '" & fechaNac & "', '" & biografia & "')"
            cmd.ExecuteNonQuery()
            LlblMessage.Text = "Autor creado correctamente."
            LlblMessage.CssClass = "form-label text-success"
            MostrarToast("by-success")
        Catch ex As Exception
            LlblMessage.Text = "Error al crear el usuario"
            LlblMessage.CssClass = "from-label text-white"
            MostrarToast("dbg-ganger")

        Finally
            If conexion.State = connectionState.Open Then
                conexion.Close()

            End If
        End Try
    End Sub
    'Sub cargarAutor()
    '    Dim sqlAutor As SqlDataSource = CType(FindControl("sqlAutor"), SqlDataSource)
    '    sqlAutor.ConnectionString = ConfigurationManager.ConnectionStrings("MiConexionSQLServer").ConnectionString
    '    sqlAutor.SelectCommand = "SELECT * FROM Autor"
    '    sqlAutor.DataBind()
    'End Sub

    Private Sub btnCrearAutor_Click(sender As Object, e As EventArgs) Handles btnCrearAutor.Click
        crearAutor()
    End Sub

    Private Sub btnCalendario_Click(sender As Object, e As ImageClickEventArgs) Handles btnCalendario.Click
        pnlCalendario.Visible = Not pnlCalendario.Visible
    End Sub
    Protected Sub calFechaNac_SelectionChanged(sender As Object, e As EventArgs)
        txtFechaNaci.Text = calFechaNac.SelectedDate.ToString("yyyy-MM-dd")
        pnlCalendario.Visible = False
    End Sub

    Private Sub MostrarToast(color As String)
        Dim script As String = "
       bootstrap.Modal.getOrCreateInstance(document.getElementById('confirm')).hide();
       document.getElementById('liveToast').className = 'toast hide align-items-center " & color & "';" &
       "bootstrap.Toast.getOrCreateInstance(document.getElementById('liveToast')).show();"
        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, Guid.NewGuid().ToString(), script, True)
    End Sub

End Class

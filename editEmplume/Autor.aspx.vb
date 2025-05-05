Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Drawing
Partial Class Autor
    Inherits System.Web.UI.Page
    'Public Property LlblError As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

        End If
        SqlAutor.ConnectionString = ConexionDB.ObtenerConexion().ConnectionString
        cargarAutor()

    End Sub
    Sub crearAutor()
        Dim nombre As String = txtNomAutor.Text.Trim().Replace("'", "''")
        Dim apellido As String = txtApelliAutor.Text.Trim().Replace("'", "''")
        Dim fechaNac As String = calFechaNac.SelectedDate.ToString("yyyy-MM-dd")
        Dim biografia As String = txtBiografia.Text.Trim().Replace("'", "''")

        Dim conexion As SqlConnection
        conexion = ConexionDB.ObtenerConexion()
        Dim cmd As SqlCommand
        Try
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
            If conexion.State = ConnectionState.Open Then
                conexion.Close()

            End If
        End Try
    End Sub
    Sub cargarAutor()
        SqlAutor.SelectCommand = "SELECT * FROM Autor"
        SqlAutor.DataBind()
    End Sub

    Protected Sub DropUpdateAutor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Exit Sub
        End If
        Dim accionSelect As String = DropUpdateAutor.SelectedValue
        If String.IsNullOrWhiteSpace(accionSelect) Then
            Exit Sub
        End If
        Select Case accionSelect
            Case "Editar"
                Response.Redirect("editarAutor.aspx")
            Case "Eliminar"
                Response.Redirect("eliminarAutor.aspx")
        End Select
    End Sub


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

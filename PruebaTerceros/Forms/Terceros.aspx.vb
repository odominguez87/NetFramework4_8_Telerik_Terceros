Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class Formulario_web1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarGrilla()
            EstadoBotones(False, False, False, False)
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim dsTerceros As New DataSet
        dsTerceros = ReadInformationQuery($"Execute spGetAllTerceros  {Me.TxtNumeroDocumento.Text}, '{Me.TxtTipoDocumento.Text.ToUpper}'")
        If dsTerceros.Tables(0).Rows.Count > 0 Then
            'MsgBox("Se encontraron resultados", MsgBoxStyle.Information, "Titulo del Mensaje")
            EstadoBotones(False, True, True, True)
            Me.TxtTipoDocumento.ReadOnly = True
            Me.TxtNumeroDocumento.ReadOnly = True
            CargarInformacion(dsTerceros)
        Else
            EstadoBotones(True, False, False, True)
            Me.TxtTipoDocumento.ReadOnly = False
            Me.TxtNumeroDocumento.ReadOnly = False
        End If
    End Sub

    Protected Sub DdlPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlPais.SelectedIndexChanged
        CargarDepartamentos(Me.DdlPais.SelectedItem.Value)
    End Sub

    Protected Sub DdlDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlDepartamento.SelectedIndexChanged
        CargarMunicipios(Me.DdlDepartamento.SelectedItem.Value)
    End Sub

    Protected Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        If ValidarCampos() = "" Then
            EjecutarCRUD("INS")
            CargarGrilla()
        End If
        LimpiarFormulario()
        EstadoBotones(False, False, False, False)
    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If ValidarCampos() = "" Then
            EjecutarCRUD("UPD")
            CargarGrilla()
        End If
        LimpiarFormulario()
        EstadoBotones(False, False, False, False)
    End Sub

    Protected Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles BtnBorrar.Click
        If ValidarCampos() = "" Then
            EjecutarCRUD("DEL")
            CargarGrilla()
        End If
        LimpiarFormulario()
        EstadoBotones(False, False, False, False)
    End Sub

    Protected Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        LimpiarFormulario()
        EstadoBotones(False, False, False, False)
    End Sub

    Private Function ValidarCampos() As String
        Dim resultado As String = ""
        If Me.TxtTipoDocumento.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Tipo Documento no puede ser vacio"
            Else
                resultado &= ", El campo Tipo Documento no puede ser vacio"
            End If
        End If
        If Me.TxtNumeroDocumento.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Numero de Documento no puede ser vacio"
            Else
                resultado &= ", El campo Numero de Documento no puede ser vacio"
            End If
        ElseIf Not IsNumeric(Me.TxtNumeroDocumento.Text.Trim) Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Numero de Documento debe ser numerico"
            Else
                resultado &= ", El campo Numero de Documento debe ser numerico"
            End If
        End If
        If Me.TxtTipoTercero.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Tipo Tercero no puede ser vacio"
            Else
                resultado &= ", El campo Tipo Tercero no puede ser vacio"
            End If
        End If
        If Me.DdlDepartamento.Items.Count = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "Se debe seleccionar un departamento valido"
            Else
                resultado &= ", Se debe seleccionar un departamento valido"
            End If
        End If
        If Me.DdlMunicipio.Items.Count = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "Se debe seleccionar un municipio valido"
            Else
                resultado &= ", Se debe seleccionar un municipio valido"
            End If
        End If
        If Me.TxtNombres.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Nombres no puede ser vacio"
            Else
                resultado &= ", El campo Nombres no puede ser vacio"
            End If
        End If
        If Me.TxtApellidos.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Apellidos no puede ser vacio"
            Else
                resultado &= ", El campo Apellidos no puede ser vacio"
            End If
        End If
        If Me.TxtRazonSocial.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Razon Social no puede ser vacio"
            Else
                resultado &= ", El campo Razon Social no puede ser vacio"
            End If
        End If
        If Me.TxtNombreComercial.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Nombre Comercial no puede ser vacio"
            Else
                resultado &= ", El campo Nombre Comercial no puede ser vacio"
            End If
        End If
        If Me.TxtSiglas.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Siglas no puede ser vacio"
            Else
                resultado &= ", El campo Siglas no puede ser vacio"
            End If
        End If
        If Me.TxtEmail.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo Email no puede ser vacio"
            Else
                resultado &= ", El campo Email no puede ser vacio"
            End If
        End If
        If Me.TxtAp.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo AP no puede ser vacio"
            Else
                resultado &= ", El campo AP no puede ser vacio"
            End If
        ElseIf Not IsNumeric(Me.TxtAp.Text.Trim) Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo AP debe ser numerico"
            Else
                resultado &= ", El campo AP debe ser numerico"
            End If
        End If
        If Me.TxtRf.Text.Trim = 0 Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo RF no puede ser vacio"
            Else
                resultado &= ", El campo RF no puede ser vacio"
            End If
        ElseIf Not IsNumeric(Me.TxtRf.Text.Trim) Then
            If resultado.Trim.Length = 0 Then
                resultado = "El campo RF debe ser numerico"
            Else
                resultado &= ", El campo RF debe ser numerico"
            End If
        End If

        ValidarCampos = resultado
    End Function
    Private Sub EstadoBotones(ByVal insertar As Boolean, ByVal actualizar As Boolean, ByVal borrar As Boolean, ByVal cancelar As Boolean)
        Me.BtnInsertar.Enabled = insertar
        Me.BtnActualizar.Enabled = actualizar
        Me.BtnBorrar.Enabled = borrar
        Me.BtnCancelar.Enabled = cancelar
    End Sub

    Private Sub CargarGrilla()
        Dim ds As New DataSet
        Me.rdGridListTerceros.DataSource = ReadInformationQuery("Execute spGetAllTerceros")
        Me.rdGridListTerceros.DataBind()
        ds = ReadInformationQuery("spGetAllCountries")
        DdlPais.DataSource = ds.Tables(0)
        DdlPais.DataValueField = "Id"
        DdlPais.DataTextField = "descripcion"
        DdlPais.DataBind()
    End Sub
    Private Sub CargarInformacion(ByVal ds As DataSet)
        Me.TxtTipoDocumento.Text = ds.Tables(0).Rows(0).Item("TipoDocumento")
        Me.TxtNumeroDocumento.Text = ds.Tables(0).Rows(0).Item("NrIdntfcion")
        Me.TxtTipoTercero.Text = ds.Tables(0).Rows(0).Item("TipoTercero")
        Me.DdlPais.SelectedIndex = DdlPais.Items.IndexOf(DdlPais.Items.FindByValue(ds.Tables(0).Rows(0).Item("Ps")))
        CargarDepartamentos(ds.Tables(0).Rows(0).Item("Ps"))
        Me.DdlDepartamento.SelectedIndex = DdlDepartamento.Items.IndexOf(DdlDepartamento.Items.FindByValue(ds.Tables(0).Rows(0).Item("Dpto")))
        CargarMunicipios(ds.Tables(0).Rows(0).Item("Dpto"))
        Me.DdlMunicipio.SelectedIndex = DdlMunicipio.Items.IndexOf(DdlMunicipio.Items.FindByValue(ds.Tables(0).Rows(0).Item("Dpto")))
        Me.TxtNombres.Text = ds.Tables(0).Rows(0).Item("NmbrsCmpltos")
        Me.TxtApellidos.Text = ds.Tables(0).Rows(0).Item("ApllsCmpltos")
        Me.TxtRazonSocial.Text = ds.Tables(0).Rows(0).Item("RznScial")
        Me.TxtNombreComercial.Text = ds.Tables(0).Rows(0).Item("NmbrCmrcial")
        Me.TxtSiglas.Text = ds.Tables(0).Rows(0).Item("Sgla")
        Me.TxtEmail.Text = ds.Tables(0).Rows(0).Item("Email")
        Me.TxtAp.Text = ds.Tables(0).Rows(0).Item("IdAp")
        Me.TxtRf.Text = ds.Tables(0).Rows(0).Item("IdRf")
    End Sub

    Private Sub CargarDepartamentos(ByVal CodPais As Integer)
        Dim dsDepartamentos As New DataSet
        dsDepartamentos = ReadInformationQuery($"Execute spGetAllDepartments {CodPais}")
        DdlDepartamento.DataSource = dsDepartamentos.Tables(0)
        DdlDepartamento.DataValueField = "Id"
        DdlDepartamento.DataTextField = "descripcion"
        DdlDepartamento.DataBind()
        DdlMunicipio.Items.Clear()
    End Sub

    Private Sub CargarMunicipios(ByVal CodDepartameto As Integer)
        Dim dsMunicipio As New DataSet
        dsMunicipio = ReadInformationQuery($"Execute spGetAllCities {CodDepartameto}")
        DdlMunicipio.DataSource = dsMunicipio.Tables(0)
        DdlMunicipio.DataValueField = "Id"
        DdlMunicipio.DataTextField = "descripcion"
        DdlMunicipio.DataBind()
    End Sub

    Private Sub LimpiarFormulario()
        Me.TxtTipoDocumento.Text = ""
        Me.TxtTipoDocumento.ReadOnly = False
        Me.TxtNumeroDocumento.Text = ""
        Me.TxtNumeroDocumento.ReadOnly = False
        Me.TxtTipoTercero.Text = ""
        Me.DdlMunicipio.Items.Clear()
        Me.DdlDepartamento.Items.Clear()
        Me.DdlPais.SelectedIndex = 0
        Me.TxtNombres.Text = ""
        Me.TxtApellidos.Text = ""
        Me.TxtRazonSocial.Text = ""
        Me.TxtNombreComercial.Text = ""
        Me.TxtSiglas.Text = ""
        Me.TxtEmail.Text = ""
        Me.TxtAp.Text = ""
        Me.TxtRf.Text = ""
    End Sub

    Public Function ReadInformationQuery(ByVal sSql As String) As DataSet
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("conSql").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd = New SqlCommand(sSql, conn)
            cmd.CommandType = CommandType.Text
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al traer la informacion")
            ds = New DataSet
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            ReadInformationQuery = ds
        End Try
    End Function

    Public Function ExecuteQuery(ByVal sSql As String) As Boolean
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("conSql").ConnectionString)
        Dim cmd As New SqlCommand
        Try
            conn.Open()
            cmd = New SqlCommand(sSql, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("", "")
            cmd.ExecuteNonQuery()
            conn.Close()
            ExecuteQuery = True
        Catch ex As Exception
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            ExecuteQuery = False
        End Try
    End Function

    Private Sub EjecutarCRUD(ByVal Procedimiento As String)
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("conSql").ConnectionString)
        Dim cmd As New SqlCommand
        Dim mensaje As String = ""
        Dim tipoResultado As Integer = 0
        Try
            conn.Open()
            cmd = New SqlCommand("spiudTerceros", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@TipoProceso", SqlDbType.VarChar)
            cmd.Parameters("@TipoProceso").Value = Procedimiento
            cmd.Parameters.Add("@TipoTercero", SqlDbType.VarChar)
            cmd.Parameters("@TipoTercero").Value = Me.TxtTipoTercero.Text
            cmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar)
            cmd.Parameters("@TipoDocumento").Value = Me.TxtTipoDocumento.Text
            cmd.Parameters.Add("@NrIdntfcion", SqlDbType.Decimal)
            cmd.Parameters("@NrIdntfcion").Value = Me.TxtNumeroDocumento.Text
            cmd.Parameters.Add("@Ps", SqlDbType.Int)
            cmd.Parameters("@Ps").Value = Me.DdlPais.SelectedItem.Value
            cmd.Parameters.Add("@Dpto", SqlDbType.Int)
            cmd.Parameters("@Dpto").Value = Me.DdlDepartamento.SelectedItem.Value
            cmd.Parameters.Add("@Mncpo", SqlDbType.Int)
            cmd.Parameters("@Mncpo").Value = Me.DdlMunicipio.SelectedItem.Value
            cmd.Parameters.Add("@NmbrsCmpltos", SqlDbType.VarChar)
            cmd.Parameters("@NmbrsCmpltos").Value = Me.TxtNombres.Text
            cmd.Parameters.Add("@ApllsCmpltos", SqlDbType.VarChar)
            cmd.Parameters("@ApllsCmpltos").Value = Me.TxtApellidos.Text
            cmd.Parameters.Add("@RznScial", SqlDbType.VarChar)
            cmd.Parameters("@RznScial").Value = Me.TxtRazonSocial.Text
            cmd.Parameters.Add("@NmbrCmrcial", SqlDbType.VarChar)
            cmd.Parameters("@NmbrCmrcial").Value = Me.TxtNombreComercial.Text
            cmd.Parameters.Add("@Sgla", SqlDbType.VarChar)
            cmd.Parameters("@Sgla").Value = Me.TxtSiglas.Text
            cmd.Parameters.Add("@Email", SqlDbType.VarChar)
            cmd.Parameters("@Email").Value = Me.TxtEmail.Text
            cmd.Parameters.Add("@IdAp", SqlDbType.Int)
            cmd.Parameters("@IdAp").Value = Me.TxtAp.Text
            cmd.Parameters.Add("@IdRf", SqlDbType.Int)
            cmd.Parameters("@IdRf").Value = Me.TxtRf.Text
            cmd.ExecuteNonQuery()
            conn.Close()
            tipoResultado = 1
            Select Case Procedimiento
                Case "INS"
                    mensaje = "El proceso de insercion se realizo exitosamente"
                Case "UPD"
                    mensaje = "El proceso de actualizacion se realizo exitosamente"
                Case "DEL"
                    mensaje = "El proceso de eliminacion se realizo exitosamente"
            End Select
        Catch ex As Exception
            mensaje = ex.Message
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Finally
            cmd.Dispose()
        End Try

        'If tipoResultado = 0 Then
        '    MsgBox(mensaje, MsgBoxStyle.Critical, "Error...")
        'Else
        '    MsgBox(mensaje, MsgBoxStyle.Information, "Proceso Realizado Exitosamente")
        'End If

    End Sub

End Class
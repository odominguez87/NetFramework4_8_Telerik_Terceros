<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Terceros.aspx.vb" Inherits="PruebaTerceros.Formulario_web1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-4">
            <label for="TxtTipoDocumento" class="form-label">Tipo Documento: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtTipoDocumento"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="TxtNumeroDocumento" class="form-label">Tipo Documento: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtNumeroDocumento" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="btnBuscar" class="form-label"></label>
            <asp:Button runat="server" CssClass="btn btn-dark col-12" ID="btnBuscar" Text="Buscar" />
        </div>
        <div class="col-md-4">
            <label for="TxtTipoTercero" class="form-label">Tipo Tercero: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtTipoTercero"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="DdlPais" class="form-label">Pais: </label>
            <asp:DropDownList ID="DdlPais" CssClass="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <label for="DdlDepartamento" class="form-label">Departamento: </label>
            <asp:DropDownList ID="DdlDepartamento" CssClass="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <label for="DdlMunicipio" class="form-label">Municipio: </label>
            <asp:DropDownList ID="DdlMunicipio" CssClass="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <label for="TxtNombres" class="form-label">Nombres: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtNombres"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="TxtApellidos" class="form-label">Apellidos: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtApellidos"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="TxtRazonSocial" class="form-label">Razon Social: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtRazonSocial"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="TxtNombreComercial" class="form-label">Nombre Comercial: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtNombreComercial"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="TxtSiglas" class="form-label">Siglas: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtSiglas"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="TxtEmail" class="form-label">Email: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtEmail"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="TxtAp" class="form-label">AP: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtAp"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="TxtRf" class="form-label">RF: </label>
            <asp:TextBox runat="server" CssClass="form-control" ID="TxtRf"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-3">
            <asp:Button runat="server" CssClass="btn btn-success col-12" ID="BtnInsertar" Text="Insertar" Enabled="False" />
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" CssClass="btn btn-primary col-12" ID="BtnActualizar" Text="Actualizar" Enabled="False" />
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" CssClass="btn btn-danger col-12" ID="BtnBorrar" Text="Borrar" Enabled="False" />
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" CssClass="btn btn-light col-12" ID="BtnCancelar" Text="Cancelar" />
        </div>
    </div>
    <br />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rdGridListTerceros">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdGridListTerceros" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadGrid  ID="rdGridListTerceros" runat="server" Culture="es-ES" CellSpacing="-1" GridLines="Both">
        <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
        <ClientSettings>
            <Selecting AllowRowSelect="true" />
            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
        </ClientSettings>
        <MasterTableView CommandItemDisplay="Top" AutoGenerateColumns="false" DataKeyNames="IdTercero">
            <Columns>
                
                <telerik:GridBoundColumn HeaderText="Tipo Tercero" DataType="System.String" DataField="TipoTercero"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Tipo de Documento" DataType="System.String" DataField="TipoDocumento"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Numero Documento" DataType="System.String" DataField="NrIdntfcion"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Pais" DataType="System.String" DataField="Ps"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Departamento" DataType="System.String" DataField="Dpto"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Municipio" DataType="System.String" DataField="Mncpo"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Nombres" DataType="System.String" DataField="NmbrsCmpltos"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Apellidos" DataType="System.String" DataField="ApllsCmpltos"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Razon Social" DataType="System.String" DataField="RznScial"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Nombre Comercial" DataType="System.String" DataField="NmbrCmrcial"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Siglas" DataType="System.String" DataField="Sgla"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Email" DataType="System.String" DataField="Email"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Ap" DataType="System.String" DataField="IdAp"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Rf" DataType="System.String" DataField="IdRf"></telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>

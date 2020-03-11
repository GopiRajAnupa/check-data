<%@ Page Title="" Language="C#" MasterPageFile="~/EffectaMain.Master" AutoEventWireup="true" CodeBehind="HTMLRecorder.aspx.cs" Inherits="Effecta.AutomationTool.HTMLRecorder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="col-xs-1 pull-left">
          <table><tr><td>            
             <%-- <asp:Label ID="lblName" runat="server" Text="Test Script :"></asp:Label>--%>
                     </td><td>
      <asp:Label ID="lblEcName" runat="server"></asp:Label>    
      </td></tr></table></div>
    <div class="col-xs-1 pull-right">
                <asp:LinkButton ID="lnkBtnBack" runat="server" OnClick="lnkBtnBack_Click" CssClass="btn btn-sm btn-primary pull-right"><span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Back</asp:LinkButton>

            </div> 
    <div>
        <iframe style="width: 100%!important; height:800px !important; overflow: scroll !important;" id="ifrmGrabber" runat="server" >
        </iframe>
    </div>
   <%--750px--%>
</asp:Content>

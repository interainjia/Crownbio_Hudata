<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserFunction.aspx.cs" Inherits="PDXmodelBase.HuData.UserFunction1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>
        <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
           <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
       <script type="text/javascript" src="../Common/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function addtime() {
            parent.$("#test").datagrid('reload');
        }
    </script>
</head>
<body>    
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
  <div>
        <asp:CheckBox ID="cbx1" runat="server" Text="Select All MoldeColumn" 
            oncheckedchanged="cbx1_CheckedChanged" AutoPostBack="true"/>
            <br />
      Role:<asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True">
          <asp:ListItem Text="SD" Value="SD"></asp:ListItem>
          <asp:ListItem Text="BD" Value="BD">BD</asp:ListItem>
          <asp:ListItem Text="HP" Value="HP">HP</asp:ListItem>
          <asp:ListItem Text="SIMM" Value="SIMM"></asp:ListItem>
      </asp:DropDownList>
    </div>
    <div>
   
   <asp:DataList ID="dlUserFunction" runat="server" Width="100%" 
            onitemdatabound="dlUserFunction_ItemDataBound" RepeatColumns="4" >
                        <ItemTemplate>
                            <div style="border-style: outset; border-width: 2px;">
                            <a id="fname" runat="server"><%#Container.DataItem%></a> 
                            <br />
                            <asp:DataList ID="newdatalit" runat="server"  onitemdatabound="newdatalit_ItemDataBound">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <a runat="server" id="operate_id"><%#DataBinder.Eval(Container.DataItem, "OPERATE")%></a>
                                    <asp:HiddenField runat="server" id="hffid" Value ='<%#DataBinder.Eval(Container.DataItem, "HUBASE_FUNCTION_ID")%>'/>
                                     <asp:HiddenField runat="server" id="hfFN" Value ='<%#DataBinder.Eval(Container.DataItem, "FUNCTION_NAME")%>'/>
                                      <asp:HiddenField runat="server" id="hffname" Value ='<%#DataBinder.Eval(Container.DataItem, "Operate")%>'/>
                                </ItemTemplate>
                            </asp:DataList>
                             </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <div style="float: right; padding-top: 10px; padding-right: 5px;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                    </div>
                
    </div>
   
  </ContentTemplate>
      </asp:UpdatePanel>
      
    </form>
</body>

</html>

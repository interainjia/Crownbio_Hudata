<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleFunction.aspx.cs" Inherits="PDXmodelBase.HuData.RoleFunction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript" src="../Common/easyui-1.3.2/jquery-1.8.0.min.js"></script>

        <script type="text/javascript" src="../Common/easyui-1.3.2/jquery.easyui.min.js"></script>
           <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Common/easyui-1.3.2/themes/icon.css" />
<%--       <script type="text/javascript" src="../Common/DatePicker/WdatePicker.js"></script>--%>

    <script type="text/javascript">
        function addtime() {
            parent.$("#dgUserRole").datagrid('reload');
            parent.$.fancybox.close();
        }
        $(function () {
            getRoleUserName();
        });
        function getRoleUserName() {
            $('#cbxUserName').combotree({
                editable: false,
                url: 'Person.ashx?M=getRoleUserName',
                id: 'id',
                text: 'text'

            });

        }
        function Save() {
            var cbxUserName = $('#cbxUserName').combotree('getValues');
            document.getElementById("hfRoleUserName").value = cbxUserName;
            var btn = document.getElementById('btnSave');
            btn.click();
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
<%--        <asp:CheckBox ID="cbx1" runat="server" Text="Select All MoldeColumn" 
            oncheckedchanged="cbx1_CheckedChanged" AutoPostBack="true"/>
            <br />--%>
        Role Name:<asp:TextBox runat="server" id="txtROLE_NAME"></asp:TextBox>
         User Name: <select id="cbxUserName" name="cbxUserName" class="easyui-combotree" multiple  style="width: 250px;">
                            </select>
    </div>
    <div>
   
   <asp:DataList ID="dlUserFunction" runat="server" Width="100%" 
            onitemdatabound="dlUserFunction_ItemDataBound" RepeatColumns="3" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <div style="border-style: outset; border-width: 2px;">
                            <a id="fname" runat="server"><%#Container.DataItem%></a> 
                            <br />
                            <div style="overflow-y: scroll; height: 200px">
                            <asp:DataList ID="newdatalit" runat="server"  onitemdatabound="newdatalit_ItemDataBound"  >
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <a runat="server" id="operate_id"><%#DataBinder.Eval(Container.DataItem, "OPERATE")%></a>
                                    <asp:HiddenField runat="server" id="hffid" Value ='<%#DataBinder.Eval(Container.DataItem, "HUBASE_FUNCTION_ID")%>'/>
                                     <asp:HiddenField runat="server" id="hfFN" Value ='<%#DataBinder.Eval(Container.DataItem, "FUNCTION_NAME")%>'/>
                                <asp:HiddenField runat="server" id="hffname" Value ='<%#DataBinder.Eval(Container.DataItem, "Operate")%>'/>
                                </ItemTemplate>
                            </asp:DataList>
                            </div>
                             </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <div style="float: right; padding-top: 10px; padding-right: 5px;">
                    <asp:HiddenField runat="server" id="hfRoleUserName" />
                    <input type="button" id="btnSave1" onclick="Save();" value="Save"/>
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" Style="display: none"/>
                    </div>
                
    </div>
   
  </ContentTemplate>
      </asp:UpdatePanel>
    
    </form>
</body>

</html>

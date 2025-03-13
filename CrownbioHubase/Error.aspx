<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PDXmodelBase.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Error</title>
     <link rel="shortcut icon" href="../images/minlogo.png" />
      <link rel="stylesheet" type="text/css" href="Common/css/buttons3.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="600" border="0" align="center" cellpadding="5" cellspacing="0">
					<tr>
						<td  class="table_bgcolor">
							<table width="100%" border="1" cellpadding="5" cellspacing="0" 
							
							class="table_bordercolor"
							
							>
								<tr style="background-position: right;background-image: url('../images/CROWN BIOSCIENCE - Final Corporate Logo - RGB.svg');background-repeat: no-repeat;" >
									<td height="22" class="table_titlebgcolor"><STRONG><FONT color="red">error：</FONT></STRONG></td>
								</tr>
								<tr>
									<td height="22">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td height="22">
													<asp:Label id="lblMsg" runat="server" Width="100%"></asp:Label>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							
							</table>
						</td>
					</tr>
				</table>
    </div>
    </form>
</body>
</html>

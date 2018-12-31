<%@ Page Language="C#" MasterPageFile="~/Models/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EARS.Models.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script language="javascript" type="text/javascript">

      
        // the jQuery ready shortcut      
        $(function () {
            // set up our datepicker 
             $('#<%=txtFromDate.ClientID%>').datetimepicker({ 

                timepicker: false,
                format: 'd-m-Y'
            });
            $('#<%=txtToDate.ClientID%>').datetimepicker({

                timepicker: false,
                format: 'd-m-Y'
            });       
        });
              

    </script>


    <fieldset>
        <legend>Test Report Summary</legend>

        <div>
            <asp:RadioButtonList ID="rdOptionList" runat="server" OnSelectedIndexChanged="rdOptionList_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                <asp:ListItem Text="Test Cycle ID" Value="TCID" />
                <asp:ListItem Text="Result Search" Value="Name" />
                <asp:ListItem Text="Date Search" Value="Date" />
            </asp:RadioButtonList>

        </div>
        <div class="pl-helper-20margin-top pl-helper-20margin-bottom">


           <!-- Date Search -->
           <asp:Label ID="lblFromDate" runat="server" Text="From Date" Font-Bold="True"></asp:Label>&nbsp;
           <asp:TextBox ID="txtFromDate" autocomplete="off" runat="server"></asp:TextBox>&nbsp; 
           <!-- <asp:DropDownList ID="ddlFromDate" runat="server"></asp:DropDownList>  -->

           <asp:Label ID="lblToDate" runat="server" Text="To Date" Font-Bold="True"></asp:Label>
           <asp:TextBox ID="txtToDate" autocomplete="off" runat="server"></asp:TextBox> 

           <!-- <asp:DropDownList ID="ddlToDate" runat="server"></asp:DropDownList> -->       

            <!-- Test Cycle ID -->
            <asp:Label ID="lblTestCycleID" runat="server">Test Cycle ID</asp:Label>
            <asp:DropDownList ID="ddlTestCycleID" runat="server"></asp:DropDownList>
            <!-- <asp:TextBox ID="txtTestCycleID" runat="server"></asp:TextBox> -->
            
            <!-- Result search -->
            <asp:Label ID="lblName" runat="server">Result</asp:Label>
            <asp:DropDownList ID="ddlName" runat="server"></asp:DropDownList>
            &nbsp;<asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" CssClass="pl-btn pl-btn-medium" />
        </div>

    </fieldset>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="pl-table pl-data-table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Test Cycle ID">
                <ItemTemplate>
                    <asp:LinkButton ID="btlLink" runat="server" Text='<%# Eval("TestCycleID") %>' OnCommand="OnLnkClick" CssClass="pl-btn pl-btn-link"
                        CommandArgument='<%# Eval("TestCycleID") %>'> </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="TestName" HeaderText="Test Name" SortExpression="TestName" />
            <asp:BoundField DataField="Expected" HeaderText="Expected" SortExpression="Expected" />
            <asp:BoundField DataField="Actual" HeaderText="Actual" SortExpression="Actual" />
            <asp:BoundField DataField="Result" HeaderText="Result" SortExpression="Result" />
            <asp:BoundField DataField="DateOfExecution" HeaderText="Executed Date" SortExpression="DateOfExecution" />
        </Columns>
    </asp:GridView>

    
    
</asp:Content>

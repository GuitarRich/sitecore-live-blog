<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sample Datasource Sublayout.ascx.cs" Inherits="Sitecore.Buckets.Client.layouts.Sample_Datasource_Sublayout" %>
<%@ Register Assembly="Sitecore.Kernel" Namespace="Sitecore.Web.UI.WebControls" TagPrefix="sc" %>
<%@ Import Namespace="Sitecore.ContentSearch.SearchTypes" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<asp:ListView ID="SampleListView" runat="server">
    <LayoutTemplate>
        <div>
            <div runat="server" id="itemPlaceholder"></div>
        </div>
    </LayoutTemplate>
    <ItemTemplate>
        <h1>
            <!-- Bind Result to Field Editor-->
            <sc:Text ID="Title" Item="<%# ((Item)Container.DataItem) %>" Field="Title" runat="server" />
            <!-- Display raw title, not editable through the Page Editor-->
            <%--<%# ((SitecoreUISearchResultItem)(Container.DataItem)).GetItem().Fields["Title"] != null ? ((SitecoreUISearchResultItem)(Container.DataItem)).GetItem().Fields["Title"].Value : "" %>--%>
        </h1>
        <div>
            <!-- Bind Result to Field Editor-->
            <sc:Text ID="Text" Item="<%# ((Item)(Container.DataItem)) %>" Field="Text" runat="server" />
            <!-- Display raw text, not editable through the Page Editor-->
            <%--<%# ((SitecoreUISearchResultItem)(Container.DataItem)).GetItem().Fields["Text"] != null ? ((SitecoreUISearchResultItem)(Container.DataItem)).GetItem().Fields["Text"].Value : "" %>--%>
        </div>

    </ItemTemplate>

</asp:ListView>
<div>
   <asp:Literal ID="RunTime" runat="server"></asp:Literal>
</div>

<!--    Code-Behind sample code running on this control.

        protected void Page_Load(object sender, EventArgs e)
        {
            //Fetch datasource string from datasource field.
            var searches = ((Sublayout)this.Parent).DataSource;
            
            //Open search context based off the current item
            using (var context = ContentSearchManager.CreateSearchContext(Sitecore.Context.Item))
            {
                //Parse the datasource query into an IQueryable instance
                var query = LinqHelper.CreateQuery<SitecoreUISearchResultItem>(context, UIFilterHelpers.ParseDatasourceString(searches))
                                                  .Filter(language => language.Language == Sitecore.Context.Language.CultureInfo.TwoLetterISOLanguageName.ToString())
                                                  .Select(toItem => toItem.GetItem());
    
                //Set IQueryable to ListView Datasource
                SampleListView.DataSource = query;
                //Bind ListView control
                SampleListView.DataBind();
            } 
            
            //Search Context Disposed
            //All querying is now finished, access to context is no longer allowed.
                
        }    
-->

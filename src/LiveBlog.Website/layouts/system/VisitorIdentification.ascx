<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<%  if (Sitecore.Context.Diagnostics.Tracing || Sitecore.Context.Diagnostics.Profiling)
    {%>
<!-- Visitor identification is disabled because debugging is active. -->
<%        
    }
    else if (Sitecore.Analytics.Tracker.IsActive && Sitecore.Analytics.Tracker.Visitor.VisitorClassification == 925)
    {
%>
<meta name="VIcurrentDateTime" content="<%: DateTime.UtcNow.Ticks %>" />
<script type="text/javascript" src="/layouts/system/VisitorIdentification.js"></script>
<%
    }
%>

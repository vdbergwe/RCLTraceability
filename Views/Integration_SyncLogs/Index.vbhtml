@ModelType IEnumerable(Of Intranet.Integration_SyncLogs)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layoutv2.vbhtml"
End Code

@Html.ActionLink("Sync SAP Materials", "get_SAP_Material", "IntegrationEngine", Nothing, New With {.class = "btn btn-default"})
@Html.ActionLink("Sync SAP Deliveries", "get_SAP_Deliveries", "IntegrationEngine", Nothing, New With {.class = "btn btn-default"})
@Html.ActionLink("Sync SAP Delivery Lines", "get_SAP_DeliveriesLines", "IntegrationEngine", Nothing, New With {.class = "btn btn-default"})
@Html.ActionLink("Sync OMD Handling Units", "post_HandlingUnits", "IntegrationEngine", Nothing, New With {.class = "btn btn-default"})
@Html.ActionLink("Sync OMD Handling Units Movements", "post_HandlingUnits_Movements", "IntegrationEngine", Nothing, New With {.class = "btn btn-default"})
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Created)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SourceSystem)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DestinationSystem)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SyncScope)
        </th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Created)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CreatedBy)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SourceSystem)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.DestinationSystem)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SyncScope)
            </td>
        </tr>
    Next

</table>

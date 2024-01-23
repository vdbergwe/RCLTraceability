@ModelType IEnumerable(Of Intranet.Handling_Units)
@Code
    ViewData("Title") = "Handling Units"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Handling Units"
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("VOID", "VOID", Nothing, New With {.class = "btn btn-default"})
    </div>
    <div class="btn-group">
        @Html.ActionLink("View Sync Logs", "VOID", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("Force Sync With SAP", "VOID", Nothing, New With {.class = "btn btn-default"})
    </div>
    <div class="btn-group">
        @Html.ActionLink("Search", "VOID", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("Export", "VOID", Nothing, New With {.class = "btn btn-default"})
    </div>
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.SSCC)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Created)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Production_Batches.Description) | @Html.DisplayNameFor(Function(model) model.Production_Batches.Plant)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Product1.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
    </tr>
    @For Each item In Model
        @<tr class="grow_row" onclick="location.href = '@Url.Action("Details", "Handling_Units", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.SSCC)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Created)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Production_Batches.Description) | @item.Production_Batches.Plant
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Product1.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Status)
            </td>
        </tr>
    Next

</table>

@ModelType IEnumerable(Of Intranet.Waypoint)
@Code
    ViewData("Title") = "Traceability"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Traceability Waypoints"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")

End Code
<div class="btn-toolbar btn-group">
    @Html.ActionLink("Add Waypoint", "Create", Nothing, New With {.class = "btn btn-default"})
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            Status
        </th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "Waypoints", New With {.Id = item.Id})'">
    <td>
        @Html.DisplayFor(Function(modelItem) item.Type)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Description)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Devices.LastOrDefault.Status)<br />
        @Html.DisplayFor(Function(modelItem) item.Devices.FirstOrDefault.IP)
        @Html.DisplayFor(Function(modelItem) item.Devices.LastOrDefault.LastCheckin)
    </td>

</tr>
    Next

</table>

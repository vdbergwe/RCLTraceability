@ModelType IEnumerable(Of Intranet.Waypoints_NumberBanks)
@Code
    ViewData("Title") = "Traceability"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Traceability Number Ranges"
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
<div class="btn-toolbar">
    <div class="btn-group-sm">
        @If User.IsInRole("Admin") Then
            @Html.ActionLink("Re-Initiliaze", "ReInit", Nothing, New With {.class = "btn btn-default"})
        End If
    </div>
</div>

<Table Class="table">
    <tr>
            <th>
            @Html.DisplayNameFor(Function(model) model.Prefix)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Bank)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Root)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastIssued)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Created)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Reserved)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Released)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Depleted)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Waypoint)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "Waypoints_NumberBanks", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.Prefix)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Bank)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Root)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FirstNumber)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LastNumber)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LastIssued)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Created)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Reserved)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Released)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Depleted)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Waypoint1.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Status)
            </td>
        </tr>
    Next

</table>

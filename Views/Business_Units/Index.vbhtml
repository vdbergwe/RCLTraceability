@ModelType IEnumerable(Of Intranet.Business_Units)
@Code
    ViewData("Title") = "Business Units"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Business Units"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
@If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) Then
@<div class="btn-toolbar btn-group">
    @Html.ActionLink("Add Business Unit", "Create", Nothing, New With {.class = "btn btn-success"})
</div>
End If
<Table Class="table">
    <tr>
    <th>
            @Html.DisplayNameFor(Function(model) model.BUCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>

    </tr>
    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "Business_Units", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.BUCode)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
        </tr>
    Next
</table>

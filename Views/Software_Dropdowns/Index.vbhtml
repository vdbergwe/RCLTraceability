@ModelType IEnumerable(Of Intranet.Software_Dropdowns)
@Code
    ViewData("Title") = "System types"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "System Types"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div class="btn-toolbar btn-group">
    @Html.ActionLink("Add New Type", "Create", Nothing, New With {.class = "btn btn-default"})
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Dropdown)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "Software_Dropdowns", New With {.Id = item.Id})'">
    <td>
        @Html.DisplayFor(Function(modelItem) item.Description)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Dropdown)
    </td>
</tr>
    Next

</table>

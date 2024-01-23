@ModelType IEnumerable(Of Intranet.Business_Units_Plants)
@Code
    ViewData("Title") = "Plants"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Plants"
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code

<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PlantCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Country)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "Business_Units_Plants", New With {.Id = item.Id})'">
    <td>
        @Html.DisplayFor(Function(modelItem) item.Description)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.PlantCode)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Country)
    </td>
</tr>
    Next
</table>

@ModelType IEnumerable(Of Intranet.Plants_Locations)

@Code
    ViewData("Title") = "Locations"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Locations"
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
<table class="table" width="100%">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Business_Units_Plants.Description)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "Plants_Locations", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Type)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Business_Units_Plants.Description)
            </td>
        </tr>
    Next

</table>

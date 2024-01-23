@ModelType IEnumerable(Of Intranet.Production_Batches)
@Code
    ViewData("Title") = "Batches"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Batches"
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
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BatchDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BatchCreated)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BatchEnded)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "Production_Batches", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Type)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Status)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.BatchDate).ToString.AsDateTime.ToShortDateString
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.BatchCreated)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.BatchEnded)
            </td>
        </tr>
    Next

</table>

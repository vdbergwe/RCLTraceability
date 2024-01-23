@ModelType IEnumerable(Of Intranet.Handling_Units_Movements)
@Code
ViewData("Title") = "Index"
End Code
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Created)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Handling_Units.SSCC)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="grow_row" onclick="location.href = '@Url.Action("Details", "Handling_Units", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.Created)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Type)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Status)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Handling_Units.SSCC)
            </td>
        </tr>
    Next

</table>

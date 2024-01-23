@ModelType IEnumerable(Of Intranet.Loadslips_Details)
@Code
ViewData("Title") = "Index"
End Code
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.HUDescription)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SSCC)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Loaded)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
    </tr>

@For Each item In Model
    @<tr>
    <td>
        @Html.DisplayFor(Function(modelItem) item.HUDescription)
    </td>
    <td  onclick="location.href = '@Url.Action("Details", "Handling_Units", New With {.Id = Nothing, .SSCC = item.SSCC})'">
        @Html.DisplayFor(Function(modelItem) item.SSCC)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Loaded)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Status)
    </td>
</tr>
Next

</table>

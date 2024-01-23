@ModelType IEnumerable(Of Intranet.Stock)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layoutv2.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Code)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Grouping)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SubGrouping)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UoM)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CostPerUnit)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FlagMin)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FlagOrder)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FlagMax)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.OrderQty)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Created)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Business_Units_Plants.Description)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Code)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Type)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Grouping)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SubGrouping)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UoM)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CostPerUnit)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FlagMin)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FlagOrder)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FlagMax)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.OrderQty)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Status)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Created)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CreatedBy)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Business_Units_Plants.Description)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>

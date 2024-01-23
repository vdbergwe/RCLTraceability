@ModelType IEnumerable(Of Intranet.Software_Packages)
@Code
    ViewData("Title") = "Index"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Software Packages</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
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
            @Html.DisplayNameFor(Function(model) model.Version)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ReleaseDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ExpiryDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PackageLocation)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PackageExecuteScriptLocation)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
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
            @Html.DisplayFor(Function(modelItem) item.Version)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ReleaseDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExpiryDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PackageLocation)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PackageExecuteScriptLocation)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>

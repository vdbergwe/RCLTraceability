@ModelType IEnumerable(Of Intranet.Software_Services)
@Code
    ViewData("Title") = "Services"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Services"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div class="btn-toolbar btn-group">
    @Html.ActionLink("Add Service", "Create", Nothing, New With {.class = "btn btn-default"})
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EndpointUrl)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.HostName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IP)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Status)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Type)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.EndpointUrl)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.HostName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.IP)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
            </td>
        </tr>
    Next

</table>

@ModelType IEnumerable(Of Intranet.QC_Scales)
@Code
    ViewData("Title") = "QC Scales"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "QC Scales"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div class="btn-toolbar btn-group">
    @Html.ActionLink("Add QC Scale", "Create", Nothing, New With {.class = "btn btn-default"})
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Make)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Model)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LoadCapacity)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Device1.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Device1.Status)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "QC_Scales", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Make)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Model)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LoadCapacity)
                @Html.DisplayFor(Function(modelItem) item.UOM)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Device1.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Device1.Status)
            </td>
        </tr>
    Next

</table>

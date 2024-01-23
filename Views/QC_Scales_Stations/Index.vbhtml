@ModelType IEnumerable(Of Intranet.QC_Scales_Stations)
@Code
    ViewData("Title") = "Scale Stations"
    ViewBag.ViewIcon = "fa fa-scale"
    ViewBag.ViewTitle = "Scale Stations"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("New", "Create", Nothing, New With {.class = "btn btn-default"})
    </div>
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Functions)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Plants_Locations.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.QC_Scales.Description)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="grow_row" onclick="location.href = '@Url.Action("Details", New With {.Id = item.Id})'">
    <td>
        @Html.DisplayFor(Function(modelItem) item.Description)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Functions)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Plants_Locations.Description)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.QC_Scales.Description)
    </td>
</tr>
    Next

</table>

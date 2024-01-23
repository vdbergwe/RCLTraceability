@ModelType IEnumerable(Of Intranet.QC_Scales_Readings)
@Code
    ViewData("Title") = "QC Readings"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "QC Readings"
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("Search", "VOID", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("Export", "VOID", Nothing, New With {.class = "btn btn-default"})
    </div>
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.ReadingDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Product)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Operator)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Median)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Result)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.QC_Scales.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.QC_Scales_Stations.Description)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "QC_Scales_Readings", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.ReadingDate)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Product)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Operator)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Median)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Result)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.QC_Scales.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.QC_Scales_Stations.Description)
            </td>
        </tr>
    Next

</table>

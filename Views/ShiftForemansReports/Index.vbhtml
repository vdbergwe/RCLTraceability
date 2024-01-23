@ModelType IEnumerable(Of Intranet.ShiftForemansReport)
@Code
    ViewData("Title") = "Shift Foremans Report"
    ViewBag.ViewIcon = "fa fa-print"
    ViewBag.ViewTitle = "Shift Foremans Report"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
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
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Plants_Shifts.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Production_Batches.Description)
        </th>
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
                @Html.DisplayFor(Function(modelItem) item.Plants_Shifts.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Production_Batches.Description)
            </td>
        </tr>
    Next

</table>

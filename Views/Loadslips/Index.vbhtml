@ModelType IEnumerable(Of Intranet.Loadslip)
@Code
    ViewData("Title") = "Loadslips"
    ViewBag.ViewIcon = "fa fa-truck"
    ViewBag.ViewTitle = "Loadslips"
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
            @Html.DisplayNameFor(Function(model) model.LoadReference)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Driver)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Horse)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Notes)
        </th>

        <th>
            @Html.DisplayNameFor(Function(model) model.ToLocation)
        </th>

        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Type)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="grow_row" onclick="location.href = '@Url.Action("Details", "Loadslips", New With {.Id = item.Id})'">

            <td>
                @Html.DisplayFor(Function(modelItem) item.LoadReference)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Driver)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Horse)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.Notes)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.ToLocation)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.Status)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.Type)
            </td>
        </tr>
    Next

</table>

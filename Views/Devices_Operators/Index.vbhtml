@ModelType IEnumerable(Of Intranet.Devices_Operators)
@Code
    ViewData("Title") = "Operators"
    ViewBag.ViewIcon = "fa fa-users"
    ViewBag.ViewTitle = "Operators"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<p>
    @Html.ActionLink("Create New", "Create", Nothing, New With {.class = "btn btn-default"})
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Code)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FirstName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Code)
            </td>
        </tr>
    Next

</table>

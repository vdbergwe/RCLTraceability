@ModelType IEnumerable(Of Intranet.Product)
@Code
    ViewData("Title") = "Products"
    ViewBag.ViewIcon = "fa fa-products"
    ViewBag.ViewTitle = "Products"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<div class="btn-group">
    @Html.ActionLink("Create New", "Create", Nothing, New With {.class = "btn btn-default"})
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.PLU)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ConsumerBarcode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SalesUnitBarcode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ProducedBy)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
    </tr>
    @For Each item In Model
        @<tr class="grow_row" onclick="location.href = '@Url.Action("Details", "Products", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.PLU)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.ConsumerBarcode)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SalesUnitBarcode)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.ProducedBy)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Status)
            </td>
        </tr>
    Next
</table>

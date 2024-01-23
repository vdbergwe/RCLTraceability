@ModelType Intranet.Stock
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layoutv2.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Stock</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Grouping)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Grouping)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SubGrouping)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SubGrouping)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UoM)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UoM)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CostPerUnit)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CostPerUnit)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FlagMin)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FlagMin)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FlagOrder)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FlagOrder)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FlagMax)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FlagMax)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.OrderQty)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.OrderQty)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Created)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Created)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Business_Units_Plants.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_Units_Plants.Description)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>

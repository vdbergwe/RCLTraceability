@ModelType Intranet.Product
@Code
    ViewData("Title") = "Delete"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = Model.Description
End Code

<div>

    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PLU)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PLU)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Packaging)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Packaging)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ConsumerUnits)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ConsumerUnits)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SalesUnits)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SalesUnits)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TargetWeight)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TargetWeight)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UOM)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UOM)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TareWeight)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TareWeight)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ConsumerBarcode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ConsumerBarcode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SalesUnitBarcode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SalesUnitBarcode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Commodity)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Commodity)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ProducedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProducedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
    <input type="submit" value="Delete" class="btn btn-default" />
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-Default"})
</div>
    End Using
</div>

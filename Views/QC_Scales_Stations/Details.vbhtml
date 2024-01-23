@ModelType Intranet.QC_Scales_Stations
@Code
    ViewData("Title") = "Scale Stations"
    ViewBag.ViewIcon = "fa fa-scale"
    ViewBag.ViewTitle = "Scale Stations"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
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
            @Html.DisplayNameFor(Function(model) model.Functions)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Functions)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Plants_Locations.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Plants_Locations.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.QC_Scales.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.QC_Scales.Description)
        </dd>

    </dl>
</div>
<div class="btn-group">
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"})
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
    </div>

@ModelType Intranet.QC_Scales_Stations
@Code
    ViewData("Title") = "Scale Stations"
    ViewBag.ViewIcon = "fa fa-scale"
    ViewBag.ViewTitle = "Scale Stations"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
    <input type="submit" value="Delete" class="btn btn-default" /> 
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-Default"})
</div>
    End Using
</div>

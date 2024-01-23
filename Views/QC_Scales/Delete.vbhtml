@ModelType Intranet.QC_Scales
@Code
    ViewData("Title") = "QC Scales"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "QC Scales"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>QC_Scales</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Make)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Make)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Model)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Model)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LoadCapacity)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LoadCapacity)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UOM)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UOM)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Device1.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Device1.Description)
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

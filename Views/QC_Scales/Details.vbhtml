@ModelType Intranet.QC_Scales
@Code
    ViewData("Title") = " "
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = " "
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("View Device", "Details", "Devices", New With {.id = Model.Device.ToString()}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id.ToString()}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
    </div>
</div>
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
        @Html.DisplayFor(Function(model) model.LoadCapacity) @Html.DisplayFor(Function(model) model.UOM)
    </dd>
    <dt>
        @Html.DisplayNameFor(Function(model) model.Device1.Description)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.Device1.Description)
    </dd>

</dl>
<h4>
    Readings
</h4>
<div>
    @Html.Action("Index", "QC_Scales_Readings", New With {.IsPartial = True, .Id = Model.Id, .FilterBy = "Scale"})
</div>
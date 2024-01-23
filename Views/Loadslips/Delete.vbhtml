@ModelType Intranet.Loadslip
@Code
    ViewData("Title") = "Loadslips"
    ViewBag.ViewIcon = "fa fa-truck"
    ViewBag.ViewTitle = "Loadslips"
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
<h3>Are you sure you want to delete this?</h3>
<div>
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.LoadReference)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LoadReference)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Driver)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Driver)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Horse)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Horse)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Trailer)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Trailer)
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
            @Html.DisplayNameFor(Function(model) model.Notes)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Notes)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantId)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantId)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FromLocation)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FromLocation)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ToLocation)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ToLocation)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsFullLoad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsFullLoad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsSharedLoad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsSharedLoad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Transporter)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Transporter)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LoadedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LoadedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Loaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Loaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
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

@ModelType Intranet.Loadslip
@Code
    ViewData("Title") = Model.LoadReference.ToString()
    ViewBag.ViewIcon = "fa fa-truck"
    ViewBag.ViewTitle = Model.Type.ToString() + " | " + Model.LoadReference.ToString() + " | " + Model.Status.ToString()
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
<div>
    <dl class="dl-horizontal">
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



    </dl>
</div>
<div>
    @Html.Action("Index", "Loadslips_Details", New With {.LoadId = Model.Id, .Status = "Loaded"})
</div>

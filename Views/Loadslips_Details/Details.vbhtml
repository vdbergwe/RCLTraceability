@ModelType Intranet.Loadslips_Details
@Code
    ViewData("Title") = "Details"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Details</h2>

<div>
    <h4>Loadslips_Details</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.SSCC)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SSCC)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Loaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Loaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LoadId)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LoadId)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>

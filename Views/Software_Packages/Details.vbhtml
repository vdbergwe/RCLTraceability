@ModelType Intranet.Software_Packages
@Code
    ViewData("Title") = "Details"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Details</h2>

<div>
    <h4>Software_Packages</h4>
    <hr />
    <dl class="dl-horizontal">
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
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Version)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Version)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ReleaseDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ReleaseDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ExpiryDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExpiryDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PackageLocation)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PackageLocation)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PackageExecuteScriptLocation)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PackageExecuteScriptLocation)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>

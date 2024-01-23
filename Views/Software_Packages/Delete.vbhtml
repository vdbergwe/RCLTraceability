@ModelType Intranet.Software_Packages
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>

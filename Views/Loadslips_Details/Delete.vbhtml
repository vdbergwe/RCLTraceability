@ModelType Intranet.Loadslips_Details
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>

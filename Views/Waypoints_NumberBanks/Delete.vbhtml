@ModelType Intranet.Waypoints_NumberBanks
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Waypoints_NumberBanks</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Prefix)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Prefix)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Bank)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Bank)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Root)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Root)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FirstNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FirstNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LastNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LastNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LastIssued)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LastIssued)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Created)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Created)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Reserved)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Reserved)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Released)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Released)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Depleted)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Depleted)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Waypoint)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Waypoint)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
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

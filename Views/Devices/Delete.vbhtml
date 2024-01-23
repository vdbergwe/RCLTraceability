@ModelType Intranet.Device
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Device</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IP)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IP)
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
            @Html.DisplayNameFor(Function(model) model.MAC)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MAC)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SwitchPort)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SwitchPort)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Switch)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Switch)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SerialNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SerialNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Plants_Locations.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Plants_Locations.Description)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
    <input type="submit" value="Delete" class="btn btn-default" /> 
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
</div>
    End Using
</div>

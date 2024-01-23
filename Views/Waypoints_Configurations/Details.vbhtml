@ModelType Intranet.Waypoints_Configurations
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layoutv2.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>Waypoints_Configurations</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.SettingName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SettingName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SettingValue)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SettingValue)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SettingType)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SettingType)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SettingGroup)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SettingGroup)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SettingSubGroup)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SettingSubGroup)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Active)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Active)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsGlobalSetting)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsGlobalSetting)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Waypoint1.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Waypoint1.Description)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>

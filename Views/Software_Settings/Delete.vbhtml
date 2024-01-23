@ModelType Intranet.Software_Settings
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Software_Settings</h4>
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

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
    <input type="submit" value="Delete" class="btn btn-default" />
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-Default"})
</div>
    End Using
</div>

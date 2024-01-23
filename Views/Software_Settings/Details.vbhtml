@ModelType Intranet.Software_Settings
@Code
    ViewData("Title") = "Details"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Details</h2>

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
</div>
<div class="btn-group">
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"}) 
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
</div>

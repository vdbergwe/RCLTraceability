@ModelType IEnumerable(Of Intranet.Waypoints_Configurations)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layoutv2.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingValue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingType)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingGroup)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingSubGroup)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Active)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsGlobalSetting)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Waypoint1.Description)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SettingName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SettingValue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SettingType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SettingGroup)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SettingSubGroup)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Active)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsGlobalSetting)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Waypoint1.Description)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>

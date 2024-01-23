@ModelType IEnumerable(Of Intranet.Software_Settings)
@Code
    ViewData("Title") = "Software Settings"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Software Settings"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div class="btn-toolbar btn-group">
    @Html.ActionLink("Add New Setting", "Create", Nothing, New With {.class = "btn btn-default"})
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingValue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingGroup)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SettingSubGroup)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Details", "Software_Settings", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.SettingName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SettingValue)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SettingGroup)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SettingSubGroup)
            </td>
        </tr>
    Next

</table>

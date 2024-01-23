@ModelType IEnumerable(Of Intranet.Device)
@Code
    ViewData("Title") = "Devices"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Devices"
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
@If ViewBag.IsPartial = False Then
    @<div class="btn-toolbar btn-group">
        @Html.ActionLink("Add Device", "Create", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("Online", "Index", New With {.FilterBy = "Online"}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Offline", "Index", New With {.FilterBy = "Offline"}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Waypoints", "Index", New With {.FilterBy = "Waypoints"}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Scales", "Index", New With {.FilterBy = "Scales"}, New With {.class = "btn btn-default"})
    </div>
End If
<div overflow="auto">
    <table Class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Description)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.IP)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Type)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Status)
            </th>
            @If ViewBag.IsPartial = False Then
                @<th>
                    @Html.DisplayNameFor(Function(model) model.MAC)
                </th>
                @<th>
                    @Html.DisplayNameFor(Function(model) model.SwitchPort)
                </th>
                @<th>
                    @Html.DisplayNameFor(Function(model) model.Switch)
                </th>
            End If
        </tr>
        @For Each item In Model
            @<tr class="menu_Card grow_row" onclick="location.href = '@Url.Action("Edit", "Devices", New With {.Id = item.Id})'">
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Description)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.IP)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Type)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Status)
                </td>
                @If ViewBag.IsPartial = False Then
                    @<td>
                        @Html.DisplayFor(Function(modelItem) item.MAC)
                    </td>
                    @<td>
                        @Html.DisplayFor(Function(modelItem) item.SwitchPort)
                    </td>
                    @<td>
                        @Html.DisplayFor(Function(modelItem) item.Switch)
                    </td>
                End If
            </tr>
        Next

    </table>
</div>
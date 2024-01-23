@ModelType IEnumerable(Of Intranet.Plants_Shifts)
@Code
    ViewData("Title") = "Shifts"
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Shifts"
    @If ViewBag.IsPartial = False Or IsNothing(ViewBag.IsPartial) = True Then
        Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
    End If
End Code
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StartTime)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EndTime)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Mon)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Tue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Wed)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Thu)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fri)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Sat)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Sun)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Active)
        </th>
    </tr>

    @For Each item In Model
        @<tr class="grow_row" onclick="location.href = '@Url.Action("Details", "Plants_Shifts", New With {.Id = item.Id})'">
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.StartTime).ToString.AsDateTime.ToShortTimeString
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.EndTime).ToString.AsDateTime.ToShortTimeString
            </td>
            <td>
                @If item.Mon = True Then
                    @<i class="glyphicon glyphicon-check"></i>
                End If
            </td>
            <td>
                @If item.Tue = True Then
                    @<i class="glyphicon glyphicon-check"></i>
                End If
            </td>
            <td>
                @If item.Wed = True Then
                    @<i class="glyphicon glyphicon-check"></i>
                End If
            </td>
            <td>
                @If item.Thu = True Then
                    @<i class="glyphicon glyphicon-check"></i>
                End If
            </td>
            <td>
                @If item.Fri = True Then
                    @<i class="glyphicon glyphicon-check"></i>
                End If
            </td>
            <td>
                @If item.Sat = True Then
                    @<i class="glyphicon glyphicon-check"></i>
                End If
            </td>
            <td>
                @If item.Sun = True Then
                    @<i class="glyphicon glyphicon-check"></i>
                End If
            </td>
            <td>
                @If item.Active = True Then
                    @<i class="glyphicon glyphicon-check"></i>
                End If
            </td>
        </tr>
    Next

</table>

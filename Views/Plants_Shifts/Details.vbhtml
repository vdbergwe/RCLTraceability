@ModelType Intranet.Plants_Shifts
@Code
    ViewData("Title") = Model.Business_Units_Plants.Description & " | " & Model.Description
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Plants"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")

End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("Start Batch", "Create", "Production_Batches", New With {.id = Model.Business_Units_Plants.Id}, New With {.class = "btn btn-default"})
    </div>
</div>
<dl class="dl-horizontal">
    <dt>
        @Html.DisplayNameFor(Function(model) model.Description)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.Description)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.StartTime)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.StartTime)
    </dd>

    <dt>
        @Html.DisplayNameFor(Function(model) model.EndTime)
    </dt>

    <dd>
        @Html.DisplayFor(Function(model) model.EndTime)
    </dd>
</dl>
<table class="table">
    <tr>
        <td>
            Monday
        </td>
        <td>
            Tuesday
        </td>
        <td>
            Wednesday
        </td>
        <td>
            Thursday
        </td>
        <td>
            Friday
        </td>
        <td>
            Saturday
        </td>
        <td>
            Sunday
        </td>
    </tr>
    <tr>
        <td>
            @If Model.Mon = True Then
                @<i class="glyphicon glyphicon-check"></i>
            End If
        </td>
        <td>
            @If Model.Tue = True Then
                @<i class="glyphicon glyphicon-check"></i>
            End If
        </td>
        <td>
            @If Model.Wed = True Then
                @<i class="glyphicon glyphicon-check"></i>
            End If
        </td>
        <td>
            @If Model.Thu = True Then
                @<i class="glyphicon glyphicon-check"></i>
            End If
        </td>
        <td>
            @If Model.Fri = True Then
                @<i class="glyphicon glyphicon-check"></i>
            End If
        </td>
        <td>
            @If Model.Sat = True Then
                @<i class="glyphicon glyphicon-check"></i>
            End If
        </td>
        <td>
            @If Model.Sun = True Then
                @<i class="glyphicon glyphicon-check"></i>
            End If
        </td>
    </tr>
</table>
<h4>
    Batches
</h4>
<div>
    @Html.Action("Index", "Production_Batches", New With {.IsPartial = True, .Id = Model.Id})
</div>
@ModelType Intranet.Plants_Shifts
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout_Split_Index.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Plants_Shifts</h4>
    <hr />
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

        <dt>
            @Html.DisplayNameFor(Function(model) model.Mon)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Mon)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tue)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tue)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Wed)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Wed)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Thu)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Thu)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fri)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fri)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sat)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sat)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sun)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sun)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Active)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Active)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Business_Units_Plants.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_Units_Plants.Description)
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

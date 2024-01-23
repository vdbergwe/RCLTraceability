@ModelType Intranet.Plants_Locations
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout_Split_Index.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Plants_Locations</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
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

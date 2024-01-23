@ModelType Intranet.Software_Dropdowns
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Software_Dropdowns</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Dropdown)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Dropdown)
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

@ModelType Intranet.Production_Batches
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Production_Batches</h4>
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
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BatchDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BatchDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BatchCreated)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BatchCreated)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BatchEnded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BatchEnded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Plants_Shifts.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Plants_Shifts.Description)
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

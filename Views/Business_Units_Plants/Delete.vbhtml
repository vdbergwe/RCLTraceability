@ModelType Intranet.Business_Units_Plants
@Code
    ViewData("Title") = "Are you sure you want to delete this?"
    Layout = "~/Views/Shared/_Layout_Split_Index.vbhtml"
End Code

<div>
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Business_Units.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_Units.Description)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" />
            @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
        </div>
    End Using
</div>

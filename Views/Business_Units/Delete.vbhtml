@ModelType Intranet.Business_Units
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
            @Html.DisplayNameFor(Function(model) model.BUCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BUCode)
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

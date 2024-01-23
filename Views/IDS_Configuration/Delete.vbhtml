@ModelType Intranet.IDS_Configuration
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout_Split_Index.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>IDS_Configuration</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Title)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Title)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Device.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Device.Description)
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

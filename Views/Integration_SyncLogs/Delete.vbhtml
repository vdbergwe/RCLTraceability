@ModelType Intranet.Integration_SyncLogs
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layoutv2.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Integration_SyncLogs</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Created)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Created)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SourceSystem)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SourceSystem)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DestinationSystem)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DestinationSystem)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SyncScope)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SyncScope)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>

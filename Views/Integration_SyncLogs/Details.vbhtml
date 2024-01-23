@ModelType Intranet.Integration_SyncLogs
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layoutv2.vbhtml"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>

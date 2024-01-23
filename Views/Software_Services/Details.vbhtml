@ModelType Intranet.Software_Services
@Code
    ViewData("Title") = "Details"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Details</h2>

<div>
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
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
            @Html.DisplayNameFor(Function(model) model.EndpointUrl)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EndpointUrl)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.HostName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.HostName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IP)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IP)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>

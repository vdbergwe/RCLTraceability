﻿@ModelType Intranet.Software_Services
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Service</h4>
    <hr />
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>

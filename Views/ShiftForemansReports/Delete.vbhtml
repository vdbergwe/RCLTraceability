﻿@ModelType Intranet.ShiftForemansReport
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layoutv2.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>ShiftForemansReport</h4>
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
            @Html.DisplayNameFor(Function(model) model.Business_Units_Plants.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_Units_Plants.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Plants_Shifts.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Plants_Shifts.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Production_Batches.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Production_Batches.Description)
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

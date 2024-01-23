@ModelType Intranet.IDS_Configuration
@Code
    ViewData("Title") = "Details"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")

End Code

<h2>Details</h2>

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
</div>
<div class="btn-group">
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"}) 
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
    </div>

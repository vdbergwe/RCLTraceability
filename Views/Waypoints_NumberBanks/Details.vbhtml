@ModelType Intranet.Waypoints_NumberBanks
@Code
    ViewData("Title") = "Details"
    ViewBag.ViewTitle = Model.Prefix & Model.Bank & Model.Root
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div>
    <dl class="dl-horizontal">

        <dt>
            @Html.DisplayNameFor(Function(model) model.FirstNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FirstNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LastNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LastNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LastIssued)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LastIssued)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Created)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Created)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Reserved)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Reserved)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Released)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Released)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Depleted)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Depleted)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Waypoint)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Waypoint)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>


    </dl>
</div>
<div class="btn-group">
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"}) 
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
</div>

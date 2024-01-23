@ModelType Intranet.Software_Dropdowns
@Code
    ViewData("Title") = "Details"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Details</h2>

<div>
    <h4>Software_Dropdowns</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Dropdown)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Dropdown)
        </dd>

    </dl>
</div>
<div class="btn-group">
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"}) 
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-Default"})
    </div>

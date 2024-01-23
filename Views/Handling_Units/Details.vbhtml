@ModelType Intranet.Handling_Units
@Code
    ViewData("Title") = Model.Product1.Description + " | " + Model.SSCC
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = Model.Product1.Description + " | " + Model.SSCC
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")

End Code

<div class="splitgrid-container">
    <div>
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.SSCC)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.SSCC)
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
                @Html.DisplayNameFor(Function(model) model.Status)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Status)
            </dd>


            <dt>
                @Html.DisplayNameFor(Function(model) model.Production_Batches.Description)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Production_Batches.Description)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Product1.Description)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Product1.Description)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Waypoints_NumberBanks.Bank)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Waypoints_NumberBanks.Bank)
            </dd>
        </dl>
    </div>
    <div class="rightcolum">
        <h4>
            Movement History
        </h4>
        @Html.Action("Index", "Handling_Units_Movements", New With {.id = Model.Id, .FilterBy = "Handling Unit", .IsPartial = True})
    </div>
</div>

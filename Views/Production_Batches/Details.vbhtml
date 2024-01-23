@ModelType Intranet.Production_Batches
@Code
    ViewData("Title") = Model.Plants_Shifts.Business_Units_Plants.Description & " | " & Model.Plants_Shifts.Description & " | " & Model.Description
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = Model.Plants_Shifts.Business_Units_Plants.Description & " | " & Model.Plants_Shifts.Description & " | " & Model.Description
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
    </div>
    <div class="btn-group">
        @Html.ActionLink("Shift Report", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"})
    </div>
</div>
<div class="splitgrid-container">
    <div>
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.Type)
            </dt>
            <dd>
                @Html.DisplayFor(Function(model) model.Type)
            </dd>
            <dt>
                @Html.DisplayNameFor(Function(model) model.Status)
            </dt>
            <dd>
                @Html.DisplayFor(Function(model) model.Status)
            </dd>
            <dt>
                @Html.DisplayNameFor(Function(model) model.BatchDate)
            </dt>
            <dd>
                @Html.DisplayFor(Function(model) model.BatchDate)
            </dd>
            <dt>
                @Html.DisplayNameFor(Function(model) model.BatchCreated)
            </dt>
            <dd>
                @Html.DisplayFor(Function(model) model.BatchCreated)
            </dd>
            <dt>
                @Html.DisplayNameFor(Function(model) model.BatchEnded)
            </dt>
            <dd>
                @Html.DisplayFor(Function(model) model.BatchEnded)
            </dd>
            <dt>
                @Html.DisplayNameFor(Function(model) model.Plants_Shifts.Business_Units_Plants.Description)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Plants_Shifts.Business_Units_Plants.Description)
            </dd>
            <dt>
                @Html.DisplayNameFor(Function(model) model.Plants_Shifts.Description)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Plants_Shifts.Description)
            </dd>
        </dl>
    </div>
    <div class="rightcolum">
        <div>
            <h4>
                QC Readings
            </h4>
            <div>
                @Html.Action("Index", "QC_Scales_Readings", New With {.IsPartial = True, .Id = Model.Id, .FilterBy = "Batch"})
            </div>
        </div>
        <div>
            <h4>
                Handling Units
            </h4>
            <div>
                @Html.Action("Index", "Handling_Units", New With {.IsPartial = True, .Id = Model.Id, .FilterBy = "Batch"})
            </div>
        </div>
    </div>
</div>
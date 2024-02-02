@ModelType Intranet.Business_Units_Plants
@Code
    ViewData("Title") = Model.PlantCode & " | " & Model.Description & " | " & Model.Country
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = Model.PlantCode & " | " & Model.Description & " | " & Model.Country
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("Add Shift", "Create", "Plants_Shifts", New With {.id = Model.Id}, New With {.class = "btn btn-success"})
        @Html.ActionLink("Add Location", "Create", "Plants_Locations", New With {.id = Model.Id}, New With {.class = "btn btn-success"})
        @Html.ActionLink("Start Batch", "Create", "Production_Batches", New With {.id = Model.Id}, New With {.class = "btn btn-success"})
        @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-warning"})
        @Html.ActionLink("Delete", "Delete", New With {.id = Model.Id}, New With {.class = "btn btn-warning"})
        @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
    </div>
</div>
<div>
    <div>
        <h4 data-bs-target="#PSh" data-bs-toggle="collapse" class="panel-heading">
            Shifts
        </h4>
        <div id="PSh" class="collapse">
            @Html.Action("Index", "Plants_Shifts", New With {.IsPartial = True, .Id = Model.Id, .FilterBy = "PL"})
        </div>
        <h4 data-bs-target="#PLo" data-bs-toggle="collapse" class="panel-heading">
            Locations
        </h4>
        <div id="PLo" class="collapse">
            @Html.Action("Index", "Plants_Locations", New With {.IsPartial = True, .Id = Model.Id, .FilterBy = "PL"})
        </div>
        <h4 data-bs-target="#PB" data-bs-toggle="collapse" class="panel-heading">
            Batches
        </h4>
        <div id="PB" class="collapse">
            @Html.Action("Index", "Production_Batches", New With {.IsPartial = True, .Id = Model.Id, .FilterBy = "PL"})
        </div>
        <h4 data-bs-target="#PNR" data-bs-toggle="collapse" class="panel-heading">
            Devices
        </h4>
        <div id="PNR" class="collapse">
            @Html.Action("Index", "Devices", New With {.IsPartial = True, .Id = Model.Id, .FilterBy = "PL"})
        </div>
        <h4 data-bs-target="#PPR" data-bs-toggle="collapse" class="panel-heading">
            Products
        </h4>
        <div id="PPR" class="collapse">
            @Html.Action("Index", "Production_Batches", New With {.IsPartial = True, .Id = Model.Id})
        </div>
    </div>

</div>
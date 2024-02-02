@ModelType Intranet.Business_Units
@Code
    ViewData("Title") = Model.BUCode & " | " & Model.Description
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = "Business Units"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code
<link href="~/Content/lazarus_main.css" rel="stylesheet" />
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("Add Plant", "Create", "Business_Units_Plants", New With {.id = Model.Id}, New With {.class = "btn btn-success"})
        @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-warning"})
        @Html.ActionLink("Delete", "Delete", New With {.id = Model.Id}, New With {.class = "btn btn-warning"})
        @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-info"})
    </div>
</div>
<h4 data-bs-target="#BP" data-bs-toggle="collapse" class="panel-heading">
    Plants
</h4>
<div id="BP" class="collapse">
    @Html.Action("Index", "Business_Units_Plants", New With {.IsPartial = True, .Id = Model.Id})
</div>
<h4 data-bs-target="#BL" data-bs-toggle="collapse" class="panel-heading">
    Locations
</h4>
<div id="BL" class="collapse">
    @Html.Action("Index", "Plants_Locations", New With {.IsPartial = True, .Id = Model.Id})
</div>
<h4 data-bs-target="#BD" data-bs-toggle="collapse" class="panel-heading">
    Devices
</h4>
<div id="BD" class="collapse">
    @Html.Action("Index", "Devices", New With {.IsPartial = True, .Id = Model.Id, .FilterBy = "BU"})
</div>
@ModelType Intranet.Plants_Locations
@Code
    ViewData("Title") = Model.Business_Units_Plants.Description & " | " & Model.Description
    ViewBag.ViewIcon = "fa fa-gear"
    ViewBag.ViewTitle = Model.Business_Units_Plants.Description & " | " & Model.Description
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")

End Code
<div class="btn-toolbar">
    <div class="btn-group">
        @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-default"})
        @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
    </div>
</div>
<h4>
    Devices
</h4>
<div>
    @Html.Action("Index", "Devices", New With {.IsPartial = True, .Id = Model.Id})
</div>
@ModelType Intranet.Business_Units_Plants
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout_Split_Index.vbhtml"
End Code
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.Id)

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.BusinessUnit, "BusinessUnit", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownList("BusinessUnit", Nothing, htmlAttributes:=New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.BusinessUnit, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.PlantCode, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.PlantCode, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.PlantCode, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Country, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Country, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Country, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10 btn-group">
            <input type="submit" value="Save" class="btn btn-default" />
            @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
        </div>
    </div>
</div>
End Using


@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section

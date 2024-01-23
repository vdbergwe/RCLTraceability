@ModelType Intranet.Production_Batches
@Code
    ViewData("Title") = "Start New Batch"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h1>
    Starting New Batch
</h1>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
         <div class="form-group">
             @Html.LabelFor(Function(model) model.Plant, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.Plant, New With {.htmlAttributes = New With {.class = "form-control", .readonly = True}})
                 @Html.ValidationMessageFor(Function(model) model.Plant, "", New With {.class = "text-danger"})
             </div>
         </div>    
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Description, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Description, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Description, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Type, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Type, New With {.htmlAttributes = New With {.class = "form-control", .readonly = True}})
                @Html.ValidationMessageFor(Function(model) model.Type, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Status, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Status, New With {.htmlAttributes = New With {.class = "form-control", .readonly = True}})
                @Html.ValidationMessageFor(Function(model) model.Status, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Shift, "Shift", htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("Shift", Nothing, htmlAttributes:= New With { .class = "form-control" })
                @Html.ValidationMessageFor(Function(model) model.Shift, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BatchDate, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BatchDate, New With {.htmlAttributes = New With {.class = "form-control", .type = "date"}})
                @Html.ValidationMessageFor(Function(model) model.BatchDate, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BatchCreated, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BatchCreated, New With {.htmlAttributes = New With {.class = "form-control", .readonly = True}})
                @Html.ValidationMessageFor(Function(model) model.BatchCreated, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BatchEnded, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BatchEnded, New With {.htmlAttributes = New With {.class = "form-control", .readonly = True}})
                @Html.ValidationMessageFor(Function(model) model.BatchEnded, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10 btn-group">
                <input type="submit" value="Create" class="btn btn-default" />
                @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default"})
            </div>
        </div>
    </div>
End Using
@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section

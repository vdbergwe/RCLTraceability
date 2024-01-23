@ModelType Intranet.QC_Scales_Readings
@Code
    ViewData("Title") = "Delete"
    Layout = ("~/Views/Shared/_Layoutv2.vbhtml")
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>QC_Scales_Readings</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.ReadingDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ReadingDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Product)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Product)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Operator)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Operator)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.S1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.S1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.S2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.S2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.S3)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.S3)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.S4)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.S4)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Median)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Median)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tare)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tare)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Result)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Result)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Result_Action)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Result_Action)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Target)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Target)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Batch)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Batch)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UOM)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UOM)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.QC_Scales.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.QC_Scales.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.QC_Scales_Stations.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.QC_Scales_Stations.Description)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
    <input type="submit" value="Delete" class="btn btn-default" />
    @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-Default"})
</div>
    End Using
</div>

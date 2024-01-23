@ModelType LoginViewModel
@Code
    ViewBag.Title = "Log in"
End Code
@Styles.Render("~/Content/css")
<style>
    body {
        padding-top: 50px;
        padding-bottom: 20px;
        color: goldenrod;
        overflow: hidden auto;
        background-image: linear-gradient(-225deg, #0b3f92 50%, dodgerblue 50%);
        background-image: linear-gradient(-225deg, #0b3f92 25%, dodgerblue 75%);
        height: 80vh;
    }

    .login_form_main {
        color: white;
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        width: 450px;
        min-height: 500px;
        height: 50vh;
        border-radius: 5px;
        box-shadow: 0 9px 50px hsla(20, 67%, 75%, 0.31);
        padding: 2%;
        background-color: #1e1e1e;
        opacity: 95%
    }

    @@media only screen and (max-width: 600px) {
        .login_form_main {
            margin-top: 60px;
            color: white;
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 450px;
            min-height: 500px;
            height: 50vh;
            border-radius: 5px;
            box-shadow: 0 9px 50px hsla(20, 67%, 75%, 0.31);
            opacity: 95%
        }
    }

    .control-label {
        padding: 5px;
    }
</style>
<div class="background_login">
    <div class="col-md-8">
        <section id="loginForm">
            @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @<text>
                    <div class="login_form_main">
                        <div class="" style="text-align:center; padding-bottom:5vh"> <h2>Login </h2> </div>
                        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                        <div class="form-group">
                            @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 control-label"})
                            <div class="col-md-10">
                                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label"})
                            <div class="col-md-10">
                                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <div class="checkbox">
                                    <div style="display:grid; grid-template-columns:1fr 1fr">
                                        <div style="line-height:5vh;">@Html.LabelFor(Function(m) m.RememberMe) </div>
                                        <div>@Html.CheckBoxFor(Function(m) m.RememberMe) </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <input type="submit" value="Log in" class="btn btn-default" />
                            </div>
                        </div>
                        @* Enable this once you have account confirmation enabled for password reset functionality
                            <p>
                            @Html.ActionLink("Forgot your password?", "ForgotPassword")
                            </p>*@
                </text>
            End Using
        </div>
    </section>
</div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section

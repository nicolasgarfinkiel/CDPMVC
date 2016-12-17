<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CDP.Master" Inherits="System.Web.Mvc.ViewPage<CDP.Models.ChoferModel>" %>

<%@ Import Namespace="CDP.Helpers" %>
<%@ Import Namespace="CDP.Common" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Carta de Porte
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Scripts.Render("~/bundles/Chofer") %>
    <script src="../../Content/bower_components/jquery/dist/jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            var Chofer = angular.module('Chofer', []);
            Chofer.controller('LandingPageController', LandingPageController);
        });
    </script>
    <div class="content-page">
        <div class="content">
            <div class="container">
                <div class="page-header">
                    <h3 class="page-title">Administración de Choferes</h3>
                    <ol class="breadcrumb">
                        <li><a>CDP</a></li>
                        <li><a>Adminitración</a></li>
                        <li class="active">Chofer</li>
                    </ol>
                </div>

                <input type="text" ng-model="helloAngular" />
                <h1>{{helloAngular}}</h1>


            </div>
        </div>
    </div>
</asp:Content>

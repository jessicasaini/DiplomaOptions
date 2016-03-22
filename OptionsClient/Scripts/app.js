function ViewModel() {
    var self = this;

    var tokenKey = 'accessToken';

    self.result = ko.observable();
    self.user = ko.observable();

    self.registerUsername = ko.observable();
    self.registerEmail = ko.observable();
    self.registerPassword = ko.observable();
    self.registerPassword2 = ko.observable();

    self.loginUsername = ko.observable();
    self.loginPassword = ko.observable();

    function showError(jqXHR) {
        self.result(jqXHR.status + ': ' + jqXHR.statusText);
    }

    self.callApi = function () {
        self.result('');

        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'GET',
            url: '/api/values',
            headers: headers
        }).done(function (data) {
            self.result(data);
        }).fail(showError);
    }

    self.register = function () {
        self.result('');

        var data = {
            Username: self.registerUsername(),
            Email: self.registerEmail(),
            Password: self.registerPassword(),
            ConfirmPassword: self.registerPassword2()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56503/api/Account/Register',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data)
        }).done(function (data) {
            self.result("Done!");
        }).fail(showError);
    }

    self.login = function () {
        self.result('');

        var loginData = {
            grant_type: 'password',
            username: self.loginUsername(),
            password: self.loginPassword()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56503/Token',
            data: loginData
        }).done(function (data) {
            self.user(data.userName);
            // Cache the access token in session storage.
            sessionStorage.setItem(tokenKey, data.access_token);
            console.log("success")
            console.log(data)
        }).fail(showError);
    }

    self.getStuff = function () {
        self.result('');

        $.ajax({
            type: 'GET',
            url: 'http://localhost:56503/api/Choices',
        }).done(function (data) {
            console.log("success")
            console.log(data)
        }).fail(showError);
    }

    self.logout = function () {
        self.user('');
        sessionStorage.removeItem(tokenKey)
    }
}

var x = new ViewModel();
ko.applyBindings(x);



//var onSuccess = function (response) {
//    console.log(response)
//};

//var onFailure = function (failed) {
//    console.log(failed)
//}

//var app = angular.module('myApp', []);
//app.controller('myCtrl', function($scope, $http) {
//    $http.get("http://localhost:56503/api/Choices")
//    .then(onSuccess,onFailure);
//});
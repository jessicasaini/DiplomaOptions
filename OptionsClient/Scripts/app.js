var app = angular.module('myApp', []);


app.controller('myCtrl', function ($scope, $http, $window) {

    var tokenKey = 'accessToken';
    var userName = 'userName';

    if (sessionStorage.getItem(tokenKey) != null) {
        $scope.token = sessionStorage.getItem(tokenKey);
    }
    if (sessionStorage.getItem(userName) != null) {
        $scope.username = sessionStorage.getItem(userName);
    }

    $scope.login = function () {
        console.log("logging in");
        var data = $.param({
            username: $scope.username,
            password: $scope.password,
            grant_type: 'password'
        });

        var onSuccess = function (response) {
            //TODO fill this out
            console.log("success");
            console.log(response)

            // Cache the access token in session storage.
            sessionStorage.setItem(userName, response.data.userName);
            sessionStorage.setItem(tokenKey, response.data.access_token);
            $window.location.reload();
        }

        var onFailure = function (response) {
            //TODO fill this out
            console.log("failed");
            console.log(response);
            $("#loginError").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>" + response.data.error_description + "</div>");

        }

        $http.post("http://localhost:56503/Token", data).then(onSuccess, onFailure);
    };

    $scope.register = function () {
        var data = $.param({
            Username: $scope.username,
            Email: $scope.email,
            Password: $scope.password,
            ConfirmPassword: $scope.password2
        });

        var postObject = new Object();
        postObject.Username = $scope.username;
        postObject.Email = $scope.email;
        postObject.Password = $scope.password;
        postObject.ConfirmPassword = $scope.password2

        var onSuccess = function (response) {
            //TODO fill this out
            console.log("success");
            console.log(response)

            $scope.login();
        }

        var onFailure = function (response) {
            //TODO fill this out
            console.log("failed");
            console.log(response);

            var str = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>";
            if (response.data.error_description) {

                str += response.data.error_description;
            }
            str += "<div>";

        }

        $http.post("http://localhost:56503/api/Account/Register", JSON.stringify(postObject)).then(onSuccess, onFailure);
    };

    $scope.select = function () {
        console.log($scope.user);
        console.log($scope.firstChoice);
        console.log($scope.secondChoice);
        console.log($scope.thirdChoice);
        console.log($scope.fourthChoice.OptionId);

        var token = sessionStorage.getItem(tokenKey)
        var headers = {}
        if(token) {
            headers.Authorization = 'Bearer ' + token;
            $http.defaults.headers.common.Authorization = 'bearer ' + token;
        }

        var postObject = new Object();
        postObject.YearTermId = 4;
        postObject.StudentId = $scope.username
        postObject.StudentFirstName = $scope.firstName;
        postObject.StudentLastName = $scope.lastName;
        postObject.ConfirmPassword = $scope.password2
        postObject.FirstChoiceOptionId = $scope.firstChoice.OptionId;
        postObject.SecondChoiceOptionId = $scope.secondChoice.OptionId;
        postObject.ThirdChoiceOptionID = $scope.thirdChoice.OptionId;
        postObject.FourthChoiceOptionId = $scope.fourthChoice.OptionId;

        var onSuccess = function (response) {
            //TODO fill this out
            console.log("success");
            console.log(response)
        }

        var onFailure = function (response) {
            //TODO fill this out
            console.log("failed");
            console.log(response);
        }

        $http.post("http://localhost:56503/api/Choices", JSON.stringify(postObject))
            .then(onSuccess, onFailure);

    }

    $scope.logout = function () {
        sessionStorage.removeItem(tokenKey);
        sessionStorage.removeItem(userName);
        $window.location.reload();
    }


    $scope.options = [];
    //populate the options dropdown
    $http.get("http://localhost:56503/api/Options")
    .then(function (response) {
        console.log(response.data);

        var result = [];
        //get options that are available
        for (var i = 0; i < response.data.length; i++) {
            if (response.data[i].IsActive == true) {
                result.push(response.data[i])
            }
        }

        $scope.options = result;
        $scope.firstChoice = $scope.options[0];
        $scope.secondChoice = $scope.options[0];
        $scope.thirdChoice = $scope.options[0];
        $scope.fourthChoice = $scope.options[0];
    });
    
});
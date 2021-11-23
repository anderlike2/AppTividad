angular.module('appTividadApp', [])
    .constant('URL_HOME_DATA', '/Home/Data')
    .constant('URL_HOME_SEARCH', '/Home/Search')
    .constant('MESSAGE_REQUIRED', 'The name of the pokemon is required')
    .constant('MESSAGE_REQUIRED_ID', 'The id of the pokemon is required')
    .constant('API_POKEMON', 'https://pokeapi.co/api/v2/pokemon/')
    .constant('WCF_POKEMON', 'http://localhost:61783/PokemonWcf.svc/')
    .constant('MESSAGE_NO_DATA_FOUND', 'No data found')
    .constant('MESSAGE_GENERIC_ERROR', 'Error Call Rest API')

    //Controller to Search Page
    .controller('SearchController', function ($scope, $window, URL_HOME_DATA, MESSAGE_REQUIRED) {
        $scope.search = "";
        $scope.showMessageInfo = false;
        $scope.messageInfo = "";
        $scope.classValue = false;

        //Function to search to pokemon and redirect to Data Page        
        $scope.searchPokemon = function () {
            if ($scope.search == null || $scope.search == "") {
                $scope.messageInfo = MESSAGE_REQUIRED;
                $scope.showMessageInfo = true;
                $scope.classValue = true;
            } else {
                $window.location.href = URL_HOME_DATA;
                localStorage.setItem('search', $scope.search);
            }
            $scope.$applyAsync();
        }
        
    })

    //Controller to Data Page
    .controller('DataController', function ($scope, $http, $window, API_POKEMON, WCF_POKEMON, MESSAGE_NO_DATA_FOUND, MESSAGE_GENERIC_ERROR,
        URL_HOME_SEARCH    ) {

        $scope.showMessageInfo = false;
        $scope.messageInfo = "";
        $scope.classValue = false;
        $scope.classSuccessValue = false;

        //Call Rest API 
        $http({
            method: 'GET',
            url: API_POKEMON + localStorage.getItem('search')
        }).then(function successCallback(response) {
            $scope.pokemons = response.data;

            //Save data pokemon
            var saveApi = WCF_POKEMON + 'CreatePokemonData';
            var input = new Object();            
            input.pokemonData = JSON.stringify(response.data.stats);

            //Call to WCF Service
            $.ajax({
                type: "POST",
                url: saveApi,
                data: JSON.stringify(input),
                contentType: 'application/json',
                dataType: "json",
                success: function (result) {
                    if (result.Success) {
                        $scope.messageInfo = result.Message;
                        $scope.showMessageInfo = true;
                        $scope.classValue = false;
                        $scope.classSuccessValue = true;
                        $scope.$applyAsync();
                    } else {
                        $scope.messageInfo = result.InternalMessage;
                        $scope.showMessageInfo = true;
                        $scope.classValue = true;
                        $scope.classSuccessValue = false;
                        $scope.$applyAsync();
                    }
                },
                error: function (response, status, error) {
                    $scope.messageInfo = response.statusText;
                    $scope.showMessageInfo = true;
                    $scope.classValue = true;
                    $scope.classSuccessValue = false;
                    $scope.$applyAsync();
                }
            });

        }, function errorCallback(response) {
            if (response.data == 'Not Found') {
                $scope.showMessageInfo = MESSAGE_NO_DATA_FOUND;
                $scope.classValue = true;
                $scope.classSuccessValue = false;
                $scope.$applyAsync();
            } else {
                $scope.showMessageInfo = MESSAGE_GENERIC_ERROR;
                $scope.classValue = true;
                $scope.classSuccessValue = false;
                $scope.$applyAsync();
            }
        });

        //Return to Search
        $scope.backToSearch = function () {
            $window.location.href = URL_HOME_SEARCH;
            localStorage.clear();
        }

        //Search detail from data
        $scope.searchDetail = function (id) {
            $("#ModalDetail").modal("show");
            $scope.baseStatDetail = $scope.pokemons.stats[id].base_stat;
            $scope.effortDetail = $scope.pokemons.stats[id].effort;
            $scope.nameDetail = $scope.pokemons.stats[id].stat.name;
            $scope.urlMoreDetail = $scope.pokemons.stats[id].stat.url;
        }

    })


    //Controller to Get Info pokemon
    .controller('GetInfoController', function ($scope, MESSAGE_REQUIRED_ID, WCF_POKEMON) {
        $scope.search = 0;
        $scope.showMessageInfo = false;
        $scope.messageInfo = "";
        $scope.classValue = false;

        //Function to search to pokemon and redirect to Data Page        
        $scope.searchPokemonId = function () {
            if ($scope.search == null || $scope.search == 0) {
                $scope.messageInfo = MESSAGE_REQUIRED_ID;
                $scope.showMessageInfo = true;
                $scope.classValue = true;
                $scope.$applyAsync();
            } else {

                var input = new Object();
                input.id = $scope.search;

                //Call to WCF Service
                $.ajax({
                    type: "POST",
                    url: WCF_POKEMON + 'GetPokemonData',
                    data: JSON.stringify(input),
                    contentType: 'application/json',
                    dataType: "json",
                    success: function (result) {
                        if (result.Success) {
                            $scope.statsDetail = JSON.parse(result.Message);
                            $scope.$applyAsync();
                        } else {
                            $scope.messageInfo = result.InternalMessage;
                            $scope.showMessageInfo = true;
                            $scope.classValue = true;
                            $scope.classSuccessValue = false;
                            $scope.statsDetail = [];
                            $scope.$applyAsync();
                        }
                    },
                    error: function (response, status, error) {
                        $scope.messageInfo = response.statusText;
                        $scope.showMessageInfo = true;
                        $scope.classValue = true;
                        $scope.classSuccessValue = false;
                        $scope.$applyAsync();
                    }
                });

            }
        }

    })
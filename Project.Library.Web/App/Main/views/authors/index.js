(function () {
    var app = angular.module('app');
    var controllerId = 'app.views.authors.index';

    app.controller(controllerId, [
        '$scope', '$uibModal', 'abp.services.app.author',
        function ($scope, $uibModal, authorService) {
            var vm = this;

            vm.listAuthor = [];

            vm.getListAuthor = function() {
                authorService.getAllAuthor().success(function(result) {
                    vm.listAuthor = result.items;
                }).error(function(data) {
                    abp.notify.error("Error loading authors");
                });
            };

            vm.deleteAuthor = function(item) {
                var input = { id: item.id }
                authorService.deleteAuthor(input).success(function() {
                    abp.notify.success("Author successfully deleted");
                    vm.listAuthor = [];
                    vm.getListAuthor();
                }).error(function() {
                    abp.notify.error("There was an error deleting the author");
                });
            };

            vm.openDialog = function(item, isEdit) {
                var modalInstance = $uibModal.open({
                    templateUrl: abp.appPath + 'App/Main/views/authors/createDialogAuthor.cshtml',
                    controller: 'app.views.authors.createDialogAuthor as ctrDialogAuthor',
                    size: 'md',
                    resolve: {
                        params: function() {
                            var params = {
                                authorid: item.id,
                                edit: isEdit
                            }
                            return params;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    if (result === true) {
                        vm.listAuthor = [];
                        vm.getListAuthor();
                    }
                });
            };

            function init() {
                vm.getListAuthor();
            };

            init();
        }
    ]);
})();
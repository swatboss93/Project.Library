(function () {
    angular.module('app').controller('app.views.authors.createDialogAuthor', [
        '$uibModalInstance', 'params', '$scope', 'abp.services.app.author',
        function ($uibModalInstance, params, $scope, authorService) {
            var vm = this;

            vm.author = {
                id: undefined,
                firstName: undefined,
                lastName: undefined,
                birthDate: undefined,
                tenantId: undefined
            };

            vm.save = function () {
                if (params.edit === true) {
                    //Update
                } else {
                    vm.createAuthor();
                }
            };

            vm.createAuthor = function () {
                authorService.insertNewAuthor(vm.author).success(function (data) {
                    abp.notify.success("Author successfully created");
                    $uibModalInstance.close(true);
                }).error(function (data) {
                    abp.notify.error("There was a problem creating the author");
                });
            };

            vm.cancel = function() {
                $uibModalInstance.dismiss('cancel');
            }
        }
    ]);        
})();
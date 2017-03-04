(function () {
    angular.module('app').controller('app.views.authors.createDialogAuthor', [
        '$uibModalInstance', 'params', '$scope', 'abp.services.app.author',
        function ($uibModalInstance, params, $scope, authorService) {
            var vm = this;

            vm.author = {
                id: undefined,
                firstName: undefined,
                lastName: undefined,
                tenantId: undefined
            };

            vm.save = function () {
                if (params.edit === true) {
                    vm.updateAuthor();
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

            vm.getAuthorDetail = function (item) {
                var input = { id: item }
                authorService.getDetail(input).success(function(data) {
                    vm.author.id = data.id;
                    vm.author.firstName = data.firstName;
                    vm.author.lastName = data.lastName;
                }).error(function(data) {
                    abp.notify.error("Error loading author");
                });
            };

            vm.updateAuthor = function() {
                authorService.updateAuthor(vm.author).success(function(data) {
                    abp.notify.success("Author successfully edited");
                    $uibModalInstance.close(true);
                }).error(function(data) {
                    abp.notify.error("There was a problem editing the author");
                });
            };

            vm.cancel = function() {
                $uibModalInstance.dismiss('cancel');
            };

            function init() {
                
                if (params.edit === true) {
                    vm.getAuthorDetail(params.authorid);
                }
            };

            init();
        }
    ]);        
})();
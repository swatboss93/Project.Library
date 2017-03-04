(function () {
    var app = angular.module('app');
    var controllerId = 'app.views.publishers.index';

    app.controller(controllerId, [
        '$scope', '$uibModal', 'abp.services.app.publisher',
        function ($scope, $uibModal, publisherService) {
            var vm = this;

            vm.listPublisher = [];

            vm.getListPublisher = function () {
                publisherService.getAllPublisher().success(function (result) {
                    vm.listPublisher = result.items;
                }).error(function (data) {
                    abp.notify.error("Error loading publishers");
                });
            };

            vm.deletePublisher = function (item) {
                var input = { id: item.id }
                publisherService.deletePublisher(input).success(function () {
                    abp.notify.success("Publisher successfully deleted");
                    vm.listPublisher = [];
                    vm.getListPublisher();
                }).error(function () {
                    abp.notify.error("There was an error deleting the publisher");
                });
            };

            vm.openDialog = function(item, isEdit) {
                var modalInstance = $uibModal.open({
                    templateUrl: abp.appPath + 'App/Main/views/publishers/createDialogPublisher.cshtml',
                    controller: 'app.views.publishers.createDialogPublisher as ctrDialogPublisher',
                    size: 'md',
                    resolve: {
                        params: function() {
                            var params = {
                                publisherid: item.id,
                                edit: isEdit
                            }
                            return params;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    if (result === true) {
                        vm.listPublisher = [];
                        vm.getListPublisher();
                    }
                });
            };

            function init() {
                vm.getListPublisher();
            };

            init();
        }
    ]);
})();
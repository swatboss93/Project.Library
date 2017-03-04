(function () {
    angular.module('app').controller('app.views.publishers.createDialogPublisher', [
        '$uibModalInstance', 'params', '$scope', 'abp.services.app.publisher',
        function ($uibModalInstance, params, $scope, publisherService) {
            var vm = this;

            vm.publisher = {
                id: undefined,
                name: undefined,
                address: undefined
            };

            vm.save = function () {
                if (params.edit === true) {
                    vm.updatePublisher();
                } else {
                    vm.createPublisher();
                }
            };

            vm.createPublisher = function () {
                publisherService.insertNewPublisher(vm.publisher).success(function (data) {
                    abp.notify.success("Publisher successfully created");
                    $uibModalInstance.close(true);
                }).error(function (data) {
                    abp.notify.error("There was a problem creating the publisher");
                });
            };

            vm.getPublisherDetail = function (item) {
                var input = { id: item }
                publisherService.getDetail(input).success(function (data) {
                    vm.publisher.id = data.id;
                    vm.publisher.name = data.name;
                    vm.publisher.address = data.address;
                }).error(function (data) {
                    abp.notify.error("Error loading publisher");
                });
            };

            vm.updatePublisher = function () {
                publisherService.updatePublisher(vm.publisher).success(function (data) {
                    abp.notify.success("Publisher successfully edited");
                    $uibModalInstance.close(true);
                }).error(function (data) {
                    abp.notify.error("There was a problem editing the publisher");
                });
            };

            vm.cancel = function() {
                $uibModalInstance.dismiss('cancel');
            };

            function init() {
                if (params.edit === true) {
                    vm.getPublisherDetail(params.publisherid);
                }
            };

            init();
        }
    ]);        
})();
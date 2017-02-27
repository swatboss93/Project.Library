(function () {
    var app = angular.module('app');
    var controllerId = 'app.views.authors.index';

    app.controller(controllerId, [
        '$scope', '$uibModal',
        function ($scope, $uibModal) {
            var vm = this;
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

                modalInstance.result.then(function(result) {

                });
            }
        }
    ]);
})();
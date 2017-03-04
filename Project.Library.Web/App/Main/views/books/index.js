(function () {
    var app = angular.module('app');
    var controllerId = 'app.views.books.index';

    app.controller(controllerId, [
        '$scope', '$uibModal', 'abp.services.app.book',
        function ($scope, $uibModal, bookService) {
            var vm = this;

            vm.listBook = [];

            vm.getListBook = function () {
                bookService.getAllBook().success(function (result) {
                    vm.listBook = result.items;
                }).error(function (data) {
                    abp.notify.error("Error loading books");
                });
            };

            vm.deleteBook = function (item) {
                var input = { id: item.id }
                bookService.deleteBook(input).success(function () {
                    abp.notify.success("Book successfully deleted");
                    vm.listBook = [];
                    vm.getListBook();
                }).error(function () {
                    abp.notify.error("There was an error deleting the book");
                });
            };

            vm.openDialog = function(item, isEdit) {
                var modalInstance = $uibModal.open({
                    templateUrl: abp.appPath + 'App/Main/views/books/createDialogBook.cshtml',
                    controller: 'app.views.books.createDialogBook as ctrDialogBook',
                    size: 'md',
                    resolve: {
                        params: function() {
                            var params = {
                                bookid: item.id,
                                edit: isEdit
                            }
                            return params;
                        }
                    }
                });

                modalInstance.result.then(function(result) {
                    vm.listBook = [];
                    vm.getListBook();
                });
            };

            function init() {
                vm.getListBook();
            };

            init();
        }
    ]);
})();
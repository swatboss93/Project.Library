(function () {
    angular.module('app').controller('app.views.books.createDialogBook', [
        '$uibModalInstance', 'params', '$scope', 'abp.services.app.book', 'abp.services.app.author', 'abp.services.app.publisher',
        function ($uibModalInstance, params, $scope, bookService, authorService, publisherService) {
            var vm = this;

            vm.listAuthor = [];
            vm.listPublisher = [];

            vm.getListAuthor = function () {
                authorService.getAllAuthor().success(function (result) {
                    vm.listAuthor = result.items;
                }).error(function (data) {
                    abp.notify.error("Error loading authors");
                });
            };

            vm.getListPublisher = function () {
                publisherService.getAllPublisher().success(function (result) {
                    vm.listPublisher = result.items;
                }).error(function (data) {
                    abp.notify.error("Error loading publishers");
                });
            };

            vm.book = {
                id: undefined,
                title: undefined,
                isbn: undefined,
                author: undefined,
                publisher: undefined
            };

            vm.save = function () {
                if (params.edit === true) {
                    vm.updateBook();
                } else {
                    vm.createBook();
                }
            };

            vm.createBook = function () {
                bookService.insertNewBook(vm.book).success(function (data) {
                    abp.notify.success("Book successfully created");
                    $uibModalInstance.close(true);
                }).error(function (data) {
                    abp.notify.error("There was a problem creating the book");
                });
            };

            vm.getBookDetail = function (item) {
                var input = { id: item }
                bookService.getDetail(input).success(function (data) {
                    vm.book.id = data.id;
                    vm.book.title = data.title;
                    vm.book.isbn = data.isbn;
                    vm.book.author = data.author;
                    vm.book.publisher = data.publishe;
                }).error(function (data) {
                    abp.notify.error("Error loading book");
                });
            };

            vm.updateBook = function () {
                bookService.updateBook(vm.book).success(function (data) {
                    abp.notify.success("Book successfully edited");
                    $uibModalInstance.close(true);
                }).error(function (data) {
                    abp.notify.error("There was a problem editing the book");
                });
            };

            vm.cancel = function() {
                $uibModalInstance.dismiss('cancel');
            };

            function init() {
                vm.getListAuthor();
                vm.getListPublisher();
                if (params.edit === true) {
                    vm.getBookDetail(params.bookid);
                }
            };

            init();
        }
    ]);        
})();
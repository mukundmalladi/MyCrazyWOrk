var ViewModel = function () {
    var self = this;
    self.currentpage = ko.observable();
    self.pagesize = 4;
    self.currentpageindex = ko.observable(0);
    self.books = ko.observableArray();

    //self.currentPage = ko.computed(function () {
    //    var pagesize = parseInt(self.pageSize, 10),
    //    startIndex = pagesize * self.currentPageIndex,
    //    endIndex = startIndex + pagesize;
    //    return $this.contacts.slice(startIndex, endIndex);
    //});
    //self.nextPage = function () {
    //    if (((self.currentPageIndex()+ 1) * self.pageSize()) < self.books().length) {
    //        self.currentPageIndex(self.currentPageIndex() + 1);
    //    }
    //    else {
    //        self.currentPageIndex(0);
    //    }
    //}
    //self.previousPage = function () {
    //    if (self.currentPageIndex() > 0) {
    //        self.currentPageIndex(self.currentPageIndex() - 1);
    //    }
    //    else {
    //        self.currentPageIndex((Math.ceil(self.books().length / self.pageSize())) - 1);
    //    }
    //}

    var booksUri = 'api/Default1';

    function ajaxHelper(uri, method, data) {

        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        });
    }

    function getPerson() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.books(data);
        });
    }

    // Fetch the initial data.
    getPerson();
};

ko.applyBindings(new ViewModel());
$(function () {
    $('.knockout-search').each(function (i, e) {

        var viewModelName = $(e).attr('data-bindname')

        console.log(viewModelName);

        var items = window[viewModelName + 'Items'];

        if (!items)
            items = [];

        var viewModel = new SearchViewModel(items);
        window[viewModelName + 'Model'] = viewModel;
        ko.applyBindings(viewModel, $(e)[0]);
    })
})

function SearchViewModel(items) {

    var that = this;

    this.Items = ko.observableArray();

    this.Items.subscribe(function () {

        for (var i = 0; i < that.Items().length; i++) {
            if (!that.Items()[i].__ko_mapping__)
                that.Items()[i] = ko.mapping.fromJS(that.Items()[i]);
            that.Items()[i].Edit = Edit;
        }

    })

    this.Items(items)

    return this;
}

function Edit(a, b) {
    console.log(a);
    console.log(b);
}
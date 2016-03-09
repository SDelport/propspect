$(function () {

    setTimeout(function () {
        $('.knockout-search').each(function (i, e) {

            var viewModelName = $(e).attr('data-bindname')

            var items = window[viewModelName + 'Items'];

            if (!items)
                items = [];

            var viewModel = new SearchViewModel(viewModelName, items);
            window[viewModelName + 'SearchModel'] = viewModel;
            ko.applyBindings(viewModel, $(e)[0]);
        })

        $('.knockout-edit').each(function (i, e) {

            var viewModelName = $(e).attr('data-bindname')

            var itemTemplate = window[viewModelName + 'Template'];

            var viewModel = new EditViewModel(viewModelName, itemTemplate);
            window[viewModelName + 'EditModel'] = viewModel;
            ko.applyBindings(viewModel, $(e)[0]);
        })
    }, 1);
})

function SearchViewModel(modelName, items) {

    var that = this;

    this.modelName = modelName;
    this.domName = modelName.toString().toLowerCase();

    this.Add = function () {
        $('#edit-modal-' + that.domName).openModal();
    }

    this.Items = ko.observableArray();


    this.Items.subscribe(function () {

        for (var i = 0; i < that.Items().length; i++) {
            if (!that.Items()[i].__ko_mapping__)
                that.Items()[i] = ko.mapping.fromJS(that.Items()[i]);
            that.Items()[i].Edit = that.EditTemplate;
        }

    })

    this.EditTemplate = function (item) {
        if (window[that.modelName + 'EditModel'])
            window[that.modelName + 'EditModel'].OpenEdit(item);
    }

    this.Items(items)

    return this;
}

function EditViewModel(modelName, itemtemplate) {
    var that = this;

    this.modelName = modelName;
    this.domName = modelName.toString().toLowerCase();
    this.EditItem = ko.observable(ko.mapping.fromJSON(itemtemplate));


    this.OpenEdit = function(item)
    {
        $('#edit-modal-' + that.domName).openModal();
        this.EditItem(ko.mapping.fromJS(item));
    }

    this.Save= function(item)
    {
        console.log(item)
    }

    return this;
}

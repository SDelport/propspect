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


            if (DropdownItems) {
                for (var property in DropdownItems) {
                    if (DropdownItems.hasOwnProperty(property)) {
                        viewModel[property] = ko.observableArray(DropdownItems[property]);
                    }
                }
            }

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
        that.EditTemplate(null);
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
            window[that.modelName + 'EditModel'].OpenEdit(ko.mapping.toJS(item));
    }

    this.Items(items)

    return this;
}

function EditViewModel(modelName, itemtemplate) {
    var that = this;

    this.modelName = modelName;
    this.domName = modelName.toString().toLowerCase();
    this.EditItem = ko.observable(ko.mapping.fromJSON(itemtemplate));
    this.template = itemtemplate;

    this.OpenEdit = function (item) {
        if (item)
            this.EditItem(ko.mapping.fromJS(item));
        else
            this.EditItem(ko.mapping.fromJS(itemtemplate));
        $('#edit-modal-' + that.domName).openModal();

    }

    this.Save = function (item) {

        ServiceProxy.Post('/' + that.domName + '/add', ko.mapping.toJSON(that.EditItem), this.SaveSuccess);
    }

    this.SaveSuccess = function (result) {
        $('#edit-modal-' + that.domName).closeModal();

    }

    this.AddSuccess = function (result) {
        $('#edit-modal-' + that.domName).closeModal();

    }

    return this;
}


var ServiceProxy =
    {
        Post: function (url, data, successmethod) {
            return $.ajax(
                {
                    url: url,
                    data: data,
                    type: "POST",
                    context: this,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        successmethod(result);
                    },
                    error: function (result) {
                        console.log(result)
                    }
                });


        }
    }
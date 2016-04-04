$(function () {



    setTimeout(function () {
        $('.knockout-search').each(function (i, e) {

            var viewModelName = $(e).attr('data-bindname')

            var items = window[viewModelName + 'Items'];



            if (!items)
                items = [];

            var viewModel = new SearchViewModel(viewModelName, items);

            if (DropdownItems) {
                for (var property in DropdownItems) {
                    if (DropdownItems.hasOwnProperty(property)) {
                        viewModel[property] = ko.observableArray(DropdownItems[property]);
                    }
                }
            }

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

    this.Search = function()
    {
        if(that.SearchString()!= '')
        ServiceProxy.Get('/' + that.domName + '/search/' + that.SearchString(), this.SearchSuccess);
    }

    this.SearchSuccess = function(data)
    {
        this.Items(data);
    }

    this.SearchString = ko.observable('');

    this.EditTemplate = function (item) {
        if (window[that.modelName + 'EditModel'])
            if (item)
                window[that.modelName + 'EditModel'].OpenEdit(ko.mapping.toJS(item));
            else
                window[that.modelName + 'EditModel'].OpenEdit(null);
    }

    this.GetSource = function (source, value) {
        if (!that[source])
            return '';

        for (var i = 0; i < that[source]().length; i++) {
            if (!value)
                continue;
            if (that[source]()[i].Value == value.toString())
                return that[source]()[i].Text;
        }
    }

    this.Items(items)

    

    return this;
}

function EditViewModel(modelName, itemtemplate) {
    var that = this;
    this.IsLoading = ko.observable(false);
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
        that.IsLoading(true);
        ServiceProxy.Post('/' + that.domName + '/add', ko.mapping.toJSON(that.EditItem), item.EditItem()[that.modelName + "ID"]() == 0 || !item.EditItem()[that.modelName + "ID"] ? this.AddSuccess : this.SaveSuccess);
    }

    this.SaveSuccess = function (result) {
        $('#edit-modal-' + that.domName).closeModal();
        that.IsLoading(false);
        for (var i = 0; i < window[that.modelName + 'SearchModel'].Items().length; i++) {
            if (window[that.modelName + 'SearchModel'].Items()[i][that.modelName + 'ID']() == result[that.modelName + 'ID']) {
                window[that.modelName + 'SearchModel'].Items.replace(window[that.modelName + 'SearchModel'].Items()[i], ko.mapping.fromJS(result));
            }
        }


    }

    this.AddSuccess = function (result) {
        $('#edit-modal-' + that.domName).closeModal();
        that.IsLoading(false);
        window[that.modelName + 'SearchModel'].Items.push(result);

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
                        alert("An error occured")
                        console.log(result)
                    }
                });
        },

        Get: function (url, successmethod) {
            return $.ajax(
                {
                    url: url,
                    type: "GET",
                    context: this,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        successmethod(result);
                    },
                    error: function (result) {
                        alert("An error occured")
                        console.log(result)
                    }
                });
        }
    }
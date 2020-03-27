function InitGridCustomFloatField() {

    var options = {
        digitGroupSeparator: '.',
        decimalCharacter: ',',
        decimalCharacterAlternative: ',',
        currencySymbol: '€',
        currencySymbolPlacement: 's',
        decimalPlacesOverride: 2,
        minimumValue: '0.00',
        emptyInputBehavior: 'zero',
        leadingZero: 'deny',
        defaultValueOverride: '0.00'
    };

    var jsGridCustomFloatField = function (config) {
        jsGrid.Field.call(this, config);
    };

    jsGridCustomFloatField.prototype = new jsGrid.Field({
        sorter: function (num1, num2) {
            return num1 - num2;
        },
        itemTemplate: function (value) {
            return $.fn.autoFormat(value, options);
        },
        insertTemplate: function (value) {
            this._insertPicker = $('<input type="text">').val(value);
            this._insertPicker.autoNumeric('init', options);
            return this._insertPicker;
        },
        editTemplate: function (value) {
            this._editPicker = $('<input type="text">').val(value);
            this._editPicker.autoNumeric('init', options);
            return this._editPicker;
        },
        filterTemplate: function () {
            if (!this.filtering)
                return '';

            var grid = this._grid,
                $result = $('<input type="text">').val(0);
            if (this.autosearch) {
                $result.on('change', function (e) {
                    grid.search();
                });
            }

            return $result;
        },
        filterValue: function () {
            console.log(this._insertPicker.val());
            return this._insertPicker.val();
        },
        insertValue: function () {
            return this._insertPicker.autoNumeric('get');
        },
        editValue: function () {
            return this._editPicker.autoNumeric('get');
        }
    });

    jsGrid.fields.customFloatField = jsGridCustomFloatField;
};
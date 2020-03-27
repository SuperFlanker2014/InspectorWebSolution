function InitGridDecimalField() {
    function DecimalField(config) {
        jsGrid.NumberField.call(this, config);
    }

    DecimalField.prototype = new jsGrid.NumberField({
        step: 0.01,
        itemTemplate: function (value) { return value.toFixed(2); }, //(parseFloat(value) || 0)
        filterValue: function (value) { return this.filterControl.val() ? parseFloat(this.filterControl.val() || 0) : undefined; },
        insertValue: function (value) { return this.insertControl.val() ? parseFloat(this.insertControl.val() || 0) : undefined; },
        editValue: function (value) { return this.editControl.val() ? parseFloat(this.editControl.val() || 0) : undefined; },
        _createTextBox: function (value) { return jsGrid.NumberField.prototype._createTextBox.call(this).attr("step", this.step); }
    });

    jsGrid.fields.decimal = jsGrid.DecimalField = DecimalField;
};
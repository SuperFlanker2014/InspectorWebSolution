function InitGridDatetimeField() {

    $.datepicker.regional.ru = {
        closeText: "Закрыть",
        prevText: "&#x3C;Пред",
        nextText: "След&#x3E;",
        currentText: "Сегодня",
        monthNames: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
        monthNamesShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июн",
            "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"],
        dayNames: ["воскресенье", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота"],
        dayNamesShort: ["вск", "пнд", "втр", "срд", "чтв", "птн", "сбт"],
        dayNamesMin: ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"],
        weekHeader: "Нед",
        dateFormat: "dd.mm.yy",
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ""
    };

    $.datepicker.setDefaults(
        $.datepicker.regional.ru
    );

    var DateField = function (config) {
        jsGrid.Field.call(this, config);
    };

    DateField.prototype = new jsGrid.Field({
        sorter: function (date1, date2) {
            return new Date(date1) - new Date(date2);
        },

        itemTemplate: function (value) {
            return new Date(value).toLocaleDateString('ru-RU');
        },

        insertTemplate: function (value) {
            return this._insertPicker = $("<input>").datepicker({ defaultDate: new Date() });
        },

        editTemplate: function (value) {
            return this._editPicker = $("<input>").datepicker().datepicker("setDate", new Date(value));
        },

        insertValue: function () {
            return this._insertPicker.datepicker("getDate").toDateString();
        },

        editValue: function () {
            return this._editPicker.datepicker("getDate").toDateString();
        },

        filterTemplate: function () {
            var grid = this._grid;
            var now = new Date();

            this._fromPicker = $("<input>").datepicker(
                {
                    defaultDate: now.setFullYear(now.getFullYear() - 1),
                    onClose: function (dateText) {
                        grid.search();
                        e.preventDefault();
                    }
                });
            this._toPicker = $("<input>").datepicker(
                {
                    defaultDate: now.setFullYear(now.getFullYear() + 1),
                    onClose: function (dateText) {
                        grid.search();
                        e.preventDefault();
                    }
                });

            var t1 = $("<td>").append("from");
            var d1 = $("<td>").append(this._fromPicker);
            var t2 = $("<td>").append("to");
            var d2 = $("<td>").append(this._toPicker);

            var tr = $("<tr>").append(t1).append(d1).append(t2).append(d2);
            return $("<table>").append(tr);
        },
        filterValue: function () {
            return {
                from: formatDate(this._fromPicker.datepicker("getDate")),
                to: formatDate(this._toPicker.datepicker("getDate"))
            };
        }
    });

    jsGrid.fields.dateField = DateField;
};

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    var f = [day, month, year].join('.');
    return f;
};
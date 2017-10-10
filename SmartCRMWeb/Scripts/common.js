



String.prototype.format = function (args) {
    var str = this;
    return str.replace(String.prototype.format.regex, function (item) {
        var intVal = parseInt(item.substring(1, item.length - 1));
        var replace;
        if (intVal >= 0) {
            replace = args[intVal];
        } else if (intVal === -1) {
            replace = "{";
        } else if (intVal === -2) {
            replace = "}";
        } else {
            replace = "";
        }
        return replace;
    });
};

String.prototype.format.regex = new RegExp("{-?[0-9]+}", "g");

String.prototype.lpad = function (padString, length) {
    var str = this;
    while (str.length < length) {
        str = padString.concat(str);
    }
    return str;
}

String.prototype.rpad = function (padString, length) {
    var str = this;
    while (str.length < length)
    { str = str.concat(padString); }
    return str;
}

String.prototype.trim = function () { return this.replace(/^\s\s*/, '').replace(/\s\s*$/, ''); };

String.prototype.MoneyStrToNumber = function () {
    return Number($(this).val().replace(/,/g, ""))
}

String.prototype.toNumber = function () {
    return Number(this.replace(/,/g, ""));
}

//////////////////////////////////////////////////

Number.prototype.format = function (subfix) {
    var num = this;
    num += '';
    var splitStr = num.split('.');
    var splitLeft = splitStr[0];
    var splitRight = splitStr[1] ? splitStr[1] : '';
    var regx = /(\d+)(\d{3})/;
    while (regx.test(splitLeft)) {
        splitLeft = splitLeft.replace(regx, '$1'.concat(',', '$2'));
    }
    if (subfix > 0) {
        if (splitRight.length > 2) {
            splitRight = ".".concat(splitRight.substr(0, 2));
        }
        else {
            splitRight = ".".concat(splitRight.rpad("0", subfix));
        }
    }
    return splitLeft.concat(splitRight);
}

Number.prototype.Floor2Position = function (subfix) {
    var num = this;
    num += '';
    var splitStr = num.split('.');
    var splitRight = '';
    if (splitStr.length == 1) {
        return this;
    }
    else {
        splitRight = splitStr[1].substr(0, 2);
    }
    return Number(splitStr[0].concat('.', splitRight));
}

Number.prototype.Round2Position = function (subfix) {
    return Math.round(this * 100) / 100;
}

//////////////////////////////////////////////////

//var ctxDateFormat = "dd/mm/yyyy";
var ctxDateFormat = "yyyy/mm/dd";

String.prototype.toJsonDateStr = function () {
    var temp = this.split(" ");
    var date = temp[0];
    var time = temp[1] ? temp[1] : "00:00:00";
    temp = date.split("/");
    if (ctxDateFormat == "dd/mm/yyyy") {
        date = temp[1].concat("/", temp[0], "/", temp[2]);
    }
    else {
        if (ctxDateFormat == "yyyy/mm/dd") {
            date = temp[1].concat("/", temp[2], "/", temp[0]);
        }
    }
    var dateObj = new Date(date.concat(" ", time));
    var localTime = dateObj.getTime();
    var localOffset = (dateObj.getTimezoneOffset()) / 60;
    var strOffset;
    if (localOffset < 0) {
        strOffset = "+".concat((-1 * localOffset).toString().lpad("0", 2), "00");

    } else {
        strOffset = "-".concat(localOffset.toString().lpad("0", 2), "00");
    }
    var strFormat = "/Date({0}{1})/";
    return strFormat.format([localTime.toString(), strOffset]);
}

String.prototype.toJsonDateHyphenStr = function () {
    var temp = this.split(" ");
    var date = temp[0];
    var time = temp[1] ? temp[1] : "00:00:00";
    temp = date.split("-");
    var dateObj = new Date(date.concat("T", time, "Z").replace(/\-/g, '\/').replace(/[T|Z]/g, ' '));
    var localTime = dateObj.getTime();
    var localOffset = (dateObj.getTimezoneOffset()) / 60;
    var strOffset;
    if (localOffset < 0) {
        strOffset = "+".concat((-1 * localOffset).toString().lpad("0", 2), "00");
    } else {
        strOffset = "-".concat(localOffset.toString().lpad("0", 2), "00");
    }
    var strFormat = "/Date({0}{1})/";
    return strFormat.format([localTime.toString(), strOffset]);
}

String.prototype.toDateFromService = function (showTime) {
    var temp = this.split("T");
    var date = temp[0];
    var time = temp[1];
    temp = date.split("-");
    if (ctxDateFormat == "dd/mm/yyyy") {
        date = temp[2].concat("/", temp[1], "/", temp[0]);
    }
    else {
        if (ctxDateFormat == "yyyy/mm/dd") {
            date = temp[0].concat("/", temp[1], "/", temp[2]);
        }
    }
    return date.concat((showTime ? " ".concat(time) : ""));
}

String.prototype.toDateControl = function () {
    var temp = this.split("T");
    var date = temp[0];
    var time = temp[1];
    temp = date.split("-");
    date = temp[1].concat("/", temp[2], "/", temp[0]);
    return new Date(date.concat(" ", time));
}

//////////////////////////////////////////////////

function GetNameField(obj) {
    return (language == "ENG" ? ((obj.NAME_ENG == null || obj.NAME_ENG == "") ? obj.NAME_LOCAL : obj.NAME_ENG) : obj.NAME_LOCAL);
}

function GetQueryStringByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]".concat(name, "=([^&#]*)")),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function SetRequireField(control) {
    if (control.val() == null || control.val() == "") { control.addClass("required-field"); } else { control.removeClass("required-field"); }
}

//////////////////////////////////////////////////

$(".MoneyTextBox").on("focus", function (e) {
    $(this).val($(this).val().replace(/,/g, ""));
});

$(".MoneyTextBox").on("keypress", function (e) {
    return isNumberKey(e);
});

$(".MoneyTextBox").on("blur", function (e) {
    $(this).val(Number($(this).val()).format(2));
});


String.prototype.capitalize = function (type) {

    // if type = all, capitalize first letter of each word
    if (type === 'all') {
        array = this.split(' '); // split on spaces
        capitalized = '';

        $.each(array, function (index, value) {
            capitalized += value.charAt(0).toUpperCase() + value.slice(1);

            if (array.length != (index + 1))
                capitalized += ' '; // add a space if not end of array
        });
        return capitalized;
    }

    // if type = title, capitalize first letter of each word so long as it is not
    // an article, coordinate conjunction, preposition (etc) unless it is the first word
    // -> traditionally left uppercase if over 4 or 5 letters
    // -> I'm only doing the common ones, add more in the doNotCapitalize array
    if (type === 'title') {
        array = this.split(' '); // split on spaces
        capitalized = '';
        doNotCapitalize = ["a", "an", "and", "as", "at", "but", "by", "etc", "for", "in", "into", "is", "nor", "of", "off", "on", "onto", "or", "so", "the", "to", "unto", "via"];

        $.each(array, function (index, value) {
            // only capitalize if first word or not in doNotCapitalize array
            if (index === 0 || $.inArray(value, doNotCapitalize) === -1) // inArray returns -1 for false, 0 for element index in array
                capitalized += value.charAt(0).toUpperCase() + value.slice(1);
            else
                capitalized += value;

            if (array.length != (index + 1))
                capitalized += ' '; // add a space if not end of array
        });
        return capitalized;
    }

    // else just capitalize first letter of first word
    return this.charAt(0).toUpperCase() + this.slice(1);
};

/// <reference path="jquery-1.6.2-vsdoc.js" />
/*
jQuery Global 
*/
var weekDay = new Array(7);
weekDay[0] = "Sun";
weekDay[1] = "Mon";
weekDay[2] = "Tue";
weekDay[3] = "Wed";
weekDay[4] = "Thu";
weekDay[5] = "Fri";
weekDay[6] = "Sat";

/* ----------------------------------------------------------------------------	
jQuery Extensions
*/
$.extend({
    isUndefined: function (obj) {
        return typeof (obj) == 'undefined' ? true : false;
    },
    isNull: function (obj) {
        return obj == null ? true : false;
    },
    isUseable: function (obj) {
        return $.isUndefined(obj) || $.isNull(obj) ? false : true;
    },
    isNullOrEmpty: function (obj) {
        return $.isUseable(obj) && $.trim(obj) == "" ? true : false;
    },
    parseDate: function (dateString) { // expected formats: yyyy-dd-mm hh:mm:ss | yyyy-dd-mm hh:mm | yyyy-mm-dd
        var regexp = new RegExp(/^(\d{4})-?(\d\d)-?(\d\d)(?:$|[ ](\d{1,2}):(\d{1,2})(?::(\d{1,2}))?$)/);
        dateString = dateString.replace('T', ' ');
        var d = dateString.match(regexp);
        if (d) {
            var dateOut = new Date();
            dateOut.setFullYear(parseInt(d[1], 10), parseInt(d[2], 10) - 1, parseInt(d[3], 10));
            dateOut.setHours(parseInt(d[4] || 0, 10), parseInt(d[5] || 0, 10), parseInt(d[6]) || 0, 10);
        } else {
            var dateOut = null; // unknown dateString format
        }
        return dateOut;
    },
    exists: function (obj) {
        return obj.length != 0 ? true : false;
    },
    strToObj: function (str) {
        try {
            var temp = eval("(" + str + ")");
            return typeof (temp) == "object" ? temp : {};
        } catch (e) {
            return {};
            debugConsole({ fn: 'strToObj', msg: 'Error: ' + e });
        }
    },
    parseURL: function (n, string) {
        var returnValue = "";
        var regexS = "[\\?&]" + n + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var tmpURL = string != undefined ? string : window.location.search.toLowerCase();
        var results = regex.exec(tmpURL);

        if (results != null) returnValue = results[1];

        return returnValue;
    },
    objToStr: function (obj) {
        if (window._browser.summary != "ie7") {
            return JSON.stringify(obj);
        }
        var count = 0;
        var objValue;
        var temp;
        for (var value in obj) {
            if (count == 0) {
                temp = '{';
            } else {
                temp += ', ';
            }
            temp += '"' + value + '"';
            objValue = typeof (obj[value]) == "object" ? $.objToStr(obj[value]) : '"' + obj[value] + '"';
            temp += ':' + objValue;
            count++;
        }
        return temp + '}';
    },
    animate: function (obj) {
        obj.animate({
            "background-color": "#faa0a0"
        }, 300, function () {
            obj.animate({
                "background-color": "white"
            }, 100, function () {
                obj.animate({
                    "background-color": "#faa0a0"
                }, 300, function () {
                    obj.css("background-color", "white");
                })
            })
        })
    },
    isContanis: function (list, obj) {
        var isExit = false;
        for (var i = 0; i < list.length; i++) {
            if ($.trim(list[i]) == $.trim(obj)) {
                isExit = true;
                break;
            }
        }

        return isExit;
    }
})
function getBrowser() {
    var OsObject = "";
    if (navigator.userAgent.indexOf("MSIE") > 0 || navigator.userAgent.indexOf("Microsoft") > 0) {
        return "MSIE";
    }
    if (navigator.userAgent.indexOf("Firefox") > 0) {
        return "Firefox";
    }
    if (navigator.userAgent.indexOf("Chrome") > 0) {
        return "Chrome";
    }
    if (navigator.userAgent.indexOf("Safari") > 0) {
        return "Safari";
    }
    if (navigator.userAgent.indexOf("Camino") > 0) {
        return "Camino";
    }
    if (navigator.userAgent.indexOf("Gecko/") > 0) {
        return "Gecko";
    }

    return "MSIE";
}

try {
    document.execCommand("BackgroundImageCache", false, true);
} catch (e) { }

var popUpWin;

function PopUpCenterWindow(URLStr, width, height, newWin, scrollbars) {
    var popUpWin = 0;
    if (typeof (newWin) == "undefined") {
        newWin = false;
    }

    if (typeof (scrollbars) == "undefined") {
        scrollbars = 0;
    }

    if (typeof (width) == "undefined") {
        width = 800;
    }

    if (typeof (height) == "undefined") {
        height = 600;
    }

    var left = 0;
    var top = 0;
    if (screen.width >= width) {
        left = Math.floor((screen.width - width) / 2);
    }

    if (screen.height >= height) {
        top = Math.floor((screen.height - height) / 2);
    }

    if (newWin) {
        open(URLStr, '', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=' + scrollbars + ',resizable=yes,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
        return;
    }

    if (popUpWin) {
        if (!popUpWin.closed) popUpWin.close();
    }

    popUpWin = open(URLStr, 'popUpWin', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=' + scrollbars + ',resizable=yes,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');

    popUpWin.focus();
}

function OpenModelWindow(url, option) {
    var fun;
    try {
        if (parent != null && parent.$ != null && parent.$.ShowIfrmDailog != undefined) {
            fun = parent.$.ShowIfrmDailog
        }
        else {
            fun = $.ShowIfrmDailog;
        }
    }
    catch (e) {
        fun = $.ShowIfrmDailog;
    }

    fun(url, option);
}
function CloseModelWindow(callback, dooptioncallback) {
    parent.$.closeIfrm(callback, dooptioncallback);
}


function StrFormat(temp, dataarry) {
    return temp.replace(/\{([\d]+)\}/g, function (s1, s2) {
        var s = dataarry[s2];
        if (typeof (s) != "undefined") {
            if (s instanceof (Date)) {
                return s.getTimezoneOffset();
            } else {
                return encodeURIComponent(s);
            }
        } else {
            return "";
        }
    });
}

function StrFormatNoEncode(temp, dataarry) {
    return temp.replace(/\{([\d]+)\}/g, function (s1, s2) {
        var s = dataarry[s2];
        if (typeof (s) != "undefined") {
            if (s instanceof (Date)) {
                return s.getTimezoneOffset()
            } else {
                return (s);
            }
        } else {
            return "";
        }
    });
}

function getiev() {
    var userAgent = window.navigator.userAgent.toLowerCase();
    $.browser.msie8 = $.browser.msie && /msie 8\.0/i.test(userAgent);
    $.browser.msie7 = $.browser.msie && /msie 7\.0/i.test(userAgent);
    $.browser.msie6 = !$.browser.msie8 && !$.browser.msie7 && $.browser.msie && /msie 6\.0/i.test(userAgent);
    var v;
    if ($.browser.msie8) {
        v = 8;
    }
    else if ($.browser.msie7) {
        v = 7;
    }
    else if ($.browser.msie6) {
        v = 6;
    }
    else {
        v = -1;
    }

    return v;
}
$(document).ready(function () {
    var v = getiev()
    if (v > 0) {
        $(document.body).addClass("ie ie" + v);
    }
});

function fnKeyStop(evt) {
    if (!window.event) {
        var keycode = evt.keyCode;
        var key = String.fromCharCode(keycode).toLowerCase();
        if (evt.ctrlKey && key == "v") {
            evt.preventDefault();
            evt.stopPropagation();
        }
    }
}
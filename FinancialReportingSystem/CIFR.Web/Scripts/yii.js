var yii = new function() {
    this.createAction = function(location, params) {
        var requestUrl = '/'+location;
        var urlParams = [];

        $.each(params, function(name, value){
            urlParams.push(name+'/'+encodeURI(value));
        });
        urlParams.push('eajax/1');
        requestUrl = requestUrl+'/'+urlParams.join('/');
        
        return {
            request: function(params, fn, options) {
                if(! options) options = {};

                $.ajax($.extend({}, {
                    url: requestUrl,
                    async: false,
                    cache: false,
                    data: params,
                    dataType: 'json',
                    type: 'post',
                    error: function(xhr, err, o) {
                        //alert(err);
                    },
                    success: function(data, state) {
                        //if(typeof(data.jSystemStatus) !== 'undefined') {
                            /*
                            if(data.jSystemStatus === -1) {
                                window.top.location.href = "/dashboard/login";
                            }
                            else if(data.jSystemStatus === 999) {
                                alert('No Permission!');
                                return;
                            }*/
                        //}
                        if(typeof(fn) === 'function') fn(data, state);
                    },
                    complete: function(xhr){
                        //
                    }
                }, options));
            }
        };
    };
};

$(function(){
    $.fn.form2json = function () {
        var fields = this.eq(0).serializeArray();
        var results = {};
        var convertToObject = function (names, value, rawObject) {
            var name = '';
            if (names.length > 1) {
                name = names.splice(0, 1);
                if (!rawObject[name]) rawObject[name] = {};
                convertToObject(names, value, rawObject[name]);
            }
            else {
                rawObject[names[0]] = value;
            }
            return rawObject;
        };

        $.each(fields, function (idx, field) {
            var names = field['name'].split('.');
            results = convertToObject(names, field['value'], results);
        });

        return results;
    };

    jQuery.validator.addMethod("strongPassword", function (value, element) {
        var length = value.length;
        if (length < 6 || length > 18) return false;
        if (!value.match(/([a-z])/)) return false;
        if (!value.match(/([A-Z])/)) return false;
        if (!value.match(/([0-9])/)) return false;
        return true;
    }, "请输入6-18位包含大小写字母、数字的密码");
});
"use strict"
/*----------------------------------------------给系统对象添加原型方法-------------------------------------------------------*/
String.prototype.trim = String.prototype.trim || function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

String.prototype.ltrim = String.prototype.ltrim || function () {
    return this.replace(/(^\s*)/g, "");
}

String.prototype.rtrim = String.prototype.rtrim || function () {
    return this.replace(/(\s*$)/g, "");
}

String.prototype.toInt = String.prototype.toInt || function () {
    return parseInt(this);
}

String.prototype.toFloat = String.prototype.toFloat || function () {
    return parseFloat(this);
}

String.prototype.toDecimal = String.prototype.toDecimal || function (digit, flag,def) {
    var result;
    if (flag) {
        if (flag == 1) {
            result = Math.ceil(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
        } else {
            result = Math.floor(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
        }
    } else {
        result = Math.round(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
    }
    return result || (def = def || 0);
}




//Object.prototype.toDecimal1 = Object.prototype.toDecimal1 || function (digit, flag, def) {
//    var result;
//    if (flag) {
//        if (flag == 1) {
//            result = Math.ceil(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
//        } else {
//            result = Math.floor(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
//        }
//    } else {
//        result = Math.round(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
//    }
//    return result || (def = def || 0);
//}


//给数字添加方法
Number.prototype.toInt = Number.prototype.toInt || function () {
    return parseInt(this);
}

Number.prototype.toDecimal = Number.prototype.toDecimal || function (digit, flag ,def) {
    var result;
    if (flag) {
        if (flag == 1) {
            result = Math.ceil(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
        } else {
            result = Math.floor(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
        }
    } else {
        result = Math.round(parseFloat(this) * Math.pow(10, digit)) / Math.pow(10, digit);
    }
    return  result||(def=def||0);
}



//给数组添加方法
Array.prototype.map =Array.prototype.map||function (callback, thisArg) {

    var T, A, k;

    if (this == null) {
        throw new TypeError(" this is null or not defined");
    }

    // 1. Let O be the result of calling ToObject passing the |this| value as the argument.
    var O = Object(this);

    // 2. Let lenValue be the result of calling the Get internal method of O with the argument "length".
    // 3. Let len be ToUint32(lenValue).
    var len = O.length >>> 0;

    // 4. If IsCallable(callback) is false, throw a TypeError exception.
    // See: http://es5.github.com/#x9.11
    if (typeof callback !== "function") {
        throw new TypeError(callback + " is not a function");
    }

    // 5. If thisArg was supplied, let T be thisArg; else let T be undefined.
    if (thisArg) {
        T = thisArg;
    }

    // 6. Let A be a new array created as if by the expression new Array(len) where Array is
    // the standard built-in constructor with that name and len is the value of len.
    A = new Array(len);

    // 7. Let k be 0
    k = 0;

    // 8. Repeat, while k < len
    while (k < len) {

        var kValue, mappedValue;

        // a. Let Pk be ToString(k).
        //   This is implicit for LHS operands of the in operator
        // b. Let kPresent be the result of calling the HasProperty internal method of O with argument Pk.
        //   This step can be combined with c
        // c. If kPresent is true, then
        if (k in O) {

            // i. Let kValue be the result of calling the Get internal method of O with argument Pk.
            kValue = O[k];

            // ii. Let mappedValue be the result of calling the Call internal method of callback
            // with T as the this value and argument list containing kValue, k, and O.
            mappedValue = callback.call(T, kValue, k, O);

            // iii. Call the DefineOwnProperty internal method of A with arguments
            // Pk, Property Descriptor {Value: mappedValue, : true, Enumerable: true, Configurable: true},
            // and false.

            // In browsers that support Object.defineProperty, use the following:
            // Object.defineProperty(A, Pk, { value: mappedValue, writable: true, enumerable: true, configurable: true });

            // For best browser support, use the following:
            A[k] = mappedValue;
        }
        // d. Increase k by 1.
        k++;
    }

    // 9. return A
    return A;
};



Array.prototype.arrayIsNullOrEmpty =Array.prototype.arrayIsNullOrEmpty||function () {

}

//判断字符串是否在数据上
Array.prototype.inArray = Array.prototype.inArray||function (str) {
    for (var i = 0; i < this.length; i++) {
        if (str == this[i]) {
            return true;
        }
    }
    return false;
}
//数据去重
Array.prototype.unique =Array.prototype.unique|| function () {
    var n = {}, r = []; //n为hash表，r为临时数组
    for (var i = 0; i < this.length; i++) //遍历当前数组
    {
        if (!n[this[i]]) //如果hash表中没有当前项
        {
            n[this[i]] = true; //存入hash表
            r.push(this[i]); //把当前数组的当前项push到临时数组里面
        }
    }
    return r;
}

//给日期对象添加格式化方法
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子：
Date.prototype.format =Date.prototype.format|| function (format) {
    var o = {
        "M+": this.getMonth() + 1, // month
        "d+": this.getDate(), // day
        "h+": this.getHours(), // hour
        "m+": this.getMinutes(), // minute
        "s+": this.getSeconds(), // second
        "q+": Math.floor((this.getMonth() + 3) / 3), // quarter
        "S": this.getMilliseconds()
        // millisecond
    }
    if (/(y+)/.test(format))
        format = format.replace(RegExp.$1, (this.getFullYear() + "")
            .substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(format))
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}







/*------------------------------------------------------------------------------------------------------------------------*/



var App =App||new Object();
App.Namespace = new Object();
App.Namespace.register = function (path) {
    var arr = path.split(".");
    var ns = "";
    for (var i = 0; i < arr.length; i++) {
        if (i > 0) ns += ".";
        ns += arr[i];
        eval("if(typeof(" + ns + ") == 'undefined') " + ns + " = new Object();");
    }
}


App.Namespace.register("App.Util");

App.Util = {
    //constructor:this,
    toDecimal: function (num, digit, flag, def) {
        var result;
        if (num != undefined && num != null) {
            if (flag) {
                if (flag == 1) {
                    result = Math.ceil(parseFloat(num) * Math.pow(10, digit)) / Math.pow(10, digit);
                } else {
                    result = Math.floor(parseFloat(num) * Math.pow(10, digit)) / Math.pow(10, digit);
                }
            } else {
                result = Math.round(parseFloat(num) * Math.pow(10, digit)) / Math.pow(10, digit);
            }
        }
        return result || (result == 0 ? 0 : (def = def || 0));
    },
    toDate: function (dateStringInRange) {
        var isoExp = /^\s*(\d{4})-(\d\d)-(\d\d)\s*$/,
               date = new Date(NaN), month,
               parts = isoExp.exec(dateStringInRange);
        if (parts) {
            month = +parts[2];
            date.setFullYear(parts[1], month - 1, parts[3]);
            if (month != date.getMonth() + 1) {
                date.setTime(NaN);
            }
        }
        return date;
    },
    arrayIsNullOrEmpty: function (arr) {
        var flag = true;
        if (arr && arr.length > 0) {
            flag = false;
        }
        return flag;
    },
    getTimeDuring: function (timeStr, month, format) {
        var time;
        if (typeof time != "Object") {
            time = new Date(Date.parse(timeStr));
        } else {
            time = timeStr;
        }
        var str = "";
        var startTime = time.format(format);
        time.setMonth(time.getMonth() + month);
        var endTime = time.format(format);
        str = startTime + "~" + endTime;
        return str;
    },
    getQueryString: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    },
    getRequet: function () {
        var url = location.search; //获取url中"?"符后的字串 
        var theRequest = new Object();
        if (url.indexOf("?") != -1) {
            var str = url.substr(1);
            strs = str.split("&");
            for (var i = 0; i < strs.length; i++) {
                theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
            }
        }
        return theRequest;
    },
    isExistFunction: function (funcName) {
        try {
            if (typeof (eval(funcName)) == "function") {
                return true;
            }
        } catch (e) { }
        return false;
    },
    isFunction: function (obj) {
        return typeof obj === "function";
    },
    Form: {
        serialize: function (form) {
            var arr = {};
            for (var i = 0; i < form.elements.length; i++) {
                var feled = form.elements[i];
                switch (feled.type) {
                    case undefined:
                    case 'button':
                    case 'file':
                    case 'reset':
                    case 'submit':
                        break;
                    case 'checkbox':
                    case 'radio':
                        if (!feled.checked) {
                            break;
                        }
                    default:
                        if (arr[feled.name]) {
                            arr[feled.name] = arr[feled.name] + ',' + feled.value;
                        } else {
                            arr[feled.name] = feled.value;
                        }

                }
            }
            return arr
        }
    },
    extend: function () {      
        var src, copyIsArray, copy, name, options, clone,
            target = arguments[0] || {},
            i = 1,
            length = arguments.length,
            deep = false;
        if (typeof target === "boolean") {
            deep = target;
            target = arguments[i] || {};
            i++;
        }
        for (; i < length; i++) {
            if ((options = arguments[i]) != null) {
                for (name in options) {
                    src = target[name];
                    copy = options[name];
                    if (target === copy) {
                        continue;
                    }
                    if (deep) {
                        target[name] = App.Util.extend(deep, clone, copy);
                    }
                    else {                     
                        target[name] = copy;
                    }
                }
            }
        }
        return target;
    },
    type: function (obj) {
        //if (obj == null) {
        //    return obj + "";
        //}
        //return typeof obj === "object" || typeof obj === "function" ?
        //    class2type[toString.call(obj)] || "object" :
        //    typeof obj;
    }
}


//EasyUI框架注册
App.Namespace.register("App.EasyUI");

App.EasyUI.DataGrid = function (selector, options) {
    this.selector = selector;
    this.options = options;
}

App.EasyUI.DataGrid.prototype = {
    init: function () {
        this.selector.datagrid(this.options);
    }
}

App.Namespace.register("App.Javascript");

App.Javascript.HttpRequest = function (options) {
   this.options=options
}
App.Javascript.HttpRequest.prototype = {
     ajax:createxmlHttp
}

var createxmlHttp =function(){
    var xmlhttp;
    if (window.XMLHttpRequest){ 
        xmlhttp=new XMLHttpRequest(); 
    }
    else{ 
        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
    } 
}


App.Namespace.register("App.Bootstrap");


App.Bootstrap.Typeahead = function (selector, url,params,keyWordName) {
    var _this = this;
    this.commStat = true;
    this.options = {
        source: function (query, process) {
            var paramsData;
            var parameter = { Token: "", keyWord: query };
            if (keyWordName) {
                parameter = {};
                parameter[keyWordName] = query;
            }         
            var requestData;
            if (params) {             
                paramsData = App.Util.isFunction(params) ? params() : params;                
                requestData = App.Util.extend(parameter, paramsData);
            } else
            {
                requestData = parameter;
            }         
            if (_this.commStat) {              
                _this.commStat = false;
                $.ajax({
                    type: 'Post',
                    url: url,
                    dataType: 'json',
                    async: true,
                    data: parameter,
                    traditional: true,
                    error: function () { },
                    beforeSend: function () {
                        //commStat = true;
                    },
                    success: function (ret) {
                     
                        if (!ret.data) {
                            var data = $.map(ret.Data, function (item, i) {
                                return item[keyWordName?keyWordName:"keyWord"];
                            });
                            process(data);
                        }
                    },
                    complete: function () {
                        _this.commStat = true;
                    }
                });
            }
        },
        items: 10,
        menu: '<ul class="typeahead dropdown-menu"></ul>',
        item: '<li><a href="#"></a></li>',
        minLength: 1,
    };
    this.selector = selector;
}

App.Bootstrap.Typeahead.prototype = {
    init: function () {
        this.selector.typeahead(this.options);
    }
}
//App.Bootstrap.DatetimePicker = function (selector,options,fn) {
//    this.selector = selector;
//    this.options = options;
//    this.fn = fn;
//}

//App.Bootstrap.DatetimePicker.prototype = {
//    init: function () {
//        this.selector.datetimepicker(this.options).on("chageDate", this.fn);
//    }
//}



App.Drag = function (id) {
    var _this = this;
    this.divX = 0;
    this.divY = 0;
    this.oDiv = document.getElementById(id);
    this.oDiv.onmousedown = function (ev) {
        _this.fnMouseDown(ev);
    }
}


App.Drag.prototype = {
    fnMouseDown: function (ev) {
        var _this = this;
        var oEvent = ev || event;
        this.divX = oEvent.clientX - this.oDiv.offsetLeft;
        this.divY = oEvent.clientY - this.oDiv.offsetTop;
        document.onmousemove = function (ev) {
            _this.fnMouseMove(ev);
            return false;
        };
        document.onmouseup = function () {
            _this.fnMouseUp();
        }
    },
    fnMouseUp: function () {
        document.onmousemove = null;
        document.onmousedown = null;
    },
    fnMouseMove: function (ev) {
        var oEvent = ev || event;
        this.oDiv.style.left = oEvent.clientX - this.divX + 'px';
        this.oDiv.style.top = oEvent.clientY - this.divY + 'px';
        
    }
}



App.LimitDrag = function (id) {
    App.Drag.call(this, id);
}

for (var i in App.Drag.prototype) {
    App.LimitDrag.prototype[i] = App.Drag.prototype[i];
}


App.LimitDrag.prototype.fnMouseMove = function (ev) {
    var oEvent = ev || event;
    var left = oEvent.clientX - this.divX;
    var top = oEvent.clientY - this.divY;
    if (left < 0) {
        left=0;
    } else if (left > document.documentElement.clientWidth - this.oDiv.offsetWidth) {
        left = document.documentElement.clientWidth - this.oDiv.offsetWidth;
    }
    if (top < 0) {
        top = 0;
    } else if (top > document.documentElement.clientHeight - this.oDiv.offsetHeight) {
        top = document.documentElement.clientHeight - this.oDiv.offsetHeight;
    }
    this.oDiv.style.left = left + 'px';
    this.oDiv.style.top = top + 'px';
}
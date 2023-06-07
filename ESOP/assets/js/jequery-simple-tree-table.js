! function(n) {
    var i = {};

    function o(e) {
        if (i[e]) return i[e].exports;
        var t = i[e] = {
            i: e,
            l: !1,
            exports: {}
        };
        return n[e].call(t.exports, t, t.exports, o), t.l = !0, t.exports
    }
    o.m = n, o.c = i, o.d = function(e, t, n) {
        o.o(e, t) || Object.defineProperty(e, t, {
            enumerable: !0,
            get: n
        })
    }, o.r = function(e) {
        "undefined" != typeof Symbol && Symbol.toStringTag && Object.defineProperty(e, Symbol.toStringTag, {
            value: "Module"
        }), Object.defineProperty(e, "__esModule", {
            value: !0
        })
    }, o.t = function(t, e) {
        if (1 & e && (t = o(t)), 8 & e) return t;
        if (4 & e && "object" == typeof t && t && t.__esModule) return t;
        var n = Object.create(null);
        if (o.r(n), Object.defineProperty(n, "default", {
                enumerable: !0,
                value: t
            }), 2 & e && "string" != typeof t)
            for (var i in t) o.d(n, i, function(e) {
                return t[e]
            }.bind(null, i));
        return n
    }, o.n = function(e) {
        var t = e && e.__esModule ? function() {
            return e.default
        } : function() {
            return e
        };
        return o.d(t, "a", t), t
    }, o.o = function(e, t) {
        return Object.prototype.hasOwnProperty.call(e, t)
    }, o.p = "", o(o.s = 1)
}([function(e, t, n) {}, function(e, t, n) {
    "use strict";
    n.r(t);
    n(0);

    function o(e, t) {
        for (var n = 0; n < t.length; n++) {
            var i = t[n];
            i.enumerable = i.enumerable || !1, i.configurable = !0, "value" in i && (i.writable = !0), Object.defineProperty(e, i.key, i)
        }
    }
    var s = "simple-tree-table",
        a = {
            expander: null,
            collapser: null,
            collapsed: !1,
            margin: 0,
            onOpen: null,
            onClose: null,
            storeState: !1,
            storeKey: s,
            storeType: "session"
        },
        r = function() {
            function n(e) {
                var t = 1 < arguments.length && void 0 !== arguments[1] ? arguments[1] : {};
                ! function(e, t) {
                    if (!(e instanceof t)) throw new TypeError("Cannot call a class as a function")
                }(this, n), this.options = Object.assign({}, a, t), this.$tree = $(e), this.$expander = $(this.options.expander), this.$collapser = $(this.options.collapser), this.init()
            }
            var e, t, i;
            return e = n, t = [{
                key: "init",
                value: function() {
                    this.$tree.addClass(s), this.buildIcons(), this.bind(), this.options.collapsed && this.collapse(), this.loadState()
                }
            }, {
                key: "buildIcons",
                value: function() {
                    var r = this;
                    this.nodes().each(function(e, t) {
                        var n = $(t);
                        if (0 === n.find(".tree-icon").length) {
                            n.data("node-id");
                            var i = r.depth(n, 0),
                                o = r.options.margin * (i - 1),
                                s = 0 !== r.findChildren(n).length,
                                a = $('<span class="tree-icon" />').css("margin-left", "".concat(o, "px"));
                            s && a.addClass("tree-opened"), n.children(":first").prepend(a)
                        }
                    })
                }
            }, {
                key: "bind",
                value: function() {
                    var i = this;
                    this.$expander.on("click.".concat(s), function(e) {
                        i.expand()
                    }), this.$collapser.on("click.".concat(s), function(e) {
                        i.collapse()
                    }), this.$tree.on("click.".concat(s), "tr .tree-icon", function(e) {
                        var t = $(e.currentTarget),
                            n = t.closest("tr");
                        t.hasClass("tree-opened") ? i.close(n) : i.open(n)
                    })
                }
            }, {
                key: "unbind",
                value: function() {
                    this.$expander.off(".".concat(s)), this.$collapser.off(".".concat(s)), this.$tree.off(".".concat(s))
                }
            }, {
                key: "expand",
                value: function() {
                    var n = this;
                    this.nodes().each(function(e, t) {
                        n.show($(t))
                    }), this.saveState()
                }
            }, {
                key: "collapse",
                value: function() {
                    var n = this;
                    this.nodes().each(function(e, t) {
                        n.hide($(t))
                    }), this.saveState()
                }
            }, {
                key: "nodes",
                value: function() {
                    return this.$tree.find("tr[data-node-id]")
                }
            }, {
                key: "depth",
                value: function(e, t) {
                    t += 1;
                    var n = e.data("node-pid"),
                        i = this.findByID(n);
                    return n && i ? this.depth(i, t) : t
                }
            }, {
                key: "open",
                value: function(e) {
                    this.show(e), this.saveState(), this.options.onOpen && this.options.onOpen(e)
                }
            }, {
                key: "show",
                value: function(e) {
                    var t = e.find(".tree-icon");
                    t.hasClass("tree-closed") && (t.removeClass("tree-closed").addClass("tree-opened"), this.showDescs(e))
                }
            }, {
                key: "showDescs",
                value: function(e) {
                    var o = this;
                    this.findChildren(e).each(function(e, t) {
                        var n = $(t),
                            i = n.find(".tree-icon");
                        n.show(), i.hasClass("tree-opened") && o.showDescs(n)
                    })
                }
            }, {
                key: "close",
                value: function(e) {
                    this.hide(e), this.saveState(), this.options.onClose && this.options.onClose(e)
                }
            }, {
                key: "hide",
                value: function(e) {
                    var t = e.find(".tree-icon");
                    t.hasClass("tree-opened") && (t.removeClass("tree-opened").addClass("tree-closed"), this.hideDescs(e))
                }
            }, {
                key: "hideDescs",
                value: function(e) {
                    var i = this;
                    this.findChildren(e).each(function(e, t) {
                        var n = $(t);
                        n.hide(), i.hideDescs(n)
                    })
                }
            }, {
                key: "findChildren",
                value: function(e) {
                    var t = e.data("node-id");
                    return this.$tree.find('tr[data-node-pid="'.concat(t, '"]'))
                }
            }, {
                key: "findDescendants",
                value: function(n) {
                    function e(e, t) {
                        return n.apply(this, arguments)
                    }
                    return e.toString = function() {
                        return n.toString()
                    }, e
                }(function(e, t) {
                    var n = findChildren(e);
                    return t.push(n), n.each(function(e, t) {
                        findDescendants($(t), descs)
                    }), t
                })
            }, {
                key: "findByID",
                value: function(e) {
                    return this.$tree.find('tr[data-node-id="'.concat(e, '"]'))
                }
            }, {
                key: "findChildrenByID",
                value: function(e) {
                    var t = this.findByID(e);
                    return this.findChildren(t)
                }
            }, {
                key: "openByID",
                value: function(e) {
                    var t = this.findByID(e);
                    this.open(t)
                }
            }, {
                key: "closeByID",
                value: function(e) {
                    var t = this.findByID(e);
                    this.close(t)
                }
            }, {
                key: "saveState",
                value: function() {
                    if (this.options.storeState) {
                        var e = this.nodes().filter(function(e, t) {
                            return 0 != $(t).find(".tree-closed").length
                        }).map(function(e, t) {
                            return $(t).data("node-id")
                        }).get();
                        n.saveData(this.storage(), this.options.storeKey, e)
                    }
                }
            }, {
                key: "loadState",
                value: function() {
                    var t = this;
                    if (this.options.storeState) {
                        var e = n.loadData(this.storage(), this.options.storeKey);
                        e && (this.expand(), e.forEach(function(e) {
                            t.closeByID(e)
                        }))
                    }
                }
            }, {
                key: "storage",
                value: function() {
                    return "local" === this.options.storeType ? window.localStorage : window.sessionStorage
                }
            }], i = [{
                key: "saveData",
                value: function(e, t, n) {
                    var i = JSON.stringify(n);
                    e.setItem(t, i)
                }
            }, {
                key: "loadData",
                value: function(e, t) {
                    var n = e.getItem(t);
                    return n ? JSON.parse(n) : null
                }
            }, {
                key: "getDefaults",
                value: function() {
                    return a
                }
            }, {
                key: "setDefaults",
                value: function(e) {
                    Object.assign(a, e)
                }
            }], t && o(e.prototype, t), i && o(e, i), n
        }();
    $.fn.simpleTreeTable = function(o) {
        return this.each(function(e, t) {
            var n = $(t),
                i = new r(n, o);
            n.data("simple-tree-table", i)
        })
    }, $.simpleTreeTable = {
        getDefaults: r.getDefaults,
        setDefaults: r.setDefaults
    }
}]);
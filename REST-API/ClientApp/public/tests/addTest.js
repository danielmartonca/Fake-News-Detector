QUnit.test("Basic Test", function (assert) {
    var result = add(1, 2);
    assert.equal(result, 3);
});

QUnit.test("Web Test", function (assert) {
    var result = isValidHttpUrl("https://www.google.com/");
    assert.equal(result, true);
});

QUnit.test("Web Test2", function (assert) {
    var result = isValidHttpUrl("httpd://www.mmediu.ro/");
    assert.equal(result, false);
});

QUnit.test("Web Test3", function (assert) {
    var result = getCookie("userLogged");
    assert.equal(result, null);
});
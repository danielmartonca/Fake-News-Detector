QUnit.test("Basic Test", function (assert) => {
    var result = add(1, 2);
    assert.equal(result, 3);
});

QUnit.test("Web Test", function (assert) => {
    var result = isValidHttpUrl("https://www.google.com/");
    assert.equal(result, "https");
});

QUnit.test("Web Test2", function (assert) => {
    var result = isValidHttpUrl("http://www.mmediu.ro/");
        assert.equal(result, "http");
});

QUnit.test("Web Test3", function (assert) => {
    var result = getCookie("testtest");
        assert.equal(result, "null");
});
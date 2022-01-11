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

QUnit.test("Web Test4", function (assert) {
    var result = isInputValid("Test", null, "Test3", "Test4");
    assert.equal(result, false);
});

QUnit.test("Web Test5", function (assert) {
    var result = isInputValid("Test", "Test2", "Test3", "Test4");
    assert.equal(result, true);
});

QUnit.test("Web Test6", function (assert) {
    var result = checkIfUserIsLogged(null);
    assert.equal(result, false);
});

QUnit.test("Web Test7", function (assert) {
    var result = checkIfUserIsLogged("false");
    assert.equal(result, false);
});

QUnit.test("Web Test8", function (assert) {
    var result = checkIfUserIsLogged("true");
    assert.equal(result, true);
});
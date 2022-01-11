QUnit.test("Basic Test", function (assert) {
    var result = add(1, 2);
    assert.equal(result, 3);
});

QUnit.test("GivenHttpUrlWhenValidObtainTrue", function (assert) {
    var result = isValidHttpUrl("https://www.google.com/");
    assert.equal(result, true);
});

QUnit.test("GivenHttpUrlWhenInvalidThenObtainFalse", function (assert) {
    var result = isValidHttpUrl("httpd://www.mmediu.ro/");
    assert.equal(result, false);
});

QUnit.test("GivenCookieWhenLoggedThenObtainNull", function (assert) {
    var result = getCookie("userLogged");
    assert.equal(result, null);
});

QUnit.test("GivenNewsDataWhenIsInvalidThenObtainFalse", function (assert) {
    var result = isInputValid("Test", null, "Test3", "Test4");
    assert.equal(result, false);
});

QUnit.test("GivenNewsDataWhenIsValidThenObtainTrue", function (assert) {
    var result = isInputValid("Test", "Test2", "Test3", "Test4");
    assert.equal(result, true);
});

QUnit.test("GivenUserCookieWhenIsNullThenObtainFalse", function (assert) {
    var result = checkIfUserIsLogged(null);
    assert.equal(result, false);
});

QUnit.test("GivenUserCookieWhenIsFalseThenObtainFalse", function (assert) {
    var result = checkIfUserIsLogged("false");
    assert.equal(result, false);
});

QUnit.test("GivenUserCookieWhenIsTrueThenObtainTrue", function (assert) {
    var result = checkIfUserIsLogged("true");
    assert.equal(result, true);
});
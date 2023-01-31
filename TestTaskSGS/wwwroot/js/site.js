
function input1_changed(exchangeRate) {
    var value = document.getElementById("input1").value;

    document.getElementById("input2").value = (value * exchangeRate).toFixed(2);

}

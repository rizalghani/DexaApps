var flag = 0;
$("#btn-add").on("click", function () {
    var _customerid = $('input[name="CustomerID"]').val();
    var _customername = $('input[name="CustomerName"]').val();
    var _address = $('input[name="Address"]').val();
    var _code = $('input[name="Code"]').val();
    var _startdate = $('input[name="StartDate"]').val();
    var _endate = $('input[name="EndDate"]').val();
    var _outletid = $('#select_type').val();

    var _input_customid = '<input type="text" name="item[' + flag + '].CustomerID" class="form-control border-0 py-0" value="' + _customerid + '" readonly />';
    var _input_customername = '<input type="text" name="item[' + flag + '].CustomerName" class="form-control border-0 py-0" value="' + _customername + '" readonly />';
    var _input_address = '<input type="text" name="item[' + flag + '].Address" class="form-control border-0 py-0" value="' + _address + '" readonly />';
    var _input_code = '<input type="text" name="item[' + flag + '].Code" class="form-control border-0 py-0" value="' + _code + '" readonly />';
    var _input_startdate = '<input type="text" name="item[' + flag + '].StartDate" class="form-control border-0 py-0" value="' + _startdate + '" readonly />';
    var _input_enddate = '<input type="text" name="item[' + flag + '].EndDate" class="form-control border-0 py-0" value="' + _endate + '" readonly />';
    var _input_outletid = '<input type="text" name="item[' + flag + '].OutletID" class="form-control border-0 py-0" value="' + _outletid + '" readonly />';

    var _tr = '<tr class="text-center" id=' + flag + '><td>' + _input_customid + '</td>' +
        '</td><td>' + _input_customername + '</input>' +
        '</td><td>' + _input_address + '</input>' +
        '</td><td>' + _input_code + '</input>' +
        '</td><td>' + _input_startdate + '</input>' +
        '</td><td>' + _input_enddate + '</input>' +
        '</td><td>' + _input_outletid + '</input>' +
        '</td></tr>'

    if (_customerid != "" && _customername != "" && _outletid != "") {
        $("#tbody-create").append(_tr);
        $("#btn-save").removeClass("d-none");
        reset();
        flag++;
    }
});

$('.onlynumber').keyup(function (e) {
    if (/\D/g.test(this.value)) {
        this.value = this.value.replace(/\D/g, '');
    }
});

function reset() {
    $('input[name="CustomerID"]').val('');
    $('input[name="CustomerName"]').val('');
    $('input[name="Address"]').val('');
    $('input[name="Code"]').val('');
    $('input[name="StartDate"]').val('');
    $('input[name="EndDate"]').val('');
    $("#select_type").trigger("change");
}


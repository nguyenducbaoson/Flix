function quocgia() {
    $('#Display').empty();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/CountryApi',
        dataType: 'json',
        success: function (data) {
            var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Danh sách quốc gia</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick ="formthemquocgia()">Thêm</button></div></div></div><br />'
            str += '<div class="card shadow mb-4"><div class="card-header py-3"><h6 class="m-0 font-weight-bold text-primary">Danh sách</h6></div><div class="card-body"><div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><label>Tìm kiếm:<input type="search" class="form-control form-control-sm" placeholder="" aria-controls="dataTable"></label><thead><tr><th>Mã QG</th><th>Tên quốc gia</th><th style="text-align: center">Chức năng</th> </tr></thead><tbody>';
            $.each(data, function (key, val) {
                str += '<tr><td>' + val.CountryID + '</td><td>' + val.Name + '</td><td style="width: 14%; text-align: center"><a type="submit" onclick="formsuaquocgia(\'' + val.CountryID + '\')" class="btn btn-primary btn-icon-split"><span class="icon text-white-50"><i class="fas fa-edit"></i></span></a><a type="submit" onclick="xoaquocgia(\'' + val.CountryID + '\')" class="btn btn-danger btn-icon-split"><span class="icon text-white-50"><i class="fas fa-trash"></i></span></a></td></tr>  ';
            });
            str += '</tbody></table></div></div></div>';
            $('#Display').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}
function formsuaquocgia(id) {
    $('#Display').empty();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/CountryApi/' + id,
        dataType: 'json',
        success: function (data) {
            var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Sửa quốc gia</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick ="quocgia()">Trở Lại</button></div></div></div><br /><div class="card shadow mb-4"><div class="card-body"><div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><tbody>';
            str += '<tr><td>Mã Quốc Gia</td><td><label>' + data.CountryID + '</label></td></tr><tr><td>Tên Quốc Gia</td><td><input id="ten" type="text" value="' + data.Name + '"></td></tr><tr><td><button type="submit" class="btn btn-success" id="but">Cập Nhật</button></td><td></td></tr>';
            str += '</tbody></table></div></div></div>';
            $('#Display').html(str);
            $('#but').click(function () {
                $.ajax({
                    type: 'PUT',
                    url: 'https://localhost:44301/api/CountryApi/update?id=' + data.CountryID + '&name=' + $('#ten').val().toString(),
                    dataType: 'json',
                    success: function (data) {
                        if (data == false)
                            alert("Sửa Không Thành Công");
                        else {
                            alert("Sửa Thành Công");
                            $('#Display').ready(function () {
                                quocgia();
                            });
                        }
                    },
                    error: function (xhr) {
                        alert(xhr.responseText);
                    }
                });
            });
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}
function formthemquocgia() {
    $('#Display').empty();
    var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Thêm quốc gia</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick ="quocgia()">Trở Lại</button></div></div></div><br /><div class="card shadow mb-4"><div class="card-body"><div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><tbody>';
    str += '<tr><td>Mã Quốc Gia</td><td><input id="Ma" type="text"></td></tr><tr><td>Tên Quốc Gia</td><td><input id="ten" type="text"></td></tr><tr><td><button type="submit" class="btn btn-success" id="but">Thêm</button></td><td></td></tr>';
    str += '</tbody></table></div></div></div>';
    $('#Display').html(str);
    $('#but').click(function () {
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44301/api/CountryApi/insert?id=',
            data: {
                id: $('#Ma').val(),
                name: $('#ten').val().toString(),
            },
            dataType: 'json',
            success: function (data) {
                if (data == false)
                    alert("Thêm Không Thành Công");
                else {
                    alert("Thêm Thành Công");
                    $('#Display').ready(function () {
                        quocgia();
                    });
                }
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    });



}
function xoaquocgia(id) {
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44301/api/CountryApi/delete?id=' + id,
        dataType: 'json',
        success: function (data) {
            if (data == false)
                alert("Xóa Không Thành Công");
            else {
                alert("Xóa Thành Công");
                $('#Display').ready(function () {
                    quocgia();
                });
            }
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}